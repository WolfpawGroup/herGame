using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace herGame
{
	public partial class f_Artists : Form
	{
		public c_SqlFunctions cs { get; set; }

		public f_Artists()
		{
			InitializeComponent();
		}

		private void btn_LoadFromDB_Click(object sender, EventArgs e)
		{
			var v = cs.GetDbContent("artists", new string[] { "id", "name", "other_names", "urls", "posts", "updated" }, "");
			var r = v.ExecuteReader();
			while (r.Read())
			{
				dgv_Artists.Rows.Add(new object[]{
					r.GetValue(0).ToString(),
					r.GetValue(1).ToString(),
					r.GetValue(2).ToString(),
					r.GetValue(3).ToString(),
					r.GetValue(4).ToString(),
					r.GetValue(5).ToString()
				});
			}
		}

		private void btn_UpdateArtists_Click(object sender, EventArgs e)
		{
			c_Downloader cd = new c_Downloader();
			foreach (var v in cd.getArtists())
			{
				cs.insertInto("artists", new string[][] {
					new string[]{ "id",             "false",    v.id.ToString()                     },
					new string[]{ "name",           "true",     v.name.ToString()                   },
					new string[]{ "other_names",    "true",     String.Join(", ", v.other_names)    },
					new string[]{ "urls",           "true",     String.Join(" ", v.urls)            },
					new string[]{ "updated",        "true",     v.updated.ToString()                }
				}, true, "id=" + v.id.ToString());
			}
		}
	}
}
