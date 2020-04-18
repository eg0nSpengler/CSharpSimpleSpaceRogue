using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSpaceRogue.Source.Engine
{
    public static class Math
    {
        public static float Distance(int x1, int x2, int y1, int y2)
        {
            return MathF.Sqrt(MathF.Pow(x2 - x1, 2) + MathF.Pow(y2 - y1, 2));
        }
    }
}
