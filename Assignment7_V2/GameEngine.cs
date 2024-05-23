using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // for keypress & timer.
using System.Drawing;
using System.Drawing.Imaging;

namespace Assignment7_V2
{
    class GameEngine
    {
        #region ----- PROPERTIES
        /// <summary>Gets and Sets game title</summary>
        public string Title { get => title; set => title = value; }
        private string title;

        /// <summary>Contains a list of objectives with completionstatus and objectivedata</summary>
        public MapObjectives MapObjectives { get => mapObjectives; set => mapObjectives = value; }
        private MapObjectives mapObjectives;

        /// <summary>Current map used by the game</summary>
        public Maps CurrentMap { get => currentMap; set => currentMap = value; }
        private Maps currentMap;

        /// <summary>Playerdata</summary>
        public Player Player { get => player; set => player = value; }
        private Player player;

        /// <summary>Gets and Sets player action</summary>
        public PlayerAction PlayerAction { get => playerAction; set => playerAction = value; }
        private PlayerAction playerAction;

        /// <summary>used to prevent keypress to trigger while player is moving (animating)</summary>
        public bool KeyLockout { get => keyLockout; set => keyLockout = value; }
        private bool keyLockout;

        /// <summary>Gamemenu class contains data and information about the game menu</summary>
        public GameMenu GameMenu { get => gameMenu; set => gameMenu = value; }
        private GameMenu gameMenu;

        /// <summary>true while menu is open</summary>
        public bool MenuOpen { get => menuOpen; set => menuOpen = value; }        
        private bool menuOpen;
        #endregion

        #region ----- FIELDS        
        private Timer actionTimer; // Resets keyLockout (496ms)        
        private Timer animationTimer; // player move animation (62ms)        
        private bool animationModSwitch; // to swap between animations
        private int pixelWidth;
        #endregion

        #region ----- CONSTRUCTOR
        /// <summary>Constructs the gameengine with appropriate objects and event subscriptions</summary>
        /// <param name="pixelWidth">Relative w/h for each block</param>
        public GameEngine(int pixelWidth)
        {
            actionTimer = new Timer() { Interval = 496 };
            actionTimer.Tick += new EventHandler(actionTimer_Tick); // subscribes timer to it's tick event
            keyLockout = false;
            menuOpen = false;

            this.pixelWidth = pixelWidth;
            player = new Player();
            var MapObject = new Maps(GameMaps.Map1);

            gameMenu = new GameMenu();

            animationTimer = new Timer() { Interval = 62 };
            animationTimer.Tick += new EventHandler(actionTimer_Tick); // subscribes timer to it's tick event

            mapObjectives = new MapObjectives();
            currentMap = new Maps(GameMaps.Map1);
        }
        #endregion

        #region ----- METHODS
        /// <summary>Returns the point next to the player in it's facing direction</summary>
        public Tuple<bool, Point> DetectInteraction(PlayerFacing playerFacing)
        {
            int x = player.PlayerPosition.X;
            int y = player.PlayerPosition.Y;

            Point loc = new Point(x, y); // new point to avoid same memory reference

            if ((int)playerFacing < 3) // up or down
                y = playerFacing == PlayerFacing.Up ? y - 1 : y + 1;
            else // left or right
                x = playerFacing == PlayerFacing.Left ? x - 1 : x + 1;

            int w = currentMap.MapGrid.GetUpperBound(0); // array x(0),y(1) size
            int z = currentMap.MapGrid.GetUpperBound(1);


            if ((x < 0 || y < 0) || (x > w || y > z)) // returns false if facing is out of bounds
                return new Tuple<bool, Point>(false, new Point(0, 0));

            return new Tuple<bool, Point>(currentMap.MapGrid[x, y] == 2 ? true : false, new Point(x, y));
        }

