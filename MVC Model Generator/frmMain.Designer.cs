namespace MVC_Model_Generator
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerateClass = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.cboTableName = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbModel = new System.Windows.Forms.TabPage();
            this.tbInterface = new System.Windows.Forms.TabPage();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TabPage();
            this.txtInterface = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tbModel.SuspendLayout();
            this.tbInterface.SuspendLayout();
            this.tbCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table Name:";
            // 
            // btnGenerateClass
            // 
            this.btnGenerateClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateClass.AutoSize = true;
            this.btnGenerateClass.Enabled = false;
            this.btnGenerateClass.Location = new System.Drawing.Point(542, 38);
            this.btnGenerateClass.Name = "btnGenerateClass";
            this.btnGenerateClass.Size = new System.Drawing.Size(100, 23);
            this.btnGenerateClass.TabIndex = 2;
            this.btnGenerateClass.Text = "&Generate Model";
            this.btnGenerateClass.UseVisualStyleBackColor = true;
            this.btnGenerateClass.Click += new System.EventHandler(this.btnGenerateClass_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Connection String:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionString.Location = new System.Drawing.Point(113, 12);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(421, 22);
            this.txtConnectionString.TabIndex = 3;
            // 
            // cboTableName
            // 
            this.cboTableName.Enabled = false;
            this.cboTableName.FormattingEnabled = true;
            this.cboTableName.Location = new System.Drawing.Point(113, 41);
            this.cboTableName.Name = "cboTableName";
            this.cboTableName.Size = new System.Drawing.Size(121, 21);
            this.cboTableName.TabIndex = 5;
            this.cboTableName.SelectedIndexChanged += new System.EventHandler(this.cboTableName_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.AutoSize = true;
            this.btnConnect.Location = new System.Drawing.Point(542, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Namespace:";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamespace.Location = new System.Drawing.Point(313, 41);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(221, 22);
            this.txtNamespace.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbModel);
            this.tabControl1.Controls.Add(this.tbInterface);
            this.tabControl1.Controls.Add(this.tbCode);
            this.tabControl1.Location = new System.Drawing.Point(13, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 182);
            this.tabControl1.TabIndex = 10;
            // 
            // tbModel
            // 
            this.tbModel.Controls.Add(this.txtModel);
            this.tbModel.Location = new System.Drawing.Point(4, 22);
            this.tbModel.Name = "tbModel";
            this.tbModel.Padding = new System.Windows.Forms.Padding(5);
            this.tbModel.Size = new System.Drawing.Size(620, 156);
            this.tbModel.TabIndex = 0;
            this.tbModel.Text = "Model";
            this.tbModel.UseVisualStyleBackColor = true;
            // 
            // tbInterface
            // 
            this.tbInterface.Controls.Add(this.txtInterface);
            this.tbInterface.Location = new System.Drawing.Point(4, 22);
            this.tbInterface.Name = "tbInterface";
            this.tbInterface.Padding = new System.Windows.Forms.Padding(3);
            this.tbInterface.Size = new System.Drawing.Size(620, 156);
            this.tbInterface.TabIndex = 1;
            this.tbInterface.Text = "Interface";
            this.tbInterface.UseVisualStyleBackColor = true;
            // 
            // txtModel
            // 
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModel.Location = new System.Drawing.Point(5, 5);
            this.txtModel.Multiline = true;
            this.txtModel.Name = "txtModel";
            this.txtModel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModel.Size = new System.Drawing.Size(610, 146);
            this.txtModel.TabIndex = 8;
            // 
            // tbCode
            // 
            this.tbCode.Controls.Add(this.txtCode);
            this.tbCode.Location = new System.Drawing.Point(4, 22);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(620, 156);
            this.tbCode.TabIndex = 2;
            this.tbCode.Text = "Code";
            this.tbCode.UseVisualStyleBackColor = true;
            // 
            // txtInterface
            // 
            this.txtInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInterface.Location = new System.Drawing.Point(3, 3);
            this.txtInterface.Multiline = true;
            this.txtInterface.Name = "txtInterface";
            this.txtInterface.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInterface.Size = new System.Drawing.Size(614, 150);
            this.txtInterface.TabIndex = 8;
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 0);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCode.Size = new System.Drawing.Size(620, 156);
            this.txtCode.TabIndex = 9;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 262);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cboTableName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.btnGenerateClass);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "MVC Model Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbModel.ResumeLayout(false);
            this.tbModel.PerformLayout();
            this.tbInterface.ResumeLayout(false);
            this.tbInterface.PerformLayout();
            this.tbCode.ResumeLayout(false);
            this.tbCode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerateClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.ComboBox cboTableName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TabPage tbInterface;
        private System.Windows.Forms.TabPage tbCode;
        private System.Windows.Forms.TextBox txtInterface;
        private System.Windows.Forms.TextBox txtCode;
    }
}

