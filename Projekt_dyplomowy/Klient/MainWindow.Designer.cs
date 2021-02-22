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
            this.gbx_Backup = new System.Windows.Forms.GroupBox();
            this.txt_szyfr = new System.Windows.Forms.TextBox();
            this.cbx_szyfrowanie = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbx_interwal_zapisu = new System.Windows.Forms.ComboBox();
            this.lbl_backup_workspace = new System.Windows.Forms.Label();
            this.lbl_backup_zapis = new System.Windows.Forms.Label();
            this.rbtn_backup_off = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.rbtn_backup_on = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbx_Ustawienia_polaczenia = new System.Windows.Forms.GroupBox();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_path_polaczenie = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nup_bufor = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Potwierdz = new System.Windows.Forms.Button();
            this.gbx_DaneUzytkownika = new System.Windows.Forms.GroupBox();
            this.cbx_czy_wersja = new System.Windows.Forms.CheckBox();
            this.cbx_czy_sekcja = new System.Windows.Forms.CheckBox();
            this.txt_Wersja = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Sekcja = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Grupa = new System.Windows.Forms.TextBox();
            this.txt_Nazwisko = new System.Windows.Forms.TextBox();
            this.txt_Imie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mstr_Menu = new System.Windows.Forms.MenuStrip();
            this.mtstr_Plik = new System.Windows.Forms.ToolStripMenuItem();
            this.mtstr_Panel = new System.Windows.Forms.ToolStripMenuItem();
            this.mtstr_Polaczenie = new System.Windows.Forms.ToolStripMenuItem();
            this.mtstr_Ustawienia = new System.Windows.Forms.ToolStripMenuItem();
            this.gbx_Polaczenie = new System.Windows.Forms.GroupBox();
            this.btn_CONNECT = new System.Windows.Forms.Button();
            this.txt_PORT = new System.Windows.Forms.TextBox();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.lbl_PORT = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.gbx_Plik = new System.Windows.Forms.GroupBox();
            this.txt_haslo = new System.Windows.Forms.TextBox();
            this.btn_wyczysc_pliki = new System.Windows.Forms.Button();
            this.cbx_ustaw_archiwum = new System.Windows.Forms.CheckBox();
            this.lbl_wybierz_nazwe = new System.Windows.Forms.Label();
            this.lbl_zip_path = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbx_czy_haslo = new System.Windows.Forms.CheckBox();
            this.cbx_zaznacz_pliki = new System.Windows.Forms.CheckBox();
            this.btn_wybierz_pliki = new System.Windows.Forms.Button();
            this.btn_utworz = new System.Windows.Forms.Button();
            this.clbx_lista_plikow = new System.Windows.Forms.CheckedListBox();
            this.gbx_Panel = new System.Windows.Forms.GroupBox();
            this.btn_wyslij = new System.Windows.Forms.Button();
            this.gbx_archiwum = new System.Windows.Forms.GroupBox();
            this.btn_zmien_archiwum = new System.Windows.Forms.Button();
            this.lbl_lokalizacja_pliku = new System.Windows.Forms.Label();
            this.lbl_nazwa_pliku = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.sstr_belka.SuspendLayout();
            this.gbx_Ustawienia.SuspendLayout();
            this.gbx_Backup.SuspendLayout();
            this.gbx_Ustawienia_polaczenia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_bufor)).BeginInit();
            this.gbx_DaneUzytkownika.SuspendLayout();
            this.mstr_Menu.SuspendLayout();
            this.gbx_Polaczenie.SuspendLayout();
            this.gbx_Plik.SuspendLayout();
            this.gbx_Panel.SuspendLayout();
            this.gbx_archiwum.SuspendLayout();
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
            this.gbx_Ustawienia.Controls.Add(this.gbx_Backup);
            this.gbx_Ustawienia.Controls.Add(this.gbx_Ustawienia_polaczenia);
            this.gbx_Ustawienia.Controls.Add(this.btn_Potwierdz);
            this.gbx_Ustawienia.Controls.Add(this.gbx_DaneUzytkownika);
            this.gbx_Ustawienia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbx_Ustawienia.Location = new System.Drawing.Point(30, 24);
            this.gbx_Ustawienia.Name = "gbx_Ustawienia";
            this.gbx_Ustawienia.Size = new System.Drawing.Size(880, 392);
            this.gbx_Ustawienia.TabIndex = 1;
            this.gbx_Ustawienia.TabStop = false;
            this.gbx_Ustawienia.Text = "Ustawienia";
            // 
            // gbx_Backup
            // 
            this.gbx_Backup.Controls.Add(this.txt_szyfr);
            this.gbx_Backup.Controls.Add(this.cbx_szyfrowanie);
            this.gbx_Backup.Controls.Add(this.label13);
            this.gbx_Backup.Controls.Add(this.cbx_interwal_zapisu);
            this.gbx_Backup.Controls.Add(this.lbl_backup_workspace);
            this.gbx_Backup.Controls.Add(this.lbl_backup_zapis);
            this.gbx_Backup.Controls.Add(this.rbtn_backup_off);
            this.gbx_Backup.Controls.Add(this.label12);
            this.gbx_Backup.Controls.Add(this.rbtn_backup_on);
            this.gbx_Backup.Controls.Add(this.label11);
            this.gbx_Backup.Controls.Add(this.label10);
            this.gbx_Backup.Controls.Add(this.label9);
            this.gbx_Backup.Location = new System.Drawing.Point(430, 30);
            this.gbx_Backup.Name = "gbx_Backup";
            this.gbx_Backup.Size = new System.Drawing.Size(420, 180);
            this.gbx_Backup.TabIndex = 3;
            this.gbx_Backup.TabStop = false;
            this.gbx_Backup.Text = "Backup";
            // 
            // txt_szyfr
            // 
            this.txt_szyfr.Location = new System.Drawing.Point(134, 147);
            this.txt_szyfr.Name = "txt_szyfr";
            this.txt_szyfr.Size = new System.Drawing.Size(100, 26);
            this.txt_szyfr.TabIndex = 12;
            // 
            // cbx_szyfrowanie
            // 
            this.cbx_szyfrowanie.AutoSize = true;
            this.cbx_szyfrowanie.Location = new System.Drawing.Point(10, 154);
            this.cbx_szyfrowanie.Name = "cbx_szyfrowanie";
            this.cbx_szyfrowanie.Size = new System.Drawing.Size(15, 14);
            this.cbx_szyfrowanie.TabIndex = 11;
            this.cbx_szyfrowanie.TabStop = false;
            this.cbx_szyfrowanie.UseVisualStyleBackColor = true;
            this.cbx_szyfrowanie.CheckedChanged += new System.EventHandler(this.cbx_szyfrowanie_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 20);
            this.label13.TabIndex = 10;
            this.label13.Text = "Opcja kopii zapasowej:";
            // 
            // cbx_interwal_zapisu
            // 
            this.cbx_interwal_zapisu.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbx_interwal_zapisu.FormattingEnabled = true;
            this.cbx_interwal_zapisu.Items.AddRange(new object[] {
            "5 min",
            "10 min",
            "15 min",
            "20 min",
            "30 min",
            "45 min",
            "60 min"});
            this.cbx_interwal_zapisu.Location = new System.Drawing.Point(132, 57);
            this.cbx_interwal_zapisu.Name = "cbx_interwal_zapisu";
            this.cbx_interwal_zapisu.Size = new System.Drawing.Size(121, 28);
            this.cbx_interwal_zapisu.TabIndex = 9;
            this.cbx_interwal_zapisu.Text = "5 min";
            // 
            // lbl_backup_workspace
            // 
            this.lbl_backup_workspace.AutoSize = true;
            this.lbl_backup_workspace.Location = new System.Drawing.Point(120, 90);
            this.lbl_backup_workspace.Name = "lbl_backup_workspace";
            this.lbl_backup_workspace.Size = new System.Drawing.Size(77, 20);
            this.lbl_backup_workspace.TabIndex = 8;
            this.lbl_backup_workspace.Text = "Wybierz...";
            this.lbl_backup_workspace.DoubleClick += new System.EventHandler(this.lbl_backup_workspace_DoubleClick);
            // 
            // lbl_backup_zapis
            // 
            this.lbl_backup_zapis.AutoSize = true;
            this.lbl_backup_zapis.Location = new System.Drawing.Point(128, 120);
            this.lbl_backup_zapis.Name = "lbl_backup_zapis";
            this.lbl_backup_zapis.Size = new System.Drawing.Size(77, 20);
            this.lbl_backup_zapis.TabIndex = 7;
            this.lbl_backup_zapis.Text = "Wybierz...";
            this.lbl_backup_zapis.DoubleClick += new System.EventHandler(this.lbl_backup_zapis_DoubleClick);
            // 
            // rbtn_backup_off
            // 
            this.rbtn_backup_off.AutoSize = true;
            this.rbtn_backup_off.Location = new System.Drawing.Point(255, 30);
            this.rbtn_backup_off.Name = "rbtn_backup_off";
            this.rbtn_backup_off.Size = new System.Drawing.Size(78, 24);
            this.rbtn_backup_off.TabIndex = 6;
            this.rbtn_backup_off.TabStop = true;
            this.rbtn_backup_off.Text = "Wyłącz";
            this.rbtn_backup_off.UseVisualStyleBackColor = true;
            this.rbtn_backup_off.Click += new System.EventHandler(this.rbtn_backup_off_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Ustaw hasło";
            // 
            // rbtn_backup_on
            // 
            this.rbtn_backup_on.AutoSize = true;
            this.rbtn_backup_on.Location = new System.Drawing.Point(178, 30);
            this.rbtn_backup_on.Name = "rbtn_backup_on";
            this.rbtn_backup_on.Size = new System.Drawing.Size(71, 24);
            this.rbtn_backup_on.TabIndex = 5;
            this.rbtn_backup_on.TabStop = true;
            this.rbtn_backup_on.Text = "Włącz";
            this.rbtn_backup_on.UseVisualStyleBackColor = true;
            this.rbtn_backup_on.Click += new System.EventHandler(this.rbtn_backup_on_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Miejsce zapisu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Miejsce pracy:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Interwał zapisu:";
            // 
            // gbx_Ustawienia_polaczenia
            // 
            this.gbx_Ustawienia_polaczenia.Controls.Add(this.lbl_ID);
            this.gbx_Ustawienia_polaczenia.Controls.Add(this.label8);
            this.gbx_Ustawienia_polaczenia.Controls.Add(this.lbl_path_polaczenie);
            this.gbx_Ustawienia_polaczenia.Controls.Add(this.label7);
            this.gbx_Ustawienia_polaczenia.Controls.Add(this.nup_bufor);
            this.gbx_Ustawienia_polaczenia.Controls.Add(this.label6);
            this.gbx_Ustawienia_polaczenia.Location = new System.Drawing.Point(30, 240);
            this.gbx_Ustawienia_polaczenia.Name = "gbx_Ustawienia_polaczenia";
            this.gbx_Ustawienia_polaczenia.Size = new System.Drawing.Size(574, 120);
            this.gbx_Ustawienia_polaczenia.TabIndex = 2;
            this.gbx_Ustawienia_polaczenia.TabStop = false;
            this.gbx_Ustawienia_polaczenia.Text = "Połączenie";
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.Location = new System.Drawing.Point(153, 30);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(9, 20);
            this.lbl_ID.TabIndex = 5;
            this.lbl_ID.Text = "\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Identyfikator klienta:";
            // 
            // lbl_path_polaczenie
            // 
            this.lbl_path_polaczenie.AutoSize = true;
            this.lbl_path_polaczenie.Location = new System.Drawing.Point(122, 90);
            this.lbl_path_polaczenie.Name = "lbl_path_polaczenie";
            this.lbl_path_polaczenie.Size = new System.Drawing.Size(77, 20);
            this.lbl_path_polaczenie.TabIndex = 3;
            this.lbl_path_polaczenie.Text = "Wybierz...";
            this.lbl_path_polaczenie.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbl_path_polaczenie_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Miejsce zapisu:";
            // 
            // nup_bufor
            // 
            this.nup_bufor.Increment = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nup_bufor.Location = new System.Drawing.Point(130, 57);
            this.nup_bufor.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.nup_bufor.Minimum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nup_bufor.Name = "nup_bufor";
            this.nup_bufor.Size = new System.Drawing.Size(120, 26);
            this.nup_bufor.TabIndex = 1;
            this.nup_bufor.Tag = "";
            this.nup_bufor.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Rozmiar bufora:";
            // 
            // btn_Potwierdz
            // 
            this.btn_Potwierdz.Location = new System.Drawing.Point(745, 331);
            this.btn_Potwierdz.Name = "btn_Potwierdz";
            this.btn_Potwierdz.Size = new System.Drawing.Size(105, 29);
            this.btn_Potwierdz.TabIndex = 4;
            this.btn_Potwierdz.Text = "Zapisz";
            this.btn_Potwierdz.UseVisualStyleBackColor = true;
            this.btn_Potwierdz.Click += new System.EventHandler(this.btn_Potwierdz_Click);
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
            this.gbx_DaneUzytkownika.Location = new System.Drawing.Point(30, 30);
            this.gbx_DaneUzytkownika.Name = "gbx_DaneUzytkownika";
            this.gbx_DaneUzytkownika.Size = new System.Drawing.Size(340, 180);
            this.gbx_DaneUzytkownika.TabIndex = 1;
            this.gbx_DaneUzytkownika.TabStop = false;
            this.gbx_DaneUzytkownika.Text = "Dane Użytkownika";
            // 
            // cbx_czy_wersja
            // 
            this.cbx_czy_wersja.AutoSize = true;
            this.cbx_czy_wersja.Location = new System.Drawing.Point(12, 154);
            this.cbx_czy_wersja.Name = "cbx_czy_wersja";
            this.cbx_czy_wersja.Size = new System.Drawing.Size(15, 14);
            this.cbx_czy_wersja.TabIndex = 7;
            this.cbx_czy_wersja.TabStop = false;
            this.cbx_czy_wersja.UseVisualStyleBackColor = true;
            this.cbx_czy_wersja.CheckedChanged += new System.EventHandler(this.cbx_czy_wersja_CheckedChanged);
            // 
            // cbx_czy_sekcja
            // 
            this.cbx_czy_sekcja.AutoSize = true;
            this.cbx_czy_sekcja.Location = new System.Drawing.Point(12, 124);
            this.cbx_czy_sekcja.Name = "cbx_czy_sekcja";
            this.cbx_czy_sekcja.Size = new System.Drawing.Size(15, 14);
            this.cbx_czy_sekcja.TabIndex = 6;
            this.cbx_czy_sekcja.TabStop = false;
            this.cbx_czy_sekcja.UseVisualStyleBackColor = true;
            this.cbx_czy_sekcja.CheckedChanged += new System.EventHandler(this.cbx_czy_sekcja_CheckedChanged);
            // 
            // txt_Wersja
            // 
            this.txt_Wersja.Location = new System.Drawing.Point(91, 147);
            this.txt_Wersja.Name = "txt_Wersja";
            this.txt_Wersja.Size = new System.Drawing.Size(78, 26);
            this.txt_Wersja.TabIndex = 5;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sekcja:";
            // 
            // txt_Sekcja
            // 
            this.txt_Sekcja.Location = new System.Drawing.Point(91, 117);
            this.txt_Sekcja.Name = "txt_Sekcja";
            this.txt_Sekcja.Size = new System.Drawing.Size(78, 26);
            this.txt_Sekcja.TabIndex = 4;
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
            // txt_Grupa
            // 
            this.txt_Grupa.Location = new System.Drawing.Point(69, 87);
            this.txt_Grupa.Name = "txt_Grupa";
            this.txt_Grupa.Size = new System.Drawing.Size(100, 26);
            this.txt_Grupa.TabIndex = 3;
            // 
            // txt_Nazwisko
            // 
            this.txt_Nazwisko.Location = new System.Drawing.Point(85, 57);
            this.txt_Nazwisko.Name = "txt_Nazwisko";
            this.txt_Nazwisko.Size = new System.Drawing.Size(230, 26);
            this.txt_Nazwisko.TabIndex = 2;
            // 
            // txt_Imie
            // 
            this.txt_Imie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_Imie.Location = new System.Drawing.Point(49, 27);
            this.txt_Imie.Name = "txt_Imie";
            this.txt_Imie.Size = new System.Drawing.Size(120, 26);
            this.txt_Imie.TabIndex = 1;
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
            this.mstr_Menu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mstr_Menu.BackColor = System.Drawing.SystemColors.Control;
            this.mstr_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mstr_Menu.Dock = System.Windows.Forms.DockStyle.None;
            this.mstr_Menu.GripMargin = new System.Windows.Forms.Padding(0);
            this.mstr_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mtstr_Plik,
            this.mtstr_Panel,
            this.mtstr_Polaczenie,
            this.mtstr_Ustawienia});
            this.mstr_Menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mstr_Menu.Location = new System.Drawing.Point(0, 0);
            this.mstr_Menu.Name = "mstr_Menu";
            this.mstr_Menu.Padding = new System.Windows.Forms.Padding(0);
            this.mstr_Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mstr_Menu.Size = new System.Drawing.Size(239, 24);
            this.mstr_Menu.TabIndex = 2;
            this.mstr_Menu.Text = "menuStrip1";
            // 
            // mtstr_Plik
            // 
            this.mtstr_Plik.Name = "mtstr_Plik";
            this.mtstr_Plik.Size = new System.Drawing.Size(38, 24);
            this.mtstr_Plik.Text = "Plik";
            this.mtstr_Plik.Click += new System.EventHandler(this.mtstr_Plik_Click);
            // 
            // mtstr_Panel
            // 
            this.mtstr_Panel.Checked = true;
            this.mtstr_Panel.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.mtstr_Panel.Name = "mtstr_Panel";
            this.mtstr_Panel.Size = new System.Drawing.Size(48, 24);
            this.mtstr_Panel.Text = "Panel";
            this.mtstr_Panel.Click += new System.EventHandler(this.mtstr_Panel_Click);
            // 
            // mtstr_Polaczenie
            // 
            this.mtstr_Polaczenie.Name = "mtstr_Polaczenie";
            this.mtstr_Polaczenie.Size = new System.Drawing.Size(75, 24);
            this.mtstr_Polaczenie.Text = "Połączenie";
            this.mtstr_Polaczenie.Click += new System.EventHandler(this.mtstr_Polaczenie_Click);
            // 
            // mtstr_Ustawienia
            // 
            this.mtstr_Ustawienia.Name = "mtstr_Ustawienia";
            this.mtstr_Ustawienia.Size = new System.Drawing.Size(76, 24);
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
            this.gbx_Polaczenie.Location = new System.Drawing.Point(30, 24);
            this.gbx_Polaczenie.Name = "gbx_Polaczenie";
            this.gbx_Polaczenie.Size = new System.Drawing.Size(880, 392);
            this.gbx_Polaczenie.TabIndex = 3;
            this.gbx_Polaczenie.TabStop = false;
            this.gbx_Polaczenie.Text = "Połączenie";
            // 
            // btn_CONNECT
            // 
            this.btn_CONNECT.BackColor = System.Drawing.SystemColors.Control;
            this.btn_CONNECT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_CONNECT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_CONNECT.Location = new System.Drawing.Point(420, 213);
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
            this.txt_PORT.Location = new System.Drawing.Point(440, 173);
            this.txt_PORT.Name = "txt_PORT";
            this.txt_PORT.Size = new System.Drawing.Size(185, 32);
            this.txt_PORT.TabIndex = 8;
            // 
            // txt_IP
            // 
            this.txt_IP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_IP.Location = new System.Drawing.Point(440, 133);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(185, 32);
            this.txt_IP.TabIndex = 7;
            // 
            // lbl_PORT
            // 
            this.lbl_PORT.AutoSize = true;
            this.lbl_PORT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PORT.Location = new System.Drawing.Point(255, 173);
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
            this.lbl_IP.Location = new System.Drawing.Point(255, 133);
            this.lbl_IP.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(185, 26);
            this.lbl_IP.TabIndex = 5;
            this.lbl_IP.Text = "Adres IP serwera:";
            this.lbl_IP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbx_Plik
            // 
            this.gbx_Plik.Controls.Add(this.txt_haslo);
            this.gbx_Plik.Controls.Add(this.btn_wyczysc_pliki);
            this.gbx_Plik.Controls.Add(this.cbx_ustaw_archiwum);
            this.gbx_Plik.Controls.Add(this.lbl_wybierz_nazwe);
            this.gbx_Plik.Controls.Add(this.lbl_zip_path);
            this.gbx_Plik.Controls.Add(this.label15);
            this.gbx_Plik.Controls.Add(this.label14);
            this.gbx_Plik.Controls.Add(this.cbx_czy_haslo);
            this.gbx_Plik.Controls.Add(this.cbx_zaznacz_pliki);
            this.gbx_Plik.Controls.Add(this.btn_wybierz_pliki);
            this.gbx_Plik.Controls.Add(this.btn_utworz);
            this.gbx_Plik.Controls.Add(this.clbx_lista_plikow);
            this.gbx_Plik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbx_Plik.Location = new System.Drawing.Point(30, 24);
            this.gbx_Plik.Name = "gbx_Plik";
            this.gbx_Plik.Size = new System.Drawing.Size(880, 389);
            this.gbx_Plik.TabIndex = 4;
            this.gbx_Plik.TabStop = false;
            this.gbx_Plik.Text = "Plik";
            // 
            // txt_haslo
            // 
            this.txt_haslo.Location = new System.Drawing.Point(558, 269);
            this.txt_haslo.Name = "txt_haslo";
            this.txt_haslo.Size = new System.Drawing.Size(157, 26);
            this.txt_haslo.TabIndex = 14;
            // 
            // btn_wyczysc_pliki
            // 
            this.btn_wyczysc_pliki.Location = new System.Drawing.Point(558, 300);
            this.btn_wyczysc_pliki.Name = "btn_wyczysc_pliki";
            this.btn_wyczysc_pliki.Size = new System.Drawing.Size(105, 29);
            this.btn_wyczysc_pliki.TabIndex = 13;
            this.btn_wyczysc_pliki.Text = "Wyczyść";
            this.btn_wyczysc_pliki.UseVisualStyleBackColor = true;
            this.btn_wyczysc_pliki.Click += new System.EventHandler(this.btn_wyczysc_pliki_Click);
            // 
            // cbx_ustaw_archiwum
            // 
            this.cbx_ustaw_archiwum.AutoSize = true;
            this.cbx_ustaw_archiwum.Location = new System.Drawing.Point(558, 199);
            this.cbx_ustaw_archiwum.Name = "cbx_ustaw_archiwum";
            this.cbx_ustaw_archiwum.Size = new System.Drawing.Size(159, 24);
            this.cbx_ustaw_archiwum.TabIndex = 12;
            this.cbx_ustaw_archiwum.Text = "Ustaw do wysłania";
            this.cbx_ustaw_archiwum.UseVisualStyleBackColor = true;
            // 
            // lbl_wybierz_nazwe
            // 
            this.lbl_wybierz_nazwe.AutoSize = true;
            this.lbl_wybierz_nazwe.Location = new System.Drawing.Point(554, 57);
            this.lbl_wybierz_nazwe.Name = "lbl_wybierz_nazwe";
            this.lbl_wybierz_nazwe.Size = new System.Drawing.Size(77, 20);
            this.lbl_wybierz_nazwe.TabIndex = 11;
            this.lbl_wybierz_nazwe.Text = "Wybierz...";
            this.lbl_wybierz_nazwe.DoubleClick += new System.EventHandler(this.lbl_wybierz_nazwe_DoubleClick);
            // 
            // lbl_zip_path
            // 
            this.lbl_zip_path.AutoSize = true;
            this.lbl_zip_path.Location = new System.Drawing.Point(554, 114);
            this.lbl_zip_path.Name = "lbl_zip_path";
            this.lbl_zip_path.Size = new System.Drawing.Size(77, 20);
            this.lbl_zip_path.TabIndex = 10;
            this.lbl_zip_path.Text = "Wybierz...";
            this.lbl_zip_path.DoubleClick += new System.EventHandler(this.lbl_zip_path_DoubleClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(554, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 20);
            this.label15.TabIndex = 9;
            this.label15.Text = "Miejsce zapisu:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(554, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 20);
            this.label14.TabIndex = 8;
            this.label14.Text = "Nazwa archiwum:";
            // 
            // cbx_czy_haslo
            // 
            this.cbx_czy_haslo.AutoSize = true;
            this.cbx_czy_haslo.Location = new System.Drawing.Point(558, 234);
            this.cbx_czy_haslo.Name = "cbx_czy_haslo";
            this.cbx_czy_haslo.Size = new System.Drawing.Size(116, 24);
            this.cbx_czy_haslo.TabIndex = 6;
            this.cbx_czy_haslo.Text = "Ustaw hasło";
            this.cbx_czy_haslo.UseVisualStyleBackColor = true;
            this.cbx_czy_haslo.Click += new System.EventHandler(this.cbx_czy_haslo_Click);
            // 
            // cbx_zaznacz_pliki
            // 
            this.cbx_zaznacz_pliki.AutoSize = true;
            this.cbx_zaznacz_pliki.Location = new System.Drawing.Point(558, 164);
            this.cbx_zaznacz_pliki.Name = "cbx_zaznacz_pliki";
            this.cbx_zaznacz_pliki.Size = new System.Drawing.Size(157, 24);
            this.cbx_zaznacz_pliki.TabIndex = 5;
            this.cbx_zaznacz_pliki.Text = "Zaznacz wszystko";
            this.cbx_zaznacz_pliki.UseVisualStyleBackColor = true;
            this.cbx_zaznacz_pliki.Click += new System.EventHandler(this.cbx_zaznacz_pliki_Click);
            // 
            // btn_wybierz_pliki
            // 
            this.btn_wybierz_pliki.Location = new System.Drawing.Point(30, 337);
            this.btn_wybierz_pliki.Name = "btn_wybierz_pliki";
            this.btn_wybierz_pliki.Size = new System.Drawing.Size(105, 29);
            this.btn_wybierz_pliki.TabIndex = 4;
            this.btn_wybierz_pliki.Text = "Wybierz...";
            this.btn_wybierz_pliki.UseVisualStyleBackColor = true;
            this.btn_wybierz_pliki.Click += new System.EventHandler(this.btn_wybierz_pliki_Click);
            // 
            // btn_utworz
            // 
            this.btn_utworz.Location = new System.Drawing.Point(745, 337);
            this.btn_utworz.Name = "btn_utworz";
            this.btn_utworz.Size = new System.Drawing.Size(105, 29);
            this.btn_utworz.TabIndex = 3;
            this.btn_utworz.Text = "Utwórz";
            this.btn_utworz.UseVisualStyleBackColor = true;
            this.btn_utworz.Click += new System.EventHandler(this.btn_utworz_Click);
            // 
            // clbx_lista_plikow
            // 
            this.clbx_lista_plikow.AllowDrop = true;
            this.clbx_lista_plikow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbx_lista_plikow.FormattingEnabled = true;
            this.clbx_lista_plikow.HorizontalScrollbar = true;
            this.clbx_lista_plikow.Location = new System.Drawing.Point(30, 30);
            this.clbx_lista_plikow.Name = "clbx_lista_plikow";
            this.clbx_lista_plikow.Size = new System.Drawing.Size(518, 296);
            this.clbx_lista_plikow.TabIndex = 0;
            this.clbx_lista_plikow.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbx_lista_plikow_ItemCheck);
            this.clbx_lista_plikow.DragDrop += new System.Windows.Forms.DragEventHandler(this.clbx_lista_plikow_DragDrop);
            this.clbx_lista_plikow.DragEnter += new System.Windows.Forms.DragEventHandler(this.clbx_lista_plikow_DragEnter);
            this.clbx_lista_plikow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.clbx_lista_plikow_KeyUp);
            // 
            // gbx_Panel
            // 
            this.gbx_Panel.BackColor = System.Drawing.SystemColors.Control;
            this.gbx_Panel.Controls.Add(this.btn_wyslij);
            this.gbx_Panel.Controls.Add(this.gbx_archiwum);
            this.gbx_Panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbx_Panel.Location = new System.Drawing.Point(30, 24);
            this.gbx_Panel.Name = "gbx_Panel";
            this.gbx_Panel.Size = new System.Drawing.Size(880, 392);
            this.gbx_Panel.TabIndex = 5;
            this.gbx_Panel.TabStop = false;
            this.gbx_Panel.Text = "Panel użytkownika";
            // 
            // btn_wyslij
            // 
            this.btn_wyslij.Location = new System.Drawing.Point(769, 354);
            this.btn_wyslij.Name = "btn_wyslij";
            this.btn_wyslij.Size = new System.Drawing.Size(105, 29);
            this.btn_wyslij.TabIndex = 1;
            this.btn_wyslij.Text = "Wyślij";
            this.btn_wyslij.UseVisualStyleBackColor = true;
            this.btn_wyslij.Click += new System.EventHandler(this.btn_wyslij_Click);
            // 
            // gbx_archiwum
            // 
            this.gbx_archiwum.Controls.Add(this.btn_zmien_archiwum);
            this.gbx_archiwum.Controls.Add(this.lbl_lokalizacja_pliku);
            this.gbx_archiwum.Controls.Add(this.lbl_nazwa_pliku);
            this.gbx_archiwum.Controls.Add(this.label17);
            this.gbx_archiwum.Controls.Add(this.label16);
            this.gbx_archiwum.Location = new System.Drawing.Point(7, 26);
            this.gbx_archiwum.Name = "gbx_archiwum";
            this.gbx_archiwum.Size = new System.Drawing.Size(756, 133);
            this.gbx_archiwum.TabIndex = 0;
            this.gbx_archiwum.TabStop = false;
            this.gbx_archiwum.Text = "Archiwum";
            // 
            // btn_zmien_archiwum
            // 
            this.btn_zmien_archiwum.Location = new System.Drawing.Point(637, 90);
            this.btn_zmien_archiwum.Name = "btn_zmien_archiwum";
            this.btn_zmien_archiwum.Size = new System.Drawing.Size(105, 29);
            this.btn_zmien_archiwum.TabIndex = 5;
            this.btn_zmien_archiwum.Text = "Zmień";
            this.btn_zmien_archiwum.UseVisualStyleBackColor = true;
            this.btn_zmien_archiwum.Click += new System.EventHandler(this.btn_zmien_archiwum_Click);
            // 
            // lbl_lokalizacja_pliku
            // 
            this.lbl_lokalizacja_pliku.AutoSize = true;
            this.lbl_lokalizacja_pliku.Location = new System.Drawing.Point(103, 60);
            this.lbl_lokalizacja_pliku.Name = "lbl_lokalizacja_pliku";
            this.lbl_lokalizacja_pliku.Size = new System.Drawing.Size(141, 20);
            this.lbl_lokalizacja_pliku.TabIndex = 4;
            this.lbl_lokalizacja_pliku.Text = "lbl_lokalizacja pliku";
            // 
            // lbl_nazwa_pliku
            // 
            this.lbl_nazwa_pliku.AutoSize = true;
            this.lbl_nazwa_pliku.Location = new System.Drawing.Point(68, 30);
            this.lbl_nazwa_pliku.Name = "lbl_nazwa_pliku";
            this.lbl_nazwa_pliku.Size = new System.Drawing.Size(120, 20);
            this.lbl_nazwa_pliku.TabIndex = 3;
            this.lbl_nazwa_pliku.Text = "lbl_nazwa_pliku";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 20);
            this.label17.TabIndex = 2;
            this.label17.Text = "Lokalizacja:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "Nazwa:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(944, 441);
            this.Controls.Add(this.sstr_belka);
            this.Controls.Add(this.mstr_Menu);
            this.Controls.Add(this.gbx_Panel);
            this.Controls.Add(this.gbx_Ustawienia);
            this.Controls.Add(this.gbx_Polaczenie);
            this.Controls.Add(this.gbx_Plik);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.mstr_Menu;
            this.Name = "MainWindow";
            this.Text = "Klient";
            this.sstr_belka.ResumeLayout(false);
            this.sstr_belka.PerformLayout();
            this.gbx_Ustawienia.ResumeLayout(false);
            this.gbx_Backup.ResumeLayout(false);
            this.gbx_Backup.PerformLayout();
            this.gbx_Ustawienia_polaczenia.ResumeLayout(false);
            this.gbx_Ustawienia_polaczenia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_bufor)).EndInit();
            this.gbx_DaneUzytkownika.ResumeLayout(false);
            this.gbx_DaneUzytkownika.PerformLayout();
            this.mstr_Menu.ResumeLayout(false);
            this.mstr_Menu.PerformLayout();
            this.gbx_Polaczenie.ResumeLayout(false);
            this.gbx_Polaczenie.PerformLayout();
            this.gbx_Plik.ResumeLayout(false);
            this.gbx_Plik.PerformLayout();
            this.gbx_Panel.ResumeLayout(false);
            this.gbx_archiwum.ResumeLayout(false);
            this.gbx_archiwum.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sstr_belka;
        private System.Windows.Forms.ToolStripStatusLabel tssl_label;
        private System.Windows.Forms.GroupBox gbx_Ustawienia;
        private System.Windows.Forms.MenuStrip mstr_Menu;
        private System.Windows.Forms.ToolStripMenuItem mtstr_Ustawienia;
        private System.Windows.Forms.ToolStripMenuItem mtstr_Plik;
        private System.Windows.Forms.ToolStripMenuItem mtstr_Panel;
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
        private System.Windows.Forms.GroupBox gbx_Ustawienia_polaczenia;
        private System.Windows.Forms.NumericUpDown nup_bufor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_path_polaczenie;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbx_Backup;
        private System.Windows.Forms.RadioButton rbtn_backup_off;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rbtn_backup_on;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_backup_workspace;
        private System.Windows.Forms.Label lbl_backup_zapis;
        private System.Windows.Forms.ComboBox cbx_interwal_zapisu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbx_szyfrowanie;
        private System.Windows.Forms.GroupBox gbx_Plik;
        private System.Windows.Forms.CheckBox cbx_ustaw_archiwum;
        private System.Windows.Forms.Label lbl_wybierz_nazwe;
        private System.Windows.Forms.Label lbl_zip_path;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbx_czy_haslo;
        private System.Windows.Forms.CheckBox cbx_zaznacz_pliki;
        private System.Windows.Forms.Button btn_wybierz_pliki;
        private System.Windows.Forms.Button btn_utworz;
        private System.Windows.Forms.CheckedListBox clbx_lista_plikow;
        private System.Windows.Forms.Button btn_wyczysc_pliki;
        private System.Windows.Forms.TextBox txt_haslo;
        private System.Windows.Forms.TextBox txt_szyfr;
        private System.Windows.Forms.GroupBox gbx_Panel;
        private System.Windows.Forms.GroupBox gbx_archiwum;
        private System.Windows.Forms.Button btn_wyslij;
        private System.Windows.Forms.Button btn_zmien_archiwum;
        private System.Windows.Forms.Label lbl_lokalizacja_pliku;
        private System.Windows.Forms.Label lbl_nazwa_pliku;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
    }
}