        /// <summary>Detects if the block the player is facing is a gate</summary>
        /// <param name="playerFacing">Players current facing direction</param>
        /// <returns>true if gate found and coords of gate</returns>
        public Tuple<bool, Point> DetectGate(PlayerFacing playerFacing)
        {
            int x = player.PlayerPosition.X;
            int y = player.PlayerPosition.Y;

            Point loc = new Point(x, y); // new point to avoid same memory reference

            if ((int)playerFacing < 3) // up or down
                y = playerFacing == PlayerFacing.Up ? y - 1 : y + 1;
            else // left or right
                x = playerFacing == PlayerFacing.Left ? x - 1 : x + 1;

            int w = currentMap.MapGrid.GetUpperBound(0); // array x(0),y(1) size
            int z = currentMap.MapGrid.GetUpperBound(1);


            if ((x < 0 || y < 0) || (x > w || y > z)) // returns false if facing is out of bounds
                return new Tuple<bool, Point>(false, new Point(0, 0));

            return new Tuple<bool, Point>(currentMap.MapGrid[x, y] == 3 ? true : false, new Point(x, y)); // the 3 in the comparison represents a gate
        }

        /// <summary>Compares players next move to prevent out of bounds, ie outside of map array dimension</summary>
        /// <param name="playerFacing">players selected move direction</param>
        /// <returns>true if out of bounds</returns>
        private bool OutOfBoundsCheck(PlayerFacing playerFacing)
        {
            int x = player.PlayerPosition.X;
            int y = player.PlayerPosition.Y;

            Point loc = new Point(x, y); // new point to avoid same memory reference

            if ((int)playerFacing < 3) // up or down
                y = playerFacing == PlayerFacing.Up ? y - 1 : y + 1;
            else // left or right
                x = playerFacing == PlayerFacing.Left ? x - 1 : x + 1;

            int w = currentMap.MapGrid.GetUpperBound(0); // array x(0),y(1) size
            int z = currentMap.MapGrid.GetUpperBound(1);


            if ((x < 0 || y < 0) || (x > w || y > z)) // returns false if facing is out of bounds
                return true;
            else
                return false;
        }

        /// <summary>Verifies if objective to pick up cat has been completed in order to hide it when switching between map2 and map1</summary>
        /// <returns>Bool to hide cat or not to</returns>
        public bool CheckForCat()
        {
            foreach (Objectives item in mapObjectives.ObjectiveList)
            {
                if (item.ObjectiveData.ObjectiveName == ObjectiveNames.Suspicious_Looking_Cat)
                {
                    return !item.CompletionStatus; // inverse of completion as it needs to be hidden if completed
                }
            }

            return true; // never reached
        }

        /// <summary>Attempts to find objective at location</summary>
        /// <param name="atLocation">Targeted location</param>
        /// <returns></returns>
        public Objectives InteractAtPoint(Point atLocation)
        {
            return MapObjectives.FindObjectiveX(atLocation);
        }

        /// <summary>Captures a keypress from the application and maps it to corresponding enumerator</summary>
        /// <param name="key">input pressed</param>
        public PlayerAction KeyPressed(Keys key)
        {
            //PlayerAction playerAction = PlayerAction.DoNothing;
            if (keyLockout) return PlayerAction.DoNothing;

            playerAction = PlayerAction.DoNothing;

            // valid key inputs if player isn't in movement animation, will return a "proceed" value.
            if (!keyLockout && (key == Keys.Left || key == Keys.Down || key == Keys.Up || key == Keys.Right || key == Keys.C || key == Keys.X || key == Keys.Z))
            {
                switch (key)
                {
                    case Keys.Left:
                        playerAction = PlayerAction.MoveLeft;
                        break;
                    case Keys.Up:
                        playerAction = PlayerAction.MoveUp;
                        break;
                    case Keys.Right:
                        playerAction = PlayerAction.MoveRight;
                        break;
                    case Keys.Down:
                        playerAction = PlayerAction.MoveDown;
                        break;
                    case Keys.C:
                        playerAction = PlayerAction.Menu;
                        break;
                    case Keys.X:
                        playerAction = PlayerAction.Accept;
                        break;
                    case Keys.Z:
                        playerAction = PlayerAction.Decline;
                        break;
                }
            }

            if (!menuOpen)
            {
                keyLockout = true;
                actionTimer.Start();
            }

            return playerAction;
        }

