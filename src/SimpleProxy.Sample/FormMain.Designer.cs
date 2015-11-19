namespace SimpleProxy.Example
{
    partial class FormMain
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
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpRestWebApi = new System.Windows.Forms.TabPage();
            this.btnRestWebApiDelete = new System.Windows.Forms.Button();
            this.btnRestWebApiEdit = new System.Windows.Forms.Button();
            this.btnRestWebApiAdd = new System.Windows.Forms.Button();
            this.lstRestWebApi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpRestWcf = new System.Windows.Forms.TabPage();
            this.btnRestWcfDelete = new System.Windows.Forms.Button();
            this.btnRestWcfEdit = new System.Windows.Forms.Button();
            this.btnRestWcfAdd = new System.Windows.Forms.Button();
            this.lstRestWcf = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpPageMethodsWebForms = new System.Windows.Forms.TabPage();
            this.btnPageMethodsWebFormsDelete = new System.Windows.Forms.Button();
            this.btnPageMethodsWebFormsEdit = new System.Windows.Forms.Button();
            this.btnPageMethodsWebFormsAdd = new System.Windows.Forms.Button();
            this.lstPageMethodsWebForms = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbcMain.SuspendLayout();
            this.tbpRestWebApi.SuspendLayout();
            this.tbpRestWcf.SuspendLayout();
            this.tbpPageMethodsWebForms.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMain.Controls.Add(this.tbpRestWebApi);
            this.tbcMain.Controls.Add(this.tbpRestWcf);
            this.tbcMain.Controls.Add(this.tbpPageMethodsWebForms);
            this.tbcMain.Location = new System.Drawing.Point(12, 12);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(548, 461);
            this.tbcMain.TabIndex = 0;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tbpRestWebApi
            // 
            this.tbpRestWebApi.Controls.Add(this.btnRestWebApiDelete);
            this.tbpRestWebApi.Controls.Add(this.btnRestWebApiEdit);
            this.tbpRestWebApi.Controls.Add(this.btnRestWebApiAdd);
            this.tbpRestWebApi.Controls.Add(this.lstRestWebApi);
            this.tbpRestWebApi.Location = new System.Drawing.Point(4, 22);
            this.tbpRestWebApi.Name = "tbpRestWebApi";
            this.tbpRestWebApi.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRestWebApi.Size = new System.Drawing.Size(540, 435);
            this.tbpRestWebApi.TabIndex = 0;
            this.tbpRestWebApi.Text = "REST WebApi";
            this.tbpRestWebApi.UseVisualStyleBackColor = true;
            // 
            // btnRestWebApiDelete
            // 
            this.btnRestWebApiDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestWebApiDelete.Location = new System.Drawing.Point(459, 403);
            this.btnRestWebApiDelete.Name = "btnRestWebApiDelete";
            this.btnRestWebApiDelete.Size = new System.Drawing.Size(75, 26);
            this.btnRestWebApiDelete.TabIndex = 3;
            this.btnRestWebApiDelete.Text = "Delete";
            this.btnRestWebApiDelete.UseVisualStyleBackColor = true;
            this.btnRestWebApiDelete.Click += new System.EventHandler(this.btnRestWebApiDelete_Click);
            // 
            // btnRestWebApiEdit
            // 
            this.btnRestWebApiEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestWebApiEdit.Location = new System.Drawing.Point(378, 403);
            this.btnRestWebApiEdit.Name = "btnRestWebApiEdit";
            this.btnRestWebApiEdit.Size = new System.Drawing.Size(75, 26);
            this.btnRestWebApiEdit.TabIndex = 2;
            this.btnRestWebApiEdit.Text = "Edit";
            this.btnRestWebApiEdit.UseVisualStyleBackColor = true;
            this.btnRestWebApiEdit.Click += new System.EventHandler(this.btnRestWebApiEdit_Click);
            // 
            // btnRestWebApiAdd
            // 
            this.btnRestWebApiAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestWebApiAdd.Location = new System.Drawing.Point(297, 403);
            this.btnRestWebApiAdd.Name = "btnRestWebApiAdd";
            this.btnRestWebApiAdd.Size = new System.Drawing.Size(75, 26);
            this.btnRestWebApiAdd.TabIndex = 1;
            this.btnRestWebApiAdd.Text = "Add";
            this.btnRestWebApiAdd.UseVisualStyleBackColor = true;
            this.btnRestWebApiAdd.Click += new System.EventHandler(this.btnRestWebApiAdd_Click);
            // 
            // lstRestWebApi
            // 
            this.lstRestWebApi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRestWebApi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstRestWebApi.FullRowSelect = true;
            this.lstRestWebApi.Location = new System.Drawing.Point(6, 6);
            this.lstRestWebApi.Name = "lstRestWebApi";
            this.lstRestWebApi.Size = new System.Drawing.Size(528, 391);
            this.lstRestWebApi.TabIndex = 0;
            this.lstRestWebApi.UseCompatibleStateImageBehavior = false;
            this.lstRestWebApi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Bar";
            // 
            // tbpRestWcf
            // 
            this.tbpRestWcf.Controls.Add(this.btnRestWcfDelete);
            this.tbpRestWcf.Controls.Add(this.btnRestWcfEdit);
            this.tbpRestWcf.Controls.Add(this.btnRestWcfAdd);
            this.tbpRestWcf.Controls.Add(this.lstRestWcf);
            this.tbpRestWcf.Location = new System.Drawing.Point(4, 22);
            this.tbpRestWcf.Name = "tbpRestWcf";
            this.tbpRestWcf.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRestWcf.Size = new System.Drawing.Size(540, 435);
            this.tbpRestWcf.TabIndex = 1;
            this.tbpRestWcf.Text = "REST WCF";
            this.tbpRestWcf.UseVisualStyleBackColor = true;
            // 
            // btnRestWcfDelete
            // 
            this.btnRestWcfDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestWcfDelete.Location = new System.Drawing.Point(459, 403);
            this.btnRestWcfDelete.Name = "btnRestWcfDelete";
            this.btnRestWcfDelete.Size = new System.Drawing.Size(75, 26);
            this.btnRestWcfDelete.TabIndex = 7;
            this.btnRestWcfDelete.Text = "Delete";
            this.btnRestWcfDelete.UseVisualStyleBackColor = true;
            this.btnRestWcfDelete.Click += new System.EventHandler(this.btnRestWcfDelete_Click);
            // 
            // btnRestWcfEdit
            // 
            this.btnRestWcfEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestWcfEdit.Location = new System.Drawing.Point(378, 403);
            this.btnRestWcfEdit.Name = "btnRestWcfEdit";
            this.btnRestWcfEdit.Size = new System.Drawing.Size(75, 26);
            this.btnRestWcfEdit.TabIndex = 6;
            this.btnRestWcfEdit.Text = "Edit";
            this.btnRestWcfEdit.UseVisualStyleBackColor = true;
            this.btnRestWcfEdit.Click += new System.EventHandler(this.btnRestWcfEdit_Click);
            // 
            // btnRestWcfAdd
            // 
            this.btnRestWcfAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestWcfAdd.Location = new System.Drawing.Point(297, 403);
            this.btnRestWcfAdd.Name = "btnRestWcfAdd";
            this.btnRestWcfAdd.Size = new System.Drawing.Size(75, 26);
            this.btnRestWcfAdd.TabIndex = 5;
            this.btnRestWcfAdd.Text = "Add";
            this.btnRestWcfAdd.UseVisualStyleBackColor = true;
            this.btnRestWcfAdd.Click += new System.EventHandler(this.btnRestWcfAdd_Click);
            // 
            // lstRestWcf
            // 
            this.lstRestWcf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRestWcf.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lstRestWcf.FullRowSelect = true;
            this.lstRestWcf.Location = new System.Drawing.Point(6, 6);
            this.lstRestWcf.Name = "lstRestWcf";
            this.lstRestWcf.Size = new System.Drawing.Size(528, 391);
            this.lstRestWcf.TabIndex = 4;
            this.lstRestWcf.UseCompatibleStateImageBehavior = false;
            this.lstRestWcf.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Bar";
            // 
            // tbpPageMethodsWebForms
            // 
            this.tbpPageMethodsWebForms.Controls.Add(this.btnPageMethodsWebFormsDelete);
            this.tbpPageMethodsWebForms.Controls.Add(this.btnPageMethodsWebFormsEdit);
            this.tbpPageMethodsWebForms.Controls.Add(this.btnPageMethodsWebFormsAdd);
            this.tbpPageMethodsWebForms.Controls.Add(this.lstPageMethodsWebForms);
            this.tbpPageMethodsWebForms.Location = new System.Drawing.Point(4, 22);
            this.tbpPageMethodsWebForms.Name = "tbpPageMethodsWebForms";
            this.tbpPageMethodsWebForms.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPageMethodsWebForms.Size = new System.Drawing.Size(540, 435);
            this.tbpPageMethodsWebForms.TabIndex = 2;
            this.tbpPageMethodsWebForms.Text = "PageMethods WebForms";
            this.tbpPageMethodsWebForms.UseVisualStyleBackColor = true;
            // 
            // btnPageMethodsWebFormsDelete
            // 
            this.btnPageMethodsWebFormsDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPageMethodsWebFormsDelete.Location = new System.Drawing.Point(459, 403);
            this.btnPageMethodsWebFormsDelete.Name = "btnPageMethodsWebFormsDelete";
            this.btnPageMethodsWebFormsDelete.Size = new System.Drawing.Size(75, 26);
            this.btnPageMethodsWebFormsDelete.TabIndex = 11;
            this.btnPageMethodsWebFormsDelete.Text = "Delete";
            this.btnPageMethodsWebFormsDelete.UseVisualStyleBackColor = true;
            this.btnPageMethodsWebFormsDelete.Click += new System.EventHandler(this.btnPageMethodsWebFormsDelete_Click);
            // 
            // btnPageMethodsWebFormsEdit
            // 
            this.btnPageMethodsWebFormsEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPageMethodsWebFormsEdit.Location = new System.Drawing.Point(378, 403);
            this.btnPageMethodsWebFormsEdit.Name = "btnPageMethodsWebFormsEdit";
            this.btnPageMethodsWebFormsEdit.Size = new System.Drawing.Size(75, 26);
            this.btnPageMethodsWebFormsEdit.TabIndex = 10;
            this.btnPageMethodsWebFormsEdit.Text = "Edit";
            this.btnPageMethodsWebFormsEdit.UseVisualStyleBackColor = true;
            this.btnPageMethodsWebFormsEdit.Click += new System.EventHandler(this.btnPageMethodsWebFormsEdit_Click);
            // 
            // btnPageMethodsWebFormsAdd
            // 
            this.btnPageMethodsWebFormsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPageMethodsWebFormsAdd.Location = new System.Drawing.Point(297, 403);
            this.btnPageMethodsWebFormsAdd.Name = "btnPageMethodsWebFormsAdd";
            this.btnPageMethodsWebFormsAdd.Size = new System.Drawing.Size(75, 26);
            this.btnPageMethodsWebFormsAdd.TabIndex = 9;
            this.btnPageMethodsWebFormsAdd.Text = "Add";
            this.btnPageMethodsWebFormsAdd.UseVisualStyleBackColor = true;
            this.btnPageMethodsWebFormsAdd.Click += new System.EventHandler(this.btnPageMethodsWebFormsAdd_Click);
            // 
            // lstPageMethodsWebForms
            // 
            this.lstPageMethodsWebForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPageMethodsWebForms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lstPageMethodsWebForms.FullRowSelect = true;
            this.lstPageMethodsWebForms.Location = new System.Drawing.Point(6, 6);
            this.lstPageMethodsWebForms.Name = "lstPageMethodsWebForms";
            this.lstPageMethodsWebForms.Size = new System.Drawing.Size(528, 391);
            this.lstPageMethodsWebForms.TabIndex = 8;
            this.lstPageMethodsWebForms.UseCompatibleStateImageBehavior = false;
            this.lstPageMethodsWebForms.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Id";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Bar";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 485);
            this.Controls.Add(this.tbcMain);
            this.Name = "FormMain";
            this.Text = "SimpleProxy Examples";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tbcMain.ResumeLayout(false);
            this.tbpRestWebApi.ResumeLayout(false);
            this.tbpRestWcf.ResumeLayout(false);
            this.tbpPageMethodsWebForms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpRestWebApi;
        private System.Windows.Forms.Button btnRestWebApiDelete;
        private System.Windows.Forms.Button btnRestWebApiEdit;
        private System.Windows.Forms.Button btnRestWebApiAdd;
        private System.Windows.Forms.ListView lstRestWebApi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tbpRestWcf;
        private System.Windows.Forms.Button btnRestWcfDelete;
        private System.Windows.Forms.Button btnRestWcfEdit;
        private System.Windows.Forms.Button btnRestWcfAdd;
        private System.Windows.Forms.ListView lstRestWcf;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage tbpPageMethodsWebForms;
        private System.Windows.Forms.Button btnPageMethodsWebFormsDelete;
        private System.Windows.Forms.Button btnPageMethodsWebFormsEdit;
        private System.Windows.Forms.Button btnPageMethodsWebFormsAdd;
        private System.Windows.Forms.ListView lstPageMethodsWebForms;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

