using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace herGame
{
	class c_ImageDataHandler
	{
		c_Downloader cd = new c_Downloader();
		c_SqlFunctions cs = null;

		public c_ImageDataHandler(c_SqlFunctions _cs)
		{
			cs = _cs;
		}

		public List<c_Image> donloadImageData(string tags)
		{
			List<c_Image> ret = new List<c_Image>();

			Stopwatch sw = new Stopwatch();
			sw.Start();
			int i = 0;
			string idList = "id \r\n\tIN \r\n(";
			bool run = false;
			List<c_ImageDetails> images = cd.getImages(tags);
			foreach (var v in images)
			{
				idList += "\r\n\t" + v.id + ", ";

				if (images.Last().Equals(v)) {
					run = true;
				}

				cs.buildInsert("images", new string[][] {
						new string[]{ "id",				"false",													v.id				+ ""			},
						new string[]{ "md5",			"true",														v.md5								},
						new string[]{ "artist",			"true",														v.artist							},
						new string[]{ "artists",		"true",		v.artists ==	null ? "" : string.Join("×",	v.artists	)						},
						new string[]{ "tags",			"true",		v.tags	==		null ? "" : string.Join("×",	v.tags		)						},
						new string[]{ "description",	"true",														v.description						},
						new string[]{ "rating",			"true",														v.rating							},
						new string[]{ "parent_id",		"false",													v.parent_id			+ ""			},
						new string[]{ "children",		"true",		v.children ==	null ? "" : string.Join("×",	v.children	)						},
						new string[]{ "source",			"true",														v.source							},
						new string[]{ "file_ext",		"true",														v.file_ext							},
						new string[]{ "sources",		"true",		v.sources ==	null ? "" : string.Join("×",	v.sources	)						},
						new string[]{ "score",			"false",													v.score				+ ""			},
						new string[]{ "file_url",		"true",														v.file_url							},
						new string[]{ "height",			"false",													v.height			+ ""			},
						new string[]{ "width",			"false",													v.width				+ ""			},
						new string[]{ "preview_url",	"true",														v.preview_url						},
						new string[]{ "preview_height",	"false",													v.preview_height	+ ""			},
						new string[]{ "preview_width",	"false",													v.preview_width		+ ""			},
						new string[]{ "sample_url",		"true",														v.sample_url						},
						new string[]{ "sample_height",	"false",													v.sample_height		+ ""			},
						new string[]{ "sample_width",	"false",													v.sample_width		+ ""			},
						new string[]{ "file_size",		"false",													v.file_size			+ ""			},
						new string[]{ "downloaded",		"true",														v.downloaded						}
					}, run);
				i++;
			}

			idList = idList.Substring(0, idList.Length - 2) + "\r\n)";

			var imgColumns = new SQLiteColumn[] {
				new SQLiteColumn(){ columnName =		"id",															dataType = SQLiteDataType.INTEGER	},
				new SQLiteColumn(){ columnName =		"md5",															dataType = SQLiteDataType.TEXT		},
				new SQLiteColumn(){ columnName =		"(SELECT id FROM artists a WHERE a.name=artist) as artist_id",	dataType = SQLiteDataType.INTEGER	},

				new SQLiteColumn(){ columnName =		"preview_url",													dataType = SQLiteDataType.TEXT		},
				new SQLiteColumn(){ columnName =		"preview_width",												dataType = SQLiteDataType.INTEGER	},
				new SQLiteColumn(){ columnName =		"preview_height",												dataType = SQLiteDataType.INTEGER	},

				new SQLiteColumn(){ columnName =		"file_ext",														dataType = SQLiteDataType.TEXT		},
				new SQLiteColumn(){ columnName =		"file_url",														dataType = SQLiteDataType.TEXT		},
				new SQLiteColumn(){ columnName =		"width",														dataType = SQLiteDataType.INTEGER	},
				new SQLiteColumn(){ columnName =		"height",														dataType = SQLiteDataType.INTEGER	},
				new SQLiteColumn(){ columnName =		"file_size",													dataType = SQLiteDataType.INTEGER	}
			};

			var reader = cs.GetDbContent("images", imgColumns, idList).ExecuteReader();

			while(reader.Read())
			{
				c_Artist		c_art =	getArtist	(reader.GetInt32(reader.GetOrdinal(		"artist_id"						)));
				c_ImageDetails	c_det =	getDetails	(reader.GetInt32(reader.GetOrdinal(		"id"							)));

				ret.Add(new c_Image() {
					id =			reader.GetInt32				(	reader.GetOrdinal(		"id"							)),
					md5 =			reader.GetString			(	reader.GetOrdinal(		"md5"							)),
					artist_id =		reader.GetInt32				(	reader.GetOrdinal(		"artist_id"						)),


					previewUrl =	reader.GetString			(	reader.GetOrdinal(		"preview_url"					)),
					previewSize =	new Size					(
									reader.GetInt32				(	reader.GetOrdinal(		"preview_width"					)), 
									reader.GetInt32				(	reader.GetOrdinal(		"preview_height"				))),


					fileExt =		reader.GetString			(	reader.GetOrdinal(		"file_ext"						)),
					fileUrl =		reader.GetString			(	reader.GetOrdinal(		"file_url"						)),
					imageSize =		new Size					(
									reader.GetInt32				(	reader.GetOrdinal(		"width"							)), 
									reader.GetInt32				(	reader.GetOrdinal(		"height"						))),
					fileSize =		reader.GetInt32				(	reader.GetOrdinal(		"file_size"						)),

					artist =		c_art,
					details =		c_det
				});
			}


			return ret;
		}

		public c_Artist			getArtist(int a_id)
		{
			SQLiteColumn[] artistColumns = new SQLiteColumn[] {
				new SQLiteColumn(){ columnName = "id",				dataType = SQLiteDataType.INTEGER						},

				new SQLiteColumn(){ columnName = "name",			dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "other_names",		dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "urls",			dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "posts",			dataType = SQLiteDataType.INTEGER						},

				new SQLiteColumn(){ columnName = "updated",			dataType = SQLiteDataType.TEXT							},
			};

			var reader = cs.GetDbContent("artists", artistColumns, $" id={ a_id }").ExecuteReader();

			var ca = (c_Artist)null;

			while (reader.Read())
			{
				ca = new c_Artist()
				{
					id = reader.GetInt32(reader.GetOrdinal("id")),

					name = reader.GetString(reader.GetOrdinal("name")),
					other_names = reader.GetString(reader.GetOrdinal("other_names")).Split('×'),
					urls = reader.GetString(reader.GetOrdinal("urls")).Split('×'),
					posts = reader.GetInt32(reader.GetOrdinal("posts")),

					updated = reader.GetString(reader.GetOrdinal("updated")),
				};
			}

			return ca;
		}

		/// <summary>
		/// Get image details | Returns all details of image selected by ID in a c_ImageDetails object
		/// </summary>
		public c_ImageDetails	getDetails(int d_id)
		{
			SQLiteColumn[] imgColumns = new SQLiteColumn[] {
				new SQLiteColumn(){ columnName = "id",				dataType = SQLiteDataType.INTEGER						},
				new SQLiteColumn(){ columnName = "md5",				dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "artist",			dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "tags",			dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "artists",			dataType = SQLiteDataType.TEXT							},

				new SQLiteColumn(){ columnName = "description",		dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "score",			dataType = SQLiteDataType.INTEGER						},
				new SQLiteColumn(){ columnName = "rating",			dataType = SQLiteDataType.TEXT							},

				new SQLiteColumn(){ columnName = "parent_id",		dataType = SQLiteDataType.INTEGER						},
				new SQLiteColumn(){ columnName = "children",		dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "source",			dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "sources",			dataType = SQLiteDataType.TEXT							},

				new SQLiteColumn(){ columnName = "file_url",		dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "width",			dataType = SQLiteDataType.INTEGER						},
				new SQLiteColumn(){ columnName = "height",			dataType = SQLiteDataType.INTEGER						},
				new SQLiteColumn(){ columnName = "file_ext",		dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "file_size",		dataType = SQLiteDataType.INTEGER						},

				new SQLiteColumn(){ columnName = "sample_url",		dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "sample_width",	dataType = SQLiteDataType.INTEGER						},
				new SQLiteColumn(){ columnName = "sample_height",	dataType = SQLiteDataType.INTEGER						},

				new SQLiteColumn(){ columnName = "preview_url",		dataType = SQLiteDataType.TEXT							},
				new SQLiteColumn(){ columnName = "preview_width",	dataType = SQLiteDataType.INTEGER						},
				new SQLiteColumn(){ columnName = "preview_height",	dataType = SQLiteDataType.INTEGER						},

				new SQLiteColumn(){ columnName = "downloaded",		dataType = SQLiteDataType.TEXT							},
			};

			var reader = cs.GetDbContent("images", imgColumns, $" id={ d_id }").ExecuteReader();
			var det = (c_ImageDetails)null;

			while (reader.Read()){
				det = new c_ImageDetails() {
					id = reader.GetInt32(reader.GetOrdinal("id")),
					md5 = reader.GetString(reader.GetOrdinal("md5")),
					artist = reader.GetString(reader.GetOrdinal("artist")),
					tags = reader.GetString(reader.GetOrdinal("tags")).Split('×'),
					artists = reader.GetString(reader.GetOrdinal("artists")).Split('×'),

					description = reader.GetString(reader.GetOrdinal("description")),
					score = reader.GetInt32(reader.GetOrdinal("score")),
					rating = reader.GetString(reader.GetOrdinal("rating")),

					parent_id = reader.GetInt32(reader.GetOrdinal("parent_id")),
					children = reader.GetString(reader.GetOrdinal("children")).Split('×'),
					source = reader.GetString(reader.GetOrdinal("source")),
					sources = reader.GetString(reader.GetOrdinal("sources")).Split('×'),

					file_url = reader.GetString(reader.GetOrdinal("file_url")),
					width = reader.GetInt32(reader.GetOrdinal("width")),
					height = reader.GetInt32(reader.GetOrdinal("height")),
					file_ext = reader.GetString(reader.GetOrdinal("file_ext")),
					file_size = reader.GetInt32(reader.GetOrdinal("file_size")),

					sample_url = reader.GetString(reader.GetOrdinal("sample_url")),
					sample_width = reader.GetInt32(reader.GetOrdinal("sample_width")),
					sample_height = reader.GetInt32(reader.GetOrdinal("sample_height")),

					preview_url = reader.GetString(reader.GetOrdinal("preview_url")),
					preview_width = reader.GetInt32(reader.GetOrdinal("preview_width")),
					preview_height = reader.GetInt32(reader.GetOrdinal("preview_height")),

					downloaded = reader.GetString(reader.GetOrdinal("downloaded")),
				};
			}

			return det;
		}
	}
}
