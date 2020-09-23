namespace FirstShotAtThis
{
    partial class GraphMyStars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphMyStars));
            this.TheRisingSun = new System.Windows.Forms.PictureBox();
            this.timer_sun = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TheRisingSun)).BeginInit();
            this.SuspendLayout();
            // 
            // TheRisingSun
            // 
            this.TheRisingSun.BackColor = System.Drawing.Color.Transparent;
            this.TheRisingSun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TheRisingSun.BackgroundImage")));
            this.TheRisingSun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TheRisingSun.Location = new System.Drawing.Point(375, 219);
            this.TheRisingSun.Name = "TheRisingSun";
            this.TheRisingSun.Size = new System.Drawing.Size(34, 35);
            this.TheRisingSun.TabIndex = 0;
            this.TheRisingSun.TabStop = false;
            this.TheRisingSun.Click += new System.EventHandler(this.TheRisingSun_Click);
            // 
            // timer_sun
            // 
            this.timer_sun.Tick += new System.EventHandler(this.timer_sun_Tick);
            // 
            // GraphMyStars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TheRisingSun);
            this.Name = "GraphMyStars";
            this.Text = "GraphMyStars";
            this.Load += new System.EventHandler(this.GraphMyStars_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphMyStars_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.TheRisingSun)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TheRisingSun;
        private System.Windows.Forms.Timer timer_sun;
    }
}