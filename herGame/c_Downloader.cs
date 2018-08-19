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

		public List<c_Artist> getArtists()
		{
			List<c_Artist> ret = new List<c_Artist>();
			string ua = c_Functions.getUserAgent();

			string res = "";
			int i = 1;
			while(!res.Contains(@"<success type=""boolean"">false</success>") && res != @"<artists type=""array""/>")
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
					} catch(Exception ex) { Console.WriteLine(ex.ToString()); }
				}

				HttpWebRequest wr = WebRequest.CreateHttp("https://e621.net/artist/index.xml?limit=100&page=" + i);
				wr.UserAgent = ua;
				//wr.Headers.Add(HttpRequestHeader.UserAgent, ua);
				wr.Method = "GET"; 
				WebResponse wres = wr.GetResponse();
				using(var r = new StreamReader(wres.GetResponseStream()))
				{
					res = r.ReadToEnd();
				}
				
				i++;

				if(i == 4) { res = @"<artists type=""array""/>"; }

				sw.Stop();
				if (sw.Elapsed.TotalSeconds < 1) { Thread.Sleep(1000); }
			}
			
			return ret;
		}

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
