using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstShotAtThis
{
    class Star
    {
       
           
            public string Name { get; set; }
            public int graphX { get; set; }
            public int graphY { get; set; }
            public int mass { get; set; }

            public Star(string n, int gx, int gy, int m)
            {
                Name = n;
                graphX = gx;
                graphY = gy;
                mass = m;
            }
        
    }
}
