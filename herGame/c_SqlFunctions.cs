using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Data.SQLite;
using System.Windows.Forms;

namespace herGame
{
	public class c_SqlFunctions
	{
		/// <summary>SQLite Connection to be used with the functions</summary>
		public SQLiteConnection sqlc { get; set; }
		private List<int> connectedList = new List<int> { 1, 4, 8 };
		StringBuilder insertBuilderBuilder = new StringBuilder();

		#region Create DB File

		/// <summary>Creates the database file if it doesn't already exist</summary>
		/// <param name="dbname">Name/path of the file to be created</param>
		/// <returns>true if file was created</returns>
		public bool createDbFile(string dbname)
		{
			if(dbname == "") { dbname = "db.sqlite"; }

			if (File.Exists(dbname)) { return true; }

			try
			{
				File.Create(dbname).Close();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return false;
			}

			return true;
		}
		/// <summary>Creates the database file if it doesn't already exist with the default "db.sqlite" name</summary>
		/// <returns>true if file was created</returns>
		public bool createDbFile() { return createDbFile(""); }

		#endregion

		#region CONNECT TO DB

		public bool createInternalConnection(string dbname)
		{
			if (dbname == "") { dbname = "db.sqlite"; }

			try
			{
				sqlc = connectToDB(dbname);
				
				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool createInternalConnection()
		{
			return createInternalConnection("");
		}

		/// <summary>Creates and opens connection with DB file</summary>
		/// <param name="dbname">Name/path of the file to be connected to</param>
		/// <returns>SQLiteConnection if connected, Null if not</returns>
		public SQLiteConnection connectToDB(string dbname)
		{
			SQLiteConnection sql = null;
			if (dbname == "") { dbname = "db.sqlite"; }

			try
			{
				sql = new SQLiteConnection("Data Source=" + dbname + ";Version=3;");
				sql.Open();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			return sql;
		}

		/// <summary>Creates and opens connection with DB file with the default "db.sqlite" name</summary>
		/// <returns>SQLiteConnection if connected, Null if not</returns>
		public SQLiteConnection connectToDB() { return connectToDB(""); }
		
		/// <summary>Checks the current sqlc connection if it exists and is not closed, connecting or broken</summary>
		/// <returns>true if connection open, false if doesn't exist or not open</returns>
		public bool checkDbConnected()
		{
			return sqlc == null ? false : (connectedList.Contains((int)sqlc.State) ? true : false);
		}

		#endregion

		/// <summary>Wrapper for the SQLiteCommand.ExecuteNonQuery function</summary>
		/// <param name="query">Query string to be executed</param>
		/// <returns>true if execution success, false if error</returns>
		public bool runNonQuery(string query)
		{
			if (!checkDbConnected()) { Console.WriteLine("ERROR:SQLC → SQL Connection NULL or not open"); return false; }

			SQLiteCommand sqlk = new SQLiteCommand(query, sqlc);
			int i = -1;

			try
			{
				i = sqlk.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Console.WriteLine("ERROR:SQLC → SQL query returned error: \r\n" + ex.Message);
				return false;
			}

			return i > -1;
		}

		#region TABLES

		/// <summary>Checks if a table can be found in the DB already</summary>
		/// <param name="tableName">Name of the table to find</param>
		/// <returns>true if table exists, false if table doesn't exist, null if error</returns>
		public bool? checkTableExists(string tableName)
		{
			if (!checkDbConnected()) { Console.WriteLine("ERROR:SQLC → SQL Connection NULL or not open"); return null; }

			SQLiteCommand sqlk = new SQLiteCommand(string.Format("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{0}';", tableName), sqlc);
			int i = 0;
			try
			{
				int.TryParse(sqlk.ExecuteScalar().ToString(), out i);
			}
			catch(Exception ex)
			{
				Console.WriteLine("ERROR:SQLC → SQL query returned error: \r\n" + ex.ToString());
				return null;
			}

			return i > 0;
		}

		/// <summary> Modular table creator function | Creates a new named table if that table doesn't yet exist in the database | Uses modular column definition for reusability</summary>
		/// <param name="tableName">Name of the table to be created</param>
		/// <param name="columns">Array of columns to be added in the newly created table. Type: SQLiteColumn</param>
		/// <returns>true if new table created</returns>
		public bool createTable(string tableName, SQLiteColumn[] columns)
		{
			if (!checkDbConnected()) { Console.WriteLine("ERROR:SQLC → SQL Connection NULL or not open"); return false; }
			object exist = checkTableExists(tableName);
			if (exist == null || (bool)exist) { return false; }

			StringBuilder tableBuilder = new StringBuilder(string.Format("CREATE TABLE {0} \r\n" +
																				"(", tableName));

			string indexes = "";

			foreach (SQLiteColumn c in columns)
			{
				tableBuilder.AppendFormat(" {0} ", c.getColumnDLL());
				if(!columns.Last().Equals(c)) { tableBuilder.Append(", \r\n"); }
				indexes += string.Format("\r\nCREATE INDEX {0} ON {1}({2});", tableName + "_" + c.columnName, tableName, c.columnName);
			}

			tableBuilder.Append("\r\n); " + indexes);

			return runNonQuery(tableBuilder.ToString()) == true;
		}

		/// <summary> Modular table creator function | Creates a new named table if that table doesn't yet exist in the database | Uses modular column definition for reusability</summary>
		/// <param name="tableName">Name of the table to be created</param>
		/// <param name="columns">List of columns to be added in the newly created table. Type: SQLiteColumn</param>
		/// <returns>true if new table created</returns>
		public bool createTable(string tableName, List<SQLiteColumn> columns)
		{
			SQLiteColumn[] cols = columns.ToArray();
			return createTable(tableName, cols);
		}

		#endregion

		#region INSERT/UPDATE/DELETE

		public void buildInsert(string tableName, string[][] values, bool runInsert = false)
		{
			string template = "";
			bool first = false;

			if (insertBuilderBuilder.Length == 0)
			{
				insertBuilderBuilder.Append(string.Format("INSERT OR REPLACE INTO {0} \r\n\t", tableName));
				first = true;
			}

			string columns = "(";
			string vals = "(";
			string id = "";

			foreach (var v in values)
			{
				columns += v[0];

				template = ((v[1] == "true" || v[1] == "1") ? "'{0}'" : "{0}");

				if (v[0] == "id") { id = string.Format(template, v[2]); }

				vals += string.Format(template, v[2].Replace("'","''"));
				
				if (!values.Last().Equals(v))
				{
					columns += ", ";
					vals += ", ";
				}
				else
				{
					columns += ")\r\n VALUES\r\n\t ";
					vals += ")";
					if (!runInsert) { vals += ",\r\n"; }
				}
			}
			if (first)
			{
				insertBuilderBuilder.AppendFormat(" {0} {1} ", columns, vals);
			}
			else
			{
				insertBuilderBuilder.AppendFormat(" {0} ", vals);
			}
			/*
			try
			{
				new SQLiteCommand(insertBuilderBuilder.ToString().Trim(new char[]{ ',','\r','\n', ' ','	' }), sqlc).VerifyOnly();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			*/
			if (runInsert)
			{
				runNonQuery(insertBuilderBuilder.ToString());
				insertBuilderBuilder.Clear();
			}
		}

		/// <summary>
		/// Insert data into selected table
		/// </summary>
		/// <param name="values">string[][Column Name|Column is String ("true"/"false")|Column Value]</param>
		public bool insertInto(string tableName, string[][] values)
		{
			if (!checkDbConnected()) { Console.WriteLine("ERROR:SQLC → SQL Connection NULL or not open"); return false; }
			object exist = checkTableExists(tableName);
			if (exist == null || !(bool)exist) { return false; }

			StringBuilder insertBuilder = new StringBuilder();
			StringBuilder updateBuilder = new StringBuilder();
			string template = "";

			insertBuilder.Append(string.Format("INSERT INTO {0} \r\n\t", tableName));
			updateBuilder.Append(string.Format("UPDATE {0} \r\n\tSET\r\n\t ", tableName));

			string columns = "(";
			string vals = "(";
			string id = "";

			foreach (var v in values)
			{
				columns += v[0];

				template = ((v[1] == "true" || v[1] == "1") ? "'{0}'" : "{0}");

				if (v[0] == "id") { id = string.Format(template, v[2]); }

				vals += string.Format(template, v[2]);

				updateBuilder.Append(string.Format(" {0}={1} ", v[0], string.Format(template, v[2])));

				if (!values.Last().Equals(v))
				{
					columns += ", ";
					vals += ", ";
					updateBuilder.Append(",\r\n\t");
				}
				else
				{
					columns += ")\r\n VALUES\r\n\t ";
					vals += ");";
				}
			}

			updateBuilder.Append(string.Format(" WHERE id={0} ", id));

			insertBuilder.AppendFormat(" {0} {1} ", columns, vals);

			bool ret = runNonQuery(insertBuilder.ToString()) == true;// || runNonQuery(updateBuilder.ToString()) == true;
			
			return ret;
		}

		public bool insertInto(string tableName, Dictionary<SQLiteColumn, string> values)
		{
			string[][] vals = new string[values.Count][];
			int i = 0;

			foreach (var v in values)
			{
				vals[i] = new string[] { v.Key.columnName, (v.Key.isString() ? "true" : "false"), v.Value };
				i++;
			}

			return insertInto(tableName, vals);
		}

		public bool insertInto(string tableName, string[] values)
		{
			string[][] vals = new string[values.Length][];
			int i = 0;
			string[] tf = new string[] { "true", "false" };

			foreach (var v in values)
			{
				string[] vT = v.Split(';');
				vals[i] = new string[] { vT[0], (tf.Contains(vT[1]) ? vT[1] : (vT[1] == "1" ? "true" : "false")), vT[2] };
				i++;
			}

			return insertInto(tableName, vals);
		}

		public bool insertInto(string tableName, string values)
		{
			string[][] vals = new string[values.Split(';').Length][];
			int i = 0;
			string[] tf = new string[] { "true", "false" };

			foreach (var v in values.Split(';'))
			{
				string[] vT = v.Split(':');
				vals[i] = new string[] { vT[0], (tf.Contains(vT[1]) ? vT[1] : (vT[1] == "1" ? "true" : "false")), vT[2] };
				i++;
			}

			return insertInto(tableName, vals);
		}

		public bool update(string tableName, Dictionary<SQLiteColumn, string> values, string where)
		{
			if (!checkDbConnected()) { Console.WriteLine("ERROR:SQLC → SQL Connection NULL or not open"); return false; }
			object exist = checkTableExists(tableName);
			if (exist == null || !(bool)exist) { return false; }

			StringBuilder updateBuilder = new StringBuilder(string.Format("UPDATE {0} \r\n\t SET ", tableName));

			foreach (var v in values)
			{
				updateBuilder.AppendFormat(" {0}={1}",v.Key.columnName,v.Key.isString() ? "'" + v.Value.Replace("'","''") + "'" : v.Value.Replace("'", "''"));
				
				if (!values.Last().Equals(v))
				{
					updateBuilder.Append(", ");
				}
				else
				{
					updateBuilder.AppendFormat(" {0} ", where == "" ? "" : " WHERE \r\n\t " + where);
				}
			}

			return runNonQuery(updateBuilder.ToString()) == true;
		}

		public bool deleteFrom(string tableName, string where = "")
		{
			if (!checkDbConnected()) { Console.WriteLine("ERROR:SQLC → SQL Connection NULL or not open"); return false; }
			object exist = checkTableExists(tableName);
			if (exist == null || !(bool)exist) { return false; }

			StringBuilder deleteBuilder = new StringBuilder(string.Format("DELETE FROM \r\n\t {0} \r\n ", tableName));
			if (where.Length > 0)
			{
				if (where.Trim().ToLower().StartsWith("where"))
				{
					where = " " + where.Substring(where.ToLower().IndexOf("where") + 5);
				}

				deleteBuilder.AppendFormat(" WHERE\r\n\t {0} ", where);
			}

			deleteBuilder.Append("; vacuum;");

			return runNonQuery(deleteBuilder.ToString()) == true;
		}

		#endregion

		#region SELECT

		public SQLiteCommand GetDbContent(string tableName, string[] cols, string where)
		{
			if (!checkDbConnected()) { Console.WriteLine("ERROR:SQLC → SQL Connection NULL or not open"); return null; }
			object exist = checkTableExists(tableName);
			if (exist == null || !(bool)exist) { return null; }

			string selectCols = (cols.Length < 2 ? (cols.Length == 0 ? " * " : cols[0]) : string.Join(", \r\n\t", cols));

			StringBuilder selectBuilder = new StringBuilder(string.Format("SELECT \r\n\t {0} \r\n FROM \r\n\t {1} \r\n ", selectCols, tableName));

			if (where.Length > 0)
			{
				if (where.Trim().ToLower().StartsWith("where"))
				{
					where = " " + where.Substring(where.ToLower().IndexOf("where") + 5);
				}

				selectBuilder.AppendFormat(" WHERE\r\n\t {0} ", where);
			}

			SQLiteCommand sqlk = new SQLiteCommand(selectBuilder.ToString(), sqlc);
			return sqlk;
		}

		public SQLiteDataReader runSelect(string sql)
		{
			try
			{
				SQLiteCommand sc = new SQLiteCommand(sql, sqlc);
				return sc.ExecuteReader();
			}
			catch
			{
				return null;
			}
		}

		public List<string[][]> select(string tableName, string[] cols, string where)
		{
			SQLiteCommand sqlk = GetDbContent(tableName, cols, where);

			return getStringsFrom(sqlk.ExecuteReader());
		}
		
		public List<string[][]> select(string tableName, SQLiteColumn[] cols, string where)
		{
			return select(tableName, cols.ToList().Select(x => x.columnName).ToArray(), where);
		}

		public List<string[][]> select(string tableName, List<SQLiteColumn> cols, string where)
		{
			return select(tableName, cols.Select(x => x.columnName).ToArray(), where);
		}

		public List<string[][]> select(string tableName, string cols, char delimiter, string where)
		{
			return select(tableName, cols.Split(delimiter), where);
		}

		public List<string[][]> select(string tableName)
		{
			return select(tableName, "*", ',', "");
		}

		/// <summary>
		/// Returns result data as a list of string[,]{value as string/datatype};
		/// </summary>
		public List<string[][]> getStringsFrom(SQLiteDataReader r)
		{
			List<string[][]> ret = null;
			ret = new List<string[][]>();

			if (r.HasRows)
			{
				while (r.Read())
				{
					string[][] tmpArr = new string[r.FieldCount][];
					string[] tmp = new string[2];
					for (int i = 0; i < r.FieldCount; i++)
					{
						tmp = new string[] { r.GetValue(i).ToString(), r.GetName(i) };
						tmpArr[i] = tmp;
					}

					ret.Add(tmpArr);
				}
			}

			return ret;
		}

		#endregion
		
		public int checkCountInTags(string name)
		{
			int ret = -1;

			SQLiteCommand s = new SQLiteCommand("SELECT COALESCE(NULLIF(a.posts,-1),NULLIF(t.count,-1),-1) as posts FROM artists a LEFT JOIN tags t ON t.name=a.name WHERE a.name='" + name + "'", sqlc);
			ret = Convert.ToInt32(s.ExecuteScalar());
			
			return ret;
		}

	}
	

	/// <summary>SQLiteColumn struct, contains all data needed for a basic column definition</summary>
	public struct SQLiteColumn
	{
		/// <summary>Name of column</summary>
		public string columnName { get; set; }

		/// <summary>Datatype of column Type: SQLiteDataType</summary>
		public SQLiteDataType dataType { get; set; }

		/// <summary>True if the column is Primary key</summary>
		public bool pimaryKey { get; set; }

		/// <summary>True if the column is AutoIncremented</summary>
		public bool autoIncrement { get; set; } 
		
		public bool hasDefaultIntValue { get; set; }
		/// <summary>defaultValueInInt</summary>
		public int defaultIntValue { get; set; }
		
		public bool hasDefaultStringValue { get; set; }
		/// <summary>defaultValueInstring</summary>
		public string defaultStringValue { get; set; }

		/// <summary>True if column has comment</summary>
		private bool hasColumnComment;
		/// <summary>Private container for Column Comment</summary>
		private string _columnComment;
		/// <summary>Public container for Column Comment</summary>
		public string columnComment { get { return _columnComment; } set { _columnComment = value; hasColumnComment = value != null && value.Length > 0; } }

		/// <summary>True if column is additional line</summary>
		private bool isAdditionalData;
		/// <summary>Private container for Additional Data</summary>
		private string _additionalData;
		/// <summary>Public container for Additional Data</summary>
		public string additionalData { get { return _additionalData; } set { _additionalData = value; isAdditionalData = value != null && value.Length > 0; } }
		
		/// <summary>Used to write out the PrimaryKey String</summary> <returns>PRIMARY KEY if true empty string otherwise</returns>
		public string pKey() { return pimaryKey ? " PRIMARY KEY " : ""; }
		
		/// <summary>Used to write out the SecondaryKey String</summary> <returns>SECONDARY KEY if true empty string otherwise</returns>
		public string aInc() { return autoIncrement ? " AUTOINCREMENT " : ""; }

		/// <summary>Used to write out any additional lines for table creation</summary> <returns>AddData String if true empty string otherwise</returns>
		public string aDat() { return isAdditionalData ? string.Format(" {0} ", _additionalData) : ""; }

		/// <summary>Used to write out the column comment if exists</summary> <returns>Comment String if true empty string otherwise</returns>
		public string cCom() { return hasColumnComment ? string.Format(" /* {0} */ ", _columnComment) : ""; }

		/// <summary>Used to check wheather the column content is a string value</summary> <returns>True if datatype = text</returns>
		public bool isString() { return dataType == SQLiteDataType.TEXT; }

		public string vDef() { if (isString() && hasDefaultStringValue) { return " DEFAULT " + defaultStringValue; } else if (!isString() && hasDefaultIntValue) { return " DEFAULT " + defaultIntValue; } else { return ""; } }

		/// <summary>Used to write the datatype of the column based on dataType value</summary> <returns>Datatype String</returns>
		public string type()
		{
			string ret = "";
			switch (dataType)
			{
				case SQLiteDataType.NONE:
					ret = "";
					break;

				case SQLiteDataType.INTEGER:
					ret = " INTEGER ";
					break;

				case SQLiteDataType.NUMERIC:
					ret = " NUMERIC ";
					break;

				case SQLiteDataType.REAL:
					ret = " REAL ";
					break;

				case SQLiteDataType.TEXT:
					ret = " TEXT ";
					break;

				default:
					ret = " TEXT ";
					break;
			}
			return ret;
		}

		/// <summary>
		/// Gets the DLL for the current column in text format
		/// </summary>
		/// <returns>DLL of column</returns>
		public string getColumnDLL()
		{
			if (isAdditionalData)
			{
				return string.Format(" {0} ", _additionalData);
			}
			else
			{
				return string.Format(" {0} {1} {2} {3} {4} ", columnName, type(), pKey() + aInc(), vDef(), cCom());
			}
		}
	}

	/// <summary>Currently supported datatypes | these are the main data container types | Additional types may be added</summary>
	public enum SQLiteDataType
	{
		NONE,
		INTEGER,
		TEXT,
		REAL,
		NUMERIC
	}

}
