using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamMapValtech.ViewModel
{
    public class PositionVM
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double OldX { get; set; }
        public double OldY { get; set; }

        private static Random _Random = new Random();
        public static PositionVM GenererFake()
        {
            PositionVM p = new PositionVM();
            p.X = _Random.NextDouble();
            p.Y = _Random.NextDouble();
            p.OldX = _Random.NextDouble();
            p.OldY = _Random.NextDouble();
            return p;
        }
    }
}
