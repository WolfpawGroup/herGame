using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace herGame
{
	/// <summary>
	/// Type for images containing all relevant data
	/// </summary>
	public class c_ImageDetails
	{
		[fieldDefinitions(partOfTable = true, columnName = "id", dataType = SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true)]
		public int id { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "md5", dataType = SQLiteDataType.TEXT)]
		public string md5 { get; set; }

		[fieldDefinitions(partOfTable = true, columnName = "parent_id", dataType = SQLiteDataType.INTEGER)]
		public int parent_id { get; set; }
		[fieldDefinitions(partOfTable = false)]
		public bool has_children { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "children", dataType = SQLiteDataType.TEXT)]
		public string[] children { get; set; }

		[fieldDefinitions(partOfTable = true, columnName = "artist", dataType = SQLiteDataType.TEXT)]
		public string artist { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "source", dataType = SQLiteDataType.TEXT)]
		public string source { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "sources", dataType = SQLiteDataType.TEXT)]
		public string[] sources { get; set; }
		
		[fieldDefinitions(partOfTable = true, columnName = "score", dataType = SQLiteDataType.INTEGER)]
		public int score { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "rating", dataType = SQLiteDataType.TEXT)]
		public string rating { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "tags", dataType = SQLiteDataType.TEXT)]
		public string tags { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "description", dataType = SQLiteDataType.TEXT)]
		public string description { get; set; }

		[fieldDefinitions(partOfTable = true, columnName = "file_url", dataType = SQLiteDataType.TEXT)]
		public string file_url { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "sample_url", dataType = SQLiteDataType.TEXT)]
		public string sample_url { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "preview_url", dataType = SQLiteDataType.TEXT)]
		public string preview_url { get; set; }

		[fieldDefinitions(partOfTable = true, columnName = "width", dataType = SQLiteDataType.INTEGER)]
		public int width { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "height", dataType = SQLiteDataType.INTEGER)]
		public int height { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "sample_width", dataType = SQLiteDataType.INTEGER)]
		public int sample_width { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "sample_height", dataType = SQLiteDataType.INTEGER)]
		public int sample_height { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "preview_width", dataType = SQLiteDataType.INTEGER)]
		public int preview_width { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "preview_height", dataType = SQLiteDataType.INTEGER)]
		public int preview_height { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "file_ext", dataType = SQLiteDataType.TEXT)]
		public string file_ext { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "file_size", dataType = SQLiteDataType.INTEGER)]
		public int file_size { get; set; }
	}

	public class c_Image
	{
		public int id { get; set; }
		public string md5 { get; set; }
		public string artist_id { get; set; }

		public c_ImageDetails details { get; set; }
		public c_Artist artist { get; set; }

		public int fileSize { get; set; }
		public Size imageSize { get; set; }
	}

	/// <summary>
	/// Type for artists containing all relevant data
	/// </summary>
	public class c_Artist
	{
		[fieldDefinitions(partOfTable = true, columnName = "id", dataType = SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true)]
		public int id { get; set; }

		[fieldDefinitions(partOfTable = true, columnName = "name", dataType = SQLiteDataType.TEXT)]																	//Artist name
		public string name { get; set; }
		[fieldDefinitions(partOfTable = false)]																														//true if artist has aliases
		public bool hasOtherNames { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "other_names", dataType = SQLiteDataType.TEXT)]															//Artist aliases
		public string[] other_names { get; set; }
		[fieldDefinitions(partOfTable = false)]																														//true if artist has url-s
		public bool hasUrls { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "urls", dataType = SQLiteDataType.TEXT)]																	//Artist url-s
		public string[] urls { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "posts", hasDefaultIntValue = true, defaultIntValue = -1, dataType = SQLiteDataType.INTEGER)]             //# of artists images
		public int posts { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "updated", dataType = SQLiteDataType.TEXT)]																//Last updated
		public string updated { get; set; }
	}

	/// <summary>
	/// Type for tags contining all relevant data
	/// </summary>
	public class c_Tags
	{
		[fieldDefinitions(partOfTable = true, columnName = "id", dataType = SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true)]
		public int id { get; set; }

		[fieldDefinitions(partOfTable = true, columnName = "name", dataType = SQLiteDataType.TEXT)]                 //Tag name
		public string name { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "count", dataType = SQLiteDataType.INTEGER)]             //Images in tag
		public int count { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "type", dataType = SQLiteDataType.INTEGER)]              //Type from tagType enum
		public int type { get; set; }

		//Relateds eg: related_General:[330;133;201;199]
		[fieldDefinitions(partOfTable = true, columnName = "related_General", dataType = SQLiteDataType.TEXT)]      //Related tags in general type
		public string related_General { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "related_Artist", dataType = SQLiteDataType.TEXT)]       //Related tags in Artist type
		public string related_Artist { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "related_Copyright", dataType = SQLiteDataType.TEXT)]    //Related tags in Copyright type
		public string related_Copyright { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "related_Character", dataType = SQLiteDataType.TEXT)]    //Related tags in Character type
		public string related_Character { get; set; }
		[fieldDefinitions(partOfTable = true, columnName = "related_Species", dataType = SQLiteDataType.TEXT)]      //Related tags in Species type
		public string related_Species { get; set; }

		[fieldDefinitions(partOfTable = true, columnName = "updated", dataType = SQLiteDataType.TEXT)]              //Last updated
		public string updated { get; set; }
	}

	/// <summary>
	/// History of actions for downloads games and queries
	/// </summary>
	public class c_History
	{
		[fieldDefinitions( partOfTable=true, columnName = "id", dataType = SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true)]
		public int id { get; set; }

		[fieldDefinitions( partOfTable=true, columnName = "activity", dataType = SQLiteDataType.INTEGER)]          //From activityType enum
		public int activity { get; set; }
		[fieldDefinitions( partOfTable=true, columnName = "additional", dataType = SQLiteDataType.TEXT)]           //Additional data / tags searched etc
		public string additional { get; set; }
		[fieldDefinitions( partOfTable=true, columnName = "result", dataType = SQLiteDataType.INTEGER)]			//-1/1 = Fail/Success
		public int result { get; set; }

		[fieldDefinitions( partOfTable=true, columnName = "playmate", dataType = SQLiteDataType.INTEGER)]			//If generating links, for whom
		public int playmate { get; set; }
		[fieldDefinitions( partOfTable=true, columnName = "no_of_items", dataType = SQLiteDataType.INTEGER)]		//Pics downloaded/images generated etc...
		public int no_of_items { get; set; }
		
		[fieldDefinitions( partOfTable=true, columnName = "datetime", dataType = SQLiteDataType.TEXT)]              //time of occurance
		public string datetime { get; set; }
	}

	/// <summary>
	/// List of playmates with name, picture and games played
	/// </summary>
	public class c_Playmates
	{
		[fieldDefinitions( partOfTable=true, columnName = "id", dataType = SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true)]
		public int id { get; set; }

		[fieldDefinitions( partOfTable=true, columnName = "name", dataType = SQLiteDataType.TEXT)]                 //Playmate name
		public string name { get; set; }
		[fieldDefinitions( partOfTable=true, columnName = "picture", dataType = SQLiteDataType.TEXT)]              //Playmate image (base64)
		public string picture { get; set; }

		[fieldDefinitions( partOfTable=true, columnName = "games_played", dataType = SQLiteDataType.INTEGER)]      //# of games played with playmate
		public string games_played { get; set; }
		[fieldDefinitions( partOfTable=true, columnName = "pictures_sent", dataType = SQLiteDataType.INTEGER)]     //# of pics sent to playmate
		public string pictures_sent { get; set; }
		[fieldDefinitions( partOfTable=true, columnName = "last_played_with", dataType = SQLiteDataType.TEXT)]     //Last time playmate played with
		public string last_played_with { get; set; }
	}

	/// <summary>
	/// Log of all downloaded images with path of the download directory
	/// </summary>
	public class c_Downloaded
	{
		[fieldDefinitions( partOfTable=true, columnName = "id", dataType = SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true)]
		public int id { get; set; }

		[fieldDefinitions( partOfTable=true, columnName = "md5", dataType = SQLiteDataType.TEXT)]                  //image md5
		public string md5 { get; set; }
		[fieldDefinitions( partOfTable=true, columnName = "path", dataType = SQLiteDataType.TEXT)]                 //path of download
		public string path { get; set; }

		[fieldDefinitions( partOfTable=true, columnName = "datetime", dataType = SQLiteDataType.TEXT)]             //time of occurance
		public string datetime { get; set; }
	}

	/// <summary>
	/// Log of all sent images with id of playmate it was sent to
	/// </summary>
	public class c_Sent
	{
		[fieldDefinitions( partOfTable=true, columnName = "id", dataType = SQLiteDataType.INTEGER, pimaryKey = true, autoIncrement = true)]
		public int id { get; set; }

		[fieldDefinitions( partOfTable=true, columnName = "md5", dataType = SQLiteDataType.TEXT)]					//image md5
		public string md5 { get; set; }
		[fieldDefinitions( partOfTable=true, columnName = "playmate", dataType = SQLiteDataType.INTEGER)]			//path of download
		public int playmate { get; set; }

		[fieldDefinitions( partOfTable=true, columnName = "datetime", dataType = SQLiteDataType.TEXT)]				//time of occurance
		public string datetime { get; set; }
	}

	public enum tagType
	{
		General,
		Artist,
		Copyright,
		Character,
		Species
	}

	public enum activityType
	{
		Download_tags,
		Download_artists,
		Download_results,
		Save_images,
		Generate_links
	}

	[AttributeUsage(
		AttributeTargets.Field | 
		AttributeTargets.Property,
		AllowMultiple = true)]
	public class fieldDefinitions : Attribute
	{
		public string columnName { get; set; }
		public SQLiteDataType dataType { get; set; }
		public bool partOfTable { get; set; }
		public bool pimaryKey { get; set; }
		public bool autoIncrement { get; set; }
		public bool hasDefaultIntValue { get; set; }
		public int defaultIntValue { get; set; }
		public bool hasDefaultStringValue { get; set; }
		public string defaultStringValue { get; set; }

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

	public class myDataGridView : DataGridView
	{
		protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
		{
			base.OnColumnHeaderMouseClick(e);
		}
	}

}
