using System;
using System.Collections.Generic;
using System.Text;
using SimpleSpaceRogue.Source.Engine.Tiles;
using GoRogue;
using GoRogue.MapViews;

namespace SimpleSpaceRogue.Source.Engine.Views
{
    public class FOVMap : IMapView<bool>
    {

        public bool this[Coord pos] => throw new NotImplementedException();

        public bool this[int index1D] => throw new NotImplementedException();

        public bool this[int x, int y] => throw new NotImplementedException();

        public int Height { get; set; }

        public int Width { get; set; }

    }
}
