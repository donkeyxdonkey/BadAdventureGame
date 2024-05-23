namespace Assignment7_V2
{
    partial class TheGame
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
            this.components = new System.ComponentModel.Container();
            this.pbAnimation = new System.Windows.Forms.PictureBox();
            this.pbExclaimation = new System.Windows.Forms.PictureBox();
            this.pbPlayerPortrait = new System.Windows.Forms.PictureBox();
            this.animationEventTimer = new System.Windows.Forms.Timer(this.components);
            this.lblInventoryInfo = new System.Windows.Forms.Label();
            this.btnDebug = new System.Windows.Forms.Button();
            this.pbGameMenuActive = new System.Windows.Forms.PictureBox();
            this.lblDebug = new System.Windows.Forms.Label();
            this.portraitTimer = new System.Windows.Forms.Timer(this.components);
            this.pbMenuBrowse = new System.Windows.Forms.PictureBox();
            this.tbGameMessages = new System.Windows.Forms.Label();
            this.pbGame = new System.Windows.Forms.PictureBox();
            this.pbGameText = new System.Windows.Forms.PictureBox();
            this.pbGameMenu = new System.Windows.Forms.PictureBox();
            this.pbNPC1 = new System.Windows.Forms.PictureBox();
            this.pbBowl = new System.Windows.Forms.PictureBox();
            this.pbCat = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.GateLockoutTimer = new System.Windows.Forms.Timer(this.components);
            this.endGameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclaimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPortrait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameMenuActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNPC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBowl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAnimation
            // 
            this.pbAnimation.BackColor = System.Drawing.Color.Transparent;
            this.pbAnimation.Location = new System.Drawing.Point(379, 247);
            this.pbAnimation.Name = "pbAnimation";
            this.pbAnimation.Size = new System.Drawing.Size(16, 16);
            this.pbAnimation.TabIndex = 39;
            this.pbAnimation.TabStop = false;
            // 
            // pbExclaimation
            // 
            this.pbExclaimation.BackColor = System.Drawing.Color.Transparent;
            this.pbExclaimation.BackgroundImage = global::Assignment7_V2.GameResources.exclaimation;
            this.pbExclaimation.Location = new System.Drawing.Point(395, 325);
            this.pbExclaimation.Name = "pbExclaimation";
            this.pbExclaimation.Size = new System.Drawing.Size(16, 16);
            this.pbExclaimation.TabIndex = 38;
            this.pbExclaimation.TabStop = false;
            // 
            // pbPlayerPortrait
            // 
            this.pbPlayerPortrait.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayerPortrait.Location = new System.Drawing.Point(39, 579);
            this.pbPlayerPortrait.Name = "pbPlayerPortrait";
            this.pbPlayerPortrait.Size = new System.Drawing.Size(32, 32);
            this.pbPlayerPortrait.TabIndex = 31;
            this.pbPlayerPortrait.TabStop = false;
            // 
            // animationEventTimer
            // 
            this.animationEventTimer.Tick += new System.EventHandler(this.animationEventTimer_Tick);
            // 
            // lblInventoryInfo
            // 
            this.lblInventoryInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInventoryInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInventoryInfo.Location = new System.Drawing.Point(108, 556);
            this.lblInventoryInfo.Name = "lblInventoryInfo";
            this.lblInventoryInfo.Size = new System.Drawing.Size(600, 16);
            this.lblInventoryInfo.TabIndex = 37;
            this.lblInventoryInfo.Text = "Inventory Info";
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(783, 647);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(20, 20);
            this.btnDebug.TabIndex = 36;
            this.btnDebug.Text = "X";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // pbGameMenuActive
            // 
            this.pbGameMenuActive.BackColor = System.Drawing.Color.Transparent;
            this.pbGameMenuActive.Location = new System.Drawing.Point(0, 0);
            this.pbGameMenuActive.Name = "pbGameMenuActive";
            this.pbGameMenuActive.Size = new System.Drawing.Size(800, 480);
            this.pbGameMenuActive.TabIndex = 35;
            this.pbGameMenuActive.TabStop = false;
            // 
            // lblDebug
            // 
            this.lblDebug.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDebug.Location = new System.Drawing.Point(5, 651);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(772, 23);
            this.lblDebug.TabIndex = 32;
            this.lblDebug.Text = "Debug";
            // 
            // portraitTimer
            // 
            this.portraitTimer.Interval = 2500;
            this.portraitTimer.Tick += new System.EventHandler(this.portraitTimer_Tick);
            // 
            // pbMenuBrowse
            // 
            this.pbMenuBrowse.Location = new System.Drawing.Point(274, 570);
            this.pbMenuBrowse.Name = "pbMenuBrowse";
            this.pbMenuBrowse.Size = new System.Drawing.Size(20, 20);
            this.pbMenuBrowse.TabIndex = 34;
            this.pbMenuBrowse.TabStop = false;
            // 
            // tbGameMessages
            // 
            this.tbGameMessages.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbGameMessages.Location = new System.Drawing.Point(5, 505);
            this.tbGameMessages.Name = "tbGameMessages";
            this.tbGameMessages.Size = new System.Drawing.Size(800, 41);
            this.tbGameMessages.TabIndex = 33;
            this.tbGameMessages.Text = "Game Messages";
            // 
            // pbGame
            // 
            this.pbGame.BackColor = System.Drawing.Color.Black;
            this.pbGame.Location = new System.Drawing.Point(5, 5);
            this.pbGame.Name = "pbGame";
            this.pbGame.Size = new System.Drawing.Size(800, 480);
            this.pbGame.TabIndex = 24;
            this.pbGame.TabStop = false;
            // 
            // pbGameText
            // 
            this.pbGameText.BackColor = System.Drawing.Color.Black;
            this.pbGameText.Location = new System.Drawing.Point(5, 485);
            this.pbGameText.Name = "pbGameText";
            this.pbGameText.Size = new System.Drawing.Size(800, 64);
            this.pbGameText.TabIndex = 30;
            this.pbGameText.TabStop = false;
            // 
            // pbGameMenu
            // 
            this.pbGameMenu.BackColor = System.Drawing.Color.Black;
            this.pbGameMenu.Location = new System.Drawing.Point(5, 549);
            this.pbGameMenu.Name = "pbGameMenu";
            this.pbGameMenu.Size = new System.Drawing.Size(800, 96);
            this.pbGameMenu.TabIndex = 29;
            this.pbGameMenu.TabStop = false;
            // 
            // pbNPC1
            // 
            this.pbNPC1.BackColor = System.Drawing.Color.Transparent;
            this.pbNPC1.Location = new System.Drawing.Point(448, 160);
            this.pbNPC1.Name = "pbNPC1";
            this.pbNPC1.Size = new System.Drawing.Size(32, 32);
            this.pbNPC1.TabIndex = 28;
            this.pbNPC1.TabStop = false;
            // 
            // pbBowl
            // 
            this.pbBowl.BackColor = System.Drawing.Color.Transparent;
            this.pbBowl.Location = new System.Drawing.Point(288, 96);
            this.pbBowl.Name = "pbBowl";
            this.pbBowl.Size = new System.Drawing.Size(32, 32);
            this.pbBowl.TabIndex = 27;
            this.pbBowl.TabStop = false;
            // 
            // pbCat
            // 
            this.pbCat.BackColor = System.Drawing.Color.Transparent;
            this.pbCat.Location = new System.Drawing.Point(64, 86);
            this.pbCat.Name = "pbCat";
            this.pbCat.Size = new System.Drawing.Size(32, 32);
            this.pbCat.TabIndex = 26;
            this.pbCat.TabStop = false;
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer.Location = new System.Drawing.Point(384, 184);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(32, 32);
            this.pbPlayer.TabIndex = 25;
            this.pbPlayer.TabStop = false;
            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 62;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // GateLockoutTimer
            // 
            this.GateLockoutTimer.Interval = 550;
            this.GateLockoutTimer.Tick += new System.EventHandler(this.GateLockoutTimer_Tick);
            // 
            // endGameTimer
            // 
            this.endGameTimer.Interval = 5000;
            this.endGameTimer.Tick += new System.EventHandler(this.endGameTimer_Tick);
            // 
            // TheGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(810, 671);
            this.Controls.Add(this.pbAnimation);
            this.Controls.Add(this.pbExclaimation);
            this.Controls.Add(this.pbPlayerPortrait);
            this.Controls.Add(this.lblInventoryInfo);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.pbGameMenuActive);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.pbMenuBrowse);
            this.Controls.Add(this.tbGameMessages);
            this.Controls.Add(this.pbGame);
            this.Controls.Add(this.pbGameText);
            this.Controls.Add(this.pbGameMenu);
            this.Controls.Add(this.pbNPC1);
            this.Controls.Add(this.pbBowl);
            this.Controls.Add(this.pbCat);
            this.Controls.Add(this.pbPlayer);
            this.MaximizeBox = false;
            this.Name = "TheGame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TheGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExclaimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPortrait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameMenuActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNPC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBowl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAnimation;
        private System.Windows.Forms.PictureBox pbExclaimation;
        private System.Windows.Forms.PictureBox pbPlayerPortrait;
        private System.Windows.Forms.Timer animationEventTimer;
        private System.Windows.Forms.Label lblInventoryInfo;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.PictureBox pbGameMenuActive;
        private System.Windows.Forms.Label lblDebug;
        private System.Windows.Forms.Timer portraitTimer;
        private System.Windows.Forms.PictureBox pbMenuBrowse;
        private System.Windows.Forms.Label tbGameMessages;
        private System.Windows.Forms.PictureBox pbGame;
        private System.Windows.Forms.PictureBox pbGameText;
        private System.Windows.Forms.PictureBox pbGameMenu;
        private System.Windows.Forms.PictureBox pbNPC1;
        private System.Windows.Forms.PictureBox pbBowl;
        private System.Windows.Forms.PictureBox pbCat;
        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.Timer GateLockoutTimer;
        private System.Windows.Forms.Timer endGameTimer;
    }
}

