namespace Klient
{
    partial class ConnectionWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_IP = new System.Windows.Forms.Label();
            this.lbl_PORT = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_PORT = new System.Windows.Forms.TextBox();
            this.btn_CONNECT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_IP.Location = new System.Drawing.Point(40, 40);
            this.lbl_IP.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(185, 26);
            this.lbl_IP.TabIndex = 0;
            this.lbl_IP.Text = "Adres IP serwera:";
            this.lbl_IP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_PORT
            // 
            this.lbl_PORT.AutoSize = true;
            this.lbl_PORT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PORT.Location = new System.Drawing.Point(40, 80);
            this.lbl_PORT.Name = "lbl_PORT";
            this.lbl_PORT.Size = new System.Drawing.Size(179, 26);
            this.lbl_PORT.TabIndex = 1;
            this.lbl_PORT.Text = "Port komunikacji:";
            // 
            // txt_IP
            // 
            this.txt_IP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_IP.Location = new System.Drawing.Point(220, 40);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(200, 32);
            this.txt_IP.TabIndex = 2;
            // 
            // txt_PORT
            // 
            this.txt_PORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PORT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_PORT.Location = new System.Drawing.Point(220, 80);
            this.txt_PORT.Name = "txt_PORT";
            this.txt_PORT.Size = new System.Drawing.Size(200, 32);
            this.txt_PORT.TabIndex = 3;
            // 
            // btn_CONNECT
            // 
            this.btn_CONNECT.BackColor = System.Drawing.SystemColors.Control;
            this.btn_CONNECT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_CONNECT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_CONNECT.Location = new System.Drawing.Point(190, 120);
            this.btn_CONNECT.Margin = new System.Windows.Forms.Padding(0);
            this.btn_CONNECT.Name = "btn_CONNECT";
            this.btn_CONNECT.Size = new System.Drawing.Size(100, 40);
            this.btn_CONNECT.TabIndex = 4;
            this.btn_CONNECT.Text = "Połącz";
            this.btn_CONNECT.UseVisualStyleBackColor = false;
            this.btn_CONNECT.Click += new System.EventHandler(this.btn_CONNECT_Click);
            // 
            // ConnectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(464, 201);
            this.Controls.Add(this.btn_CONNECT);
            this.Controls.Add(this.txt_PORT);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.lbl_PORT);
            this.Controls.Add(this.lbl_IP);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 240);
            this.MinimumSize = new System.Drawing.Size(480, 240);
            this.Name = "ConnectionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Połącz z serwerem";
            this.Load += new System.EventHandler(this.ConnectionWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Label lbl_PORT;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_PORT;
        private System.Windows.Forms.Button btn_CONNECT;
    }
}

