
namespace Klient
{
    partial class SendingFileBar
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
            this.sending_status = new System.Windows.Forms.ProgressBar();
            this.lbl_file_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sending_status
            // 
            this.sending_status.BackColor = System.Drawing.SystemColors.ControlDark;
            this.sending_status.ForeColor = System.Drawing.Color.Chartreuse;
            this.sending_status.Location = new System.Drawing.Point(125, 50);
            this.sending_status.Margin = new System.Windows.Forms.Padding(0);
            this.sending_status.Minimum = 1;
            this.sending_status.Name = "sending_status";
            this.sending_status.Size = new System.Drawing.Size(150, 30);
            this.sending_status.Step = 1;
            this.sending_status.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.sending_status.TabIndex = 0;
            this.sending_status.Value = 1;
            // 
            // lbl_file_name
            // 
            this.lbl_file_name.AutoSize = true;
            this.lbl_file_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_file_name.Location = new System.Drawing.Point(20, 25);
            this.lbl_file_name.Name = "lbl_file_name";
            this.lbl_file_name.Size = new System.Drawing.Size(111, 16);
            this.lbl_file_name.TabIndex = 3;
            this.lbl_file_name.Text = "Wysyłanie pliku: ";
            // 
            // SendingFileBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 94);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_file_name);
            this.Controls.Add(this.sending_status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(25, 25);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendingFileBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar sending_status;
        private System.Windows.Forms.Label lbl_file_name;
    }
}