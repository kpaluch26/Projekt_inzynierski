namespace Klient
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.sstr_belka = new System.Windows.Forms.StatusStrip();
            this.tssl_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbx_Ustawienia = new System.Windows.Forms.GroupBox();
            this.btn_change_backup = new System.Windows.Forms.Button();
            this.lbl_backup = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btn_change_work_path = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_work_path = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_confirm_config = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_change_save_path = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_savepath = new System.Windows.Forms.Label();
            this.mstr_Menu = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mtstr_Polaczenie = new System.Windows.Forms.ToolStripMenuItem();
            this.mtstr_Ustawienia = new System.Windows.Forms.ToolStripMenuItem();
            this.gbx_Polaczenie = new System.Windows.Forms.GroupBox();
            this.btn_CONNECT = new System.Windows.Forms.Button();
            this.txt_PORT = new System.Windows.Forms.TextBox();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.lbl_PORT = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.tssb_Rozlacz = new System.Windows.Forms.ToolStripSplitButton();
            this.rozłączToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sstr_belka.SuspendLayout();
            this.gbx_Ustawienia.SuspendLayout();
            this.mstr_Menu.SuspendLayout();
            this.gbx_Polaczenie.SuspendLayout();
            this.SuspendLayout();
            // 
            // sstr_belka
            // 
            this.sstr_belka.BackColor = System.Drawing.SystemColors.Control;
            this.sstr_belka.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.sstr_belka.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_label,
            this.tssb_Rozlacz});
            this.sstr_belka.Location = new System.Drawing.Point(0, 416);
            this.sstr_belka.Name = "sstr_belka";
            this.sstr_belka.Size = new System.Drawing.Size(944, 25);
            this.sstr_belka.TabIndex = 0;
            // 
            // tssl_label
            // 
            this.tssl_label.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.tssl_label.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tssl_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tssl_label.Name = "tssl_label";
            this.tssl_label.Size = new System.Drawing.Size(137, 20);
            this.tssl_label.Text = "Połączenie aktywne";
            this.tssl_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbx_Ustawienia
            // 
            this.gbx_Ustawienia.BackColor = System.Drawing.SystemColors.Control;
            this.gbx_Ustawienia.Controls.Add(this.btn_change_backup);
            this.gbx_Ustawienia.Controls.Add(this.lbl_backup);
            this.gbx_Ustawienia.Controls.Add(this.label6);
            this.gbx_Ustawienia.Controls.Add(this.comboBox2);
            this.gbx_Ustawienia.Controls.Add(this.btn_change_work_path);
            this.gbx_Ustawienia.Controls.Add(this.label2);
            this.gbx_Ustawienia.Controls.Add(this.label4);
            this.gbx_Ustawienia.Controls.Add(this.lbl_work_path);
            this.gbx_Ustawienia.Controls.Add(this.comboBox1);
            this.gbx_Ustawienia.Controls.Add(this.btn_confirm_config);
            this.gbx_Ustawienia.Controls.Add(this.label3);
            this.gbx_Ustawienia.Controls.Add(this.btn_change_save_path);
            this.gbx_Ustawienia.Controls.Add(this.label1);
            this.gbx_Ustawienia.Controls.Add(this.lbl_savepath);
            this.gbx_Ustawienia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbx_Ustawienia.Location = new System.Drawing.Point(0, 27);
            this.gbx_Ustawienia.Name = "gbx_Ustawienia";
            this.gbx_Ustawienia.Size = new System.Drawing.Size(944, 386);
            this.gbx_Ustawienia.TabIndex = 1;
            this.gbx_Ustawienia.TabStop = false;
            this.gbx_Ustawienia.Text = "Ustawienia";
            // 
            // btn_change_backup
            // 
            this.btn_change_backup.Location = new System.Drawing.Point(492, 140);
            this.btn_change_backup.Name = "btn_change_backup";
            this.btn_change_backup.Size = new System.Drawing.Size(98, 101);
            this.btn_change_backup.TabIndex = 10;
            this.btn_change_backup.Text = "Zmień";
            this.btn_change_backup.UseVisualStyleBackColor = true;
            // 
            // lbl_backup
            // 
            this.lbl_backup.AutoSize = true;
            this.lbl_backup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_backup.Location = new System.Drawing.Point(123, 81);
            this.lbl_backup.Name = "lbl_backup";
            this.lbl_backup.Size = new System.Drawing.Size(187, 20);
            this.lbl_backup.TabIndex = 9;
            this.lbl_backup.Text = "C:/Users/Kamil/Download";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(7, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Backup:";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "5 min",
            "10 min",
            "15 min",
            "20 min",
            "30 min"});
            this.comboBox2.Location = new System.Drawing.Point(92, 204);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 28);
            this.comboBox2.TabIndex = 7;
            // 
            // btn_change_work_path
            // 
            this.btn_change_work_path.Location = new System.Drawing.Point(492, 33);
            this.btn_change_work_path.Name = "btn_change_work_path";
            this.btn_change_work_path.Size = new System.Drawing.Size(98, 101);
            this.btn_change_work_path.TabIndex = 5;
            this.btn_change_work_path.Text = "Zmień";
            this.btn_change_work_path.UseVisualStyleBackColor = true;
            this.btn_change_work_path.Click += new System.EventHandler(this.btn_change_work_path_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(14, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buffer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(9, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Autosave:";
            // 
            // lbl_work_path
            // 
            this.lbl_work_path.AutoSize = true;
            this.lbl_work_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_work_path.Location = new System.Drawing.Point(123, 33);
            this.lbl_work_path.Name = "lbl_work_path";
            this.lbl_work_path.Size = new System.Drawing.Size(187, 20);
            this.lbl_work_path.TabIndex = 4;
            this.lbl_work_path.Text = "C:/Users/Kamil/Download";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 KB",
            "2 KB",
            "4 KB",
            "8 KB",
            "16 KB",
            "32 KB",
            "64 KB"});
            this.comboBox1.Location = new System.Drawing.Point(77, 158);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 2;
            // 
            // btn_confirm_config
            // 
            this.btn_confirm_config.Location = new System.Drawing.Point(490, 257);
            this.btn_confirm_config.Name = "btn_confirm_config";
            this.btn_confirm_config.Size = new System.Drawing.Size(100, 33);
            this.btn_confirm_config.TabIndex = 2;
            this.btn_confirm_config.Text = "Potwierdź";
            this.btn_confirm_config.UseVisualStyleBackColor = true;
            this.btn_confirm_config.Click += new System.EventHandler(this.btn_confirm_config_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(7, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Praca:";
            // 
            // btn_change_save_path
            // 
            this.btn_change_save_path.Location = new System.Drawing.Point(372, 41);
            this.btn_change_save_path.Name = "btn_change_save_path";
            this.btn_change_save_path.Size = new System.Drawing.Size(98, 101);
            this.btn_change_save_path.TabIndex = 3;
            this.btn_change_save_path.Text = "Zmień";
            this.btn_change_save_path.UseVisualStyleBackColor = true;
            this.btn_change_save_path.Click += new System.EventHandler(this.btn_change_save_path_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zapis:";
            // 
            // lbl_savepath
            // 
            this.lbl_savepath.AutoSize = true;
            this.lbl_savepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_savepath.Location = new System.Drawing.Point(88, 54);
            this.lbl_savepath.Name = "lbl_savepath";
            this.lbl_savepath.Size = new System.Drawing.Size(187, 20);
            this.lbl_savepath.TabIndex = 2;
            this.lbl_savepath.Text = "C:/Users/Kamil/Download";
            // 
            // mstr_Menu
            // 
            this.mstr_Menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mstr_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.panelToolStripMenuItem,
            this.mtstr_Polaczenie,
            this.mtstr_Ustawienia});
            this.mstr_Menu.Location = new System.Drawing.Point(0, 0);
            this.mstr_Menu.Name = "mstr_Menu";
            this.mstr_Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mstr_Menu.Size = new System.Drawing.Size(944, 24);
            this.mstr_Menu.TabIndex = 2;
            this.mstr_Menu.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // panelToolStripMenuItem
            // 
            this.panelToolStripMenuItem.Name = "panelToolStripMenuItem";
            this.panelToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.panelToolStripMenuItem.Text = "Panel";
            // 
            // mtstr_Polaczenie
            // 
            this.mtstr_Polaczenie.Name = "mtstr_Polaczenie";
            this.mtstr_Polaczenie.Size = new System.Drawing.Size(75, 20);
            this.mtstr_Polaczenie.Text = "Połączenie";
            this.mtstr_Polaczenie.Click += new System.EventHandler(this.mtstr_Polaczenie_Click);
            // 
            // mtstr_Ustawienia
            // 
            this.mtstr_Ustawienia.Name = "mtstr_Ustawienia";
            this.mtstr_Ustawienia.Size = new System.Drawing.Size(76, 20);
            this.mtstr_Ustawienia.Text = "Ustawienia";
            this.mtstr_Ustawienia.Click += new System.EventHandler(this.mtstr_Ustawienia_Click);
            // 
            // gbx_Polaczenie
            // 
            this.gbx_Polaczenie.BackColor = System.Drawing.SystemColors.Control;
            this.gbx_Polaczenie.Controls.Add(this.btn_CONNECT);
            this.gbx_Polaczenie.Controls.Add(this.txt_PORT);
            this.gbx_Polaczenie.Controls.Add(this.txt_IP);
            this.gbx_Polaczenie.Controls.Add(this.lbl_PORT);
            this.gbx_Polaczenie.Controls.Add(this.lbl_IP);
            this.gbx_Polaczenie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gbx_Polaczenie.Location = new System.Drawing.Point(0, 27);
            this.gbx_Polaczenie.Name = "gbx_Polaczenie";
            this.gbx_Polaczenie.Size = new System.Drawing.Size(944, 386);
            this.gbx_Polaczenie.TabIndex = 3;
            this.gbx_Polaczenie.TabStop = false;
            this.gbx_Polaczenie.Text = "Połączenie";
            // 
            // btn_CONNECT
            // 
            this.btn_CONNECT.BackColor = System.Drawing.SystemColors.Control;
            this.btn_CONNECT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_CONNECT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_CONNECT.Location = new System.Drawing.Point(432, 213);
            this.btn_CONNECT.Margin = new System.Windows.Forms.Padding(0);
            this.btn_CONNECT.Name = "btn_CONNECT";
            this.btn_CONNECT.Size = new System.Drawing.Size(100, 40);
            this.btn_CONNECT.TabIndex = 9;
            this.btn_CONNECT.Text = "Połącz";
            this.btn_CONNECT.UseVisualStyleBackColor = false;
            this.btn_CONNECT.Click += new System.EventHandler(this.btn_CONNECT_Click);
            // 
            // txt_PORT
            // 
            this.txt_PORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PORT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_PORT.Location = new System.Drawing.Point(462, 173);
            this.txt_PORT.Name = "txt_PORT";
            this.txt_PORT.Size = new System.Drawing.Size(200, 32);
            this.txt_PORT.TabIndex = 8;
            // 
            // txt_IP
            // 
            this.txt_IP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_IP.Location = new System.Drawing.Point(462, 133);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(200, 32);
            this.txt_IP.TabIndex = 7;
            // 
            // lbl_PORT
            // 
            this.lbl_PORT.AutoSize = true;
            this.lbl_PORT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PORT.Location = new System.Drawing.Point(282, 173);
            this.lbl_PORT.Name = "lbl_PORT";
            this.lbl_PORT.Size = new System.Drawing.Size(179, 26);
            this.lbl_PORT.TabIndex = 6;
            this.lbl_PORT.Text = "Port komunikacji:";
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_IP.Location = new System.Drawing.Point(282, 133);
            this.lbl_IP.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(185, 26);
            this.lbl_IP.TabIndex = 5;
            this.lbl_IP.Text = "Adres IP serwera:";
            this.lbl_IP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssb_Rozlacz
            // 
            this.tssb_Rozlacz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssb_Rozlacz.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rozłączToolStripMenuItem});
            this.tssb_Rozlacz.Image = ((System.Drawing.Image)(resources.GetObject("tssb_Rozlacz.Image")));
            this.tssb_Rozlacz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssb_Rozlacz.Name = "tssb_Rozlacz";
            this.tssb_Rozlacz.Size = new System.Drawing.Size(32, 23);
            this.tssb_Rozlacz.Text = "toolStripSplitButton1";
            // 
            // rozłączToolStripMenuItem
            // 
            this.rozłączToolStripMenuItem.Name = "rozłączToolStripMenuItem";
            this.rozłączToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rozłączToolStripMenuItem.Text = "Rozłącz";
            this.rozłączToolStripMenuItem.Click += new System.EventHandler(this.rozłączToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(944, 441);
            this.Controls.Add(this.gbx_Polaczenie);
            this.Controls.Add(this.sstr_belka);
            this.Controls.Add(this.mstr_Menu);
            this.Controls.Add(this.gbx_Ustawienia);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.mstr_Menu;
            this.Name = "MainWindow";
            this.Text = "Klient";
            this.sstr_belka.ResumeLayout(false);
            this.sstr_belka.PerformLayout();
            this.gbx_Ustawienia.ResumeLayout(false);
            this.gbx_Ustawienia.PerformLayout();
            this.mstr_Menu.ResumeLayout(false);
            this.mstr_Menu.PerformLayout();
            this.gbx_Polaczenie.ResumeLayout(false);
            this.gbx_Polaczenie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sstr_belka;
        private System.Windows.Forms.ToolStripStatusLabel tssl_label;
        private System.Windows.Forms.GroupBox gbx_Ustawienia;
        private System.Windows.Forms.Button btn_change_save_path;
        private System.Windows.Forms.Label lbl_savepath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_confirm_config;
        private System.Windows.Forms.Button btn_change_work_path;
        private System.Windows.Forms.Label lbl_work_path;
        private System.Windows.Forms.Button btn_change_backup;
        private System.Windows.Forms.Label lbl_backup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip mstr_Menu;
        private System.Windows.Forms.ToolStripMenuItem mtstr_Ustawienia;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mtstr_Polaczenie;
        private System.Windows.Forms.GroupBox gbx_Polaczenie;
        private System.Windows.Forms.Button btn_CONNECT;
        private System.Windows.Forms.TextBox txt_PORT;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Label lbl_PORT;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.ToolStripSplitButton tssb_Rozlacz;
        private System.Windows.Forms.ToolStripMenuItem rozłączToolStripMenuItem;
    }
}