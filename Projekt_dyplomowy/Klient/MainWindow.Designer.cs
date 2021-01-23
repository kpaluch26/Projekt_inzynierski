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
            this.tssb_Rozlacz = new System.Windows.Forms.ToolStripSplitButton();
            this.rozłączToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbx_Ustawienia = new System.Windows.Forms.GroupBox();
            this.gbx_DaneUzytkownika = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Imie = new System.Windows.Forms.TextBox();
            this.txt_Nazwisko = new System.Windows.Forms.TextBox();
            this.txt_Grupa = new System.Windows.Forms.TextBox();
            this.txt_Sekcja = new System.Windows.Forms.TextBox();
            this.txt_Wersja = new System.Windows.Forms.TextBox();
            this.btn_Potwierdz = new System.Windows.Forms.Button();
            this.cbx_czy_sekcja = new System.Windows.Forms.CheckBox();
            this.cbx_czy_wersja = new System.Windows.Forms.CheckBox();
            this.sstr_belka.SuspendLayout();
            this.gbx_Ustawienia.SuspendLayout();
            this.gbx_DaneUzytkownika.SuspendLayout();
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
            this.rozłączToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.rozłączToolStripMenuItem.Text = "Rozłącz";
            this.rozłączToolStripMenuItem.Click += new System.EventHandler(this.rozłączToolStripMenuItem_Click);
            // 
            // gbx_Ustawienia
            // 
            this.gbx_Ustawienia.BackColor = System.Drawing.SystemColors.Control;
            this.gbx_Ustawienia.Controls.Add(this.btn_Potwierdz);
            this.gbx_Ustawienia.Controls.Add(this.gbx_DaneUzytkownika);
            this.gbx_Ustawienia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbx_Ustawienia.Location = new System.Drawing.Point(0, 27);
            this.gbx_Ustawienia.Name = "gbx_Ustawienia";
            this.gbx_Ustawienia.Size = new System.Drawing.Size(944, 386);
            this.gbx_Ustawienia.TabIndex = 1;
            this.gbx_Ustawienia.TabStop = false;
            this.gbx_Ustawienia.Text = "Ustawienia";
            // 
            // gbx_DaneUzytkownika
            // 
            this.gbx_DaneUzytkownika.Controls.Add(this.cbx_czy_wersja);
            this.gbx_DaneUzytkownika.Controls.Add(this.cbx_czy_sekcja);
            this.gbx_DaneUzytkownika.Controls.Add(this.txt_Wersja);
            this.gbx_DaneUzytkownika.Controls.Add(this.label5);
            this.gbx_DaneUzytkownika.Controls.Add(this.label4);
            this.gbx_DaneUzytkownika.Controls.Add(this.txt_Sekcja);
            this.gbx_DaneUzytkownika.Controls.Add(this.label3);
            this.gbx_DaneUzytkownika.Controls.Add(this.txt_Grupa);
            this.gbx_DaneUzytkownika.Controls.Add(this.txt_Nazwisko);
            this.gbx_DaneUzytkownika.Controls.Add(this.txt_Imie);
            this.gbx_DaneUzytkownika.Controls.Add(this.label2);
            this.gbx_DaneUzytkownika.Controls.Add(this.label1);
            this.gbx_DaneUzytkownika.Location = new System.Drawing.Point(12, 25);
            this.gbx_DaneUzytkownika.Name = "gbx_DaneUzytkownika";
            this.gbx_DaneUzytkownika.Size = new System.Drawing.Size(340, 180);
            this.gbx_DaneUzytkownika.TabIndex = 1;
            this.gbx_DaneUzytkownika.TabStop = false;
            this.gbx_DaneUzytkownika.Text = "Dane Użytkownika";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię:";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nazwisko:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grupa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sekcja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Wersja:";
            // 
            // txt_Imie
            // 
            this.txt_Imie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Imie.Location = new System.Drawing.Point(49, 27);
            this.txt_Imie.Name = "txt_Imie";
            this.txt_Imie.Size = new System.Drawing.Size(120, 26);
            this.txt_Imie.TabIndex = 2;
            // 
            // txt_Nazwisko
            // 
            this.txt_Nazwisko.Location = new System.Drawing.Point(85, 57);
            this.txt_Nazwisko.Name = "txt_Nazwisko";
            this.txt_Nazwisko.Size = new System.Drawing.Size(230, 26);
            this.txt_Nazwisko.TabIndex = 3;
            // 
            // txt_Grupa
            // 
            this.txt_Grupa.Location = new System.Drawing.Point(69, 87);
            this.txt_Grupa.Name = "txt_Grupa";
            this.txt_Grupa.Size = new System.Drawing.Size(100, 26);
            this.txt_Grupa.TabIndex = 4;
            // 
            // txt_Sekcja
            // 
            this.txt_Sekcja.Location = new System.Drawing.Point(91, 117);
            this.txt_Sekcja.Name = "txt_Sekcja";
            this.txt_Sekcja.Size = new System.Drawing.Size(78, 26);
            this.txt_Sekcja.TabIndex = 5;
            // 
            // txt_Wersja
            // 
            this.txt_Wersja.Location = new System.Drawing.Point(91, 147);
            this.txt_Wersja.Name = "txt_Wersja";
            this.txt_Wersja.Size = new System.Drawing.Size(78, 26);
            this.txt_Wersja.TabIndex = 6;
            // 
            // btn_Potwierdz
            // 
            this.btn_Potwierdz.Location = new System.Drawing.Point(833, 351);
            this.btn_Potwierdz.Name = "btn_Potwierdz";
            this.btn_Potwierdz.Size = new System.Drawing.Size(105, 29);
            this.btn_Potwierdz.TabIndex = 2;
            this.btn_Potwierdz.Text = "Zapisz";
            this.btn_Potwierdz.UseVisualStyleBackColor = true;
            this.btn_Potwierdz.Click += new System.EventHandler(this.btn_Potwierdz_Click);
            // 
            // cbx_czy_sekcja
            // 
            this.cbx_czy_sekcja.AutoSize = true;
            this.cbx_czy_sekcja.Location = new System.Drawing.Point(12, 124);
            this.cbx_czy_sekcja.Name = "cbx_czy_sekcja";
            this.cbx_czy_sekcja.Size = new System.Drawing.Size(15, 14);
            this.cbx_czy_sekcja.TabIndex = 3;
            this.cbx_czy_sekcja.UseVisualStyleBackColor = true;
            this.cbx_czy_sekcja.Click += new System.EventHandler(this.cbx_czy_sekcja_Click);
            // 
            // cbx_czy_wersja
            // 
            this.cbx_czy_wersja.AutoSize = true;
            this.cbx_czy_wersja.Location = new System.Drawing.Point(12, 154);
            this.cbx_czy_wersja.Name = "cbx_czy_wersja";
            this.cbx_czy_wersja.Size = new System.Drawing.Size(15, 14);
            this.cbx_czy_wersja.TabIndex = 7;
            this.cbx_czy_wersja.UseVisualStyleBackColor = true;
            this.cbx_czy_wersja.CheckedChanged += new System.EventHandler(this.cbx_czy_wersja_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(944, 441);
            this.Controls.Add(this.sstr_belka);
            this.Controls.Add(this.mstr_Menu);
            this.Controls.Add(this.gbx_Ustawienia);
            this.Controls.Add(this.gbx_Polaczenie);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.mstr_Menu;
            this.Name = "MainWindow";
            this.Text = "Klient";
            this.sstr_belka.ResumeLayout(false);
            this.sstr_belka.PerformLayout();
            this.gbx_Ustawienia.ResumeLayout(false);
            this.gbx_DaneUzytkownika.ResumeLayout(false);
            this.gbx_DaneUzytkownika.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbx_DaneUzytkownika;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Wersja;
        private System.Windows.Forms.TextBox txt_Imie;
        private System.Windows.Forms.TextBox txt_Sekcja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Grupa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Nazwisko;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Potwierdz;
        private System.Windows.Forms.CheckBox cbx_czy_sekcja;
        private System.Windows.Forms.CheckBox cbx_czy_wersja;
    }
}