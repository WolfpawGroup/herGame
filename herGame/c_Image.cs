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
		public int id {get;set;}
		public string md5 {get;set;}

		public int parent_id {get;set;}
		public bool has_children {get;set;}
		public string[] children { get;set;}

		public string artist {get;set;}
		public string source { get;set;}
		public string[] sources {get;set;}

		public int fav_count { get;set;}
		public int score { get;set;}
		public string rating {get;set;}
		public string tags {get;set;}
		public string description {get;set;}

		public string file_url {get;set;}
		public string sample_url {get;set;}
		public string preview_url { get;set;}
		public int width {get;set;}
		public int height {get;set;}
		public int sample_width {get;set;}
		public int sample_height {get;set;}
		public int preview_width {get;set;}
		public int preview_height { get;set;}
		public string file_ext { get;set;}
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
		public int id { get; set; }
		public string name { get; set; }
		public string[] other_names { get; set; }
		public string[] urls { get; set; }
	}
}
