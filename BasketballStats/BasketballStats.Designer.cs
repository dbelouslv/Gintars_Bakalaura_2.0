namespace BasketballStats
{
    partial class BasketballStats
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasketballStats));
            this.leftMenu = new System.Windows.Forms.Panel();
            this.createGameBtn = new System.Windows.Forms.PictureBox();
            this.homeBtn = new System.Windows.Forms.PictureBox();
            this.blackTopPanel = new System.Windows.Forms.Panel();
            this.appName = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.topMenu = new System.Windows.Forms.Panel();
            this.exitLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.CreateGamePanel = new System.Windows.Forms.Panel();
            this.izveidotSpeletaju = new System.Windows.Forms.Label();
            this.savePlayerBtn = new System.Windows.Forms.Button();
            this.selectedTeams = new System.Windows.Forms.ComboBox();
            this.numberInput = new System.Windows.Forms.TextBox();
            this.surnameInput = new System.Windows.Forms.TextBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.izveidotLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timeInput = new System.Windows.Forms.TextBox();
            this.vieta = new System.Windows.Forms.Label();
            this.placeInput = new System.Windows.Forms.TextBox();
            this.dateInput = new System.Windows.Forms.TextBox();
            this.datums = new System.Windows.Forms.Label();
            this.hrThird = new System.Windows.Forms.Panel();
            this.nLabel4 = new System.Windows.Forms.Label();
            this.nLabel3 = new System.Windows.Forms.Label();
            this.reffereTwo = new System.Windows.Forms.TextBox();
            this.reffereOne = new System.Windows.Forms.TextBox();
            this.tiesnesi = new System.Windows.Forms.Label();
            this.hrSecond = new System.Windows.Forms.Panel();
            this.nLabel2 = new System.Windows.Forms.Label();
            this.nLabel1 = new System.Windows.Forms.Label();
            this.selectedTeamTwo = new System.Windows.Forms.ComboBox();
            this.selectedTeamOne = new System.Windows.Forms.ComboBox();
            this.izveletiesKomandas = new System.Windows.Forms.Label();
            this.hrFirst = new System.Windows.Forms.Panel();
            this.newTeamInput = new System.Windows.Forms.TextBox();
            this.createTeamBtn = new System.Windows.Forms.Button();
            this.izveidotKomanduLabel = new System.Windows.Forms.Label();
            this.teamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.leftMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createGameBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeBtn)).BeginInit();
            this.blackTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.topMenu.SuspendLayout();
            this.CreateGamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // leftMenu
            // 
            this.leftMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.leftMenu.Controls.Add(this.createGameBtn);
            this.leftMenu.Controls.Add(this.homeBtn);
            this.leftMenu.Controls.Add(this.blackTopPanel);
            this.leftMenu.Location = new System.Drawing.Point(0, 0);
            this.leftMenu.Name = "leftMenu";
            this.leftMenu.Size = new System.Drawing.Size(230, 680);
            this.leftMenu.TabIndex = 0;
            // 
            // createGameBtn
            // 
            this.createGameBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createGameBtn.Image = ((System.Drawing.Image)(resources.GetObject("createGameBtn.Image")));
            this.createGameBtn.Location = new System.Drawing.Point(60, 185);
            this.createGameBtn.Name = "createGameBtn";
            this.createGameBtn.Size = new System.Drawing.Size(97, 83);
            this.createGameBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.createGameBtn.TabIndex = 2;
            this.createGameBtn.TabStop = false;
            this.createGameBtn.Click += new System.EventHandler(this.CreateNewGame);
            // 
            // homeBtn
            // 
            this.homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeBtn.Image = ((System.Drawing.Image)(resources.GetObject("homeBtn.Image")));
            this.homeBtn.Location = new System.Drawing.Point(50, 76);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(107, 83);
            this.homeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homeBtn.TabIndex = 1;
            this.homeBtn.TabStop = false;
            // 
            // blackTopPanel
            // 
            this.blackTopPanel.BackColor = System.Drawing.Color.Black;
            this.blackTopPanel.Controls.Add(this.appName);
            this.blackTopPanel.Controls.Add(this.ball);
            this.blackTopPanel.Location = new System.Drawing.Point(0, 0);
            this.blackTopPanel.Name = "blackTopPanel";
            this.blackTopPanel.Size = new System.Drawing.Size(230, 70);
            this.blackTopPanel.TabIndex = 0;
            // 
            // appName
            // 
            this.appName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.appName.ForeColor = System.Drawing.Color.White;
            this.appName.Location = new System.Drawing.Point(68, 9);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(150, 58);
            this.appName.TabIndex = 1;
            this.appName.Text = "BASKETABALLSTATS";
            this.appName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ball
            // 
            this.ball.Image = ((System.Drawing.Image)(resources.GetObject("ball.Image")));
            this.ball.Location = new System.Drawing.Point(0, 3);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(62, 64);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ball.TabIndex = 0;
            this.ball.TabStop = false;
            // 
            // topMenu
            // 
            this.topMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.topMenu.Controls.Add(this.exitLabel);
            this.topMenu.Controls.Add(this.messageLabel);
            this.topMenu.Location = new System.Drawing.Point(230, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(790, 70);
            this.topMenu.TabIndex = 1;
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitLabel.Location = new System.Drawing.Point(751, 3);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(27, 25);
            this.exitLabel.TabIndex = 1;
            this.exitLabel.Text = "X";
            this.exitLabel.Click += new System.EventHandler(this.Exit);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageLabel.Location = new System.Drawing.Point(9, 10);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 20);
            this.messageLabel.TabIndex = 0;
            // 
            // CreateGamePanel
            // 
            this.CreateGamePanel.Controls.Add(this.izveidotSpeletaju);
            this.CreateGamePanel.Controls.Add(this.savePlayerBtn);
            this.CreateGamePanel.Controls.Add(this.selectedTeams);
            this.CreateGamePanel.Controls.Add(this.numberInput);
            this.CreateGamePanel.Controls.Add(this.surnameInput);
            this.CreateGamePanel.Controls.Add(this.nameInput);
            this.CreateGamePanel.Controls.Add(this.izveidotLabel);
            this.CreateGamePanel.Controls.Add(this.panel1);
            this.CreateGamePanel.Controls.Add(this.label1);
            this.CreateGamePanel.Controls.Add(this.timeInput);
            this.CreateGamePanel.Controls.Add(this.vieta);
            this.CreateGamePanel.Controls.Add(this.placeInput);
            this.CreateGamePanel.Controls.Add(this.dateInput);
            this.CreateGamePanel.Controls.Add(this.datums);
            this.CreateGamePanel.Controls.Add(this.hrThird);
            this.CreateGamePanel.Controls.Add(this.nLabel4);
            this.CreateGamePanel.Controls.Add(this.nLabel3);
            this.CreateGamePanel.Controls.Add(this.reffereTwo);
            this.CreateGamePanel.Controls.Add(this.reffereOne);
            this.CreateGamePanel.Controls.Add(this.tiesnesi);
            this.CreateGamePanel.Controls.Add(this.hrSecond);
            this.CreateGamePanel.Controls.Add(this.nLabel2);
            this.CreateGamePanel.Controls.Add(this.nLabel1);
            this.CreateGamePanel.Controls.Add(this.selectedTeamTwo);
            this.CreateGamePanel.Controls.Add(this.selectedTeamOne);
            this.CreateGamePanel.Controls.Add(this.izveletiesKomandas);
            this.CreateGamePanel.Controls.Add(this.hrFirst);
            this.CreateGamePanel.Controls.Add(this.newTeamInput);
            this.CreateGamePanel.Controls.Add(this.createTeamBtn);
            this.CreateGamePanel.Controls.Add(this.izveidotKomanduLabel);
            this.CreateGamePanel.Location = new System.Drawing.Point(230, 70);
            this.CreateGamePanel.Name = "CreateGamePanel";
            this.CreateGamePanel.Size = new System.Drawing.Size(790, 610);
            this.CreateGamePanel.TabIndex = 2;
            // 
            // izveidotSpeletaju
            // 
            this.izveidotSpeletaju.AutoSize = true;
            this.izveidotSpeletaju.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.izveidotSpeletaju.Location = new System.Drawing.Point(11, 175);
            this.izveidotSpeletaju.Name = "izveidotSpeletaju";
            this.izveidotSpeletaju.Size = new System.Drawing.Size(150, 20);
            this.izveidotSpeletaju.TabIndex = 26;
            this.izveidotSpeletaju.Text = "Izveidot spēlētāju";
            // 
            // savePlayerBtn
            // 
            this.savePlayerBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.savePlayerBtn.FlatAppearance.BorderSize = 2;
            this.savePlayerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savePlayerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.savePlayerBtn.ForeColor = System.Drawing.Color.Black;
            this.savePlayerBtn.Location = new System.Drawing.Point(724, 172);
            this.savePlayerBtn.Name = "savePlayerBtn";
            this.savePlayerBtn.Size = new System.Drawing.Size(47, 26);
            this.savePlayerBtn.TabIndex = 25;
            this.savePlayerBtn.Text = "OK";
            this.savePlayerBtn.UseVisualStyleBackColor = true;
            this.savePlayerBtn.Click += new System.EventHandler(this.SavePlayer);
            // 
            // selectedTeams
            // 
            this.selectedTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectedTeams.FormattingEnabled = true;
            this.selectedTeams.Location = new System.Drawing.Point(543, 172);
            this.selectedTeams.MaxDropDownItems = 24;
            this.selectedTeams.Name = "selectedTeams";
            this.selectedTeams.Size = new System.Drawing.Size(168, 26);
            this.selectedTeams.TabIndex = 24;
            // 
            // numberInput
            // 
            this.numberInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberInput.Location = new System.Drawing.Point(484, 172);
            this.numberInput.Name = "numberInput";
            this.numberInput.Size = new System.Drawing.Size(45, 26);
            this.numberInput.TabIndex = 23;
            // 
            // surnameInput
            // 
            this.surnameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.surnameInput.Location = new System.Drawing.Point(328, 172);
            this.surnameInput.Name = "surnameInput";
            this.surnameInput.Size = new System.Drawing.Size(150, 26);
            this.surnameInput.TabIndex = 22;
            // 
            // nameInput
            // 
            this.nameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameInput.Location = new System.Drawing.Point(172, 172);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(150, 26);
            this.nameInput.TabIndex = 21;
            // 
            // izveidotLabel
            // 
            this.izveidotLabel.AutoSize = true;
            this.izveidotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.izveidotLabel.Location = new System.Drawing.Point(161, 139);
            this.izveidotLabel.Name = "izveidotLabel";
            this.izveidotLabel.Size = new System.Drawing.Size(512, 20);
            this.izveidotLabel.TabIndex = 20;
            this.izveidotLabel.Text = "             Vārds                    Uzvārds       Numurs           Komanda";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(15, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 2);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(720, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Laiks";
            // 
            // timeInput
            // 
            this.timeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeInput.Location = new System.Drawing.Point(717, 26);
            this.timeInput.Name = "timeInput";
            this.timeInput.Size = new System.Drawing.Size(61, 26);
            this.timeInput.TabIndex = 8;
            // 
            // vieta
            // 
            this.vieta.AutoSize = true;
            this.vieta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vieta.Location = new System.Drawing.Point(650, 61);
            this.vieta.Name = "vieta";
            this.vieta.Size = new System.Drawing.Size(51, 20);
            this.vieta.TabIndex = 17;
            this.vieta.Text = "Vieta";
            // 
            // placeInput
            // 
            this.placeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.placeInput.Location = new System.Drawing.Point(583, 84);
            this.placeInput.Name = "placeInput";
            this.placeInput.Size = new System.Drawing.Size(195, 26);
            this.placeInput.TabIndex = 9;
            // 
            // dateInput
            // 
            this.dateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateInput.Location = new System.Drawing.Point(583, 26);
            this.dateInput.Name = "dateInput";
            this.dateInput.Size = new System.Drawing.Size(128, 26);
            this.dateInput.TabIndex = 7;
            // 
            // datums
            // 
            this.datums.AutoSize = true;
            this.datums.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datums.Location = new System.Drawing.Point(612, 3);
            this.datums.Name = "datums";
            this.datums.Size = new System.Drawing.Size(71, 20);
            this.datums.TabIndex = 14;
            this.datums.Text = "Datums";
            // 
            // hrThird
            // 
            this.hrThird.BackColor = System.Drawing.Color.Black;
            this.hrThird.Location = new System.Drawing.Point(575, 5);
            this.hrThird.Name = "hrThird";
            this.hrThird.Size = new System.Drawing.Size(2, 110);
            this.hrThird.TabIndex = 5;
            // 
            // nLabel4
            // 
            this.nLabel4.AutoSize = true;
            this.nLabel4.BackColor = System.Drawing.Color.Transparent;
            this.nLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nLabel4.Location = new System.Drawing.Point(393, 85);
            this.nLabel4.Name = "nLabel4";
            this.nLabel4.Size = new System.Drawing.Size(24, 20);
            this.nLabel4.TabIndex = 13;
            this.nLabel4.Text = "2.";
            // 
            // nLabel3
            // 
            this.nLabel3.AutoSize = true;
            this.nLabel3.BackColor = System.Drawing.Color.Transparent;
            this.nLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nLabel3.Location = new System.Drawing.Point(393, 44);
            this.nLabel3.Name = "nLabel3";
            this.nLabel3.Size = new System.Drawing.Size(24, 20);
            this.nLabel3.TabIndex = 12;
            this.nLabel3.Text = "1.";
            // 
            // reffereTwo
            // 
            this.reffereTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reffereTwo.Location = new System.Drawing.Point(419, 82);
            this.reffereTwo.Name = "reffereTwo";
            this.reffereTwo.Size = new System.Drawing.Size(150, 26);
            this.reffereTwo.TabIndex = 6;
            // 
            // reffereOne
            // 
            this.reffereOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reffereOne.Location = new System.Drawing.Point(419, 40);
            this.reffereOne.Name = "reffereOne";
            this.reffereOne.Size = new System.Drawing.Size(150, 26);
            this.reffereOne.TabIndex = 5;
            // 
            // tiesnesi
            // 
            this.tiesnesi.AutoSize = true;
            this.tiesnesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tiesnesi.Location = new System.Drawing.Point(440, 3);
            this.tiesnesi.Name = "tiesnesi";
            this.tiesnesi.Size = new System.Drawing.Size(75, 20);
            this.tiesnesi.TabIndex = 9;
            this.tiesnesi.Text = "Tiesneši";
            // 
            // hrSecond
            // 
            this.hrSecond.BackColor = System.Drawing.Color.Black;
            this.hrSecond.Location = new System.Drawing.Point(390, 5);
            this.hrSecond.Name = "hrSecond";
            this.hrSecond.Size = new System.Drawing.Size(2, 110);
            this.hrSecond.TabIndex = 4;
            // 
            // nLabel2
            // 
            this.nLabel2.AutoSize = true;
            this.nLabel2.BackColor = System.Drawing.Color.Transparent;
            this.nLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nLabel2.Location = new System.Drawing.Point(188, 85);
            this.nLabel2.Name = "nLabel2";
            this.nLabel2.Size = new System.Drawing.Size(24, 20);
            this.nLabel2.TabIndex = 8;
            this.nLabel2.Text = "2.";
            // 
            // nLabel1
            // 
            this.nLabel1.AutoSize = true;
            this.nLabel1.BackColor = System.Drawing.Color.Transparent;
            this.nLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nLabel1.Location = new System.Drawing.Point(188, 43);
            this.nLabel1.Name = "nLabel1";
            this.nLabel1.Size = new System.Drawing.Size(24, 20);
            this.nLabel1.TabIndex = 7;
            this.nLabel1.Text = "1.";
            // 
            // selectedTeamTwo
            // 
            this.selectedTeamTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectedTeamTwo.FormattingEnabled = true;
            this.selectedTeamTwo.Location = new System.Drawing.Point(212, 82);
            this.selectedTeamTwo.MaxDropDownItems = 24;
            this.selectedTeamTwo.Name = "selectedTeamTwo";
            this.selectedTeamTwo.Size = new System.Drawing.Size(168, 26);
            this.selectedTeamTwo.TabIndex = 4;
            this.selectedTeamTwo.SelectionChangeCommitted += new System.EventHandler(this.SelectTeam);
            // 
            // selectedTeamOne
            // 
            this.selectedTeamOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectedTeamOne.FormattingEnabled = true;
            this.selectedTeamOne.Location = new System.Drawing.Point(212, 40);
            this.selectedTeamOne.MaxDropDownItems = 24;
            this.selectedTeamOne.Name = "selectedTeamOne";
            this.selectedTeamOne.Size = new System.Drawing.Size(168, 26);
            this.selectedTeamOne.TabIndex = 3;
            this.selectedTeamOne.SelectionChangeCommitted += new System.EventHandler(this.SelectTeam);
            // 
            // izveletiesKomandas
            // 
            this.izveletiesKomandas.AutoSize = true;
            this.izveletiesKomandas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.izveletiesKomandas.Location = new System.Drawing.Point(193, 3);
            this.izveletiesKomandas.Name = "izveletiesKomandas";
            this.izveletiesKomandas.Size = new System.Drawing.Size(172, 20);
            this.izveletiesKomandas.TabIndex = 4;
            this.izveletiesKomandas.Text = "Izvēlaties komandas";
            // 
            // hrFirst
            // 
            this.hrFirst.BackColor = System.Drawing.Color.Black;
            this.hrFirst.Location = new System.Drawing.Point(185, 5);
            this.hrFirst.Name = "hrFirst";
            this.hrFirst.Size = new System.Drawing.Size(2, 110);
            this.hrFirst.TabIndex = 3;
            // 
            // newTeamInput
            // 
            this.newTeamInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newTeamInput.Location = new System.Drawing.Point(15, 40);
            this.newTeamInput.Name = "newTeamInput";
            this.newTeamInput.Size = new System.Drawing.Size(150, 26);
            this.newTeamInput.TabIndex = 1;
            // 
            // createTeamBtn
            // 
            this.createTeamBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.createTeamBtn.FlatAppearance.BorderSize = 2;
            this.createTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTeamBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createTeamBtn.ForeColor = System.Drawing.Color.Black;
            this.createTeamBtn.Location = new System.Drawing.Point(15, 82);
            this.createTeamBtn.Name = "createTeamBtn";
            this.createTeamBtn.Size = new System.Drawing.Size(153, 31);
            this.createTeamBtn.TabIndex = 2;
            this.createTeamBtn.Text = "Izveidot";
            this.createTeamBtn.UseVisualStyleBackColor = true;
            this.createTeamBtn.Click += new System.EventHandler(this.CreateTeam);
            // 
            // izveidotKomanduLabel
            // 
            this.izveidotKomanduLabel.AutoSize = true;
            this.izveidotKomanduLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.izveidotKomanduLabel.Location = new System.Drawing.Point(11, 3);
            this.izveidotKomanduLabel.Name = "izveidotKomanduLabel";
            this.izveidotKomanduLabel.Size = new System.Drawing.Size(157, 20);
            this.izveidotKomanduLabel.TabIndex = 0;
            this.izveidotKomanduLabel.Text = "Izveidot Komandu:";
            // 
            // teamBindingSource
            // 
            this.teamBindingSource.DataSource = typeof(BS.EntityData.Context.Team);
            // 
            // BasketballStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 680);
            this.Controls.Add(this.CreateGamePanel);
            this.Controls.Add(this.topMenu);
            this.Controls.Add(this.leftMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BasketballStats";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BasketballStats";
            this.leftMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.createGameBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homeBtn)).EndInit();
            this.blackTopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.CreateGamePanel.ResumeLayout(false);
            this.CreateGamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftMenu;
        private System.Windows.Forms.Panel blackTopPanel;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Panel topMenu;
        private System.Windows.Forms.Panel CreateGamePanel;
        private System.Windows.Forms.TextBox newTeamInput;
        private System.Windows.Forms.Button createTeamBtn;
        private System.Windows.Forms.Label izveidotKomanduLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.PictureBox createGameBtn;
        private System.Windows.Forms.PictureBox homeBtn;
        private System.Windows.Forms.Label nLabel2;
        private System.Windows.Forms.Label nLabel1;
        private System.Windows.Forms.ComboBox selectedTeamTwo;
        private System.Windows.Forms.ComboBox selectedTeamOne;
        private System.Windows.Forms.Label izveletiesKomandas;
        private System.Windows.Forms.Panel hrFirst;
        private System.Windows.Forms.BindingSource teamBindingSource;
        private System.Windows.Forms.Panel hrSecond;
        private System.Windows.Forms.Label nLabel4;
        private System.Windows.Forms.Label nLabel3;
        private System.Windows.Forms.TextBox reffereTwo;
        private System.Windows.Forms.TextBox reffereOne;
        private System.Windows.Forms.Label tiesnesi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox timeInput;
        private System.Windows.Forms.Label vieta;
        private System.Windows.Forms.TextBox placeInput;
        private System.Windows.Forms.TextBox dateInput;
        private System.Windows.Forms.Label datums;
        private System.Windows.Forms.Panel hrThird;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label izveidotSpeletaju;
        private System.Windows.Forms.Button savePlayerBtn;
        private System.Windows.Forms.ComboBox selectedTeams;
        private System.Windows.Forms.TextBox numberInput;
        private System.Windows.Forms.TextBox surnameInput;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label izveidotLabel;
    }
}

