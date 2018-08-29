namespace herGame
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btn_DLC = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_DLC_ArtistMode = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_DLC_TagsMode = new System.Windows.Forms.ToolStripMenuItem();
			this.lbl_ArtistName = new System.Windows.Forms.ToolStripLabel();
			this.tb_ArtistName = new System.Windows.Forms.ToolStripComboBox();
			this.tb_Tags = new System.Windows.Forms.ToolStripComboBox();
			this.lbl_numOfWorks = new System.Windows.Forms.ToolStripLabel();
			this.btn_FindWorks = new System.Windows.Forms.ToolStripButton();
			this.btn_Settings = new System.Windows.Forms.ToolStripButton();
			this.sep_02 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_Logs = new System.Windows.Forms.ToolStripButton();
			this.btn_Images = new System.Windows.Forms.ToolStripButton();
			this.btn_Tags = new System.Windows.Forms.ToolStripButton();
			this.btn_Artists = new System.Windows.Forms.ToolStripButton();
			this.sep_01 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_PlayMates = new System.Windows.Forms.ToolStripDropDownButton();
			this.cb_PlayMates = new System.Windows.Forms.ToolStripComboBox();
			this.btn_AddPlaymate = new System.Windows.Forms.ToolStripMenuItem();
			this.p_Options = new System.Windows.Forms.Panel();
			this.btn_Options_SetupDownload = new System.Windows.Forms.Button();
			this.btn_Options_Cancel = new System.Windows.Forms.Button();
			this.btn_Options_Save = new System.Windows.Forms.Button();
			this.btn_Options_SetupOutput = new System.Windows.Forms.Button();
			this.num_RandomImages = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.rb_RandomImages = new System.Windows.Forms.RadioButton();
			this.rb_AllImages = new System.Windows.Forms.RadioButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lv_Images = new System.Windows.Forms.ListView();
			this.ch_ImageListIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.c_ImageListMd5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_ImageListSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_ImageListScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ch_ImageListShared = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.statusStrip2 = new System.Windows.Forms.StatusStrip();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.btn_Pages_Previous = new System.Windows.Forms.ToolStripButton();
			this.sep_Pages_Sep1 = new System.Windows.Forms.ToolStripSeparator();
			this.lbl_Pages_Goto = new System.Windows.Forms.ToolStripLabel();
			this.tb_Pages_Number = new System.Windows.Forms.ToolStripTextBox();
			this.lbl_Pages_OfNumber = new System.Windows.Forms.ToolStripLabel();
			this.btn_Pages_Goto = new System.Windows.Forms.ToolStripButton();
			this.sep_Pages_Sep2 = new System.Windows.Forms.ToolStripSeparator();
			this.btn_Pages_Next = new System.Windows.Forms.ToolStripButton();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tp_List = new System.Windows.Forms.TabPage();
			this.lv_ImageList = new System.Windows.Forms.ListView();
			this.ch_ImgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_ImageListDelete = new System.Windows.Forms.Button();
			this.tp_Output = new System.Windows.Forms.TabPage();
			this.pb_PreviewImage = new System.Windows.Forms.PictureBox();
			this.toolStrip1.SuspendLayout();
			this.p_Options.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_RandomImages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tp_List.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pb_PreviewImage)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(971, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_DLC,
            this.lbl_ArtistName,
            this.tb_ArtistName,
            this.tb_Tags,
            this.lbl_numOfWorks,
            this.btn_FindWorks,
            this.btn_Settings,
            this.sep_02,
            this.btn_Logs,
            this.btn_Images,
            this.btn_Tags,
            this.btn_Artists,
            this.sep_01,
            this.btn_PlayMates});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip1.Size = new System.Drawing.Size(971, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btn_DLC
			// 
			this.btn_DLC.AutoSize = false;
			this.btn_DLC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_DLC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_DLC_ArtistMode,
            this.btn_DLC_TagsMode});
			this.btn_DLC.Image = ((System.Drawing.Image)(resources.GetObject("btn_DLC.Image")));
			this.btn_DLC.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_DLC.Name = "btn_DLC";
			this.btn_DLC.Size = new System.Drawing.Size(42, 22);
			this.btn_DLC.Text = "DLC";
			this.btn_DLC.DropDownOpening += new System.EventHandler(this.btn_DLC_DropDownOpening);
			// 
			// btn_DLC_ArtistMode
			// 
			this.btn_DLC_ArtistMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_DLC_ArtistMode.Name = "btn_DLC_ArtistMode";
			this.btn_DLC_ArtistMode.Size = new System.Drawing.Size(136, 22);
			this.btn_DLC_ArtistMode.Text = "Artist Mode";
			this.btn_DLC_ArtistMode.Click += new System.EventHandler(this.btn_DLC_ArtistMode_Click);
			// 
			// btn_DLC_TagsMode
			// 
			this.btn_DLC_TagsMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_DLC_TagsMode.Name = "btn_DLC_TagsMode";
			this.btn_DLC_TagsMode.Size = new System.Drawing.Size(136, 22);
			this.btn_DLC_TagsMode.Text = "Tags Mode";
			this.btn_DLC_TagsMode.Click += new System.EventHandler(this.btn_DLC_TagsMode_Click);
			// 
			// lbl_ArtistName
			// 
			this.lbl_ArtistName.AutoSize = false;
			this.lbl_ArtistName.Margin = new System.Windows.Forms.Padding(0);
			this.lbl_ArtistName.Name = "lbl_ArtistName";
			this.lbl_ArtistName.Size = new System.Drawing.Size(80, 22);
			this.lbl_ArtistName.Text = "Artist Name: ";
			this.lbl_ArtistName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tb_ArtistName
			// 
			this.tb_ArtistName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.tb_ArtistName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.tb_ArtistName.DropDownWidth = 140;
			this.tb_ArtistName.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
			this.tb_ArtistName.Name = "tb_ArtistName";
			this.tb_ArtistName.Size = new System.Drawing.Size(200, 25);
			this.tb_ArtistName.SelectedIndexChanged += new System.EventHandler(this.tb_ArtistName_TextUpdate);
			// 
			// tb_Tags
			// 
			this.tb_Tags.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.tb_Tags.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.tb_Tags.DropDownWidth = 140;
			this.tb_Tags.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
			this.tb_Tags.Name = "tb_Tags";
			this.tb_Tags.Size = new System.Drawing.Size(200, 25);
			this.tb_Tags.Visible = false;
			// 
			// lbl_numOfWorks
			// 
			this.lbl_numOfWorks.Name = "lbl_numOfWorks";
			this.lbl_numOfWorks.Size = new System.Drawing.Size(13, 22);
			this.lbl_numOfWorks.Text = "0";
			// 
			// btn_FindWorks
			// 
			this.btn_FindWorks.BackColor = System.Drawing.Color.Gainsboro;
			this.btn_FindWorks.Image = ((System.Drawing.Image)(resources.GetObject("btn_FindWorks.Image")));
			this.btn_FindWorks.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_FindWorks.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
			this.btn_FindWorks.Name = "btn_FindWorks";
			this.btn_FindWorks.Size = new System.Drawing.Size(74, 22);
			this.btn_FindWorks.Text = "Find Pics";
			this.btn_FindWorks.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btn_FindWorks.Click += new System.EventHandler(this.btn_FindWorks_Click);
			// 
			// btn_Settings
			// 
			this.btn_Settings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Settings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_Settings.Image = ((System.Drawing.Image)(resources.GetObject("btn_Settings.Image")));
			this.btn_Settings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Settings.Name = "btn_Settings";
			this.btn_Settings.Size = new System.Drawing.Size(23, 22);
			this.btn_Settings.Text = "Settings";
			this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
			// 
			// sep_02
			// 
			this.sep_02.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.sep_02.Name = "sep_02";
			this.sep_02.Size = new System.Drawing.Size(6, 25);
			// 
			// btn_Logs
			// 
			this.btn_Logs.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Logs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_Logs.Image = ((System.Drawing.Image)(resources.GetObject("btn_Logs.Image")));
			this.btn_Logs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Logs.Name = "btn_Logs";
			this.btn_Logs.Size = new System.Drawing.Size(23, 22);
			this.btn_Logs.ToolTipText = "Logs";
			// 
			// btn_Images
			// 
			this.btn_Images.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Images.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_Images.Image = ((System.Drawing.Image)(resources.GetObject("btn_Images.Image")));
			this.btn_Images.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Images.Name = "btn_Images";
			this.btn_Images.Size = new System.Drawing.Size(23, 22);
			this.btn_Images.ToolTipText = "Images";
			// 
			// btn_Tags
			// 
			this.btn_Tags.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Tags.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_Tags.Image = ((System.Drawing.Image)(resources.GetObject("btn_Tags.Image")));
			this.btn_Tags.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Tags.Name = "btn_Tags";
			this.btn_Tags.Size = new System.Drawing.Size(23, 22);
			this.btn_Tags.ToolTipText = "Tags";
			// 
			// btn_Artists
			// 
			this.btn_Artists.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_Artists.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_Artists.Image = ((System.Drawing.Image)(resources.GetObject("btn_Artists.Image")));
			this.btn_Artists.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Artists.Name = "btn_Artists";
			this.btn_Artists.Size = new System.Drawing.Size(23, 22);
			this.btn_Artists.ToolTipText = "Artists";
			this.btn_Artists.Click += new System.EventHandler(this.btn_Artists_Click);
			// 
			// sep_01
			// 
			this.sep_01.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.sep_01.Name = "sep_01";
			this.sep_01.Size = new System.Drawing.Size(6, 25);
			// 
			// btn_PlayMates
			// 
			this.btn_PlayMates.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btn_PlayMates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_PlayMates.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cb_PlayMates,
            this.btn_AddPlaymate});
			this.btn_PlayMates.Image = ((System.Drawing.Image)(resources.GetObject("btn_PlayMates.Image")));
			this.btn_PlayMates.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_PlayMates.Name = "btn_PlayMates";
			this.btn_PlayMates.Size = new System.Drawing.Size(124, 22);
			this.btn_PlayMates.Text = "--- No Playmate ---";
			// 
			// cb_PlayMates
			// 
			this.cb_PlayMates.Name = "cb_PlayMates";
			this.cb_PlayMates.Size = new System.Drawing.Size(121, 23);
			// 
			// btn_AddPlaymate
			// 
			this.btn_AddPlaymate.Name = "btn_AddPlaymate";
			this.btn_AddPlaymate.Size = new System.Drawing.Size(181, 22);
			this.btn_AddPlaymate.Text = "Add Playmate";
			// 
			// p_Options
			// 
			this.p_Options.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.p_Options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.p_Options.Controls.Add(this.btn_Options_SetupDownload);
			this.p_Options.Controls.Add(this.btn_Options_Cancel);
			this.p_Options.Controls.Add(this.btn_Options_Save);
			this.p_Options.Controls.Add(this.btn_Options_SetupOutput);
			this.p_Options.Controls.Add(this.num_RandomImages);
			this.p_Options.Controls.Add(this.label2);
			this.p_Options.Controls.Add(this.label1);
			this.p_Options.Controls.Add(this.rb_RandomImages);
			this.p_Options.Controls.Add(this.rb_AllImages);
			this.p_Options.Location = new System.Drawing.Point(731, 25);
			this.p_Options.Name = "p_Options";
			this.p_Options.Size = new System.Drawing.Size(240, 0);
			this.p_Options.TabIndex = 2;
			// 
			// btn_Options_SetupDownload
			// 
			this.btn_Options_SetupDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Options_SetupDownload.Location = new System.Drawing.Point(7, -73);
			this.btn_Options_SetupDownload.Name = "btn_Options_SetupDownload";
			this.btn_Options_SetupDownload.Size = new System.Drawing.Size(97, 23);
			this.btn_Options_SetupDownload.TabIndex = 8;
			this.btn_Options_SetupDownload.Text = "Setup Download";
			this.btn_Options_SetupDownload.UseVisualStyleBackColor = true;
			this.btn_Options_SetupDownload.Click += new System.EventHandler(this.btn_Options_SetupDownload_Click);
			// 
			// btn_Options_Cancel
			// 
			this.btn_Options_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Options_Cancel.Location = new System.Drawing.Point(154, -26);
			this.btn_Options_Cancel.Name = "btn_Options_Cancel";
			this.btn_Options_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Options_Cancel.TabIndex = 7;
			this.btn_Options_Cancel.Text = "Cancel";
			this.btn_Options_Cancel.UseVisualStyleBackColor = true;
			this.btn_Options_Cancel.Click += new System.EventHandler(this.btn_Options_Cancel_Click);
			// 
			// btn_Options_Save
			// 
			this.btn_Options_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Options_Save.Location = new System.Drawing.Point(7, -26);
			this.btn_Options_Save.Name = "btn_Options_Save";
			this.btn_Options_Save.Size = new System.Drawing.Size(75, 23);
			this.btn_Options_Save.TabIndex = 6;
			this.btn_Options_Save.Text = "Save";
			this.btn_Options_Save.UseVisualStyleBackColor = true;
			this.btn_Options_Save.Click += new System.EventHandler(this.btn_Options_Save_Click);
			// 
			// btn_Options_SetupOutput
			// 
			this.btn_Options_SetupOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Options_SetupOutput.Location = new System.Drawing.Point(7, -102);
			this.btn_Options_SetupOutput.Name = "btn_Options_SetupOutput";
			this.btn_Options_SetupOutput.Size = new System.Drawing.Size(97, 23);
			this.btn_Options_SetupOutput.TabIndex = 5;
			this.btn_Options_SetupOutput.Text = "Setup Output";
			this.btn_Options_SetupOutput.UseVisualStyleBackColor = true;
			this.btn_Options_SetupOutput.Click += new System.EventHandler(this.btn_Options_SetupOutput_Click);
			// 
			// num_RandomImages
			// 
			this.num_RandomImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.num_RandomImages.Location = new System.Drawing.Point(141, -134);
			this.num_RandomImages.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.num_RandomImages.Name = "num_RandomImages";
			this.num_RandomImages.Size = new System.Drawing.Size(40, 20);
			this.num_RandomImages.TabIndex = 4;
			this.num_RandomImages.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(49, -132);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "# of images to get";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(80, -206);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "Options";
			// 
			// rb_RandomImages
			// 
			this.rb_RandomImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rb_RandomImages.AutoSize = true;
			this.rb_RandomImages.Location = new System.Drawing.Point(7, -155);
			this.rb_RandomImages.Name = "rb_RandomImages";
			this.rb_RandomImages.Size = new System.Drawing.Size(164, 17);
			this.rb_RandomImages.TabIndex = 1;
			this.rb_RandomImages.Text = "Get random images from artist";
			this.rb_RandomImages.UseVisualStyleBackColor = true;
			// 
			// rb_AllImages
			// 
			this.rb_AllImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rb_AllImages.AutoSize = true;
			this.rb_AllImages.Checked = true;
			this.rb_AllImages.Location = new System.Drawing.Point(7, -178);
			this.rb_AllImages.Name = "rb_AllImages";
			this.rb_AllImages.Size = new System.Drawing.Size(139, 17);
			this.rb_AllImages.TabIndex = 0;
			this.rb_AllImages.TabStop = true;
			this.rb_AllImages.Text = "Get all images from artist";
			this.rb_AllImages.UseVisualStyleBackColor = true;
			this.rb_AllImages.CheckedChanged += new System.EventHandler(this.rb_AllImages_CheckedChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lv_Images);
			this.splitContainer1.Panel1.Controls.Add(this.statusStrip2);
			this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(971, 403);
			this.splitContainer1.SplitterDistance = 475;
			this.splitContainer1.TabIndex = 3;
			// 
			// lv_Images
			// 
			this.lv_Images.CheckBoxes = true;
			this.lv_Images.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_ImageListIndex,
            this.c_ImageListMd5,
            this.ch_ImageListSize,
            this.ch_ImageListScore,
            this.ch_ImageListShared});
			this.lv_Images.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lv_Images.FullRowSelect = true;
			this.lv_Images.GridLines = true;
			this.lv_Images.Location = new System.Drawing.Point(0, 25);
			this.lv_Images.Name = "lv_Images";
			this.lv_Images.Size = new System.Drawing.Size(475, 356);
			this.lv_Images.TabIndex = 2;
			this.lv_Images.UseCompatibleStateImageBehavior = false;
			this.lv_Images.View = System.Windows.Forms.View.Details;
			this.lv_Images.SelectedIndexChanged += new System.EventHandler(this.lv_Images_SelectedIndexChanged);
			// 
			// ch_ImageListIndex
			// 
			this.ch_ImageListIndex.Text = "#";
			this.ch_ImageListIndex.Width = 46;
			// 
			// c_ImageListMd5
			// 
			this.c_ImageListMd5.Text = "MD5";
			this.c_ImageListMd5.Width = 175;
			// 
			// ch_ImageListSize
			// 
			this.ch_ImageListSize.Text = "Size";
			this.ch_ImageListSize.Width = 72;
			// 
			// ch_ImageListScore
			// 
			this.ch_ImageListScore.Text = "Score";
			this.ch_ImageListScore.Width = 45;
			// 
			// ch_ImageListShared
			// 
			this.ch_ImageListShared.Text = "Shared";
			this.ch_ImageListShared.Width = 46;
			// 
			// statusStrip2
			// 
			this.statusStrip2.Location = new System.Drawing.Point(0, 381);
			this.statusStrip2.Name = "statusStrip2";
			this.statusStrip2.Size = new System.Drawing.Size(475, 22);
			this.statusStrip2.TabIndex = 1;
			this.statusStrip2.Text = "statusStrip2";
			// 
			// toolStrip2
			// 
			this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Pages_Previous,
            this.sep_Pages_Sep1,
            this.lbl_Pages_Goto,
            this.tb_Pages_Number,
            this.lbl_Pages_OfNumber,
            this.btn_Pages_Goto,
            this.sep_Pages_Sep2,
            this.btn_Pages_Next});
			this.toolStrip2.Location = new System.Drawing.Point(0, 0);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip2.Size = new System.Drawing.Size(475, 25);
			this.toolStrip2.TabIndex = 0;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStrip2.SizeChanged += new System.EventHandler(this.toolStrip2_SizeChanged);
			// 
			// btn_Pages_Previous
			// 
			this.btn_Pages_Previous.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_Pages_Previous.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pages_Previous.Image")));
			this.btn_Pages_Previous.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Pages_Previous.Name = "btn_Pages_Previous";
			this.btn_Pages_Previous.Size = new System.Drawing.Size(23, 22);
			this.btn_Pages_Previous.Text = "Previous";
			// 
			// sep_Pages_Sep1
			// 
			this.sep_Pages_Sep1.Name = "sep_Pages_Sep1";
			this.sep_Pages_Sep1.Size = new System.Drawing.Size(6, 25);
			// 
			// lbl_Pages_Goto
			// 
			this.lbl_Pages_Goto.Name = "lbl_Pages_Goto";
			this.lbl_Pages_Goto.Size = new System.Drawing.Size(36, 22);
			this.lbl_Pages_Goto.Text = "Go to";
			// 
			// tb_Pages_Number
			// 
			this.tb_Pages_Number.Name = "tb_Pages_Number";
			this.tb_Pages_Number.Size = new System.Drawing.Size(35, 25);
			// 
			// lbl_Pages_OfNumber
			// 
			this.lbl_Pages_OfNumber.Name = "lbl_Pages_OfNumber";
			this.lbl_Pages_OfNumber.Size = new System.Drawing.Size(30, 22);
			this.lbl_Pages_OfNumber.Text = " / 00";
			// 
			// btn_Pages_Goto
			// 
			this.btn_Pages_Goto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_Pages_Goto.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pages_Goto.Image")));
			this.btn_Pages_Goto.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Pages_Goto.Name = "btn_Pages_Goto";
			this.btn_Pages_Goto.Size = new System.Drawing.Size(23, 22);
			this.btn_Pages_Goto.Text = "toolStripButton2";
			// 
			// sep_Pages_Sep2
			// 
			this.sep_Pages_Sep2.Name = "sep_Pages_Sep2";
			this.sep_Pages_Sep2.Size = new System.Drawing.Size(6, 25);
			// 
			// btn_Pages_Next
			// 
			this.btn_Pages_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btn_Pages_Next.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pages_Next.Image")));
			this.btn_Pages_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_Pages_Next.Name = "btn_Pages_Next";
			this.btn_Pages_Next.Size = new System.Drawing.Size(23, 22);
			this.btn_Pages_Next.Text = "Next";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.pb_PreviewImage);
			this.splitContainer2.Size = new System.Drawing.Size(492, 403);
			this.splitContainer2.SplitterDistance = 173;
			this.splitContainer2.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tp_List);
			this.tabControl1.Controls.Add(this.tp_Output);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(492, 173);
			this.tabControl1.TabIndex = 0;
			// 
			// tp_List
			// 
			this.tp_List.Controls.Add(this.lv_ImageList);
			this.tp_List.Controls.Add(this.btn_ImageListDelete);
			this.tp_List.Location = new System.Drawing.Point(4, 22);
			this.tp_List.Name = "tp_List";
			this.tp_List.Padding = new System.Windows.Forms.Padding(3);
			this.tp_List.Size = new System.Drawing.Size(484, 147);
			this.tp_List.TabIndex = 0;
			this.tp_List.Text = "List of Images";
			this.tp_List.UseVisualStyleBackColor = true;
			// 
			// lv_ImageList
			// 
			this.lv_ImageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_ImgName});
			this.lv_ImageList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lv_ImageList.FullRowSelect = true;
			this.lv_ImageList.GridLines = true;
			this.lv_ImageList.Location = new System.Drawing.Point(3, 3);
			this.lv_ImageList.Name = "lv_ImageList";
			this.lv_ImageList.Size = new System.Drawing.Size(431, 141);
			this.lv_ImageList.TabIndex = 1;
			this.lv_ImageList.UseCompatibleStateImageBehavior = false;
			this.lv_ImageList.View = System.Windows.Forms.View.Details;
			// 
			// ch_ImgName
			// 
			this.ch_ImgName.Text = "Image Name";
			this.ch_ImgName.Width = 338;
			// 
			// btn_ImageListDelete
			// 
			this.btn_ImageListDelete.Dock = System.Windows.Forms.DockStyle.Right;
			this.btn_ImageListDelete.Location = new System.Drawing.Point(434, 3);
			this.btn_ImageListDelete.Name = "btn_ImageListDelete";
			this.btn_ImageListDelete.Size = new System.Drawing.Size(47, 141);
			this.btn_ImageListDelete.TabIndex = 0;
			this.btn_ImageListDelete.Text = "Delete";
			this.btn_ImageListDelete.UseVisualStyleBackColor = true;
			this.btn_ImageListDelete.Click += new System.EventHandler(this.btn_ImageListDelete_Click);
			// 
			// tp_Output
			// 
			this.tp_Output.Location = new System.Drawing.Point(4, 22);
			this.tp_Output.Name = "tp_Output";
			this.tp_Output.Padding = new System.Windows.Forms.Padding(3);
			this.tp_Output.Size = new System.Drawing.Size(484, 147);
			this.tp_Output.TabIndex = 1;
			this.tp_Output.Text = "Output";
			this.tp_Output.UseVisualStyleBackColor = true;
			// 
			// pb_PreviewImage
			// 
			this.pb_PreviewImage.BackColor = System.Drawing.Color.Black;
			this.pb_PreviewImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pb_PreviewImage.Location = new System.Drawing.Point(0, 0);
			this.pb_PreviewImage.Name = "pb_PreviewImage";
			this.pb_PreviewImage.Size = new System.Drawing.Size(492, 226);
			this.pb_PreviewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pb_PreviewImage.TabIndex = 0;
			this.pb_PreviewImage.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(971, 450);
			this.Controls.Add(this.p_Options);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.DoubleBuffered = true;
			this.Name = "Form1";
			this.Text = "Anya\'s Game";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.p_Options.ResumeLayout(false);
			this.p_Options.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_RandomImages)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tp_List.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pb_PreviewImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel lbl_ArtistName;
		private System.Windows.Forms.ToolStripComboBox tb_ArtistName;
		private System.Windows.Forms.ToolStripButton btn_FindWorks;
		private System.Windows.Forms.ToolStripButton btn_Settings;
		private System.Windows.Forms.Panel p_Options;
		private System.Windows.Forms.Button btn_Options_Cancel;
		private System.Windows.Forms.Button btn_Options_Save;
		private System.Windows.Forms.Button btn_Options_SetupOutput;
		private System.Windows.Forms.NumericUpDown num_RandomImages;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rb_RandomImages;
		private System.Windows.Forms.RadioButton rb_AllImages;
		private System.Windows.Forms.Button btn_Options_SetupDownload;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tp_List;
		private System.Windows.Forms.TabPage tp_Output;
		private System.Windows.Forms.PictureBox pb_PreviewImage;
		private System.Windows.Forms.ListView lv_ImageList;
		private System.Windows.Forms.Button btn_ImageListDelete;
		private System.Windows.Forms.ColumnHeader ch_ImgName;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton btn_Pages_Previous;
		private System.Windows.Forms.ToolStripSeparator sep_Pages_Sep1;
		private System.Windows.Forms.ToolStripLabel lbl_Pages_Goto;
		private System.Windows.Forms.ToolStripTextBox tb_Pages_Number;
		private System.Windows.Forms.ToolStripLabel lbl_Pages_OfNumber;
		private System.Windows.Forms.ToolStripButton btn_Pages_Goto;
		private System.Windows.Forms.ToolStripSeparator sep_Pages_Sep2;
		private System.Windows.Forms.ToolStripButton btn_Pages_Next;
		private System.Windows.Forms.ListView lv_Images;
		private System.Windows.Forms.ColumnHeader ch_ImageListIndex;
		private System.Windows.Forms.ColumnHeader c_ImageListMd5;
		private System.Windows.Forms.ColumnHeader ch_ImageListSize;
		private System.Windows.Forms.ColumnHeader ch_ImageListScore;
		private System.Windows.Forms.ColumnHeader ch_ImageListShared;
		private System.Windows.Forms.StatusStrip statusStrip2;
		private System.Windows.Forms.ToolStripSeparator sep_02;
		private System.Windows.Forms.ToolStripButton btn_Logs;
		private System.Windows.Forms.ToolStripButton btn_Images;
		private System.Windows.Forms.ToolStripButton btn_Tags;
		private System.Windows.Forms.ToolStripButton btn_Artists;
		private System.Windows.Forms.ToolStripSeparator sep_01;
		private System.Windows.Forms.ToolStripDropDownButton btn_PlayMates;
		private System.Windows.Forms.ToolStripComboBox cb_PlayMates;
		private System.Windows.Forms.ToolStripLabel lbl_numOfWorks;
		private System.Windows.Forms.ToolStripDropDownButton btn_DLC;
		private System.Windows.Forms.ToolStripMenuItem btn_DLC_ArtistMode;
		private System.Windows.Forms.ToolStripMenuItem btn_DLC_TagsMode;
		private System.Windows.Forms.ToolStripComboBox tb_Tags;
		private System.Windows.Forms.ToolStripMenuItem btn_AddPlaymate;
	}
}

