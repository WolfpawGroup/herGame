namespace herGame
{
	partial class f_Artists
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			herGame.attachment attachment1 = new herGame.attachment();
			this.dgv_Artists = new System.Windows.Forms.DataGridView();
			this.artist_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.artist_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.artist_otherNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.artist_urls = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.artist_posts = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.artist_updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btn_UpdateArtists = new System.Windows.Forms.Button();
			this.btn_LoadFromDB = new System.Windows.Forms.Button();
			this.btn_Close = new System.Windows.Forms.Button();
			this.btn_EmptyArtistsDB_Open = new System.Windows.Forms.Button();
			this.tb_PageNum = new System.Windows.Forms.TextBox();
			this.btn_GoToPage = new System.Windows.Forms.Button();
			this.lbl_0 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_Next = new System.Windows.Forms.Button();
			this.btn_Last = new System.Windows.Forms.Button();
			this.btn_Previous = new System.Windows.Forms.Button();
			this.btn_First = new System.Windows.Forms.Button();
			this.p_EmptyArtistsDB = new herGame.uc_OpenablePanel();
			this.btn_EmptyArtistsDB = new System.Windows.Forms.Button();
			this.cb_YesImSure = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dgv_Artists)).BeginInit();
			this.p_EmptyArtistsDB.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgv_Artists
			// 
			this.dgv_Artists.AllowUserToAddRows = false;
			this.dgv_Artists.AllowUserToDeleteRows = false;
			this.dgv_Artists.AllowUserToResizeRows = false;
			this.dgv_Artists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgv_Artists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv_Artists.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv_Artists.ColumnHeadersHeight = 25;
			this.dgv_Artists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgv_Artists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artist_id,
            this.artist_name,
            this.artist_otherNames,
            this.artist_urls,
            this.artist_posts,
            this.artist_updated});
			this.dgv_Artists.EnableHeadersVisualStyles = false;
			this.dgv_Artists.Location = new System.Drawing.Point(0, 0);
			this.dgv_Artists.Name = "dgv_Artists";
			this.dgv_Artists.ReadOnly = true;
			this.dgv_Artists.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgv_Artists.RowHeadersVisible = false;
			this.dgv_Artists.Size = new System.Drawing.Size(772, 498);
			this.dgv_Artists.TabIndex = 0;
			// 
			// artist_id
			// 
			this.artist_id.HeaderText = "ID";
			this.artist_id.Name = "artist_id";
			this.artist_id.ReadOnly = true;
			// 
			// artist_name
			// 
			this.artist_name.HeaderText = "Name";
			this.artist_name.Name = "artist_name";
			this.artist_name.ReadOnly = true;
			// 
			// artist_otherNames
			// 
			this.artist_otherNames.HeaderText = "Other Names";
			this.artist_otherNames.Name = "artist_otherNames";
			this.artist_otherNames.ReadOnly = true;
			// 
			// artist_urls
			// 
			this.artist_urls.HeaderText = "URL-s";
			this.artist_urls.Name = "artist_urls";
			this.artist_urls.ReadOnly = true;
			// 
			// artist_posts
			// 
			this.artist_posts.HeaderText = "Posts";
			this.artist_posts.Name = "artist_posts";
			this.artist_posts.ReadOnly = true;
			// 
			// artist_updated
			// 
			this.artist_updated.HeaderText = "Last Updated";
			this.artist_updated.Name = "artist_updated";
			this.artist_updated.ReadOnly = true;
			// 
			// btn_UpdateArtists
			// 
			this.btn_UpdateArtists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_UpdateArtists.Location = new System.Drawing.Point(766, 35);
			this.btn_UpdateArtists.Name = "btn_UpdateArtists";
			this.btn_UpdateArtists.Size = new System.Drawing.Size(129, 35);
			this.btn_UpdateArtists.TabIndex = 1;
			this.btn_UpdateArtists.Text = "Update Artists";
			this.btn_UpdateArtists.UseVisualStyleBackColor = true;
			this.btn_UpdateArtists.Click += new System.EventHandler(this.btn_UpdateArtists_Click);
			// 
			// btn_LoadFromDB
			// 
			this.btn_LoadFromDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_LoadFromDB.Location = new System.Drawing.Point(766, 68);
			this.btn_LoadFromDB.Name = "btn_LoadFromDB";
			this.btn_LoadFromDB.Size = new System.Drawing.Size(129, 35);
			this.btn_LoadFromDB.TabIndex = 2;
			this.btn_LoadFromDB.Text = "Load Artists from DB";
			this.btn_LoadFromDB.UseVisualStyleBackColor = true;
			this.btn_LoadFromDB.Click += new System.EventHandler(this.btn_LoadFromDB_Click);
			// 
			// btn_Close
			// 
			this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Close.Location = new System.Drawing.Point(766, 496);
			this.btn_Close.Name = "btn_Close";
			this.btn_Close.Size = new System.Drawing.Size(129, 35);
			this.btn_Close.TabIndex = 3;
			this.btn_Close.Text = "Close";
			this.btn_Close.UseVisualStyleBackColor = true;
			this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
			// 
			// btn_EmptyArtistsDB_Open
			// 
			this.btn_EmptyArtistsDB_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_EmptyArtistsDB_Open.Location = new System.Drawing.Point(766, 398);
			this.btn_EmptyArtistsDB_Open.Name = "btn_EmptyArtistsDB_Open";
			this.btn_EmptyArtistsDB_Open.Size = new System.Drawing.Size(129, 35);
			this.btn_EmptyArtistsDB_Open.TabIndex = 4;
			this.btn_EmptyArtistsDB_Open.Text = "Empty Artist Database";
			this.btn_EmptyArtistsDB_Open.UseVisualStyleBackColor = true;
			this.btn_EmptyArtistsDB_Open.Click += new System.EventHandler(this.btn_EmptyDB_Click);
			// 
			// tb_PageNum
			// 
			this.tb_PageNum.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.tb_PageNum.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tb_PageNum.Location = new System.Drawing.Point(369, 500);
			this.tb_PageNum.MaxLength = 3;
			this.tb_PageNum.Name = "tb_PageNum";
			this.tb_PageNum.Size = new System.Drawing.Size(34, 26);
			this.tb_PageNum.TabIndex = 9;
			this.tb_PageNum.Text = "0";
			this.tb_PageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btn_GoToPage
			// 
			this.btn_GoToPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btn_GoToPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_GoToPage.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_GoToPage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn_GoToPage.Location = new System.Drawing.Point(403, 500);
			this.btn_GoToPage.Margin = new System.Windows.Forms.Padding(0);
			this.btn_GoToPage.Name = "btn_GoToPage";
			this.btn_GoToPage.Size = new System.Drawing.Size(48, 26);
			this.btn_GoToPage.TabIndex = 10;
			this.btn_GoToPage.Text = "Go >";
			this.btn_GoToPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_GoToPage.UseVisualStyleBackColor = true;
			this.btn_GoToPage.Click += new System.EventHandler(this.btn_GoToPage_Click);
			// 
			// lbl_0
			// 
			this.lbl_0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_0.AutoSize = true;
			this.lbl_0.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_0.ForeColor = System.Drawing.Color.Gray;
			this.lbl_0.Location = new System.Drawing.Point(796, 18);
			this.lbl_0.Name = "lbl_0";
			this.lbl_0.Size = new System.Drawing.Size(68, 18);
			this.lbl_0.TabIndex = 11;
			this.lbl_0.Text = "Update";
			this.lbl_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Courier New", 12F);
			this.label2.ForeColor = System.Drawing.Color.Gray;
			this.label2.Location = new System.Drawing.Point(796, 381);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 18);
			this.label2.TabIndex = 12;
			this.label2.Text = "Delete";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gainsboro;
			this.panel1.Location = new System.Drawing.Point(771, 102);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(124, 67);
			this.panel1.TabIndex = 14;
			// 
			// btn_Next
			// 
			this.btn_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Next.Image = global::herGame.Properties.Resources.right;
			this.btn_Next.Location = new System.Drawing.Point(640, 497);
			this.btn_Next.Name = "btn_Next";
			this.btn_Next.Size = new System.Drawing.Size(50, 33);
			this.btn_Next.TabIndex = 8;
			this.btn_Next.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_Next.UseVisualStyleBackColor = true;
			this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
			// 
			// btn_Last
			// 
			this.btn_Last.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Last.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Last.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Last.Image = global::herGame.Properties.Resources.right_full;
			this.btn_Last.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn_Last.Location = new System.Drawing.Point(689, 497);
			this.btn_Last.Name = "btn_Last";
			this.btn_Last.Size = new System.Drawing.Size(83, 33);
			this.btn_Last.TabIndex = 7;
			this.btn_Last.Text = "Last";
			this.btn_Last.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_Last.UseVisualStyleBackColor = true;
			this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
			// 
			// btn_Previous
			// 
			this.btn_Previous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Previous.Image = global::herGame.Properties.Resources.left;
			this.btn_Previous.Location = new System.Drawing.Point(82, 497);
			this.btn_Previous.Name = "btn_Previous";
			this.btn_Previous.Size = new System.Drawing.Size(50, 33);
			this.btn_Previous.TabIndex = 6;
			this.btn_Previous.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn_Previous.UseVisualStyleBackColor = true;
			this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
			// 
			// btn_First
			// 
			this.btn_First.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_First.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_First.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_First.Image = global::herGame.Properties.Resources.left_full;
			this.btn_First.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_First.Location = new System.Drawing.Point(0, 497);
			this.btn_First.Name = "btn_First";
			this.btn_First.Size = new System.Drawing.Size(83, 33);
			this.btn_First.TabIndex = 5;
			this.btn_First.Text = "First";
			this.btn_First.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btn_First.UseVisualStyleBackColor = true;
			this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
			// 
			// p_EmptyArtistsDB
			// 
			this.p_EmptyArtistsDB.AttachedControl = this.btn_EmptyArtistsDB_Open;
			this.p_EmptyArtistsDB.BackColor = System.Drawing.Color.Gainsboro;
			attachment1.attachPoint = herGame.attachmentPoint.TopAttach;
			attachment1.slideMode = herGame.slideDirection.SlideUp_AnchorTop;
			this.p_EmptyArtistsDB.ControlAttachment = attachment1;
			this.p_EmptyArtistsDB.Controls.Add(this.btn_EmptyArtistsDB);
			this.p_EmptyArtistsDB.Controls.Add(this.cb_YesImSure);
			this.p_EmptyArtistsDB.Location = new System.Drawing.Point(771, 431);
			this.p_EmptyArtistsDB.Name = "p_EmptyArtistsDB";
			this.p_EmptyArtistsDB.OpenCloseInterval = 10;
			this.p_EmptyArtistsDB.PanelHeight = 50;
			this.p_EmptyArtistsDB.PanelWidth = 100;
			this.p_EmptyArtistsDB.Size = new System.Drawing.Size(124, 67);
			this.p_EmptyArtistsDB.StartClosed = false;
			this.p_EmptyArtistsDB.TabIndex = 13;
			// 
			// btn_EmptyArtistsDB
			// 
			this.btn_EmptyArtistsDB.Location = new System.Drawing.Point(7, 26);
			this.btn_EmptyArtistsDB.Name = "btn_EmptyArtistsDB";
			this.btn_EmptyArtistsDB.Size = new System.Drawing.Size(107, 31);
			this.btn_EmptyArtistsDB.TabIndex = 1;
			this.btn_EmptyArtistsDB.Text = "Empty Database!";
			this.btn_EmptyArtistsDB.UseVisualStyleBackColor = true;
			// 
			// cb_YesImSure
			// 
			this.cb_YesImSure.AutoSize = true;
			this.cb_YesImSure.Location = new System.Drawing.Point(7, 3);
			this.cb_YesImSure.Name = "cb_YesImSure";
			this.cb_YesImSure.Size = new System.Drawing.Size(91, 17);
			this.cb_YesImSure.TabIndex = 0;
			this.cb_YesImSure.Text = "Yes, I\'m Sure!";
			this.cb_YesImSure.UseVisualStyleBackColor = true;
			// 
			// f_Artists
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(891, 528);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbl_0);
			this.Controls.Add(this.btn_GoToPage);
			this.Controls.Add(this.tb_PageNum);
			this.Controls.Add(this.btn_Next);
			this.Controls.Add(this.btn_Last);
			this.Controls.Add(this.btn_Previous);
			this.Controls.Add(this.btn_First);
			this.Controls.Add(this.dgv_Artists);
			this.Controls.Add(this.btn_EmptyArtistsDB_Open);
			this.Controls.Add(this.btn_LoadFromDB);
			this.Controls.Add(this.btn_UpdateArtists);
			this.Controls.Add(this.btn_Close);
			this.Controls.Add(this.p_EmptyArtistsDB);
			this.Name = "f_Artists";
			this.Text = "Artists";
			((System.ComponentModel.ISupportInitialize)(this.dgv_Artists)).EndInit();
			this.p_EmptyArtistsDB.ResumeLayout(false);
			this.p_EmptyArtistsDB.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv_Artists;
		private System.Windows.Forms.Button btn_UpdateArtists;
		private System.Windows.Forms.Button btn_LoadFromDB;
		private System.Windows.Forms.Button btn_Close;
		private System.Windows.Forms.DataGridViewTextBoxColumn artist_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn artist_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn artist_otherNames;
		private System.Windows.Forms.DataGridViewTextBoxColumn artist_urls;
		private System.Windows.Forms.DataGridViewTextBoxColumn artist_posts;
		private System.Windows.Forms.DataGridViewTextBoxColumn artist_updated;
		private System.Windows.Forms.Button btn_EmptyArtistsDB_Open;
		private System.Windows.Forms.Button btn_First;
		private System.Windows.Forms.Button btn_Previous;
		private System.Windows.Forms.Button btn_Next;
		private System.Windows.Forms.Button btn_Last;
		private System.Windows.Forms.TextBox tb_PageNum;
		private System.Windows.Forms.Button btn_GoToPage;
		private System.Windows.Forms.Label lbl_0;
		private System.Windows.Forms.Label label2;
		private uc_OpenablePanel p_EmptyArtistsDB;
		private System.Windows.Forms.Button btn_EmptyArtistsDB;
		private System.Windows.Forms.CheckBox cb_YesImSure;
		private System.Windows.Forms.Panel panel1;
	}
}