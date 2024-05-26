using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Assignment7_V2.Enumerations;

namespace Assignment7_V2
{
    public class GameMenu
    {

        public Color MenuInactive { get => menuInactive; set => menuInactive = value; }
        private Color menuInactive = Color.FromArgb(0, 64, 88);

        public Color MenuActive { get => menuActive; set => menuActive = value; }
        private Color menuActive = Color.FromArgb(0, 85, 88);

        public bool MenuOpen { get => menuOpen; set => menuOpen = value; }
        bool menuOpen = false;

        public Point[,] MenuPointArray { get => menuPointArray; set => menuPointArray = value; }
        private Point[,] menuPointArray;

        public bool InteractionEnabled { get => interactionEnabled; set => interactionEnabled = value; }
        private bool interactionEnabled;

        public Point? InteractionPoint { get => interactionPoint; set => interactionPoint = value; }
        private Point? interactionPoint;

        private int menuX;
        private int menuY;
        private int rows;
        private int columns;

        /// <summary>Returns current menu position</summary>
        public Point GetMenuLocation()
        {
            return new Point(menuX, menuY);
        }

        public GameMenu()
        {
            interactionEnabled = false;
            menuPointArray = new Point[3, 5];

            columns = menuPointArray.GetUpperBound(0) + 1;
            rows = menuPointArray.GetUpperBound(1) + 1;

            ReloadMenu();
            PopulateMenuArrays();
        }

        public void ReloadMenu()
        {
            menuX = 0;
            menuY = 0;
        }

        /// <summary>Fills up inventory browsing array with points to move image</summary>
        private void PopulateMenuArrays()
        {
            int x = 104; // starting location x,y for first image
            int y = 575;
            int offset = 22;

            for (int i = 0; i < columns; i++) // outer loop itterating columns
            {
                x = 104; // resets x to it's starting location before each inner loop

                for (int j = 0; j < rows; j++) // inner loop itterating rows
                {
                    menuPointArray[i, j] = new Point(x, y);
                    x += offset; // increments X-offset each inner loop
                }
                y += offset; // increments Y-offset for next loop

            }
        }

        public Image ChangeMenuColor(Image img)
        {

            Bitmap bmp = null;
            if (!menuOpen)
            {
                bmp = new Bitmap(GameResources.gameMenu);
            }
            else
            {
                Color color = MenuInactive;

                byte r = color.R; //For Red colour

                bmp = new Bitmap(img);
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        Color gotColor = bmp.GetPixel(x, y);
                        gotColor = Color.FromArgb(r, gotColor.G, gotColor.B);
                        bmp.SetPixel(x, y, gotColor);
                    }
                }
            }

            menuOpen = !menuOpen ? true : false;

            return bmp;
        }

        /// <summary>Returns toggling bool to activate menubrowse</summary>
        public bool BrowseVisible()
        {
            return menuOpen ? false : true;
        }

        public Tuple<bool, Point> MoveMenu(PlayerAction playerAction)
        {
            Point ss = new Point(menuX, menuY); // current position
            bool validMove = false;

            switch (playerAction) // updates active move grid
            {
                case PlayerAction.MoveLeft:
                    if (!(ss.Y - 1 < 0))
                    {
                        ss = new Point(ss.X, ss.Y - 1);
                        validMove = true;
                    }
                    else
                        validMove = false;
                    break;
                case PlayerAction.MoveRight:
                    if (!(ss.Y > rows - 2))
                    {
                        ss = new Point(ss.X, ss.Y + 1);
                        validMove = true;
                    }
                    else
                        validMove = false;
                    break;
                case PlayerAction.MoveUp:
                    if (!(ss.X - 1 < 0))
                    {
                        ss = new Point(ss.X - 1, ss.Y);
                        validMove = true;
                    }
                    else
                        validMove = false;
                    break;
                case PlayerAction.MoveDown:
                    if (!(ss.X > columns - 2))
                    {
                        ss = new Point(ss.X + 1, ss.Y);
                        validMove = true;
                    }
                    else
                        validMove = false;
                    break;
            }

            menuX = ss.X;
            menuY = ss.Y;

            return new Tuple<bool, Point>(validMove, menuPointArray[ss.X, ss.Y]);
        }
    }
}