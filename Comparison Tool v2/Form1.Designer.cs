﻿namespace Comparison_Tool_v2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblPayHistoryPR = new System.Windows.Forms.Label();
            this.lblYearToDatePR = new System.Windows.Forms.Label();
            this.lblPayHistoryStar = new System.Windows.Forms.Label();
            this.lblYearToDateStar = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblClear = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabImport = new System.Windows.Forms.TabPage();
            this.lblImportYTD = new System.Windows.Forms.Label();
            this.lblImportPH = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnYearToDateStar = new Telerik.WinControls.UI.RadButton();
            this.btnYearToDatePR = new Telerik.WinControls.UI.RadButton();
            this.btnPayHistoryStar = new Telerik.WinControls.UI.RadButton();
            this.btnPayHistoryPR = new Telerik.WinControls.UI.RadButton();
            this.tabPH = new System.Windows.Forms.TabPage();
            this.btnDownloadPH = new Telerik.WinControls.UI.RadButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabYTD = new System.Windows.Forms.TabPage();
            this.btnDownloadYTD = new Telerik.WinControls.UI.RadButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sfdPH = new System.Windows.Forms.SaveFileDialog();
            this.sfdYTD = new System.Windows.Forms.SaveFileDialog();
            this.tabControl.SuspendLayout();
            this.tabImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnYearToDateStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYearToDatePR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPayHistoryStar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPayHistoryPR)).BeginInit();
            this.tabPH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownloadPH)).BeginInit();
            this.tabYTD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownloadYTD)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPayHistoryPR
            // 
            this.lblPayHistoryPR.AutoSize = true;
            this.lblPayHistoryPR.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.lblPayHistoryPR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblPayHistoryPR.Location = new System.Drawing.Point(174, 93);
            this.lblPayHistoryPR.Name = "lblPayHistoryPR";
            this.lblPayHistoryPR.Size = new System.Drawing.Size(0, 22);
            this.lblPayHistoryPR.TabIndex = 2;
            // 
            // lblYearToDatePR
            // 
            this.lblYearToDatePR.AutoSize = true;
            this.lblYearToDatePR.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.lblYearToDatePR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblYearToDatePR.Location = new System.Drawing.Point(174, 185);
            this.lblYearToDatePR.Name = "lblYearToDatePR";
            this.lblYearToDatePR.Size = new System.Drawing.Size(0, 22);
            this.lblYearToDatePR.TabIndex = 3;
            // 
            // lblPayHistoryStar
            // 
            this.lblPayHistoryStar.AutoSize = true;
            this.lblPayHistoryStar.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.lblPayHistoryStar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblPayHistoryStar.Location = new System.Drawing.Point(174, 277);
            this.lblPayHistoryStar.Name = "lblPayHistoryStar";
            this.lblPayHistoryStar.Size = new System.Drawing.Size(0, 22);
            this.lblPayHistoryStar.TabIndex = 4;
            // 
            // lblYearToDateStar
            // 
            this.lblYearToDateStar.AutoSize = true;
            this.lblYearToDateStar.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.lblYearToDateStar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblYearToDateStar.Location = new System.Drawing.Point(174, 369);
            this.lblYearToDateStar.Name = "lblYearToDateStar";
            this.lblYearToDateStar.Size = new System.Drawing.Size(0, 22);
            this.lblYearToDateStar.TabIndex = 5;
            // 
            // lblClear
            // 
            this.lblClear.Image = ((System.Drawing.Image)(resources.GetObject("lblClear.Image")));
            this.lblClear.Location = new System.Drawing.Point(623, 424);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(45, 46);
            this.lblClear.TabIndex = 17;
            this.toolTip1.SetToolTip(this.lblClear, "Clear Files");
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            this.lblClear.MouseEnter += new System.EventHandler(this.lblClear_MouseEnter_1);
            this.lblClear.MouseLeave += new System.EventHandler(this.lblClear_MouseLeave_1);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabImport);
            this.tabControl.Controls.Add(this.tabPH);
            this.tabControl.Controls.Add(this.tabYTD);
            this.tabControl.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(-1, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(682, 508);
            this.tabControl.TabIndex = 10;
            // 
            // tabImport
            // 
            this.tabImport.BackColor = System.Drawing.Color.White;
            this.tabImport.Controls.Add(this.lblImportYTD);
            this.tabImport.Controls.Add(this.lblYearToDateStar);
            this.tabImport.Controls.Add(this.lblImportPH);
            this.tabImport.Controls.Add(this.lblPayHistoryStar);
            this.tabImport.Controls.Add(this.lblClear);
            this.tabImport.Controls.Add(this.lblYearToDatePR);
            this.tabImport.Controls.Add(this.label1);
            this.tabImport.Controls.Add(this.lblPayHistoryPR);
            this.tabImport.Controls.Add(this.btnYearToDateStar);
            this.tabImport.Controls.Add(this.btnYearToDatePR);
            this.tabImport.Controls.Add(this.btnPayHistoryStar);
            this.tabImport.Controls.Add(this.btnPayHistoryPR);
            this.tabImport.Font = new System.Drawing.Font("Dubai", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabImport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.tabImport.Location = new System.Drawing.Point(4, 31);
            this.tabImport.Name = "tabImport";
            this.tabImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabImport.Size = new System.Drawing.Size(674, 473);
            this.tabImport.TabIndex = 0;
            this.tabImport.Text = "Import";
            // 
            // lblImportYTD
            // 
            this.lblImportYTD.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportYTD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblImportYTD.Location = new System.Drawing.Point(354, 433);
            this.lblImportYTD.Name = "lblImportYTD";
            this.lblImportYTD.Size = new System.Drawing.Size(124, 29);
            this.lblImportYTD.TabIndex = 16;
            this.lblImportYTD.Text = "Import YTD Files";
            this.lblImportYTD.Click += new System.EventHandler(this.lblImportYTD_Click);
            this.lblImportYTD.MouseEnter += new System.EventHandler(this.lblImportYTD_MouseEnter_1);
            this.lblImportYTD.MouseLeave += new System.EventHandler(this.lblImportYTD_MouseLeave_1);
            // 
            // lblImportPH
            // 
            this.lblImportPH.BackColor = System.Drawing.Color.White;
            this.lblImportPH.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportPH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblImportPH.Location = new System.Drawing.Point(197, 433);
            this.lblImportPH.Name = "lblImportPH";
            this.lblImportPH.Size = new System.Drawing.Size(114, 29);
            this.lblImportPH.TabIndex = 15;
            this.lblImportPH.Text = "Import PH Files";
            this.lblImportPH.Click += new System.EventHandler(this.lblImportPH_Click);
            this.lblImportPH.MouseEnter += new System.EventHandler(this.lblImportPH_MouseEnter_1);
            this.lblImportPH.MouseLeave += new System.EventHandler(this.lblImportPH_MouseLeave_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(64, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 33);
            this.label1.TabIndex = 14;
            this.label1.Text = "Compare the differences between Star and PayRun.IO Reports";
            // 
            // btnYearToDateStar
            // 
            this.btnYearToDateStar.BackColor = System.Drawing.Color.White;
            this.btnYearToDateStar.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.btnYearToDateStar.Location = new System.Drawing.Point(43, 348);
            this.btnYearToDateStar.Name = "btnYearToDateStar";
            this.btnYearToDateStar.Size = new System.Drawing.Size(107, 43);
            this.btnYearToDateStar.TabIndex = 11;
            this.btnYearToDateStar.Text = "Star YTD";
            this.btnYearToDateStar.Click += new System.EventHandler(this.btnYearToDateStar_Click);
            this.btnYearToDateStar.MouseEnter += new System.EventHandler(this.btnYearToDateStar_MouseEnter_1);
            this.btnYearToDateStar.MouseLeave += new System.EventHandler(this.btnYearToDateStar_MouseLeave_1);
            // 
            // btnYearToDatePR
            // 
            this.btnYearToDatePR.BackColor = System.Drawing.Color.White;
            this.btnYearToDatePR.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.btnYearToDatePR.Location = new System.Drawing.Point(43, 164);
            this.btnYearToDatePR.Name = "btnYearToDatePR";
            this.btnYearToDatePR.Size = new System.Drawing.Size(107, 43);
            this.btnYearToDatePR.TabIndex = 12;
            this.btnYearToDatePR.Text = "PR YTD";
            this.btnYearToDatePR.Click += new System.EventHandler(this.btnYearToDatePR_Click);
            this.btnYearToDatePR.MouseEnter += new System.EventHandler(this.btnYearToDatePR_MouseEnter_1);
            this.btnYearToDatePR.MouseLeave += new System.EventHandler(this.btnYearToDatePR_MouseLeave_1);
            // 
            // btnPayHistoryStar
            // 
            this.btnPayHistoryStar.BackColor = System.Drawing.Color.White;
            this.btnPayHistoryStar.Font = new System.Drawing.Font("Dubai", 9.749999F);
            this.btnPayHistoryStar.Location = new System.Drawing.Point(43, 256);
            this.btnPayHistoryStar.Name = "btnPayHistoryStar";
            this.btnPayHistoryStar.Size = new System.Drawing.Size(107, 43);
            this.btnPayHistoryStar.TabIndex = 13;
            this.btnPayHistoryStar.Text = "Star PH";
            this.btnPayHistoryStar.Click += new System.EventHandler(this.btnPayHistoryStar_Click);
            this.btnPayHistoryStar.MouseEnter += new System.EventHandler(this.btnPayHistoryStar_MouseEnter_1);
            this.btnPayHistoryStar.MouseLeave += new System.EventHandler(this.btnPayHistoryStar_MouseLeave_1);
            // 
            // btnPayHistoryPR
            // 
            this.btnPayHistoryPR.BackColor = System.Drawing.Color.White;
            this.btnPayHistoryPR.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayHistoryPR.Location = new System.Drawing.Point(43, 72);
            this.btnPayHistoryPR.Name = "btnPayHistoryPR";
            this.btnPayHistoryPR.Size = new System.Drawing.Size(107, 43);
            this.btnPayHistoryPR.TabIndex = 10;
            this.btnPayHistoryPR.Text = "PR PH";
            this.btnPayHistoryPR.Click += new System.EventHandler(this.btnPayHistoryPR_Click);
            this.btnPayHistoryPR.MouseEnter += new System.EventHandler(this.btnPayHistoryPR_MouseEnter_1);
            this.btnPayHistoryPR.MouseLeave += new System.EventHandler(this.btnPayHistoryPR_MouseLeave_1);
            // 
            // tabPH
            // 
            this.tabPH.BackColor = System.Drawing.Color.White;
            this.tabPH.Controls.Add(this.btnDownloadPH);
            this.tabPH.Controls.Add(this.label4);
            this.tabPH.Controls.Add(this.label2);
            this.tabPH.Location = new System.Drawing.Point(4, 31);
            this.tabPH.Name = "tabPH";
            this.tabPH.Padding = new System.Windows.Forms.Padding(3);
            this.tabPH.Size = new System.Drawing.Size(674, 473);
            this.tabPH.TabIndex = 1;
            this.tabPH.Text = "Pay History";
            // 
            // btnDownloadPH
            // 
            this.btnDownloadPH.BackColor = System.Drawing.Color.White;
            this.btnDownloadPH.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadPH.Location = new System.Drawing.Point(267, 206);
            this.btnDownloadPH.Name = "btnDownloadPH";
            this.btnDownloadPH.Size = new System.Drawing.Size(141, 60);
            this.btnDownloadPH.TabIndex = 18;
            this.btnDownloadPH.Text = "Download PH Report";
            this.btnDownloadPH.Click += new System.EventHandler(this.btnDownloadPH_Click);
            this.btnDownloadPH.MouseEnter += new System.EventHandler(this.btnDownloadPH_MouseEnter);
            this.btnDownloadPH.MouseLeave += new System.EventHandler(this.btnDownloadPH_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 22);
            this.label4.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(139, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 33);
            this.label2.TabIndex = 15;
            this.label2.Text = "Compare the differences in the Pay History files.";
            // 
            // tabYTD
            // 
            this.tabYTD.Controls.Add(this.btnDownloadYTD);
            this.tabYTD.Controls.Add(this.label5);
            this.tabYTD.Controls.Add(this.label3);
            this.tabYTD.Location = new System.Drawing.Point(4, 31);
            this.tabYTD.Name = "tabYTD";
            this.tabYTD.Padding = new System.Windows.Forms.Padding(3);
            this.tabYTD.Size = new System.Drawing.Size(674, 473);
            this.tabYTD.TabIndex = 2;
            this.tabYTD.Text = "YTD";
            this.tabYTD.UseVisualStyleBackColor = true;
            // 
            // btnDownloadYTD
            // 
            this.btnDownloadYTD.BackColor = System.Drawing.Color.White;
            this.btnDownloadYTD.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadYTD.Location = new System.Drawing.Point(267, 206);
            this.btnDownloadYTD.Name = "btnDownloadYTD";
            this.btnDownloadYTD.Size = new System.Drawing.Size(141, 60);
            this.btnDownloadYTD.TabIndex = 19;
            this.btnDownloadYTD.Text = "Download YTD Report";
            this.btnDownloadYTD.Click += new System.EventHandler(this.btnDownloadYTD_Click);
            this.btnDownloadYTD.MouseEnter += new System.EventHandler(this.btnDownloadYTD_MouseEnter);
            this.btnDownloadYTD.MouseLeave += new System.EventHandler(this.btnDownloadYTD_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 22);
            this.label5.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(168, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 33);
            this.label3.TabIndex = 16;
            this.label3.Text = "Compare the differences in the YTD files.";
            // 
            // sfdPH
            // 
            this.sfdPH.DefaultExt = "CSV";
            this.sfdPH.FileName = "_PayHistoryDifferences.csv";
            this.sfdPH.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
            this.sfdPH.RestoreDirectory = true;
            this.sfdPH.Title = "Please choose a location to save your report";
            // 
            // sfdYTD
            // 
            this.sfdYTD.DefaultExt = "CSV";
            this.sfdYTD.FileName = "_YTDDifferences.csv";
            this.sfdYTD.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
            this.sfdYTD.RestoreDirectory = true;
            this.sfdYTD.Title = "Please choose a location to save your report";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 508);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabImport.ResumeLayout(false);
            this.tabImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnYearToDateStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnYearToDatePR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPayHistoryStar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPayHistoryPR)).EndInit();
            this.tabPH.ResumeLayout(false);
            this.tabPH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownloadPH)).EndInit();
            this.tabYTD.ResumeLayout(false);
            this.tabYTD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownloadYTD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblPayHistoryPR;
        private System.Windows.Forms.Label lblYearToDatePR;
        private System.Windows.Forms.Label lblPayHistoryStar;
        private System.Windows.Forms.Label lblYearToDateStar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label lblImportYTD;
        private System.Windows.Forms.Label lblImportPH;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnYearToDateStar;
        private Telerik.WinControls.UI.RadButton btnYearToDatePR;
        private Telerik.WinControls.UI.RadButton btnPayHistoryStar;
        private Telerik.WinControls.UI.RadButton btnPayHistoryPR;
        private System.Windows.Forms.TabPage tabPH;
        private System.Windows.Forms.TabPage tabYTD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadButton btnDownloadPH;
        private Telerik.WinControls.UI.RadButton btnDownloadYTD;
        private System.Windows.Forms.SaveFileDialog sfdPH;
        private System.Windows.Forms.SaveFileDialog sfdYTD;
    }
}
