using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace herGame
{
	public static class c_Functions
	{
		public static string getUserAgent()
		{
			string ret = "";

			ret = "WolfPawStudios-HerGame/v01/oid=" + randomNumber() + "/(by:WolfyD)";

			return ret;
		}

		public static int randomNumber()
		{
			int ret = 0;

			byte[] btmp = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(Environment.TickCount.ToString()));

			int i = 0;
			foreach(int b in btmp) { i += b; }

			ret = new Random(i).Next() * 100 + i;

			return ret;
		}

		public static XmlDocument parseXML(string xml)
		{
			XmlDocument xd = new XmlDocument();

			try
			{
				xd.LoadXml(xml);
			}
			catch (Exception ex)
			{
				xd = null;
				Console.WriteLine(ex.ToString());
			}

			return xd;
		}
	}
}
