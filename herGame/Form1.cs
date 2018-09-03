using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace herGame
{
	public partial class Form1 : Form
	{
		public Timer			t_Settings =	new Timer() { Interval = 1 };
		public c_SqlFunctions	cs =			new c_SqlFunctions();
		public List<c_Image>	images =		new List<c_Image>();
		public bool				SettingsOpen =	false;
		public bool				DLC =			false;
		public int				limit =			100;
		public int				page =			0;
		public int				numOfPages =	0;

		public Form1()
		{
			InitializeComponent();
			t_Settings.Tick += T_Settings_Tick;
			Load += Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			fixPaginationLayout();
			c_Functions.initializeSQL(cs);
			loadArtists();
			btn_DLC.DropDown.Width = 100;
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		private void T_Settings_Tick(object sender, EventArgs e)
		{
			if (SettingsOpen)
			{
				if(p_Options.Height < 210)
				{
					if (p_Options.Height < 200)
					{
						p_Options.Height += 5;
					}
					else if (p_Options.Height < 206)
					{
						p_Options.Height += 2;
					}
					else
					{
						p_Options.Height++;
					}
				}
				else
				{
					t_Settings.Stop();
				}
			}
			else
			{
				if (p_Options.Height > 0)
				{
					if (p_Options.Height > 30)
					{
						p_Options.Height -= 20;
					}
					else if (p_Options.Height > 15)
					{
						p_Options.Height -= 10;
					}
					else if(p_Options.Height > 5)
					{
						p_Options.Height -= 3;
					}
					else
					{
						p_Options.Height--;
					}
				}
				else
				{
					t_Settings.Stop();
				}
			}
		}

		private void btn_Settings_Click(object sender, EventArgs e)
		{
			openCloseSettings();
		}

		public void openCloseSettings()
		{
			SettingsOpen = !SettingsOpen;
			if (SettingsOpen) { loadSettings(); }
			if (!t_Settings.Enabled) { t_Settings.Start(); }
		}

		public void loadSettings()
		{
			if(Properties.Settings.Default.s_NoOfImages > 0)
			{
				rb_RandomImages.Checked = true;
				num_RandomImages.Value = Properties.Settings.Default.s_NoOfImages;
			}
			else
			{
				rb_AllImages.Checked = true;
			}
		}

		public void saveSettings()
		{
			Properties.Settings.Default.s_NoOfImages = (rb_AllImages.Checked ? -1 : (num_RandomImages.Value > 0 ? (int)num_RandomImages.Value : 3));
			Properties.Settings.Default.Save();
		}

		private void btn_Options_Save_Click(object sender, EventArgs e)
		{
			saveSettings();
			openCloseSettings();
		}

		private void btn_Options_Cancel_Click(object sender, EventArgs e)
		{
			openCloseSettings();
		}

		private void btn_Options_SetupOutput_Click(object sender, EventArgs e)
		{

		}

		private void btn_Options_SetupDownload_Click(object sender, EventArgs e)
		{

		}

		private void rb_AllImages_CheckedChanged(object sender, EventArgs e)
		{
			if(rb_AllImages.Checked)
			{
				label2.Enabled = false;
				num_RandomImages.Enabled = false;
			}
			else
			{
				label2.Enabled = true;
				num_RandomImages.Enabled = true;
				num_RandomImages.Focus();
				num_RandomImages.Select();
			}
		}

		private void toolStrip2_SizeChanged(object sender, EventArgs e)
		{
			fixPaginationLayout();
		}

		public void fixPaginationLayout()
		{
			int w = btn_Pages_Previous.Width + btn_Pages_Next.Width + btn_Pages_Goto.Width + lbl_Pages_Goto.Width + lbl_Pages_OfNumber.Width + tb_Pages_Number.Width + sep_Pages_Sep1.Width + sep_Pages_Sep2.Width;
			int remw = toolStrip2.Width - w - 20;
			int qrw = remw / 4;
			sep_Pages_Sep1.Margin = new Padding(qrw, 0, qrw, 0);
			sep_Pages_Sep2.Margin = new Padding(qrw, 0, qrw, 0);
		}

		public void loadArtists()
		{
			var lst = cs.select("artists", "name", ';', "");
			var vst = lst.Select(x => x[0][0]);
			tb_ArtistName.Items.AddRange(vst.ToArray());
		}

		private void btn_Artists_Click(object sender, EventArgs e)
		{
			new f_Artists
			{
				cs = cs
			}.ShowDialog();
			
		}
		
		private void tb_ArtistName_TextUpdate(object sender, EventArgs e)
		{
			if (tb_ArtistName.Items.OfType<string>().Select(x => x.ToLower()).Contains(tb_ArtistName.Text.ToLower()))
			{
				tb_ArtistName.Text = tb_ArtistName.Items.OfType<string>().Where(x => x.ToLower() == tb_ArtistName.Text.ToLower()).First();
				int cnt = getArtistCount(tb_ArtistName.Text);
				if(cnt > -1) { lbl_numOfWorks.Text = cnt + ""; }
			}
		}

		public int getArtistCount(string name)
		{
			int ret = -1;

			ret = cs.checkCountInTags(name);

			if(ret == -1)
			{
				ret = c_Downloader.getArtistPosts(cs, name);
			}

			if (ret != -1)
			{
				cs.runNonQuery(string.Format("UPDATE artists SET posts={0} WHERE name='{1}'", ret, name));
			}

			return ret;
		}

		private void btn_DLC_DropDownOpening(object sender, EventArgs e)
		{
		}

		private void btn_DLC_TagsMode_Click(object sender, EventArgs e)
		{
			tb_ArtistName.Visible = false;
			tb_Tags.Visible = true;
			lbl_ArtistName.Text = "Tags: ";
			lbl_numOfWorks.Text = "";
			lbl_numOfWorks.Padding = new Padding(0, 0, 13, 0);
			DLC = true;
		}

		private void btn_DLC_ArtistMode_Click(object sender, EventArgs e)
		{
			tb_ArtistName.Visible = true;
			tb_Tags.Visible = false;
			lbl_ArtistName.Text = "Artist Name: ";
			lbl_numOfWorks.Text = "0";
			lbl_numOfWorks.Padding = new Padding(0, 0, 0, 0);
			DLC = false;
		}

		private void btn_FindWorks_Click(object sender, EventArgs e)
		{
			string tags = DLC ? tb_Tags.Text : tb_ArtistName.Text;
			c_ImageDataHandler cid = new c_ImageDataHandler(cs);
			images = cid.donloadImageData(tags);

			numOfPages = (images.Count / limit) + (images.Count % limit == 0 ? 0 : 1);

			loadImagesIntoListView();
			
		}

		public void loadImagesIntoListView()
		{
			lbl_Pages_OfNumber.Text =	numOfPages.ToString();
			tb_Pages_Number.Text =		(page + 1).ToString().PadLeft(numOfPages.ToString().Length, '0');

			limit = limit > images.Count ? images.Count : limit;
			var arr = new c_Image[limit];
			images.CopyTo((limit * page), arr, 0, limit);
			int i = 0;
			foreach (var v in arr)
			{
				Image img = new Bitmap(1, 1);
				ListViewItem lvi = new ListViewItem
				{
					Text = ++i + ""
				};
				lvi.SubItems.AddRange(new ListViewItem.ListViewSubItem[] {
					
					new ListViewItem.ListViewSubItem(){ Text = v.md5 },
					new ListViewItem.ListViewSubItem(){ Text = v.imageSize.Width + " x " + v.imageSize.Height },
					new ListViewItem.ListViewSubItem(){ Text = v.details.score + "" },
					new ListViewItem.ListViewSubItem(){ Text = v.shared ? "" : "" }
				});

				lvi.Tag = new object[] { v, img };

				lv_Images.Items.Add(lvi);
			}
		}

		private void btn_ImageListDelete_Click(object sender, EventArgs e)
		{
			

		}

		private void lv_Images_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(lv_Images.FocusedItem != null)
			{
				//TODO:: Check if preview image exists in db else download and save it before showing it
			}
		}
	}
}
