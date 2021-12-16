
namespace OkulKitapligiADONET
{
    partial class FormOduncIslemleri_Sonra
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
            this.groupBoxOgrenci = new System.Windows.Forms.GroupBox();
            this.UC_MyListBoxOgrenciler = new OkulKitapligiADONET.UC_MyListBox();
            this.groupBoxKitap = new System.Windows.Forms.GroupBox();
            this.UC_MyListBoxKitaplar = new OkulKitapligiADONET.UC_MyListBox();
            this.groupBoxOgrenci.SuspendLayout();
            this.groupBoxKitap.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOgrenci
            // 
            this.groupBoxOgrenci.Controls.Add(this.UC_MyListBoxOgrenciler);
            this.groupBoxOgrenci.Location = new System.Drawing.Point(36, 36);
            this.groupBoxOgrenci.Name = "groupBoxOgrenci";
            this.groupBoxOgrenci.Size = new System.Drawing.Size(294, 700);
            this.groupBoxOgrenci.TabIndex = 0;
            this.groupBoxOgrenci.TabStop = false;
            this.groupBoxOgrenci.Text = "Öğrenci";
            // 
            // UC_MyListBoxOgrenciler
            // 
            this.UC_MyListBoxOgrenciler.Location = new System.Drawing.Point(0, 21);
            this.UC_MyListBoxOgrenciler.Name = "UC_MyListBoxOgrenciler";
            this.UC_MyListBoxOgrenciler.Size = new System.Drawing.Size(294, 741);
            this.UC_MyListBoxOgrenciler.TabIndex = 0;
            // 
            // groupBoxKitap
            // 
            this.groupBoxKitap.Controls.Add(this.UC_MyListBoxKitaplar);
            this.groupBoxKitap.Location = new System.Drawing.Point(398, 36);
            this.groupBoxKitap.Name = "groupBoxKitap";
            this.groupBoxKitap.Size = new System.Drawing.Size(338, 700);
            this.groupBoxKitap.TabIndex = 0;
            this.groupBoxKitap.TabStop = false;
            this.groupBoxKitap.Text = "Kitap";
            // 
            // UC_MyListBoxKitaplar
            // 
            this.UC_MyListBoxKitaplar.Location = new System.Drawing.Point(0, 23);
            this.UC_MyListBoxKitaplar.Name = "UC_MyListBoxKitaplar";
            this.UC_MyListBoxKitaplar.Size = new System.Drawing.Size(338, 739);
            this.UC_MyListBoxKitaplar.TabIndex = 0;
            // 
            // FormOduncIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 764);
            this.Controls.Add(this.groupBoxKitap);
            this.Controls.Add(this.groupBoxOgrenci);
            this.Name = "FormOduncIslemleri";
            this.Text = "KİTAP ÖDÜNÇ ALIM İŞLEMLERİ";
            this.Load += new System.EventHandler(this.FormOduncIslemleri_Load);
            this.groupBoxOgrenci.ResumeLayout(false);
            this.groupBoxKitap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOgrenci;
        private System.Windows.Forms.GroupBox groupBoxKitap;
        private UC_MyListBox UC_MyListBoxOgrenciler;
        private UC_MyListBox UC_MyListBoxKitaplar;
    }
}