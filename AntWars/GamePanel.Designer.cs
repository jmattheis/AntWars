﻿namespace AntWars
{
    partial class GamePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePanel));
            this.timer_GameTick = new System.Windows.Forms.Timer(this.components);
            this.pb_Game = new System.Windows.Forms.PictureBox();
            this.groupstats = new System.Windows.Forms.GroupBox();
            this.groupgamestats = new System.Windows.Forms.GroupBox();
            this.labeltimer = new System.Windows.Forms.Label();
            this.labeltimershow = new System.Windows.Forms.Label();
            this.groupplayer1 = new System.Windows.Forms.GroupBox();
            this.labelplayer1points = new System.Windows.Forms.Label();
            this.labelplayer1pointsshow = new System.Windows.Forms.Label();
            this.labelplayer1money = new System.Windows.Forms.Label();
            this.labelplayer1moneyshow = new System.Windows.Forms.Label();
            this.groupplayer2 = new System.Windows.Forms.GroupBox();
            this.labelplayer2moneyshow = new System.Windows.Forms.Label();
            this.labelplayer2money = new System.Windows.Forms.Label();
            this.labelplayer2pointsshow = new System.Windows.Forms.Label();
            this.labelplayer2points = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Game)).BeginInit();
            this.groupstats.SuspendLayout();
            this.groupgamestats.SuspendLayout();
            this.groupplayer1.SuspendLayout();
            this.groupplayer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_GameTick
            // 
            this.timer_GameTick.Tick += new System.EventHandler(this.timer_GameTick_Tick);
            // 
            // pb_Game
            // 
            this.pb_Game.BackColor = System.Drawing.Color.White;
            this.pb_Game.Location = new System.Drawing.Point(0, 0);
            this.pb_Game.Name = "pb_Game";
            this.pb_Game.Size = new System.Drawing.Size(284, 261);
            this.pb_Game.TabIndex = 0;
            this.pb_Game.TabStop = false;
            this.pb_Game.Click += new System.EventHandler(this.pb_Game_Click);
            // 
            // groupstats
            // 
            this.groupstats.Controls.Add(this.groupplayer2);
            this.groupstats.Controls.Add(this.groupplayer1);
            this.groupstats.Controls.Add(this.groupgamestats);
            this.groupstats.Location = new System.Drawing.Point(290, 12);
            this.groupstats.Name = "groupstats";
            this.groupstats.Size = new System.Drawing.Size(142, 212);
            this.groupstats.TabIndex = 1;
            this.groupstats.TabStop = false;
            this.groupstats.Text = "Statistics";
            // 
            // groupgamestats
            // 
            this.groupgamestats.Controls.Add(this.labeltimershow);
            this.groupgamestats.Controls.Add(this.labeltimer);
            this.groupgamestats.Location = new System.Drawing.Point(7, 20);
            this.groupgamestats.Name = "groupgamestats";
            this.groupgamestats.Size = new System.Drawing.Size(129, 39);
            this.groupgamestats.TabIndex = 0;
            this.groupgamestats.TabStop = false;
            this.groupgamestats.Text = "Game";
            // 
            // labeltimer
            // 
            this.labeltimer.AutoSize = true;
            this.labeltimer.Location = new System.Drawing.Point(7, 20);
            this.labeltimer.Name = "labeltimer";
            this.labeltimer.Size = new System.Drawing.Size(30, 13);
            this.labeltimer.TabIndex = 0;
            this.labeltimer.Text = "Time";
            // 
            // labeltimershow
            // 
            this.labeltimershow.AutoSize = true;
            this.labeltimershow.Location = new System.Drawing.Point(78, 20);
            this.labeltimershow.Name = "labeltimershow";
            this.labeltimershow.Size = new System.Drawing.Size(51, 13);
            this.labeltimershow.TabIndex = 1;
            this.labeltimershow.Text = "hh:mm:ss";
            // 
            // groupplayer1
            // 
            this.groupplayer1.Controls.Add(this.labelplayer1moneyshow);
            this.groupplayer1.Controls.Add(this.labelplayer1money);
            this.groupplayer1.Controls.Add(this.labelplayer1pointsshow);
            this.groupplayer1.Controls.Add(this.labelplayer1points);
            this.groupplayer1.Location = new System.Drawing.Point(7, 66);
            this.groupplayer1.Name = "groupplayer1";
            this.groupplayer1.Size = new System.Drawing.Size(135, 66);
            this.groupplayer1.TabIndex = 1;
            this.groupplayer1.TabStop = false;
            this.groupplayer1.Text = "Player 1";
            // 
            // labelplayer1points
            // 
            this.labelplayer1points.AutoSize = true;
            this.labelplayer1points.Location = new System.Drawing.Point(7, 20);
            this.labelplayer1points.Name = "labelplayer1points";
            this.labelplayer1points.Size = new System.Drawing.Size(36, 13);
            this.labelplayer1points.TabIndex = 0;
            this.labelplayer1points.Text = "Points";
            // 
            // labelplayer1pointsshow
            // 
            this.labelplayer1pointsshow.AutoSize = true;
            this.labelplayer1pointsshow.Location = new System.Drawing.Point(92, 20);
            this.labelplayer1pointsshow.Name = "labelplayer1pointsshow";
            this.labelplayer1pointsshow.Size = new System.Drawing.Size(37, 13);
            this.labelplayer1pointsshow.TabIndex = 1;
            this.labelplayer1pointsshow.Text = "99999";
            // 
            // labelplayer1money
            // 
            this.labelplayer1money.AutoSize = true;
            this.labelplayer1money.Location = new System.Drawing.Point(7, 42);
            this.labelplayer1money.Name = "labelplayer1money";
            this.labelplayer1money.Size = new System.Drawing.Size(39, 13);
            this.labelplayer1money.TabIndex = 2;
            this.labelplayer1money.Text = "Money";
            // 
            // labelplayer1moneyshow
            // 
            this.labelplayer1moneyshow.AutoSize = true;
            this.labelplayer1moneyshow.Location = new System.Drawing.Point(92, 42);
            this.labelplayer1moneyshow.Name = "labelplayer1moneyshow";
            this.labelplayer1moneyshow.Size = new System.Drawing.Size(37, 13);
            this.labelplayer1moneyshow.TabIndex = 3;
            this.labelplayer1moneyshow.Text = "99999";
            // 
            // groupplayer2
            // 
            this.groupplayer2.Controls.Add(this.labelplayer2moneyshow);
            this.groupplayer2.Controls.Add(this.labelplayer2money);
            this.groupplayer2.Controls.Add(this.labelplayer2pointsshow);
            this.groupplayer2.Controls.Add(this.labelplayer2points);
            this.groupplayer2.Location = new System.Drawing.Point(7, 138);
            this.groupplayer2.Name = "groupplayer2";
            this.groupplayer2.Size = new System.Drawing.Size(135, 66);
            this.groupplayer2.TabIndex = 4;
            this.groupplayer2.TabStop = false;
            this.groupplayer2.Text = "Player 2";
            // 
            // labelplayer2moneyshow
            // 
            this.labelplayer2moneyshow.AutoSize = true;
            this.labelplayer2moneyshow.Location = new System.Drawing.Point(92, 42);
            this.labelplayer2moneyshow.Name = "labelplayer2moneyshow";
            this.labelplayer2moneyshow.Size = new System.Drawing.Size(37, 13);
            this.labelplayer2moneyshow.TabIndex = 3;
            this.labelplayer2moneyshow.Text = "99999";
            // 
            // labelplayer2money
            // 
            this.labelplayer2money.AutoSize = true;
            this.labelplayer2money.Location = new System.Drawing.Point(7, 42);
            this.labelplayer2money.Name = "labelplayer2money";
            this.labelplayer2money.Size = new System.Drawing.Size(39, 13);
            this.labelplayer2money.TabIndex = 2;
            this.labelplayer2money.Text = "Money";
            // 
            // labelplayer2pointsshow
            // 
            this.labelplayer2pointsshow.AutoSize = true;
            this.labelplayer2pointsshow.Location = new System.Drawing.Point(92, 20);
            this.labelplayer2pointsshow.Name = "labelplayer2pointsshow";
            this.labelplayer2pointsshow.Size = new System.Drawing.Size(37, 13);
            this.labelplayer2pointsshow.TabIndex = 1;
            this.labelplayer2pointsshow.Text = "99999";
            // 
            // labelplayer2points
            // 
            this.labelplayer2points.AutoSize = true;
            this.labelplayer2points.Location = new System.Drawing.Point(7, 20);
            this.labelplayer2points.Name = "labelplayer2points";
            this.labelplayer2points.Size = new System.Drawing.Size(36, 13);
            this.labelplayer2points.TabIndex = 0;
            this.labelplayer2points.Text = "Points";
            // 
            // GamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 261);
            this.Controls.Add(this.groupstats);
            this.Controls.Add(this.pb_Game);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GamePanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GamePanel";
            this.Load += new System.EventHandler(this.GamePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Game)).EndInit();
            this.groupstats.ResumeLayout(false);
            this.groupgamestats.ResumeLayout(false);
            this.groupgamestats.PerformLayout();
            this.groupplayer1.ResumeLayout(false);
            this.groupplayer1.PerformLayout();
            this.groupplayer2.ResumeLayout(false);
            this.groupplayer2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_GameTick;
        private System.Windows.Forms.PictureBox pb_Game;
        private System.Windows.Forms.GroupBox groupstats;
        private System.Windows.Forms.GroupBox groupgamestats;
        private System.Windows.Forms.Label labeltimer;
        private System.Windows.Forms.Label labeltimershow;
        private System.Windows.Forms.GroupBox groupplayer1;
        private System.Windows.Forms.GroupBox groupplayer2;
        private System.Windows.Forms.Label labelplayer2moneyshow;
        private System.Windows.Forms.Label labelplayer2money;
        private System.Windows.Forms.Label labelplayer2pointsshow;
        private System.Windows.Forms.Label labelplayer2points;
        private System.Windows.Forms.Label labelplayer1moneyshow;
        private System.Windows.Forms.Label labelplayer1money;
        private System.Windows.Forms.Label labelplayer1pointsshow;
        private System.Windows.Forms.Label labelplayer1points;
    }
}