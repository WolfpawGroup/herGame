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

		public static c_SqlFunctions initializeSQL(c_SqlFunctions csqlf)
		{
			csqlf.createDbFile();
			csqlf.sqlc = csqlf.connectToDB();

			foreach (KeyValuePair<string, List<SQLiteColumn>> kvp in getListOfTables())
			{
				csqlf.createTable(kvp.Key, kvp.Value);
			}

			

			return csqlf;
		}

		public static Dictionary<string, List<SQLiteColumn>> getListOfTables()
		{
			Dictionary<string, List<SQLiteColumn>> tables = new Dictionary<string, List<SQLiteColumn>>();

			//TODO: Changed for testing!

			tables.Add("artists", new List<SQLiteColumn>() {
				new SQLiteColumn() { tableComment = "This is a test comment." },
				new SQLiteColumn() { columnName = "id", dataType =  SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true },	//ID = int
				new SQLiteColumn() { columnName = "name", dataType = SQLiteDataType.TEXT,columnComment = "Comment on column!" },		//Name = string
				new SQLiteColumn() { columnName = "has_other_names", dataType = SQLiteDataType.INTEGER },								//HasOtherNames = bool 1=true
				new SQLiteColumn() { columnName = "other_names", dataType = SQLiteDataType.TEXT },										//OtherNames = string[] as XML
				new SQLiteColumn() { columnName = "has_urls", dataType = SQLiteDataType.INTEGER },										//HasURLs = bool 1=true
				new SQLiteColumn() { columnName = "urls", dataType = SQLiteDataType.TEXT },                                             //URLs = string[] as XML
				new SQLiteColumn() { columnName = "added", dataType = SQLiteDataType.TEXT }                                             //DateAdded = string eg:2018.05.11
			});

			tables.Add("images", new List<SQLiteColumn>()
			{
				//TODO: Add data to images
				//Don't forget to add already downloaded and already sent
			});



			return tables;
		}
	}
}
