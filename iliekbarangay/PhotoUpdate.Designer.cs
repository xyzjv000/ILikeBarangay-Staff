namespace iliekbarangay
{
    partial class PhotoUpdate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoUpdate));
            this.resImage = new System.Windows.Forms.PictureBox();
            this.name = new System.Windows.Forms.Label();
            this.gender = new System.Windows.Forms.Label();
            this.marital = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Panel();
            this.save = new Bunifu.Framework.UI.BunifuFlatButton();
            this.openCam = new Bunifu.Framework.UI.BunifuFlatButton();
            this.text = new System.Windows.Forms.Label();
            this.eskwelaPa = new System.Windows.Forms.Label();
            this.eskwelaLvl = new System.Windows.Forms.Label();
            this.eskwelaStat = new System.Windows.Forms.Label();
            this.healthproblem = new System.Windows.Forms.Label();
            this.healthstatus = new System.Windows.Forms.Label();
            this.skill = new System.Windows.Forms.Label();
            this.cnum = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.Label();
            this.dob = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.Label();
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.formName = new System.Windows.Forms.Label();
            this.clsBtn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.capture = new Bunifu.Framework.UI.BunifuFlatButton();
            this.id = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resImage)).BeginInit();
            this.header.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resImage
            // 
            this.resImage.BackColor = System.Drawing.Color.Transparent;
            this.resImage.BackgroundImage = global::iliekbarangay.Properties.Resources.profileImage_BackgroundImage;
            this.resImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.resImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resImage.Location = new System.Drawing.Point(115, 60);
            this.resImage.Name = "resImage";
            this.resImage.Size = new System.Drawing.Size(170, 154);
            this.resImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resImage.TabIndex = 0;
            this.resImage.TabStop = false;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(198, 65);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(0, 22);
            this.name.TabIndex = 12;
            // 
            // gender
            // 
            this.gender.AutoSize = true;
            this.gender.BackColor = System.Drawing.Color.Transparent;
            this.gender.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gender.Location = new System.Drawing.Point(198, 154);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(0, 20);
            this.gender.TabIndex = 14;
            // 
            // marital
            // 
            this.marital.AutoSize = true;
            this.marital.BackColor = System.Drawing.Color.Transparent;
            this.marital.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marital.Location = new System.Drawing.Point(337, 154);
            this.marital.Name = "marital";
            this.marital.Size = new System.Drawing.Size(0, 20);
            this.marital.TabIndex = 15;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.White;
            this.header.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("header.BackgroundImage")));
            this.header.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.header.Controls.Add(this.id);
            this.header.Controls.Add(this.save);
            this.header.Controls.Add(this.text);
            this.header.Controls.Add(this.eskwelaPa);
            this.header.Controls.Add(this.eskwelaLvl);
            this.header.Controls.Add(this.eskwelaStat);
            this.header.Controls.Add(this.healthproblem);
            this.header.Controls.Add(this.healthstatus);
            this.header.Controls.Add(this.skill);
            this.header.Controls.Add(this.cnum);
            this.header.Controls.Add(this.address);
            this.header.Controls.Add(this.dob);
            this.header.Controls.Add(this.marital);
            this.header.Controls.Add(this.gender);
            this.header.Controls.Add(this.age);
            this.header.Controls.Add(this.name);
            this.header.Controls.Add(this.resImage);
            this.header.Controls.Add(this.capture);
            this.header.Controls.Add(this.openCam);
            this.header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header.Location = new System.Drawing.Point(0, 43);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(401, 439);
            this.header.TabIndex = 6;
            // 
            // save
            // 
            this.save.Activecolor = System.Drawing.Color.Maroon;
            this.save.BackColor = System.Drawing.Color.Maroon;
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.save.BorderRadius = 5;
            this.save.ButtonText = "Save";
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.DisabledColor = System.Drawing.Color.Gray;
            this.save.Iconcolor = System.Drawing.Color.Transparent;
            this.save.Iconimage = ((System.Drawing.Image)(resources.GetObject("save.Iconimage")));
            this.save.Iconimage_right = null;
            this.save.Iconimage_right_Selected = null;
            this.save.Iconimage_Selected = null;
            this.save.IconMarginLeft = 0;
            this.save.IconMarginRight = 0;
            this.save.IconRightVisible = true;
            this.save.IconRightZoom = 0D;
            this.save.IconVisible = true;
            this.save.IconZoom = 60D;
            this.save.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.save.IsTab = false;
            this.save.Location = new System.Drawing.Point(98, 294);
            this.save.Name = "save";
            this.save.Normalcolor = System.Drawing.Color.Maroon;
            this.save.OnHovercolor = System.Drawing.Color.Firebrick;
            this.save.OnHoverTextColor = System.Drawing.Color.White;
            this.save.selected = false;
            this.save.Size = new System.Drawing.Size(205, 53);
            this.save.TabIndex = 29;
            this.save.Text = "Save";
            this.save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.save.Textcolor = System.Drawing.Color.White;
            this.save.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // openCam
            // 
            this.openCam.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.openCam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.openCam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openCam.BorderRadius = 5;
            this.openCam.ButtonText = "Open Camera";
            this.openCam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openCam.DisabledColor = System.Drawing.Color.Gray;
            this.openCam.Iconcolor = System.Drawing.Color.Transparent;
            this.openCam.Iconimage = ((System.Drawing.Image)(resources.GetObject("openCam.Iconimage")));
            this.openCam.Iconimage_right = null;
            this.openCam.Iconimage_right_Selected = null;
            this.openCam.Iconimage_Selected = null;
            this.openCam.IconMarginLeft = 0;
            this.openCam.IconMarginRight = 0;
            this.openCam.IconRightVisible = true;
            this.openCam.IconRightZoom = 0D;
            this.openCam.IconVisible = true;
            this.openCam.IconZoom = 50D;
            this.openCam.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.openCam.IsTab = false;
            this.openCam.Location = new System.Drawing.Point(98, 233);
            this.openCam.Name = "openCam";
            this.openCam.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.openCam.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.openCam.OnHoverTextColor = System.Drawing.Color.White;
            this.openCam.selected = false;
            this.openCam.Size = new System.Drawing.Size(205, 53);
            this.openCam.TabIndex = 28;
            this.openCam.Text = "Open Camera";
            this.openCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.openCam.Textcolor = System.Drawing.Color.White;
            this.openCam.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openCam.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // text
            // 
            this.text.BackColor = System.Drawing.Color.Transparent;
            this.text.Dock = System.Windows.Forms.DockStyle.Top;
            this.text.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text.ForeColor = System.Drawing.Color.Maroon;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(399, 43);
            this.text.TabIndex = 27;
            this.text.Text = "Photo Registration";
            this.text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eskwelaPa
            // 
            this.eskwelaPa.AutoSize = true;
            this.eskwelaPa.BackColor = System.Drawing.Color.Transparent;
            this.eskwelaPa.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eskwelaPa.Location = new System.Drawing.Point(25, 467);
            this.eskwelaPa.Name = "eskwelaPa";
            this.eskwelaPa.Size = new System.Drawing.Size(0, 20);
            this.eskwelaPa.TabIndex = 25;
            // 
            // eskwelaLvl
            // 
            this.eskwelaLvl.AutoSize = true;
            this.eskwelaLvl.BackColor = System.Drawing.Color.Transparent;
            this.eskwelaLvl.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eskwelaLvl.Location = new System.Drawing.Point(234, 467);
            this.eskwelaLvl.Name = "eskwelaLvl";
            this.eskwelaLvl.Size = new System.Drawing.Size(0, 20);
            this.eskwelaLvl.TabIndex = 24;
            // 
            // eskwelaStat
            // 
            this.eskwelaStat.AutoSize = true;
            this.eskwelaStat.BackColor = System.Drawing.Color.Transparent;
            this.eskwelaStat.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eskwelaStat.Location = new System.Drawing.Point(440, 467);
            this.eskwelaStat.Name = "eskwelaStat";
            this.eskwelaStat.Size = new System.Drawing.Size(0, 20);
            this.eskwelaStat.TabIndex = 22;
            // 
            // healthproblem
            // 
            this.healthproblem.AutoSize = true;
            this.healthproblem.BackColor = System.Drawing.Color.Transparent;
            this.healthproblem.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthproblem.Location = new System.Drawing.Point(25, 402);
            this.healthproblem.Name = "healthproblem";
            this.healthproblem.Size = new System.Drawing.Size(0, 17);
            this.healthproblem.TabIndex = 21;
            // 
            // healthstatus
            // 
            this.healthstatus.AutoSize = true;
            this.healthstatus.BackColor = System.Drawing.Color.Transparent;
            this.healthstatus.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthstatus.Location = new System.Drawing.Point(307, 318);
            this.healthstatus.Name = "healthstatus";
            this.healthstatus.Size = new System.Drawing.Size(0, 20);
            this.healthstatus.TabIndex = 20;
            // 
            // skill
            // 
            this.skill.AutoSize = true;
            this.skill.BackColor = System.Drawing.Color.Transparent;
            this.skill.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skill.Location = new System.Drawing.Point(24, 318);
            this.skill.Name = "skill";
            this.skill.Size = new System.Drawing.Size(0, 20);
            this.skill.TabIndex = 19;
            // 
            // cnum
            // 
            this.cnum.AutoSize = true;
            this.cnum.BackColor = System.Drawing.Color.Transparent;
            this.cnum.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnum.Location = new System.Drawing.Point(446, 243);
            this.cnum.Name = "cnum";
            this.cnum.Size = new System.Drawing.Size(0, 20);
            this.cnum.TabIndex = 18;
            // 
            // address
            // 
            this.address.AutoSize = true;
            this.address.BackColor = System.Drawing.Color.Transparent;
            this.address.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(24, 243);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(0, 20);
            this.address.TabIndex = 17;
            // 
            // dob
            // 
            this.dob.AutoSize = true;
            this.dob.BackColor = System.Drawing.Color.Transparent;
            this.dob.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dob.Location = new System.Drawing.Point(479, 154);
            this.dob.Name = "dob";
            this.dob.Size = new System.Drawing.Size(0, 20);
            this.dob.TabIndex = 16;
            // 
            // age
            // 
            this.age.AutoSize = true;
            this.age.BackColor = System.Drawing.Color.Transparent;
            this.age.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.age.Location = new System.Drawing.Point(512, 65);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(0, 22);
            this.age.TabIndex = 13;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.header;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.formName;
            this.bunifuDragControl1.Vertical = true;
            // 
            // formName
            // 
            this.formName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formName.ForeColor = System.Drawing.Color.White;
            this.formName.Location = new System.Drawing.Point(0, 0);
            this.formName.Name = "formName";
            this.formName.Size = new System.Drawing.Size(401, 43);
            this.formName.TabIndex = 0;
            this.formName.Text = "label1";
            this.formName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clsBtn
            // 
            this.clsBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.clsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.clsBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clsBtn.BackgroundImage")));
            this.clsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clsBtn.BorderRadius = 0;
            this.clsBtn.ButtonText = "";
            this.clsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clsBtn.DisabledColor = System.Drawing.Color.Gray;
            this.clsBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.clsBtn.Iconimage = null;
            this.clsBtn.Iconimage_right = null;
            this.clsBtn.Iconimage_right_Selected = null;
            this.clsBtn.Iconimage_Selected = null;
            this.clsBtn.IconMarginLeft = 0;
            this.clsBtn.IconMarginRight = 0;
            this.clsBtn.IconRightVisible = true;
            this.clsBtn.IconRightZoom = 0D;
            this.clsBtn.IconVisible = true;
            this.clsBtn.IconZoom = 90D;
            this.clsBtn.IsTab = false;
            this.clsBtn.Location = new System.Drawing.Point(353, 8);
            this.clsBtn.Name = "clsBtn";
            this.clsBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.clsBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.clsBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.clsBtn.selected = false;
            this.clsBtn.Size = new System.Drawing.Size(38, 28);
            this.clsBtn.TabIndex = 3;
            this.clsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clsBtn.Textcolor = System.Drawing.Color.White;
            this.clsBtn.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clsBtn.Click += new System.EventHandler(this.clsBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(119)))), ((int)(((byte)(186)))));
            this.panel1.Controls.Add(this.clsBtn);
            this.panel1.Controls.Add(this.formName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 43);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 482);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(401, 10);
            this.panel3.TabIndex = 5;
            // 
            // capture
            // 
            this.capture.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(119)))), ((int)(((byte)(186)))));
            this.capture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(119)))), ((int)(((byte)(186)))));
            this.capture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.capture.BorderRadius = 5;
            this.capture.ButtonText = "Capture Image";
            this.capture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.capture.DisabledColor = System.Drawing.Color.Gray;
            this.capture.Iconcolor = System.Drawing.Color.Transparent;
            this.capture.Iconimage = ((System.Drawing.Image)(resources.GetObject("capture.Iconimage")));
            this.capture.Iconimage_right = null;
            this.capture.Iconimage_right_Selected = null;
            this.capture.Iconimage_Selected = null;
            this.capture.IconMarginLeft = 0;
            this.capture.IconMarginRight = 0;
            this.capture.IconRightVisible = true;
            this.capture.IconRightZoom = 0D;
            this.capture.IconVisible = true;
            this.capture.IconZoom = 50D;
            this.capture.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.capture.IsTab = false;
            this.capture.Location = new System.Drawing.Point(98, 233);
            this.capture.Name = "capture";
            this.capture.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(119)))), ((int)(((byte)(186)))));
            this.capture.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(145)))), ((int)(((byte)(213)))));
            this.capture.OnHoverTextColor = System.Drawing.Color.White;
            this.capture.selected = false;
            this.capture.Size = new System.Drawing.Size(205, 53);
            this.capture.TabIndex = 30;
            this.capture.Text = "Capture Image";
            this.capture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.capture.Textcolor = System.Drawing.Color.White;
            this.capture.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capture.Visible = false;
            this.capture.Click += new System.EventHandler(this.capture_Click);
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(12, 281);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(15, 13);
            this.id.TabIndex = 31;
            this.id.Text = "id";
            this.id.Visible = false;
            // 
            // PhotoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 492);
            this.Controls.Add(this.header);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PhotoUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PhotoUpdate";
            ((System.ComponentModel.ISupportInitialize)(this.resImage)).EndInit();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox resImage;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label gender;
        private System.Windows.Forms.Label marital;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label eskwelaPa;
        private System.Windows.Forms.Label eskwelaLvl;
        private System.Windows.Forms.Label eskwelaStat;
        private System.Windows.Forms.Label healthproblem;
        private System.Windows.Forms.Label healthstatus;
        private System.Windows.Forms.Label skill;
        private System.Windows.Forms.Label cnum;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label dob;
        private System.Windows.Forms.Label age;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        public System.Windows.Forms.Label formName;
        private Bunifu.Framework.UI.BunifuFlatButton clsBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label text;
        private Bunifu.Framework.UI.BunifuFlatButton save;
        private Bunifu.Framework.UI.BunifuFlatButton openCam;
        private Bunifu.Framework.UI.BunifuFlatButton capture;
        private System.Windows.Forms.Label id;
    }
}