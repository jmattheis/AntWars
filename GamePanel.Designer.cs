namespace AntWars
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
            this.timer_GameTick = new System.Windows.Forms.Timer(this.components);
            this.pb_Game = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Game)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_GameTick
            // 
            this.timer_GameTick.Tick += new System.EventHandler(this.timer_GameTick_Tick);
            // 
            // pb_Game
            // 
            this.pb_Game.BackColor = System.Drawing.Color.White;
            this.pb_Game.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Game.Location = new System.Drawing.Point(0, 0);
            this.pb_Game.Name = "pb_Game";
            this.pb_Game.Size = new System.Drawing.Size(370, 362);
            this.pb_Game.TabIndex = 0;
            this.pb_Game.TabStop = false;
            this.pb_Game.Click += new System.EventHandler(this.pb_Game_Click);
            // 
            // GamePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 362);
            this.Controls.Add(this.pb_Game);
            this.Name = "GamePanel";
            this.Text = "GamePanel";
            this.Load += new System.EventHandler(this.GamePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Game)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_GameTick;
        private System.Windows.Forms.PictureBox pb_Game;
    }
}