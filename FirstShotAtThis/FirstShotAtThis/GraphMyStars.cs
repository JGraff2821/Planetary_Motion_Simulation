using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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




        //Some of my instance variables
        private Rectangle screen = Screen.PrimaryScreen.WorkingArea;
        private Bitmap btm;
        private bool drawOnce = true;
        private List<Pixel> changedPixels = new List<Pixel>();
        private List<Pixel> centerPixels = new List<Pixel>();

        //All my number variables
        private double contactDistance;
        private double Voy = 0;
        private double Vox = 0;
        private double planetX;
        private double planetY;
        private double massRadius = 0.25;
        private double planetRadius = 0.10;
        private double distanceX;
        private double distanceY;
        private double width;
        private double height;
        private double bufferX = 0.5;
        private double minX, maxX, minY, maxY;

        


        
        

        

        private void GraphMyStars_Load(object sender, EventArgs e)
        {
            //Define Instance Variables
            contactDistance = massRadius + planetRadius;
            width = ScaleDOWN(screen.Width * 0.94); //Set the width to 94% of total screen.
            height = ScaleDOWN(screen.Height * 0.9);//Set the height to 90% of the total screen. (Reduction Accounts for Bottom Task Bar)
            Console.WriteLine($"Width: {screen.Width}, Height {screen.Height}");
            Vox = 0;
            Voy = 0.5;
            planetX = 1;
            planetY = 5;


            //*******Code for my bitMap******************

            //First Definitions
            int bitX = Convert.ToInt32(ScaleUP(width+bufferX));
            int bitY = Convert.ToInt32(ScaleUP(height+bufferX));
            btm = new Bitmap(bitX, bitY);

            //Draw the base layer.
            for (int x = 1; x <= bitX-1; x++)
            {
                for (int y = 1; y <= bitY-1; y++)
                {
                    btm.SetPixel(x, y, Color.Purple);
                }

            }


            //Draw our border
            minX = bufferX / 2;
            int blackStartX = Convert.ToInt32(ScaleUP(minX));
            maxX = width + bufferX / 2;
            int blackEndX = Convert.ToInt32(ScaleUP(maxX));
            minY = bufferX / 2;
            int blackStartY = Convert.ToInt32(ScaleUP(minY));
            maxY = height + bufferX / 2;
            int blackEndY = Convert.ToInt32(ScaleUP(maxY));
            
            //Debug Varifying lengths and widths
            //Console.WriteLine($"X from: {minX} to {maxX}");
            //Console.WriteLine($"Y from: {minY} to {maxY}");


            for ( int x = blackStartX; x<blackEndX; x ++)
            {
                for( int y = blackStartY; y < blackEndY; y ++)
                {
                    btm.SetPixel(x, y, Color.Black);
                }
            }



            //***********Start our Timer*********
            InitializeTimer();

            //***********Background thread*******
            //to smoothe out the blinking problem.
            //Not just my problem, but frequent in a windows form.

            //Define Thread
            Thread t = new Thread(new ThreadStart(

                () => {
                    while (true)
                    {
                        Thread.Sleep(10);

                        this.Invoke(new Action(
                            () => {

                                this.Refresh();
                                this.Invalidate();
                                this.DoubleBuffered = true;
                                
                            }
                         )
                       );
                    }
                }
                )
                );

            //Start Thread
            t.Start();

        }

       
        private void GraphMyStars_Paint(object sender, PaintEventArgs e)
        {

            //***********************************STARS AND FLOW LINES ***************************


            if(drawOnce) // There is no need to redraw as they do not change. 
                         //Needed as a paint event activates frequently
            {
                double radius = 0.25;
                //**********Draw Flow Lines(Gravitational Field) **********
                foreach (Star currentStar in myStars)
                {

                    for (int i = 0; i < 36; i++)// 36 starting points on each star, separated by PI/18
                    {
                        double unitXValue, unitYValue;
                        unitXValue = currentStar.graphX + radius * Math.Cos(i * Math.PI / 18);
                        unitYValue = currentStar.graphY + radius * Math.Sin(i * Math.PI / 18);
                       
                        int count = 0;

                        while ((unitXValue >= minX) && (unitXValue <= maxX) && (unitYValue >= minY) && (unitYValue <= maxY) && (count < 3000))// While the flow lines are within the bounds of the screen
                        {
                            count++;
                            btm.SetPixel(Convert.ToInt32(ConvertX(unitXValue)), Convert.ToInt32(ConvertY(unitYValue)), Color.Aqua);///Placing a pixel at the current x and y positions
                            double forceX = 0;
                            double forceY = 0;
                            foreach (Star s in myStars) //Calculate Graviational Field Strength/Direction
                            {
                                forceX += s.mass * (unitXValue - s.graphX) / Math.Pow(Math.Sqrt(Math.Pow(s.graphX - unitXValue, 2) + Math.Pow((s.graphY) - unitYValue, 2)), 3);
                                forceY += s.mass * (unitYValue - (s.graphY)) / Math.Pow(Math.Sqrt(Math.Pow(s.graphX - unitXValue, 2) + Math.Pow((s.graphY) - unitYValue, 2)), 3);
                            }

                            //use force values to change the x and y unit values
                            unitXValue += ScaleDOWN(forceX / Math.Sqrt(Math.Pow(forceX, 2) + Math.Pow(forceY, 2)));
                            unitYValue += ScaleDOWN(forceY / Math.Sqrt(Math.Pow(forceX, 2) + Math.Pow(forceY, 2)));
                        }
                    }

                    //*******Draw Each of My Stars *******
                    foreach (Star newStar in myStars)
                    {
                        double scaledX = ConvertX(newStar.graphX);
                        double scaledY = ConvertY(newStar.graphY);

                        drawCircle(Convert.ToInt32(scaledX), Convert.ToInt32(scaledY), Convert.ToInt32(ScaleUP(massRadius)));

                    }

                }
                drawOnce = false;
            }
            
            //Update the screen to the most current picture
            e.Graphics.DrawImage(btm, 25, 25);


        }



        //************MY TIMER AND ITS PURPOSE **************
        private void InitializeTimer()
        {
            // Call this procedure when the application starts.  
            // Set to 1 second.  
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer1_Tick);


            // Enable timer.  
            timer1.Enabled = true;

            //timer2.Interval = 5;
            //timer2.Tick += new EventHandler(timer2_Tick);
            //timer2.Enabled = true;




        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Reset the pixels that were changed by the last iteration.
            while (changedPixels.Count != 0)
            {
                if (changedPixels[0].x == planetX && changedPixels[0].y == planetY)
                {
                    btm.SetPixel(changedPixels[0].x, changedPixels[0].y, Color.White);
                    changedPixels.RemoveAt(0);
                }

                else
                {
                    btm.SetPixel(changedPixels[0].x, changedPixels[0].y, changedPixels[0].c);
                    changedPixels.RemoveAt(0);
                }

            }


            //Find Current Position
            movePixel();

            //Tracer
            centerPixels.Add(new Pixel(Convert.ToInt32(ConvertX(planetX)), Convert.ToInt32(ConvertY(planetY)), Color.White));

            //Draw Position, find the pixels that are being replaced
            drawCircle(Convert.ToInt32(ConvertX(planetX)), Convert.ToInt32(ConvertY(planetY)), Convert.ToInt32(ScaleUP(planetRadius)), true);

        }

        private void movePixel()
        {
            //keepMoving = true;

            //if (planetX <= width - planetRadius && planetX >= planetRadius && planetY >= planetRadius && planetY <= height - planetRadius)
                
                //*******************Checking for CONTACT * *******************
                foreach (Star s in myStars)
                {
                    distanceX = Math.Abs(s.graphX - planetX);
                    distanceY = Math.Abs(s.graphY- planetY);
                    //distanceX <= contactDistance && distanceY <= contactDistance
                    if (Math.Sqrt(distanceX * distanceX + distanceY * distanceY) <= contactDistance)
                    {
                    

                    double Wx = planetX - s.graphX;
                    double Wy = planetY - s.graphY;
                    //Console.WriteLine($"Wx:{Wx}, Wy{Wy}");
                    Console.WriteLine($"X: {Vox}, Y: {Voy} ");
                    Vox = Vox - 2 * ((Vox * Wx + Voy * Wy) / (Wx * Wx + Wy * Wy)) * Wx;
                    Voy = Voy - 2 * ((Vox * Wx + Voy * Wy) / (Wx * Wx + Wy * Wy)) * Wy;
                    Console.WriteLine($"CHANGED X: {Vox}, Y: {Voy} ");
                    planetX += Vox / 20;
                    planetY += Voy / 20;
                  

                }
                }

                    ////calculate ax(), ay()
                    double ax = 0;
                    double ay = 0;

                    foreach (Star s in myStars)
                    {
                        ax = -s.mass * (planetX - s.graphX) /           (Math.Pow(Math.Sqrt(Math.Pow(planetX - s.graphX, 2) + Math.Pow(planetY - s.graphY, 2)), 3));
                        ay = -s.mass * (planetY - s.graphY) / (Math.Pow(Math.Sqrt(Math.Pow(planetX - s.graphX, 2) + Math.Pow(planetY - s.graphY, 2)), 3));

                    }
                    //Console.WriteLine($"ax: {ax}, ay: {ay}");
                    //Console.WriteLine($"vx: {Vox}, vy: {Voy}");
                    //change velocity accordingly
                    Vox += ax/20;
                    Voy += ay/20;
                    //change position accordingly
                    planetX += Vox/20;
                    planetY += Voy/20;
                
                //It is at the Right Hand boarder
                if (planetX > maxX - planetRadius)
                {
                    Console.WriteLine("Right Border");
                    //planetX -= Vox/20;
                    Vox *= -1;
                    //Voy *= -1;

                }
                //It is at the Left Hand boarder
                else if (planetX <= minX+ planetRadius)
                {
                    Console.WriteLine("Left Border");
                    //planetX -= Vox/20;
                    Vox *= -1;
                // Voy *= -1;
                
                }
                //It is at the bottom boarder
                else if (planetY <= minY+planetRadius)
                {
                    Console.WriteLine("Bottom Border");
                    //planetY -= Voy/20;
                    Voy *= -1;
                    //Vox *= -1;
                }
                //Top Boarder
                else if (planetY >= maxY-planetRadius)
                {
                    Console.WriteLine("Top Border");
                    //planetY -= Voy/20;
                    Voy *= -1;
                    //Vox *= -1;
                }

           

            //This Creates a visual tracer of the planet as determined by where its center has been.
            foreach (Pixel p in centerPixels)
            {
                if (btm.GetPixel(p.x, p.y) != p.c)
                {
                    btm.SetPixel(p.x, p.y, p.c);
                }
            }

        }





        //************* This is how I Draw my circle **************
        private void drawCircle(int x0, int y0, int radius, bool savePixels = false)
        {
            if (!savePixels)
            {
                for (int x = -radius; x < radius; x++)
                {
                    int height = (int)Math.Sqrt(radius * radius - x * x);

                    for (int y = -height; y < height; y++)
                        btm.SetPixel(x + x0, y + y0, Color.MediumPurple);
                }
            }
            else
            {
                for (int x = -radius; x < radius; x++)
                {
                    int height = (int)Math.Sqrt(radius * radius - x * x);

                    for (int y = -height; y < height; y++)
                    { 
                        changedPixels.Add(new Pixel(x0+x, y0+y, btm.GetPixel(x0+x, y0+y)));
                        btm.SetPixel(x + x0, y + y0, Color.White);

                    }
                }
            }
        }




















        //*********SCALING FUNCTIONS **************


        private double ConvertX(double mathUnitX) //Converts a given X value to its pixel equivalent
        {
            double pixelX = ScaleUP(mathUnitX);
            return pixelX;
        }

        private double ConvertY(double  mathUnitY) //Converts a given Y value to its pixel equivalent
        {
            double pixelY = ScaleUP(height+bufferX-mathUnitY);
            return pixelY;
        }

        private double ScaleUP(double mathUnitValue) //used for constants that don't have orientation (math units to the pixel values)
        {
            //check for mistake
            if(mathUnitValue>100)
            {
                Console.WriteLine("May have scaled DOWN the wrong item!");
            }

            double conversionFactor = 100;
            return mathUnitValue * conversionFactor;
        }

        private double ScaleDOWN(double mathUnitValue)//used for constants that don't have orientation (pixel values to math units)
        {
            //simple check for mistake
            if (mathUnitValue < 100)
            {
                Console.WriteLine("May have scaled DOWN the wrong item!");
            }

            double conversionFactor = 100;
            return (double) mathUnitValue / conversionFactor;
        }

































        //******************RANDOM, NO LONGER USED *****************
        //The fact that they were once used, means that they are called in the designer code.
        //I am unsure how to override/fix this.
        private void timer_sun_Tick(object sender, EventArgs e)
        {
        }
       
        private void timer2_Tick(object sender, EventArgs e)
        {


        }
        private void TheRisingSun_Click(object sender, EventArgs e)
        {

        }


    }
}

