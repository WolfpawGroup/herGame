using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace herGame
{
	class c_ImageDataHandler
	{
		c_Downloader cd = new c_Downloader();
		c_SqlFunctions cs = new c_SqlFunctions();

		public List<c_Image> donloadImageData(string tags)
		{
			List<c_Image> ret = new List<c_Image>();

			Stopwatch sw = new Stopwatch();
			sw.Start();
			int i = 0;
			string idList = "id \r\n\tIN \r\n(";
			bool run = false;
			List<c_ImageDetails> artists = cd.getImages(tags);
			foreach (var v in artists)
			{
				idList += "\r\n\t" + v.id + ", ";

				if (artists.Last().Equals(v)) { run = true; }

				cs.buildInsert("artists", new string[][] {
						new string[]{ "id",				"false",						v.id				+ ""	},
						new string[]{ "md5",			"true",							v.md5						},
						new string[]{ "artist",			"true",							v.artist					},
						new string[]{ "artists",		"true",		string.Join(", ",	v.artists	)				},
						new string[]{ "tags",			"true",		string.Join(", ",	v.tags		)				},
						new string[]{ "description",	"true",							v.description				},
						new string[]{ "rating",			"true",							v.rating					},
						new string[]{ "parent_id",		"false",						v.parent_id			+ ""	},
						new string[]{ "children",		"true",		string.Join(", ",	v.children	)				},
						new string[]{ "source",			"true",							v.source					},
						new string[]{ "file_ext",		"true",							v.file_ext					},
						new string[]{ "sources",		"true",		string.Join(", ",	v.sources	)				},
						new string[]{ "score",			"false",						v.score				+ ""	},
						new string[]{ "file_url",		"true",							v.file_url					},
						new string[]{ "height",			"false",						v.height			+ ""	},
						new string[]{ "width",			"false",						v.width				+ ""	},
						new string[]{ "preview_url",	"true",							v.preview_url				},
						new string[]{ "preview_height",	"false",						v.preview_height	+ ""	},
						new string[]{ "preview_width",	"false",						v.preview_width		+ ""	},
						new string[]{ "sample_url",		"true",							v.sample_url				},
						new string[]{ "sample_height",	"false",						v.sample_height		+ ""	},
						new string[]{ "sample_width",	"false",						v.sample_width		+ ""	},
						new string[]{ "file_size",		"false",						v.file_size			+ ""	},
						new string[]{ "downloaded",		"true",							v.downloaded				}
					}, run);
				i++;
			}

			idList = idList.Substring(0, idList.Length - 2) + "\r\n)";

			var imgColumns = new SQLiteColumn[] {
				new SQLiteColumn(){ columnName = "id",				dataType = SQLiteDataType.INTEGER	},
				new SQLiteColumn(){ columnName = "md5",				dataType = SQLiteDataType.TEXT		},
				new SQLiteColumn(){ columnName = "artist_id",		dataType = SQLiteDataType.INTEGER	},

				new SQLiteColumn(){ columnName = "preview_url",		dataType = SQLiteDataType.TEXT		},
				new SQLiteColumn(){ columnName = "preview_width",	dataType = SQLiteDataType.INTEGER	},
				new SQLiteColumn(){ columnName = "preview_height",	dataType = SQLiteDataType.INTEGER	},

				new SQLiteColumn(){ columnName = "file_ext",		dataType = SQLiteDataType.TEXT		},
				new SQLiteColumn(){ columnName = "file_url",		dataType = SQLiteDataType.TEXT		},
				new SQLiteColumn(){ columnName = "width",			dataType = SQLiteDataType.INTEGER	},
				new SQLiteColumn(){ columnName = "height",			dataType = SQLiteDataType.INTEGER	},
				new SQLiteColumn(){ columnName = "file_size",		dataType = SQLiteDataType.INTEGER	}
			};

			foreach (var v in cs.select("images", imgColumns, idList))
			{
				foreach(var vv in v) { Console.WriteLine(string.Join(", ", vv)); }
				ret.Add(new c_Image() {
					
				});
			}


			return ret;
		}
	}
}
