using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace herGame
{
	public partial class f_Artists : Form
	{
		int page = 0;
		public c_SqlFunctions cs { get; set; }
		int countArtists = 0;
		int maxPage = 0;

		public f_Artists()
		{
			InitializeComponent();
			Load += F_Artists_Load;
		}

		private void F_Artists_Load(object sender, EventArgs e)
		{
			if(p_EmptyArtistsDB.AttachedControl != null) { Console.WriteLine(p_EmptyArtistsDB.AttachedControl.Text); }

			artist_id.ValueType = typeof(int);
			getArtistCount();
			getMaxPage();
			loadDataToTable(Properties.Settings.Default.s_MaxShowLines, 0);
			tb_PageNum.MouseWheel += Tb_PageNum_MouseWheel;
		}

		private void Tb_PageNum_MouseWheel(object sender, MouseEventArgs e)
		{
			int.TryParse(tb_PageNum.Text, out int i);

			if (e.Delta > 0)
			{
				i = i >= maxPage ? maxPage + 1 : i + 1;
			}
			else
			{
				i = i <= 1 ? 1 : i - 1;
			}
			tb_PageNum.Text = i + "";
			btn_GoToPage_Click(null, null);
		}

		public void getArtistCount()
		{
			var r = cs.runSelect("SELECT count(id) FROM artists");
			r.Read();
			countArtists = r.GetInt32(0);
		}

		public void getMaxPage()
		{
			maxPage = countArtists / Properties.Settings.Default.s_MaxShowLines + (countArtists % Properties.Settings.Default.s_MaxShowLines == 0 ? -1 : 0);
		}
		

		private void btn_LoadFromDB_Click(object sender, EventArgs e)
		{
			loadDataToTable(Properties.Settings.Default.s_MaxShowLines, 0);
		}

		public void loadDataToTable(int limit, int offset)
		{
			dgv_Artists.Rows.Clear();
			try
			{
				var v = cs.GetDbContent("artists", new string[] { "id", "name", "other_names", "urls", "posts", "updated" }, " 1=1\r\n\tlimit " + (offset * limit) + ", " + limit);
				var r = v.ExecuteReader();
				while (r.Read())
				{
					dgv_Artists.Rows.Add(new object[]{
					r.GetValue(0),
					r.GetValue(1).ToString(),
					r.GetValue(2).ToString(),
					r.GetValue(3).ToString(),
					r.GetValue(4),
					r.GetValue(5).ToString()
				});
				}

				btn_First.Enabled = btn_Previous.Enabled = page == 0 ? false : true;
				btn_Last.Enabled = btn_Next.Enabled = page == maxPage ? false : true;

			}
			catch { }
			
			tb_PageNum.Text = (page + 1) + "";
		}

		private void btn_UpdateArtists_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("This operation will attempt to download all artist data from E621\r\nSince there are more than 32000 artists on E621 this may take anywhere from 5 to 15 minutes depending on your internet speed.\r\n\r\nAre you sure you wish to continue?", "Are you sure?!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				c_Downloader cd = new c_Downloader();
				Stopwatch sw = new Stopwatch();
				sw.Start();
				int i = 0;
				bool run = false;
				List<c_Artist> artists = cd.getArtists(out long elapsedTime);
				foreach (var v in artists)
				{
					if (artists.Last().Equals(v)) { run = true; }
					cs.buildInsert("artists", new string[][] {
						new string[]{ "id",             "false",    v.id.ToString()						},
						new string[]{ "name",           "true",     v.name.ToString()					},
						new string[]{ "other_names",    "true",     String.Join("×", v.other_names)		},
						new string[]{ "urls",           "true",     String.Join("×", v.urls)			},
						new string[]{ "updated",        "true",     v.updated.ToString()				}
					}, run);
					i++;
				}
				
				sw.Stop();
				MessageBox.Show(string.Format("Update finished.\r\n\r\n{0} artists updated. \r\nDownload took {1}s. \r\nTotal time taken {2}s", i, elapsedTime / 1000, ((int)sw.ElapsedMilliseconds) / 1000), "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_EmptyDB_Click(object sender, EventArgs e)
		{
			//TODO:OpenPanel
		}

		private void btn_Next_Click(object sender, EventArgs e)
		{
			page++;
			loadDataToTable(Properties.Settings.Default.s_MaxShowLines, page);
		}

		private void btn_Previous_Click(object sender, EventArgs e)
		{
			page--;
			loadDataToTable(Properties.Settings.Default.s_MaxShowLines, page);
		}

		private void btn_First_Click(object sender, EventArgs e)
		{
			page = 0;
			loadDataToTable(Properties.Settings.Default.s_MaxShowLines, 0);
		}

		private void btn_Last_Click(object sender, EventArgs e)
		{
			page = maxPage;
			loadDataToTable(Properties.Settings.Default.s_MaxShowLines, page);

		}

		private void btn_GoToPage_Click(object sender, EventArgs e)
		{
			int i = page;
			int.TryParse(tb_PageNum.Text, out i);
			page = i-1;
			loadDataToTable(Properties.Settings.Default.s_MaxShowLines, page);
		}
	}
}
