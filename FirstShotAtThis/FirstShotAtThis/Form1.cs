using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstShotAtThis
{
    
    public partial class Form1 : Form
    {
        private string newName;
        private int newGraphX, newGraphY, newMass;
        private List<Star> stars = new List<Star>();
        public Form1()
        {
            
           

            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void DrawRectangleFloat(PaintEventArgs e)
        {

            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create location and size of rectangle.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 200.0F;

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, x, y, width, height);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            GraphMyStars graphy =new GraphMyStars();
            graphy.Show();
            foreach(Star newStar in stars)
            {
                graphy.addStars(newStar.Name, newStar.graphX, newStar.graphY, newStar.mass);
            }
        }

        private void starGraphX_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(starGraphX.Text, out newGraphX);
        
        }

        private void starGraphY_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(starGraphY.Text, out newGraphY);
       
        }

        private void starMass_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(starMass.Text, out newMass);
           
        }

        private void addStar_Click(object sender, EventArgs e)
        {
            stars.Add(new Star(newName, newGraphX, newGraphY, newMass));
            starName.Clear();
            starGraphX.Clear();
            starGraphY.Clear();
            starMass.Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            newName = starName.Text;
        }
    }
    
}
