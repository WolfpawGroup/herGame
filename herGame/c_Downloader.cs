using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace herGame
{
	class c_Downloader
	{
		List<string> currentlyDownloading = new List<string>();
		List<string> alreadyDownloaded = new List<string>();
		Stopwatch sw = new Stopwatch();

		public List<c_Artist> getArtists(out long seconds)
		{
			List<c_Artist> ret = new List<c_Artist>();
			long time = 0;

			string res = "";
			int i = 1;
			while(!res.Contains(@"<success type=""boolean"">false</success>") && !res.Contains(@"<artists type=""array""/>"))
			{
				sw.Start();
				if (res != "")
				{
					try
					{
						var doc = c_Functions.parseXML(res);
						if (doc.GetElementsByTagName("artist").Count > 0)
						{
							foreach (XmlElement x in doc.GetElementsByTagName("artist"))
							{
								ret.Add(new c_Artist()
								{
									id = Convert.ToInt32(x.GetElementsByTagName("id")[0].InnerText),
									name = x.GetElementsByTagName("name")[0].InnerText,
									hasUrls = x.GetElementsByTagName("urls")[0].InnerText != "",
									urls = x.GetElementsByTagName("urls")[0].InnerText.Split(' '),
									hasOtherNames = x.GetElementsByTagName("other_names")[0].InnerText != "",
									other_names = x.GetElementsByTagName("other_names")[0].InnerText.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries),
									posts = 0,
									updated = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()
								});
							}
						}
					}
					catch (Exception ex) { Console.WriteLine(ex.ToString()); }
				}

				string url = "https://e621.net/artist/index.xml?limit=100&page=" + i;
				res = GetPageData(url);

				i++;

				//if(i == 14) { res = @"<artists type=""array""/>"; }

				sw.Stop();
				time += (int)sw.Elapsed.TotalMilliseconds;
				if (sw.Elapsed.TotalSeconds < 1) { Thread.Sleep(1000); }
				sw.Reset();
			}
			seconds = time;
			return ret;
		}

		private static string GetPageData(string url)
		{
			try
			{
				string ua = c_Functions.getUserAgent();
				string res;
				HttpWebRequest wr = WebRequest.CreateHttp(url);
				wr.UserAgent = ua;
				wr.Method = "GET";
				WebResponse wres = wr.GetResponse();
				using (var r = new StreamReader(wres.GetResponseStream()))
				{
					res = r.ReadToEnd();
				}

				return res;
			}
			catch
			{
				return "";
			}
		}

		public static int getArtistPosts(c_SqlFunctions cs, string name)
		{
			int ret = -1;

			ret = getTag(cs, name);
			
			return ret;
		}

		public static int getTag(c_SqlFunctions cs, string name)
		{
			string url = "https://e621.net/tag/show.xml?name=" + name;
			var d = c_Functions.parseXML(GetPageData(url));

			if(d != null)
			{
				if (d.GetElementsByTagName("success").Count == 0)
				{
					cs.insertInto("tags", new string[][] {
						new string[]{ "id",                 "false",    d.GetElementsByTagName("id")[0].InnerText       },
						new string[]{ "name",               "true",     d.GetElementsByTagName("name")[0].InnerText     },
						new string[]{ "count",              "false",    d.GetElementsByTagName("count")[0].InnerText    },
						new string[]{ "type",               "false",    d.GetElementsByTagName("type")[0].InnerText     },
						new string[]{ "updated",            "true", DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() }
					});
				}

				Thread t = new Thread(() => getTagData(cs, name));
				t.Start();

				//getTagData(cs, name);

				int i = -1;
				int.TryParse(d.GetElementsByTagName("count")[0].InnerText, out i);

				return i;
			}
			else
			{
				return -1;
			}
		}

		public static void getTagData(c_SqlFunctions cs, string name)
		{
			string url		= string.Format("https://e621.net/tag/related.xml?tags={0}&type=", name	) + "{0}";
			var d_General	= c_Functions.parseXML(GetPageData(string.Format(url, "general"		))		);
			Thread.Sleep(1000);
			var d_Artist	= c_Functions.parseXML(GetPageData(string.Format(url, "artist"		))		);
			Thread.Sleep(1000);
			var d_Copyright	= c_Functions.parseXML(GetPageData(string.Format(url, "copyright"	))		);
			Thread.Sleep(1000);
			var d_Character	= c_Functions.parseXML(GetPageData(string.Format(url, "character"	))		);
			Thread.Sleep(1000);
			var d_Species	= c_Functions.parseXML(GetPageData(string.Format(url, "species"		))		);

			Dictionary<SQLiteColumn, string> related = new Dictionary<SQLiteColumn, string>() {
				{ new SQLiteColumn() { columnName="related_General",    dataType = SQLiteDataType.TEXT }, string.Join(" ",	getArray(  d_General	))},
				{ new SQLiteColumn() { columnName="related_Artist",     dataType = SQLiteDataType.TEXT }, string.Join(" ",	getArray(  d_Artist		))},
				{ new SQLiteColumn() { columnName="related_Copyright",  dataType = SQLiteDataType.TEXT }, string.Join(" ",	getArray(  d_Copyright	))},
				{ new SQLiteColumn() { columnName="related_Character",  dataType = SQLiteDataType.TEXT }, string.Join(" ",	getArray(  d_Character	))},
				{ new SQLiteColumn() { columnName="related_Species",    dataType = SQLiteDataType.TEXT }, string.Join(" ",	getArray(  d_Species	))}
			};

			cs.update("tags", related, " name='" + name + "' ");
		}

		public static string[] getArray(XmlDocument doc)
		{
			List<string> str = new List<string>();
			foreach(XmlElement x in doc.GetElementsByTagName("tag"))
			{
				if (x.HasAttribute("count"))
				{
					str.Add(x.GetAttribute("name") + ":" + x.GetAttribute("count"));
				}
			}

			return str.ToArray();
		}

		/*
		new string[]{ "",     "false",    String.Join(" ", d_General.GetElementsByTagName("tag").OfType<XmlElement>().Select(x=>x.Value)) },
		new string[]{ "",  "false",    String.Join(" ", d_General.GetElementsByTagName("tag").OfType<XmlElement>().Select(x=>x.Value)) },
		new string[]{ "",  "false",    String.Join(" ", d_General.GetElementsByTagName("tag").OfType<XmlElement>().Select(x=>x.Value)) },
		new string[]{ "",    "false",    String.Join(" ", d_General.GetElementsByTagName("tag").OfType<XmlElement>().Select(x=>x.Value)) }
			
			 */

		public List<string> getList()
		{
			List<string> ret = new List<string>();

			string userAgent = c_Functions.getUserAgent();

			return ret;
		}

		public Bitmap getThumbnail()
		{
			return null;
		}

		public Bitmap getImage()
		{
			return null;
		}


	}
}
