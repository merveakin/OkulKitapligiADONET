
namespace OkulKitapligiADONET
{
    partial class FormKitapOduncIslemleri
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
            this.comboBoxOgrenci = new System.Windows.Forms.ComboBox();
            this.comboBoxKitap = new System.Windows.Forms.ComboBox();
            this.groupBoxOgrenci = new System.Windows.Forms.GroupBox();
            this.groupBoxKitap = new System.Windows.Forms.GroupBox();
            this.groupBoxOduncTarihler = new System.Windows.Forms.GroupBox();
            this.dateTimePickerBitis = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewOduncKitaplar = new System.Windows.Forms.DataGridView();
            this.UC_MyButtonOduncAl = new OkulKitapligiADONET.UC_MyButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kitabiTeslimEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxOgrenci.SuspendLayout();
            this.groupBoxKitap.SuspendLayout();
            this.groupBoxOduncTarihler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOduncKitaplar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxOgrenci
            // 
            this.comboBoxOgrenci.FormattingEnabled = true;
            this.comboBoxOgrenci.Location = new System.Drawing.Point(22, 46);
            this.comboBoxOgrenci.Name = "comboBoxOgrenci";
            this.comboBoxOgrenci.Size = new System.Drawing.Size(419, 24);
            this.comboBoxOgrenci.TabIndex = 0;
            this.comboBoxOgrenci.SelectedIndexChanged += new System.EventHandler(this.comboBoxOgrenci_SelectedIndexChanged);
            // 
            // comboBoxKitap
            // 
            this.comboBoxKitap.FormattingEnabled = true;
            this.comboBoxKitap.Location = new System.Drawing.Point(22, 54);
            this.comboBoxKitap.Name = "comboBoxKitap";
            this.comboBoxKitap.Size = new System.Drawing.Size(419, 24);
            this.comboBoxKitap.TabIndex = 1;
            this.comboBoxKitap.SelectedIndexChanged += new System.EventHandler(this.comboBoxKitap_SelectedIndexChanged);
            // 
            // groupBoxOgrenci
            // 
            this.groupBoxOgrenci.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxOgrenci.Controls.Add(this.comboBoxOgrenci);
            this.groupBoxOgrenci.Location = new System.Drawing.Point(12, 34);
            this.groupBoxOgrenci.Name = "groupBoxOgrenci";
            this.groupBoxOgrenci.Size = new System.Drawing.Size(477, 119);
            this.groupBoxOgrenci.TabIndex = 2;
            this.groupBoxOgrenci.TabStop = false;
            this.groupBoxOgrenci.Text = "Öğrenci Seçiniz :";
            // 
            // groupBoxKitap
            // 
            this.groupBoxKitap.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxKitap.Controls.Add(this.comboBoxKitap);
            this.groupBoxKitap.Location = new System.Drawing.Point(12, 159);
            this.groupBoxKitap.Name = "groupBoxKitap";
            this.groupBoxKitap.Size = new System.Drawing.Size(477, 120);
            this.groupBoxKitap.TabIndex = 1;
            this.groupBoxKitap.TabStop = false;
            this.groupBoxKitap.Text = "Kitap Seçiniz :";
            // 
            // groupBoxOduncTarihler
            // 
            this.groupBoxOduncTarihler.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxOduncTarihler.Controls.Add(this.UC_MyButtonOduncAl);
            this.groupBoxOduncTarihler.Controls.Add(this.dateTimePickerBitis);
            this.groupBoxOduncTarihler.Controls.Add(this.label2);
            this.groupBoxOduncTarihler.Controls.Add(this.label1);
            this.groupBoxOduncTarihler.Controls.Add(this.dateTimePickerBaslangic);
            this.groupBoxOduncTarihler.Location = new System.Drawing.Point(605, 34);
            this.groupBoxOduncTarihler.Name = "groupBoxOduncTarihler";
            this.groupBoxOduncTarihler.Size = new System.Drawing.Size(489, 245);
            this.groupBoxOduncTarihler.TabIndex = 2;
            this.groupBoxOduncTarihler.TabStop = false;
            this.groupBoxOduncTarihler.Text = "Tarihleri Seçiniz :";
            this.groupBoxOduncTarihler.Enter += new System.EventHandler(this.groupBoxOduncTarihler_Enter);
            // 
            // dateTimePickerBitis
            // 
            this.dateTimePickerBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBitis.Location = new System.Drawing.Point(9, 135);
            this.dateTimePickerBitis.Name = "dateTimePickerBitis";
            this.dateTimePickerBitis.Size = new System.Drawing.Size(340, 22);
            this.dateTimePickerBitis.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bitiş Tarihi :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Başlangıç Tarihi :";
            // 
            // dateTimePickerBaslangic
            // 
            this.dateTimePickerBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBaslangic.Location = new System.Drawing.Point(9, 58);
            this.dateTimePickerBaslangic.Name = "dateTimePickerBaslangic";
            this.dateTimePickerBaslangic.Size = new System.Drawing.Size(340, 22);
            this.dateTimePickerBaslangic.TabIndex = 3;
            this.dateTimePickerBaslangic.ValueChanged += new System.EventHandler(this.dateTimePickerBaslangic_ValueChanged);
            // 
            // dataGridViewOduncKitaplar
            // 
            this.dataGridViewOduncKitaplar.AllowUserToAddRows = false;
            this.dataGridViewOduncKitaplar.AllowUserToDeleteRows = false;
            this.dataGridViewOduncKitaplar.AllowUserToOrderColumns = true;
            this.dataGridViewOduncKitaplar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOduncKitaplar.Location = new System.Drawing.Point(12, 288);
            this.dataGridViewOduncKitaplar.Name = "dataGridViewOduncKitaplar";
            this.dataGridViewOduncKitaplar.ReadOnly = true;
            this.dataGridViewOduncKitaplar.RowHeadersWidth = 51;
            this.dataGridViewOduncKitaplar.RowTemplate.Height = 24;
            this.dataGridViewOduncKitaplar.Size = new System.Drawing.Size(1082, 304);
            this.dataGridViewOduncKitaplar.TabIndex = 0;
            // 
            // UC_MyButtonOduncAl
            // 
            this.UC_MyButtonOduncAl.Location = new System.Drawing.Point(9, 179);
            this.UC_MyButtonOduncAl.Margin = new System.Windows.Forms.Padding(4);
            this.UC_MyButtonOduncAl.Name = "UC_MyButtonOduncAl";
            this.UC_MyButtonOduncAl.Size = new System.Drawing.Size(340, 41);
            this.UC_MyButtonOduncAl.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kitabiTeslimEtToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 28);
            // 
            // kitabiTeslimEtToolStripMenuItem
            // 
            this.kitabiTeslimEtToolStripMenuItem.Name = "kitabiTeslimEtToolStripMenuItem";
            this.kitabiTeslimEtToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.kitabiTeslimEtToolStripMenuItem.Text = "Kitabı Teslim Et";
            this.kitabiTeslimEtToolStripMenuItem.Click += new System.EventHandler(this.kitabiTeslimEtToolStripMenuItem_Click);
            // 
            // FormKitapOduncIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 620);
            this.Controls.Add(this.dataGridViewOduncKitaplar);
            this.Controls.Add(this.groupBoxOduncTarihler);
            this.Controls.Add(this.groupBoxKitap);
            this.Controls.Add(this.groupBoxOgrenci);
            this.Name = "FormKitapOduncIslemleri";
            this.Text = "KİTAP ÖDÜNÇ ALIM FORMU";
            this.Load += new System.EventHandler(this.FormKitapOduncIslemleri_Load);
            this.groupBoxOgrenci.ResumeLayout(false);
            this.groupBoxKitap.ResumeLayout(false);
            this.groupBoxOduncTarihler.ResumeLayout(false);
            this.groupBoxOduncTarihler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOduncKitaplar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOgrenci;
        private System.Windows.Forms.ComboBox comboBoxKitap;
        private System.Windows.Forms.GroupBox groupBoxOgrenci;
        private System.Windows.Forms.GroupBox groupBoxKitap;
        private System.Windows.Forms.GroupBox groupBoxOduncTarihler;
        private System.Windows.Forms.DataGridView dataGridViewOduncKitaplar;
        private UC_MyButton UC_MyButtonOduncAl;
        private System.Windows.Forms.DateTimePicker dateTimePickerBitis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaslangic;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kitabiTeslimEtToolStripMenuItem;
    }
}