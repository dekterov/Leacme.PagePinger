// Copyright (c) 2017 Leacme (http://leac.me). View LICENSE.md for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Media;


namespace Leacme.App.PagePinger {

	public class AppUI {

		private Window optionsWindow;
		private StackPanel rootPan = (StackPanel)Application.Current.MainWindow.Content;
		private DataGrid sitesGrid;

		public bool IsShowNotificationEnabled { get; set; } = false;
		public int RefreshMinutes { get; set; } = 60;

		public AppUI() {
			optionsWindow = InitOptionsWindow();
			var instrBlock = App.TextBlock;
			instrBlock.Text = "Add a new website to begin monitoring for changes. Right-click existing site to remove.";
			instrBlock.TextAlignment = TextAlignment.Center;
			instrBlock.Margin = new Thickness(0, 20, 0, 0);

			var addSiteField = App.HorizontalFieldWithButton;
			addSiteField.holder.HorizontalAlignment = HorizontalAlignment.Center;
			addSiteField.holder.Children.OfType<TextBlock>().First().Text = "Site URL:";
			var urlField = addSiteField.holder.Children.OfType<TextBox>().First();
			urlField.Width = 600;
			urlField.Watermark = "http://www.example.com/home.htm";

			addSiteField.holder.Children.OfType<Button>().First().Content = "Add Site";
			addSiteField.holder.Children.OfType<Button>().First().Click += (z, zz) => {
				if (!string.IsNullOrWhiteSpace(urlField.Text)) {
					try {
						var newSiteEntry = new GridSite(sitesGrid, urlField.Text);
						sitesGrid.Items = Enumerable.Prepend(sitesGrid.Items.Cast<GridSite>(), newSiteEntry);
						urlField.Text = string.Empty;
					} catch (InvalidUrlException e) {
						var wrongUrlWin = App.NotificationWindow;
						wrongUrlWin.Title = "Error";
						((StackPanel)wrongUrlWin.Content).Children.OfType<TextBlock>().First().Text = e.Message;
						wrongUrlWin.ShowDialog<Window>(Application.Current.MainWindow);
					}
				}
			};

			addSiteField.holder.Margin = new Thickness(0, 20);
			rootPan.Children.AddRange(new List<Control> { instrBlock, addSiteField.holder });

			sitesGrid = App.DataGrid;
			sitesGrid.Items = new List<GridSite>();
			rootPan.Children.Add(sitesGrid);

			sitesGrid.CellPointerPressed += (z, zz) => {
				if (zz.PointerPressedEventArgs.MouseButton.Equals(MouseButton.Right)) {
					ContextMenu oneM = new ContextMenu();
					MenuItem RemEntryMenuItem = new MenuItem() { Header = "Remove" };
					RemEntryMenuItem.Click += (zzz, zzzz) => {
						var entryToRemove = sitesGrid.Items.Cast<GridSite>().ToList().ElementAt(zz.Row.GetIndex());
						sitesGrid.Items = sitesGrid.Items.Cast<GridSite>().ToList().Except(new List<GridSite>() { entryToRemove });
						entryToRemove.Dispose();
					};
					((AvaloniaList<object>)oneM.Items).Add(RemEntryMenuItem);
					oneM.Open((DataGrid)z);
				}
			};

			var optMenuItem = new MenuItem() { Header = "Options..." };
			optMenuItem.Click += async (x, y) => {
				if (!Application.Current.Windows.Contains(optionsWindow)) {
					optionsWindow = InitOptionsWindow();
					await optionsWindow.ShowDialog<Window>(Application.Current.MainWindow);
				}
			};
			((AvaloniaList<object>)((MenuItem)((AvaloniaList<object>)((Menu)
			rootPan.Children.First()).Items).First()).Items).Insert(0, optMenuItem);
		}

		private Window InitOptionsWindow() {
			var optWin = App.NotificationWindow;
			optWin.Title = "Options";
			optWin.Width = 450;
			optWin.Height = 150;
			var contPanel = new StackPanel();
			optWin.Content = contPanel;
			var notifSettings = App.TextBlock;
			notifSettings.Text = "Notification settings";
			contPanel.Children.Add(notifSettings);

			var notifSp = App.HorizontalCheckBoxEntry;
			var notifCb = notifSp.holder.Children.OfType<CheckBox>().First();
			notifCb.IsChecked = IsShowNotificationEnabled;
			notifCb.PropertyChanged += (x, y) => {
				if (y.Property.Equals(CheckBox.IsCheckedProperty)) {
					IsShowNotificationEnabled = (bool)y.NewValue;
				}
			};

			notifSp.holder.Children.OfType<TextBlock>().First().Text = "Show popup window on website change";
			contPanel.Children.Add(notifSp.holder);

			var refrTimeSettings = App.TextBlock;
			refrTimeSettings.Text = "Page refresh settings";
			contPanel.Children.Add(refrTimeSettings);

			var reftSecSlide = App.HorizontalSliderWithValue;
			var reftSlider = reftSecSlide.holder.Children.OfType<Slider>().First();
			reftSlider.Minimum = 1;
			reftSlider.Maximum = 360;
			reftSlider.Value = RefreshMinutes;
			reftSecSlide.holder.Children.OfType<TextBlock>().First().PropertyChanged += (x, y) => {
				if (y.Property.Equals(TextBlock.TextProperty)) {
					RefreshMinutes = (int)double.Parse((string)y.NewValue);
				}
			};
			var refreshMinBlurb = App.TextBlock;
			refreshMinBlurb.Text = "minutes - refresh interval for new entries";
			reftSecSlide.holder.Children.Add(refreshMinBlurb);

			contPanel.Children.Add(reftSecSlide.holder);

			var confBt = App.Button;
			confBt.Content = "OK";
			confBt.Margin = new Thickness(10);
			confBt.Click += (x, y) => { optWin.Close(); };
			contPanel.Children.Add(confBt);

			return optWin;
		}
	}
}