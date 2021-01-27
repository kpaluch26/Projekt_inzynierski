
namespace Klient
{
    partial class WriteName
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
            this.txt_nazwa_archiwum = new System.Windows.Forms.TextBox();
            this.btn_akceptuj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Podaj nazwę:";
            // 
            // txt_nazwa_archiwum
            // 
            this.txt_nazwa_archiwum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_nazwa_archiwum.Location = new System.Drawing.Point(120, 10);
            this.txt_nazwa_archiwum.Name = "txt_nazwa_archiwum";
            this.txt_nazwa_archiwum.Size = new System.Drawing.Size(100, 26);
            this.txt_nazwa_archiwum.TabIndex = 1;
            this.txt_nazwa_archiwum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_nazwa_archiwum_KeyUp);
            // 
            // btn_akceptuj
            // 
            this.btn_akceptuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_akceptuj.Location = new System.Drawing.Point(80, 44);
            this.btn_akceptuj.Name = "btn_akceptuj";
            this.btn_akceptuj.Size = new System.Drawing.Size(75, 25);
            this.btn_akceptuj.TabIndex = 2;
            this.btn_akceptuj.Text = "OK";
            this.btn_akceptuj.UseVisualStyleBackColor = true;
            this.btn_akceptuj.Click += new System.EventHandler(this.btn_akceptuj_Click);
            // 
            // WriteName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 75);
            this.ControlBox = false;
            this.Controls.Add(this.btn_akceptuj);
            this.Controls.Add(this.txt_nazwa_archiwum);
            this.Controls.Add(this.label1);
            this.Name = "WriteName";
            this.Text = "Archiwum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nazwa_archiwum;
        private System.Windows.Forms.Button btn_akceptuj;
    }
}