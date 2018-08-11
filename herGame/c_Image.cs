using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace herGame
{
	class c_ImageDetails
	{
		[fieldDefinitions(columnName = "id", dataType = SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true)]
		public int id {get;set;}
		[fieldDefinitions(columnName = "md5", dataType = SQLiteDataType.TEXT)]
		public string md5 {get;set;}

		[fieldDefinitions(columnName = "parent_id", dataType = SQLiteDataType.INTEGER)]
		public int parent_id {get;set;}
		[fieldDefinitions(columnName = "has_children", dataType = SQLiteDataType.INTEGER)]
		public bool has_children {get;set;}
		[fieldDefinitions(columnName = "children", dataType = SQLiteDataType.TEXT)]
		public string[] children { get;set;}

		[fieldDefinitions(columnName = "artist", dataType = SQLiteDataType.TEXT)]
		public string artist {get;set;}
		[fieldDefinitions(columnName = "source", dataType = SQLiteDataType.TEXT)]
		public string source { get;set;}
		[fieldDefinitions(columnName = "sources", dataType = SQLiteDataType.TEXT)]
		public string[] sources {get;set;}

		[fieldDefinitions(columnName = "fav_count", dataType = SQLiteDataType.INTEGER)]
		public int fav_count { get;set;}
		[fieldDefinitions(columnName = "score", dataType = SQLiteDataType.INTEGER)]
		public int score { get;set;}
		[fieldDefinitions(columnName = "rating", dataType = SQLiteDataType.TEXT)]
		public string rating {get;set;}
		[fieldDefinitions(columnName = "tags", dataType = SQLiteDataType.TEXT)]
		public string tags {get;set;}
		[fieldDefinitions(columnName = "description", dataType = SQLiteDataType.TEXT)]
		public string description {get;set;}

		[fieldDefinitions(columnName = "file_url", dataType = SQLiteDataType.TEXT)]
		public string file_url {get;set;}
		[fieldDefinitions(columnName = "sample_url", dataType = SQLiteDataType.TEXT)]
		public string sample_url {get;set;}
		[fieldDefinitions(columnName = "preview_url", dataType = SQLiteDataType.TEXT)]
		public string preview_url { get;set;}

		[fieldDefinitions(columnName = "width", dataType = SQLiteDataType.INTEGER)]
		public int width {get;set;}
		[fieldDefinitions(columnName = "height", dataType = SQLiteDataType.INTEGER)]
		public int height {get;set;}
		[fieldDefinitions(columnName = "sample_width", dataType = SQLiteDataType.INTEGER)]
		public int sample_width {get;set;}
		[fieldDefinitions(columnName = "sample_height", dataType = SQLiteDataType.INTEGER)]
		public int sample_height {get;set;}
		[fieldDefinitions(columnName = "preview_width", dataType = SQLiteDataType.INTEGER)]
		public int preview_width {get;set;}
		[fieldDefinitions(columnName = "preview_height", dataType = SQLiteDataType.INTEGER)]
		public int preview_height { get;set;}
		[fieldDefinitions(columnName = "file_ext", dataType = SQLiteDataType.TEXT)]
		public string file_ext { get;set;}
		[fieldDefinitions(columnName = "file_size", dataType = SQLiteDataType.INTEGER)]
		public int file_size { get;set;}
	}

	class c_Image
	{
		public int id { get; set; }
		public string md5 { get; set; }
		public string artist_id { get; set; }

		public c_ImageDetails details { get; set; }
		public c_Artist artist { get; set; }
		
		public int fileSize { get; set; }
		public Size imageSize { get; set; }
	}

	class c_Artist
	{
		[fieldDefinitions(columnName = "id", dataType = SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true)]
		public int id { get; set; }
		[fieldDefinitions(columnName = "name", dataType = SQLiteDataType.TEXT)]
		public string name { get; set; }
		[fieldDefinitions(columnName = "hasOtherNames", dataType = SQLiteDataType.INTEGER)]
		public bool hasOtherNames { get; set; }
		[fieldDefinitions(columnName = "other_names", dataType = SQLiteDataType.TEXT)]
		public string[] other_names { get; set; }
		[fieldDefinitions(columnName = "hasUrls", dataType = SQLiteDataType.INTEGER)]
		public bool hasUrls { get; set; }
		[fieldDefinitions(columnName = "urls", dataType = SQLiteDataType.TEXT)]
		public string[] urls { get; set; }
		[fieldDefinitions(columnName = "added", dataType = SQLiteDataType.TEXT)]
		public string added { get; set; }
	}

	[AttributeUsage(
		AttributeTargets.Field | 
		AttributeTargets.Property,
		AllowMultiple = true)]
	public class fieldDefinitions : Attribute
	{
		public string columnName { get; set; }
		public SQLiteDataType dataType { get; set; }
		public bool pimaryKey { get; set; }
		public bool autoIncrement { get; set; }
		
		private bool hasColumnComment;
		private string _columnComment;

		public string columnComment {
			get { return _columnComment; }
			set { _columnComment = value;
				hasColumnComment = value.Length > 0; }
		}
		
		private bool isAdditionalData;
		private string _additionalData;

		public string additionalData {
			get { return _additionalData; }
			set { _additionalData = value;
				isAdditionalData = value.Length > 0; }
		}
	}
}
