using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment7_V2
{
    class Player
    {
        #region ----- PROPERTIES
        /// <summary>Players current position</summary>
        public Point PlayerPosition { get => playerPosition; set => playerPosition = value; }
        private Point playerPosition;

        /// <summary>Current direction player is facing</summary>
        public PlayerFacing PlayerFacing { get => playerFacing; set => playerFacing = value; }
        private PlayerFacing playerFacing;

        /// <summary>A list of items obtained by the player</summary>
        public PlayerInventory PlayerInventory { get => playerInventory; set => playerInventory = value; }
        private PlayerInventory playerInventory;

        /// <summary>Players current target location</summary>
        public Point TargetLocation { get => targetLocation; set => targetLocation = value; }
        private Point targetLocation;
        #endregion

        #region ----- CONSTRUCTOR
        public Player()
        {
            playerPosition = new Point(22, 13); // default starting position
            playerFacing = PlayerFacing.Down;
            PlayerInventory = new PlayerInventory();
        }
        #endregion

        #region ----- METHODS
        /// <summary>Gets new player coordinates by constructing a gate with players current position</summary>
        /// <param name="gate">gate player is entering</param>
        /// <returns>other map spawn location</returns>
        public Point GetNewCoords(Point gate)
        {
            var newCoords = new GateCoords(gate);
            return newCoords.SetCoords();
        }

        /// <summary>Normalizes game grid to pixelsize</summary>
        /// <param name="pixelWidth">game pixelwidth</param>
        /// <returns>pixelpoint for player to spawn</returns>
        public Point SpawnPlayer(int pixelWidth)
        {
            Point position = PlayerPosition;

            int x = position.X * pixelWidth;
            int y = position.Y * pixelWidth;

            return new Point(x, y);
        }
        #endregion






    }
}