        /// <summary>Detects if player is moving to a collisionblock</summary>
        /// <param name="playerAction">players selected move</param> // this method is only triggered by arrow movement
        /// <returns>true if collision ahead</returns>
        public bool DetectCollision(PlayerAction playerAction)
        {
            bool collision;

            int x = player.PlayerPosition.X;
            int y = player.PlayerPosition.Y;

            int xMax = currentMap.MapGrid.GetUpperBound(0);
            int yMax = currentMap.MapGrid.GetUpperBound(1);

            switch (playerAction)
            {
                case PlayerAction.MoveUp:
                    y -= 1; break;
                case PlayerAction.MoveDown:
                    y += 1; break;
                case PlayerAction.MoveLeft:
                    x -= 1; break;
                case PlayerAction.MoveRight:
                    x += 1; break;
            }

            if ((x < 0 || y < 0) || (x > xMax || y > yMax)) collision = true; // out of bounds check
            else
            {
                collision = currentMap.MapGrid[x, y] != null ? true : false;
                if (!collision) player.PlayerPosition = new Point(x, y); // updates player position
            }

            return collision;
        }

        /// <summary>Returns an "itterative" animation used when the player is moving</summary>
        /// <param name="direction">the direction the player is moving</param>
        /// <param name="location">current player location</param>
        /// <param name="lastloop">end condition for the animation</param>
        /// <returns>A point for the player to move to and an updated image</returns>
        public Tuple<Point, Image> MovePlayer(PlayerAction direction, Point location, bool lastloop = false)
        {
            int x = location.X;
            int y = location.Y;
            Image img = null;

            switch (direction)
            {
                case PlayerAction.MoveUp:
                    y -= 4; // (last itteration? if so default image) --- Otherwise a toggle between two images facing that direction - SAME logic locally
                    img = lastloop ? GameResources.Hero1_FacingUp : !animationModSwitch ? GameResources.Hero1_Up1 : GameResources.Hero1_Up2;
                    break;
                case PlayerAction.MoveDown:
                    y += 4;
                    img = lastloop ? GameResources.Hero1_FacingDown : !animationModSwitch ? GameResources.Hero1_Down1 : GameResources.Hero1_Down2;
                    break;
                case PlayerAction.MoveLeft:
                    x -= 4;
                    img = lastloop ? GameResources.Hero1_FacingLeft : !animationModSwitch ? GameResources.Hero1_Left1 : GameResources.Hero1_Left2;
                    break;
                case PlayerAction.MoveRight:
                    x += 4;
                    img = lastloop ? GameResources.Hero1_FacingRight : !animationModSwitch ? GameResources.Hero1_Right1 : GameResources.Hero1_Right2;
                    break;
            }

            animationModSwitch = animationModSwitch ? false : true; // toggles

            return new Tuple<Point, Image>(new Point(x, y), img);
        }

        /// <summary>Returns a normalized player position from it's current image position.</summary>
        public Point UpdatePlayerPosition(Point imgLocation)
        {
            return new Point(imgLocation.X / pixelWidth, imgLocation.Y / pixelWidth);
        }

        /// <summary>When player moves into a collision block or tries to move out of bounds</summary>
        /// <param name="playerAction">selected direction</param>
        /// <returns>An playerimage of the direction the player attempted to move</returns>
        public Image ChangePlayerFacing(PlayerAction playerAction)
        {
            keyLockout = false; // resets keylockout

            if (playerAction == PlayerAction.MoveUp)
            {
                return GameResources.Hero1_FacingUp;
            }
            else if (PlayerAction == PlayerAction.MoveDown)
            {
                return GameResources.Hero1_FacingDown;
            }
            else if (PlayerAction == PlayerAction.MoveLeft)
            {
                return GameResources.Hero1_FacingLeft;
            }
            else if (PlayerAction == PlayerAction.MoveRight)
            {
                return GameResources.Hero1_FacingRight;
            }

            return null; // won't ever be reached
        }
        #endregion

        #region ----- EVENTS
        private void actionTimer_Tick(object sender, EventArgs e)
        {
            keyLockout = false;
            actionTimer.Stop();

        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            actionTimer.Stop();
        }
        #endregion
    }
}