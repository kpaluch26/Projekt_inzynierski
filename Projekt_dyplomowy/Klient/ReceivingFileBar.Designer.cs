
namespace Klient
{
    partial class ReceivingFileBar
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
            this.prb_receiving_status = new System.Windows.Forms.ProgressBar();
            this.lbl_file_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prb_receiving_status
            // 
            this.prb_receiving_status.BackColor = System.Drawing.SystemColors.ControlDark;
            this.prb_receiving_status.ForeColor = System.Drawing.Color.Chartreuse;
            this.prb_receiving_status.Location = new System.Drawing.Point(62, 35);
            this.prb_receiving_status.Margin = new System.Windows.Forms.Padding(0);
            this.prb_receiving_status.Minimum = 1;
            this.prb_receiving_status.Name = "prb_receiving_status";
            this.prb_receiving_status.Size = new System.Drawing.Size(170, 30);
            this.prb_receiving_status.Step = 1;
            this.prb_receiving_status.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prb_receiving_status.TabIndex = 1;
            this.prb_receiving_status.Value = 1;
            // 
            // lbl_file_name
            // 
            this.lbl_file_name.AutoSize = true;
            this.lbl_file_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_file_name.Location = new System.Drawing.Point(3, 9);
            this.lbl_file_name.Name = "lbl_file_name";
            this.lbl_file_name.Size = new System.Drawing.Size(111, 16);
            this.lbl_file_name.TabIndex = 2;
            this.lbl_file_name.Text = "Pobieranie pliku: ";
            // 
            // ReceivingFileBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(294, 74);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_file_name);
            this.Controls.Add(this.prb_receiving_status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ReceivingFileBar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prb_receiving_status;
        private System.Windows.Forms.Label lbl_file_name;
    }
}