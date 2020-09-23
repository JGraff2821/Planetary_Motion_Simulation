namespace FirstShotAtThis
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.starName = new System.Windows.Forms.TextBox();
            this.starMass = new System.Windows.Forms.TextBox();
            this.starGraphY = new System.Windows.Forms.TextBox();
            this.starGraphX = new System.Windows.Forms.TextBox();
            this.addStar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Adobe Heiti Std R", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(710, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "To The Stars!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mass";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "X Coordiante";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Y Coordinate";
            // 
            // starName
            // 
            this.starName.AccessibleName = "Star_Name";
            this.starName.Location = new System.Drawing.Point(160, 109);
            this.starName.Name = "starName";
            this.starName.Size = new System.Drawing.Size(94, 20);
            this.starName.TabIndex = 5;
            this.starName.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // starMass
            // 
            this.starMass.Location = new System.Drawing.Point(160, 196);
            this.starMass.Name = "starMass";
            this.starMass.Size = new System.Drawing.Size(94, 20);
            this.starMass.TabIndex = 6;
            this.starMass.TextChanged += new System.EventHandler(this.starMass_TextChanged);
            // 
            // starGraphY
            // 
            this.starGraphY.Location = new System.Drawing.Point(160, 163);
            this.starGraphY.Name = "starGraphY";
            this.starGraphY.Size = new System.Drawing.Size(94, 20);
            this.starGraphY.TabIndex = 7;
            this.starGraphY.TextChanged += new System.EventHandler(this.starGraphY_TextChanged);
            // 
            // starGraphX
            // 
            this.starGraphX.Location = new System.Drawing.Point(160, 137);
            this.starGraphX.Name = "starGraphX";
            this.starGraphX.Size = new System.Drawing.Size(94, 20);
            this.starGraphX.TabIndex = 8;
            this.starGraphX.TextChanged += new System.EventHandler(this.starGraphX_TextChanged);
            // 
            // addStar
            // 
            this.addStar.Location = new System.Drawing.Point(39, 253);
            this.addStar.Name = "addStar";
            this.addStar.Size = new System.Drawing.Size(75, 23);
            this.addStar.TabIndex = 9;
            this.addStar.Text = "Add Star";
            this.addStar.UseVisualStyleBackColor = true;
            this.addStar.Click += new System.EventHandler(this.addStar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addStar);
            this.Controls.Add(this.starGraphX);
            this.Controls.Add(this.starGraphY);
            this.Controls.Add(this.starMass);
            this.Controls.Add(this.starName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox starName;
        private System.Windows.Forms.TextBox starMass;
        private System.Windows.Forms.TextBox starGraphY;
        private System.Windows.Forms.TextBox starGraphX;
        private System.Windows.Forms.Button addStar;
    }
}

