using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FirstShotAtThis
{
    public partial class GraphMyStars : Form
    {
        private List<Star> myStars = new List<Star>();
        public GraphMyStars()
        {
            
            InitializeComponent();
        }
        public void addStars(String n, int gx, int gy, int m)
        {
            myStars.Add(new Star(n, gx, gy, m));
        }



        //double scaleUP = SystemInformation.VirtualScreen.Height/ (Double)16;
        double scaleUP = (Double)100;
        //width = 1800, height = 900
        int xMax = 1850;
        int xMin = 50;
        int yMin = 50;
        int yMax = 950;
        int Vo = 5;
        int theta = 45;
        int Voy = 0;
        int Vox = 0;

        //int scaleUP = 50;
        //double scaleY = 150;
        private const int massWidth = 50, massHeight = 50;

        private void TheRisingSun_Click(object sender, EventArgs e)
        {

        }

        private void GraphMyStars_Load(object sender, EventArgs e)
        {
            Vox = Convert.ToInt32(Vo * Math.Cos(theta));
            Voy = Convert.ToInt32(Vo*Math.Sin(theta));
            timer_sun.Interval = 5;
            timer_sun.Start();
        }

        private void timer_sun_Tick(object sender, EventArgs e)
        {
            
            if((TheRisingSun.Right<=xMax)&&TheRisingSun.Left>=xMin&& TheRisingSun.Top >= yMin&& TheRisingSun.Bottom <= yMax)
            {
                TheRisingSun.Left +=Vox;
                TheRisingSun.Top -= Voy;
            }
            //It is at the Right Hand boarder
            else if(TheRisingSun.Right>xMax)
            {
                TheRisingSun.Left -= 1 * Vox;
                Vox *= -1;
                //Voy *= -1;
                
            }
            //It is at the Left Hand boarder
            else if(TheRisingSun.Left<xMin)
            {
                TheRisingSun.Left -= 1 * Vox;
                Vox *= -1;
               // Voy *= -1;
            }
            //It is at the top boarder
            else if(TheRisingSun.Top<=yMin)
            {
                TheRisingSun.Top += 1 * Voy;
                Voy *= -1;
                //Vox *= -1;
            }
            //Bottom Boarder
            else if (TheRisingSun.Bottom>=yMax)
            {
                TheRisingSun.Top +=1 * Voy;
                Voy *= -1;
                //Vox *= -1;
            }
                
            
            
        }

        private void GraphMyStars_Paint(object sender, PaintEventArgs e)
        {
            double radius = 0.25;
            Pen flowPen = new Pen(Color.BlueViolet);
            //Draw our Box
            Pen blackPen = new Pen(Color.Black);
            blackPen.Width = 3;
            int x, y;
            int width, height;
            x = 50;
            y = 50;
            width = 1800;
            height = 900;

           

            //DRAW OUR FLOW LINES
            foreach(Star currentStar in myStars)
            {
               
                for (int i=0;i<36;i++)
                {
                    double unitXValue, unitYValue;
                    unitXValue = currentStar.graphX + radius* Math.Cos(i * Math.PI / 18);
                    unitYValue = currentStar.graphY + radius * Math.Sin(i * Math.PI / 18);
                    //unitXValue = currentStar.graphX;
                    //unitYValue = currentStar.graphY;

                    //for (int j = 0; j < 10000; j++)
                    int count = 0;
                    while ((unitXValue >= 0.5) && (unitXValue <= 18.5) && (unitYValue >= 0.5) && (unitYValue <= 9.5)&&(count<3000))
                    {
                        count++;
                        e.Graphics.DrawRectangle(flowPen, Convert.ToInt32(unitXValue * scaleUP), Convert.ToInt32(unitYValue * scaleUP), 1, 1);
                        double forceX = 0;
                        double forceY = 0;
                        foreach (Star s in myStars)
                        {
                            forceX += s.mass*(unitXValue - s.graphX) / Math.Pow(Math.Sqrt(Math.Pow(s.graphX - unitXValue, 2) + Math.Pow(s.graphY - unitYValue, 2)), 3);
                            forceY += s.mass*(unitYValue - s.graphY) / Math.Pow(Math.Sqrt(Math.Pow(s.graphX - unitXValue, 2) + Math.Pow(s.graphY - unitYValue, 2)), 3);
                            //Console.WriteLine($"fx: {forceX} fy: {forceY}");
                        }

                        //use force values to change the x and y unit values
                        unitXValue += forceX / Math.Sqrt(Math.Pow(forceX, 2) + Math.Pow(forceY, 2)) * (1 / scaleUP);
                        unitYValue += forceY /Math.Sqrt(Math.Pow(forceX, 2) + Math.Pow(forceY, 2)) * (1 / scaleUP);
                    }
                }
                
            }
            //Draw the Stars
            e.Graphics.DrawRectangle(blackPen, Convert.ToInt32(x), Convert.ToInt32(y), width, height);
            foreach (Star newStar in myStars)
            {
                double scaledX = (newStar.graphX-.25) * scaleUP;
                double scaledY = (newStar.graphY-.25) * scaleUP;
                // Create BRUSH.
                SolidBrush redBrush = new SolidBrush(Color.Red);

                // Create rectangle for ellipse.
                Rectangle rect = new Rectangle(Convert.ToInt32(scaledX), Convert.ToInt32(scaledY), massWidth, massHeight);

                // Draw ellipse to screen.
                e.Graphics.FillEllipse(redBrush, rect);
            }

        }

        //List of Stars
        
       
    }
}
