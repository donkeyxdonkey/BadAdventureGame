using System.Drawing;

namespace Assignment7_V2
{
    class GateCoords
    {
        #region ----- FIELDS
        private int x;
        private int y;
        #endregion

        #region ----- CONSTRUCTOR
        /// <summary>Constructor creating a set of coordinates based on incomming player position</summary>
        /// <param name="point">targeted gate position</param>
        public GateCoords(Point point)
        {
            x = point.X;
            y = point.Y;
            SetCoords();
        }
        #endregion

        #region ----- METHODS
        /// <summary>Sets player spawn location based on players gate entry location</summary>
        /// <returns>new spawn coords</returns>
        public Point SetCoords()
        {
            if (x == 22 && y == 5) // map 1 gate 1
            {
                x = 23;
                y = 13;
            }
            else if (x == 6 && y == 3) // map 1 gate 2
            {
                x = 1;
                y = 2;
            }
            else if (x == 1 && y == 1) // map 2 gate 1
            {
                x = 6;
                y = 4;
            }
            else if (x == 23 && y == 12) // map 2 gate 2
            {
                x = 22;
                y = 6;
            }

            return new Point(x, y);
        }
        #endregion
    }
}