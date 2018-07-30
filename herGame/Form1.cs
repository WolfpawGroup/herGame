using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace herGame
{
	public partial class Form1 : Form
	{
		public bool SettingsOpen = false;
		Timer t_Settings = new Timer() { Interval = 1 };

		public Form1()
		{
			InitializeComponent();
			t_Settings.Tick += T_Settings_Tick;
			Load += Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			fixPaginationLayout();
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

		private void btn_FindWorks_Click(object sender, EventArgs e)
		{
			//TODO: Changed for testing!

			c_SqlFunctions cs = new c_SqlFunctions();
			c_Functions.initializeSQL(cs);
			/*
			cs.createDbFile();
			cs.sqlc = cs.connectToDB();

			SQLiteColumn c1 = new SQLiteColumn()
			{
				columnName = "id",
				dataType = SQLiteDataType.INTEGER,
				pimaryKey = true,
				foreignKey = false
			};

			SQLiteColumn c2 = new SQLiteColumn()
			{
				columnName = "name",
				dataType = SQLiteDataType.TEXT,
				pimaryKey = false,
				foreignKey = true
			};

			SQLiteColumn c3 = new SQLiteColumn()
			{
				columnName = "dob",
				dataType = SQLiteDataType.TEXT,
				pimaryKey = false,
				foreignKey = false
			};

			SQLiteColumn[] cols = new SQLiteColumn[] { c1, c2, c3 };

			cs.createTable("test_table", cols);
			*/

		}
	}
}
