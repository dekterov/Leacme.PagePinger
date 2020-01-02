// Copyright (c) 2017 Leacme (http://leac.me). View LICENSE.md for more information.
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Leacme.Lib.PagePinger {
	public class Library {

		/// <summary>
		/// Queries a website for a response.
		/// /// </summary>
		/// <param name="uri">Site address.</param>
		/// <returns>Website response.</returns>
		public async Task<string> GetPageAsync(Uri uri) {
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream)) {
				return await reader.ReadToEndAsync();
			}
		}

		/// <summary>
		/// Uses HtmlAgilityPack to parse the raw website response into a structured text document.
		/// /// </summary>
		/// <param name="rawHttpWebResponse">The raw response received after sending a website request.</param>
		/// <returns>Human-readable text contents of the website's response.</returns>
		public string GetParsedPageContent(string rawHttpWebResponse) {
			HtmlDocument parsed = new HtmlDocument();
			parsed.LoadHtml(rawHttpWebResponse);
			var sb = new StringBuilder();
			foreach (var textNode in parsed.DocumentNode.Descendants().Where(_ => _.NodeType == HtmlNodeType.Text && _.ParentNode.Name != "script" && _.ParentNode.Name != "style")) {
				sb.AppendLine(textNode.InnerText.Trim());
			}
			return Regex.Replace(sb.ToString(), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
		}

		/// <summary>
		/// Extracts the differences between the original and the new text.
		/// /// </summary>
		/// <param name="originalText"></param>
		/// <param name="newText"></param>
		/// <returns>A pair containing the old and new different texts.</returns>
		public Tuple<string, string> GetTextDifferences(string originalText, string newText) {
			string oText = String.Join(" ", originalText.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Except(newText.Split(new[] { Environment.NewLine }, StringSplitOptions.None)));
			string nText = String.Join(" ", newText.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Except(originalText.Split(new[] { Environment.NewLine }, StringSplitOptions.None)));
			return new Tuple<string, string>(oText, nText);
		}
	}
}