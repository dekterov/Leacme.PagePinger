using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using Leacme.Lib.PagePinger;

namespace Leacme.App.PagePinger {

	public enum Status {
		Initializing, Unchanged, Changed, Unreachable
	}

	public class InvalidUrlException : Exception {
		public InvalidUrlException() : base("Invalid website address.") {
		}
	}

	public class GridSite : IDisposable {
		public Status Status { get; set; } = Status.Initializing;
		public DateTime Last { get; set; }
		public DateTime Next { get; set; }
		public string Site { get; set; }
		private IDisposable timerDisposable;
		private string currentContent;
		private string newContent;

		public GridSite(DataGrid owningGrid, string urlString) {
			Uri uriOut;
			if (!(Uri.TryCreate(urlString, UriKind.Absolute, out uriOut)
								&& (uriOut.Scheme == Uri.UriSchemeHttp || uriOut.Scheme == Uri.UriSchemeHttps))) {
				throw new InvalidUrlException();
			}
			Site = uriOut.ToString();

			Library lib = new Library();

			void ForceGridUpdate() {
				owningGrid.Items = owningGrid.Items.Cast<GridSite>().ToList();
			}

			async void UpdateTimedEntry() {
				Last = DateTime.Now;
				Next = DateTime.Now.AddMinutes(((App)Application.Current).AppUI.RefreshMinutes);
				bool siteReached = true;

				if (Status.Equals(Status.Initializing)) {
					try {
						currentContent = lib.GetParsedPageContent(await lib.GetPageAsync(uriOut));
					} catch {
						Status = Status.Unreachable;
						siteReached = false;
						ForceGridUpdate();
					}
					if (siteReached) {
						Status = Status.Unchanged;
						ForceGridUpdate();
					}
				} else {
					try {
						newContent = lib.GetParsedPageContent(await lib.GetPageAsync(uriOut));
					} catch {
						Status = Status.Unreachable;
						siteReached = false;
						ForceGridUpdate();
					}
					if (siteReached && currentContent.Equals(newContent)) {
						Status = Status.Unchanged;
						ForceGridUpdate();
					} else if (siteReached && !currentContent.Equals(newContent)) {
						Status = Status.Changed;
						var oldNewtextDiffs = lib.GetTextDifferences(currentContent, newContent);
						if (((App)Application.Current).AppUI.IsShowNotificationEnabled) {
							await InitDiffsWindow(oldNewtextDiffs).ShowDialog<Window>(Application.Current.MainWindow);
						}
						ForceGridUpdate();
					}
				}
			}
			UpdateTimedEntry();

			timerDisposable = DispatcherTimer.Run(() => {
				UpdateTimedEntry();
				return true;
			}, new TimeSpan(0, 0, ((App)Application.Current).AppUI.RefreshMinutes, 0, 0));

		}

		private Window InitDiffsWindow(Tuple<string, string> oldNewtextDiffs) {
			Window diffWin = App.NotificationWindow;
			diffWin.CanResize = true;
			diffWin.Height = 500;
			diffWin.Width = 800;
			diffWin.Title = "Content differences for: " + Site;
			((StackPanel)diffWin.Content).Children.RemoveAt(0);
			ScrollViewer currentTbSv = App.ScrollViewer;
			currentTbSv.Width = 700;
			ScrollViewer newTbSv = App.ScrollViewer;
			newTbSv.Width = 700;

			TextBlock currentTb = App.TextBlock;
			currentTb.Width = currentTbSv.Width - App.Margin.Top * 6;
			TextBlock newTb = App.TextBlock;
			newTb.Width = newTbSv.Width - App.Margin.Top * 6;
			currentTb.Text = oldNewtextDiffs.Item1;
			newTb.Text = oldNewtextDiffs.Item2;

			currentTbSv.Content = currentTb;
			newTbSv.Content = newTb;

			TextBlock oldContentBlurb = App.TextBlock;
			oldContentBlurb.Text = "Old Content:";
			TextBlock newContentBlurb = App.TextBlock;
			newContentBlurb.Text = "New Content:";

			((StackPanel)diffWin.Content).Children.Insert(0, oldContentBlurb);
			((StackPanel)diffWin.Content).Children.Insert(1, currentTbSv);
			((StackPanel)diffWin.Content).Children.Insert(2, newContentBlurb);
			((StackPanel)diffWin.Content).Children.Insert(3, newTbSv);
			return diffWin;
		}

		public void Dispose() {
			timerDisposable.Dispose();
		}
	}
}