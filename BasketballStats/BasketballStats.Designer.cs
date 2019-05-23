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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasketballStats));
            this.leftMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.appName = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.topMenu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.CreateGamePanel = new System.Windows.Forms.Panel();
            this.newTeamInput = new System.Windows.Forms.TextBox();
            this.createTeamBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.homeBtn = new System.Windows.Forms.PictureBox();
            this.createGameBtn = new System.Windows.Forms.PictureBox();
            this.leftMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.topMenu.SuspendLayout();
            this.CreateGamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.createGameBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // leftMenu
            // 
            this.leftMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.leftMenu.Controls.Add(this.createGameBtn);
            this.leftMenu.Controls.Add(this.homeBtn);
            this.leftMenu.Controls.Add(this.panel1);
            this.leftMenu.Location = new System.Drawing.Point(0, 0);
            this.leftMenu.Name = "leftMenu";
            this.leftMenu.Size = new System.Drawing.Size(230, 680);
            this.leftMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.appName);
            this.panel1.Controls.Add(this.ball);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 70);
            this.panel1.TabIndex = 0;
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
            this.topMenu.Controls.Add(this.label2);
            this.topMenu.Controls.Add(this.MessageLabel);
            this.topMenu.Location = new System.Drawing.Point(230, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(790, 70);
            this.topMenu.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(751, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.Exit);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageLabel.Location = new System.Drawing.Point(9, 10);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(0, 20);
            this.MessageLabel.TabIndex = 0;
            // 
            // CreateGamePanel
            // 
            this.CreateGamePanel.Controls.Add(this.newTeamInput);
            this.CreateGamePanel.Controls.Add(this.createTeamBtn);
            this.CreateGamePanel.Controls.Add(this.label1);
            this.CreateGamePanel.Location = new System.Drawing.Point(230, 70);
            this.CreateGamePanel.Name = "CreateGamePanel";
            this.CreateGamePanel.Size = new System.Drawing.Size(790, 610);
            this.CreateGamePanel.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izveidot Komandu:";
            // 
            // homeBtn
            // 
            this.homeBtn.Image = ((System.Drawing.Image)(resources.GetObject("homeBtn.Image")));
            this.homeBtn.Location = new System.Drawing.Point(50, 76);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(107, 83);
            this.homeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homeBtn.TabIndex = 1;
            this.homeBtn.TabStop = false;
            // 
            // createGameBtn
            // 
            this.createGameBtn.Image = ((System.Drawing.Image)(resources.GetObject("createGameBtn.Image")));
            this.createGameBtn.Location = new System.Drawing.Point(60, 185);
            this.createGameBtn.Name = "createGameBtn";
            this.createGameBtn.Size = new System.Drawing.Size(97, 83);
            this.createGameBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.createGameBtn.TabIndex = 2;
            this.createGameBtn.TabStop = false;
            this.createGameBtn.Click += new System.EventHandler(this.CreateNewGame);
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
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.CreateGamePanel.ResumeLayout(false);
            this.CreateGamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.createGameBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Panel topMenu;
        private System.Windows.Forms.Panel CreateGamePanel;
        private System.Windows.Forms.TextBox newTeamInput;
        private System.Windows.Forms.Button createTeamBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox createGameBtn;
        private System.Windows.Forms.PictureBox homeBtn;
    }
}

