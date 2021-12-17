
namespace OkulKitapligiADONET
{
    partial class FormGiris
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
            this.UC_MyButton1 = new OkulKitapligiADONET.UC_MyButton();
            this.UC_MyButton2 = new OkulKitapligiADONET.UC_MyButton();
            this.SuspendLayout();
            // 
            // UC_MyButton1
            // 
            this.UC_MyButton1.Location = new System.Drawing.Point(61, 83);
            this.UC_MyButton1.Margin = new System.Windows.Forms.Padding(4);
            this.UC_MyButton1.Name = "UC_MyButton1";
            this.UC_MyButton1.Size = new System.Drawing.Size(232, 99);
            this.UC_MyButton1.TabIndex = 0;
            // 
            // UC_MyButton2
            // 
            this.UC_MyButton2.Location = new System.Drawing.Point(61, 296);
            this.UC_MyButton2.Margin = new System.Windows.Forms.Padding(4);
            this.UC_MyButton2.Name = "UC_MyButton2";
            this.UC_MyButton2.Size = new System.Drawing.Size(232, 122);
            this.UC_MyButton2.TabIndex = 1;
            // 
            // FormGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 647);
            this.Controls.Add(this.UC_MyButton2);
            this.Controls.Add(this.UC_MyButton1);
            this.Name = "FormGiris";
            this.Text = "FormGiris";
            this.Load += new System.EventHandler(this.FormGiris_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC_MyButton UC_MyButton1;
        private UC_MyButton UC_MyButton2;
    }
}