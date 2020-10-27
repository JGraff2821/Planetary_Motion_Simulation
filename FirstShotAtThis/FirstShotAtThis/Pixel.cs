using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FirstShotAtThis
{
    class Pixel
    {
        public int x { get; set; }
        public int y { get; set; }
        public Color c { get; set; }

        public Pixel(int xval, int yval, Color cval)
        {
            x = xval;
            y = yval;
            c = cval;
        }
    }
}
