using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace herGame
{
	public static class c_Functions
	{
		public static string getUserAgent()
		{
			string ret = "";
			ret = Environment.TickCount.ToString();
			ret = ret.Substring(ret.Length - 4);
			Random r = new Random();
			foreach (byte b in MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(ret + "_" + randomNumber())))
			{
				r.NextBytes(new byte[3]);
				ret += b.ToString("X" + r.Next(1, 5)).ToUpper();
			}
			ret = Convert.ToBase64String(Encoding.ASCII.GetBytes(ret));
			ret = "WolfPawStudios-HerGame/v01/oid=" + ret + "/(by:WolfyD)";

			return ret; 
		}

		public static int randomNumber()
		{
			int ret = 0;

			byte[] btmp = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(Environment.TickCount.ToString()));

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


		//==================================//
		//		Handling table creation		//
		//==================================//

		public static c_SqlFunctions initializeSQL(c_SqlFunctions csqlf)
		{
			csqlf.createDbFile();
			csqlf.createInternalConnection();

			foreach (KeyValuePair<string, List<SQLiteColumn>> kvp in getListOfTables())
			{
				csqlf.createTable(kvp.Key, kvp.Value);
			}
			
			return csqlf;
		}

		public static Dictionary<string, List<SQLiteColumn>> getListOfTables()
		{
			Dictionary<string, List<SQLiteColumn>> tables = new Dictionary<string, List<SQLiteColumn>>();
			
			Type ArtistType = typeof(c_Artist);
			tables.Add("artists", getColumnListFromMethod(ArtistType));

			Type ImageDetailType = typeof(c_ImageDetails);
			tables.Add("images", getColumnListFromMethod(ImageDetailType));

			Type TagType = typeof(c_Tags);
			tables.Add("tags", getColumnListFromMethod(TagType));

			Type HistoryType = typeof(c_History);
			tables.Add("history", getColumnListFromMethod(HistoryType));

			Type PlaymatesType = typeof(c_Playmates);
			tables.Add("playmates", getColumnListFromMethod(PlaymatesType));

			return tables;
		}

		/// <summary>
		/// Serialized methods using customAttributes
		/// Using methods to get table dll
		/// </summary>
		public static List<SQLiteColumn> getColumnListFromMethod(Type type)
		{
			List<SQLiteColumn> sqltmpcol = new List<SQLiteColumn>();
			foreach (PropertyInfo m in type.GetProperties())
			{
				foreach (var att in m.GetCustomAttributes(true))
				{
					fieldDefinitions fd = att as fieldDefinitions;
					if (fd != null && fd.partOfTable)
					{
						SQLiteColumn sqlCol = new SQLiteColumn()
						{
							columnName = fd.columnName,
							pimaryKey = fd.pimaryKey,
							autoIncrement = fd.autoIncrement,
							dataType = fd.dataType,
							columnComment = fd.columnComment,
							additionalData = fd.additionalData,
							hasDefaultIntValue = fd.hasDefaultIntValue,
							hasDefaultStringValue = fd.hasDefaultStringValue
						};
						if (sqlCol.hasDefaultIntValue) { sqlCol.defaultIntValue = fd.defaultIntValue; }
						if (sqlCol.hasDefaultStringValue) { sqlCol.defaultStringValue = fd.defaultStringValue; }

						sqltmpcol.Add(sqlCol);
					}
				}
			}

			return sqltmpcol;
		}

	}
}
