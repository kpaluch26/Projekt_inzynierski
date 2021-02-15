
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
            this.SuspendLayout();
            // 
            // sending_status
            // 
            this.sending_status.BackColor = System.Drawing.SystemColors.ControlDark;
            this.sending_status.ForeColor = System.Drawing.Color.Chartreuse;
            this.sending_status.Location = new System.Drawing.Point(12, 7);
            this.sending_status.Margin = new System.Windows.Forms.Padding(0);
            this.sending_status.Minimum = 1;
            this.sending_status.Name = "sending_status";
            this.sending_status.Size = new System.Drawing.Size(170, 30);
            this.sending_status.Step = 1;
            this.sending_status.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.sending_status.TabIndex = 0;
            this.sending_status.Value = 1;
            // 
            // SendingFileBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 44);
            this.ControlBox = false;
            this.Controls.Add(this.sending_status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SendingFileBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar sending_status;
    }
}