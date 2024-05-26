using System;
using System.Drawing;
using System.Windows.Forms;
using Assignment7_V2.Animations;
using Assignment7_V2.Enumerations;

namespace Assignment7_V2
{
    public partial class TheGame : Form
    {
        #region ----- FIELDS
        private GameEngine Game;
        private AnimationEvents AnimationEvent;

        private bool gameOver = false;
        private int animator = 1;

        const int pixelWidth = 32;
        const int animationCount = 8;
        const int inventorySize = 15;

        private PictureBox[] pbPlayerInventory;
        private Image[] imgPlayerInventory;

        private bool debug;
        #endregion

        #region --- CONSTRUCTOR & LOADUP
        /// <summary>Default Constructor</summary>
        public TheGame()
        {
            Game = new GameEngine(pixelWidth);

            pbPlayerInventory = new PictureBox[inventorySize];
            imgPlayerInventory = new Image[inventorySize];

            CreatePlayerInventory();

            InitializeComponent();
            InitializeGUI();
        }

        /// <summary>Initializes GUI - re-used when switching map</summary>
        private void InitializeGUI()
        {
            Text = string.Empty;
            tbGameMessages.Text = lblDebug.Text = string.Empty;
            MaximizeBox = false;
            pbGame.Image = Game.CurrentMap.MapImage;

            switch (Game.CurrentMap.GameMap)
            {
                case GameMaps.Map1:
                    pbCat.Image = HelperMethods.ReloadImage(pbCat, GameResources.Cat_FacingRight);
                    pbCat.Location = new Point(64, 86);
                    pbCat.Visible = Game.CheckForCat();
                    pbBowl.Image = HelperMethods.ReloadImage(pbBowl, GameResources.bowl);
                    pbBowl.Location = new Point(288, 96);
                    pbBowl.Visible = true;
                    pbNPC1.Image = HelperMethods.ReloadImage(pbNPC1, GameResources.NPC1_FacingDown);
                    pbNPC1.Location = new Point(448, 160);
                    pbNPC1.Visible = true;
                    pbBowl.Image = HelperMethods.ReloadImage(pbBowl, GameResources.bowl);
                    break;
                case GameMaps.Map2:
                    pbCat.Image = HelperMethods.ReloadImage(pbCat, GameResources.NPC3);
                    pbCat.Location = new Point(192, 224);
                    pbCat.Visible = true;
                    pbBowl.Image = HelperMethods.ReloadImage(pbBowl, GameResources.tony);
                    pbBowl.Location = new Point(672, 32);
                    pbBowl.Visible = true;
                    pbNPC1.Image = HelperMethods.ReloadImage(pbNPC1, GameResources.NPC2);
                    pbNPC1.Location = new Point(608, 448);
                    //pbNPC1.Visible = false;
                    break;
            }

            pbPlayer.Image = HelperMethods.ReloadImage(pbPlayer, GameResources.Hero1_FacingDown);
        }

        /// <summary>Generates images for player inventory</summary>
        private void CreatePlayerInventory()
        {
            int count = Enum.GetNames(typeof(QuestItems)).Length;
            int offset = 2;
            int z = 16; // picturebox width&height

            for (int i = 0; i < count; i++)
            {
                Items item = new Items((QuestItems)i); // constructs an item from casted corresponding QuestItem
                Point location = Game.GameMenu.MenuPointArray[item.InventoryLocation.X, item.InventoryLocation.Y]; // items location
                Point newLocation = new Point(location.X + offset, location.Y + offset);

                pbPlayerInventory[i] = new PictureBox() { Location = newLocation, Width = z, Height = z, BackColor = Color.Transparent };

                bool HasItem = Game.Player.PlayerInventory.OwnedCheck(item.Name); // if player has item colorized image otherwise gray
                pbPlayerInventory[i].Image = HasItem ? item.ItemImages.Item2 : item.ItemImages.Item1;
                pbPlayerInventory[i].Parent = pbGameMenu; // sets parent in order to not pierce through image with transparence

                Controls.Add(pbPlayerInventory[i]);
            }
        }

        private void TheGame_Load(object sender, EventArgs e)
        {
            // decomment to use the debugger
            //btnDebug.Visible = true;

            pbPlayer.Location = Game.Player.SpawnPlayer(pixelWidth);
            pbGameMenu.Image = GameResources.gameMenu;
            pbPlayer.Image = GameResources.Hero1_FacingDown;

            pbGameMenuActive.Image = GameResources.gameMenuOpen;
            pbGameMenuActive.Image = HelperMethods.ChangeImageOpacity(pbGameMenuActive.Image, 0.5);
            pbGameMenuActive.Visible = false;

            pbPlayerPortrait.Image = GameResources.Hero1_Portrait1;
            portraitTimer.Start();

            // sets parent in order to keep transparence of png image(s) otherwise it will just pierce through to the form itself.
            pbGameMenuActive.Parent = pbPlayer.Parent = pbCat.Parent = pbBowl.Parent = pbNPC1.Parent = pbExclaimation.Parent = pbAnimation.Parent = pbGame;
            lblInventoryInfo.Text = string.Empty;

            pbMenuBrowse.Visible = pbExclaimation.Visible = pbAnimation.Visible = false;
            pbMenuBrowse.Location = new Point(104, 575);
        }
        #endregion

        #region ----- METHODS
        /// <summary>Processes input key and attempts to call game for it's next action</summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            // if movement animation or any other animation is running game won't attempt making any actions
            if (gameOver || (!animationTimer.Enabled && !animationEventTimer.Enabled && !GateLockoutTimer.Enabled && !endGameTimer.Enabled))
                NextGameAction(key);

            // Call the base class
            return base.ProcessCmdKey(ref msg, key); // Returnpart is never used, the override is simply used to access the key from ProcessCmdKey
        }

        #region ----- ----- NEXT GAME ACTION
        private void NextGameAction(Keys key)
        {
            PlayerAction playerAction = Game.KeyPressed(key);

            if (playerAction == PlayerAction.DoNothing) return; // 0. If no valid key return

            if ((int)playerAction <= 4) // 1. Look for movement keypress - if not 2.*
            {
                Game.Player.PlayerFacing = (PlayerFacing)playerAction; // casts playeraction to corresponding playeraction

                if (Game.GameMenu.MenuOpen) // 3. Is the gamemenu open? If so perform move within menu then return
                {
                    MoveMenu(playerAction);
                    return;
                }

                if (!Game.DetectCollision(playerAction)) // 4. If no collision, move the player*.
                {
                    animationTimer.Start();
                }
                else // * otherwise change player's facing
                {
                    pbPlayer.Image = Game.ChangePlayerFacing(playerAction);
                    if (debug) Debugger(Game.Player.PlayerPosition);
                }

                Tuple<bool, Point> interaction = Game.DetectInteraction(Game.Player.PlayerFacing);
                if (interaction.Item1) // 5. Detects if player moved to an interactive object
                {
                    InteractionFound(interaction.Item2);
                }
                else // * otherwise clears up GUI
                {
                    ClearGUI();
                    Tuple<bool, Point> gate = Game.DetectGate(Game.Player.PlayerFacing); // detects if player moved towards a map gate
                    if (gate.Item1)
                    {
                        LoadGate(gate.Item2);
                    }
                }
            }
            else if (playerAction == PlayerAction.Menu)
            {
                Game.KeyLockout = false;
                Game.MenuOpen = !Game.MenuOpen ? true : false; // game menu toggle

                if (Game.MenuOpen) // opens menu and hides NPCs
                {
                    pbGameMenuActive.Visible = true;
                    pbCat.Visible = pbNPC1.Visible = pbBowl.Visible = false;
                    UpdateInventoryMessages();
                }
                else
                {
                    pbGameMenuActive.Visible = false;
                    if (Game.CurrentMap.GameMap == GameMaps.Map1)
                        pbCat.Visible = Game.CheckForCat(); // cat visible if objective to pick it up not completed
                    else
                        pbCat.Visible = true;

                    pbNPC1.Visible = pbBowl.Visible = true;
                    lblInventoryInfo.Text = string.Empty;
                }

                pbMenuBrowse.Visible = Game.GameMenu.BrowseVisible();
                pbGameMenu.Image = Game.GameMenu.ChangeMenuColor(pbGameMenu.Image);
            }
            else if (playerAction == PlayerAction.Accept)
            {
                if (Game.GameMenu.MenuOpen && Game.GameMenu.InteractionEnabled)
                    MenuAccept(); // acceptbutton pressed with menu open
                else
                {
                    if (Game.GameMenu.InteractionEnabled)
                        MapAccept(); // acceptbutton pressed in world map
                }
            }
            else if (playerAction == PlayerAction.Decline)
            {
                HideMenu(); // attempts to hide menu if its open
            }
        }

        /// <summary>Moves position in player inventory</summary>
        /// <param name="playerAction">Arrow movement capture</param>
        private void MoveMenu(PlayerAction playerAction)
        {
            Tuple<bool, Point> menuMove = Game.GameMenu.MoveMenu(playerAction);
            if (menuMove.Item1) // if not out of bounds
            {
                pbMenuBrowse.Location = menuMove.Item2; // moves inventory location to new
                UpdateInventoryMessages();
            }
        }

        /// <summary>Escapes the inventory menu and "invisible" npc's reappears.</summary>
        private void HideMenu()
        {
            Game.KeyLockout = false;

            if (Game.MenuOpen)
            {
                pbGameMenuActive.Visible = false;
                pbCat.Visible = pbNPC1.Visible = pbBowl.Visible = true;
                lblInventoryInfo.Text = string.Empty;
                pbMenuBrowse.Visible = Game.GameMenu.BrowseVisible();
                pbGameMenu.Image = Game.GameMenu.ChangeMenuColor(pbGameMenu.Image);
                Game.MenuOpen = false;
            }
        }

        /// <summary>Sets properties for interaction and updates game messages</summary>
        /// <param name="location">@location of found interaction</param>
        private void InteractionFound(Point location)
        {
            Game.GameMenu.InteractionEnabled = true;
            Game.GameMenu.InteractionPoint = location;
            Game.Player.TargetLocation = location;
            pbMenuBrowse.Image = GameResources.menuBrowseActive; // sets the menubrowse frame to a green one to indicate it's possible to interact
            tbGameMessages.Text = Game.MapObjectives.FindObjective(location);
        }

        /// <summary>Sets properties for interaction and clears game messages</summary>
        private void ClearGUI()
        {
            Game.GameMenu.InteractionEnabled = false;
            Game.GameMenu.InteractionPoint = null;
            pbMenuBrowse.Image = GameResources.menuBrowse; // sets the menubrowse frame to a red one to indicate it's not possible to interact 
            tbGameMessages.Text = string.Empty; // clears game message
        }

        /// <summary>Moves player to "the other" map</summary>
        /// <param name="location">gate location</param>
        private void LoadGate(Point location)
        {
            if (!animationTimer.Enabled)
            {
                Game.CurrentMap.GameMap = Game.CurrentMap.GameMap == GameMaps.Map1 ? GameMaps.Map2 : GameMaps.Map1; // map toggle
                Game.CurrentMap.LoadMap(Game.CurrentMap.GameMap);
                Game.Player.PlayerPosition = Game.Player.GetNewCoords(location); // sets new player position
                pbPlayer.Location = Game.Player.SpawnPlayer(pixelWidth); // spawns player in corresponding location
                InitializeGUI(); // reloads GUI
                GateLockoutTimer.Start(); // prevents player from moving for a short duration after switching maps, since many gates are entered in same direction
            }
        }

        /// <summary>Accept pressed from menu</summary>
        private void MenuAccept()
        {
            Point itemLocation = Game.GameMenu.GetMenuLocation();
            Tuple<bool, Items> currentItem = Game.Player.PlayerInventory.FindInventoryItemFromPoint(itemLocation);
            if (!currentItem.Item1) // item not in inventory
                return;

            if (currentItem.Item2.TargetLocation != Game.Player.TargetLocation)
            {
                RandomFailedInventoryaction(currentItem.Item2);
                return;
            }

            Tuple<Interactions?[], Items> interaction = FindGameInteraction();
            if (interaction.Item2 == null)
                return;

            InteractionFound(interaction.Item2);
            Game.MapObjectives.UpdateObjective(Game.Player.TargetLocation);
        }

        /// <summary>Accept pressed from the world map</summary>
        private void MapAccept()
        {
            Tuple<bool, Point> interaction = Game.DetectInteraction(Game.Player.PlayerFacing);
            Objectives obj = Game.InteractAtPoint(interaction.Item2);

            if (obj == null) // i just dont want to deal with null objects
            {
                RandomFailedInteraction();
            }
            else
            {
                if (!obj.CompletionStatus) // attempts to interact with objective if it's not already completed
                {
                    if (obj.ObjectiveData.Interaction != null && obj.ObjectiveData.InteractionType == InteractionType.Map)
                    {
                        MapInteraction(obj); // interacts with object
                    }
                    else
                    {
                        if (obj.ObjectiveData.NpcMessages != null)
                            RandomFailedNPCInteraction(obj.ObjectiveData.NpcMessages);
                        else
                             RandomFailedInteraction();
                    }
                }
                else // if already completed
                    if (obj.ObjectiveData.NpcMessages != null)
                        RandomFailedNPCInteraction(obj.ObjectiveData.NpcMessages);
                    else
                        RandomFailedInteraction();
            }
        }

        /// <summary>Displays a randomized error message when a map-interaction fails</summary>
        private void RandomFailedInteraction()
        {
            string errMsg = tbGameMessages.Text;
            var item = new string[] { "Can't be done.", "Ahuum.. Nope..", "No MiLord.", "Sometimes i think about things.", "When the shit goes down, you better be?", "What would Elon do?", "Donald Who?", "And I thought I was on to something!..", "Snakes, why'd it have to be snakes!!", "When im done with this game, im gonna need a vacation.", "Well no.. no.. no.. JUST! no.." };

            while (tbGameMessages.Text == errMsg) // re-randoms error message until it's not the same
            {
                Random rnd = new Random();
                int rand = rnd.Next(item.Length);
                errMsg = $"[You] {item[rand]}";
            }
            tbGameMessages.Text = errMsg;
        }

        /// <summary>Displays a randomized error message from an item when interaction fails</summary>
        /// <param name="item">item being interacted with</param>
        private void RandomFailedInventoryaction(Items item)
        {
            string errMsg = tbGameMessages.Text;
            string[] err = item.ErrorMessage;

            while (tbGameMessages.Text == errMsg) // re-randoms error message until it's not the same
            {
                Random rnd = new Random();
                int rand = rnd.Next(err.Length);
                errMsg = $"{err[rand]}";
            }
            tbGameMessages.Text = errMsg;
        }

        private void RandomFailedNPCInteraction(string[] npcMessages)
        {
            string errMsg = tbGameMessages.Text;
            string[] err = npcMessages;

            while (tbGameMessages.Text == errMsg) // re-randoms error message until it's not the same
            {
                Random rnd = new Random();
                int rand = rnd.Next(err.Length);
                errMsg = $"{err[rand]}";
            }
            tbGameMessages.Text = errMsg;
        }
        #endregion

        /// <summary>Returns an array of interactions for an item and the item itself when attempting to interact from the menu</summary>
        private Tuple<Interactions?[], Items> FindGameInteraction()
        {
            Point itemLocation = Game.GameMenu.GetMenuLocation();
            Tuple<bool, Items> currentItem = Game.Player.PlayerInventory.FindInventoryItemFromPoint(itemLocation);
            if (currentItem.Item1) // item found
            {
                Point? itemTarget = Game.GameMenu.InteractionPoint;
                Interactions?[] interaction = PlayerInventory.GetInteractions(currentItem.Item2, itemTarget);
                return new Tuple<Interactions?[], Items>(interaction, currentItem.Item2);
            }
            else return null;
        }

        /// <summary>Corresponding interactions when player interacts, through the map, with objectives</summary>
        /// <param name="obj">Map objective being interacted with</param>
        private void MapInteraction(Objectives obj)
        {
            switch (obj.ObjectiveData.Interaction)
            {
                case Interactions.New_Item:
                    Tuple<QuestItems?, string> reward = obj.ObjectiveData.Reward;
                    Items item = new Items((QuestItems)reward.Item1);
                    Game.Player.PlayerInventory.AddItem((QuestItems)reward.Item1);

                    UpdateInventoryImages(item, obj.ObjectiveData.Interaction);
                    tbGameMessages.Text = reward.Item2;

                    obj.CompletionStatus = true;
                    break;
                case Interactions.Destroy_Item:
                    Point itemLocation = Game.GameMenu.GetMenuLocation();
                    Tuple<bool, Items> currentItem = Game.Player.PlayerInventory.FindInventoryItemFromPoint(itemLocation);
                    Game.Player.PlayerInventory.DeleteItem(currentItem.Item2.Name);
                    tbGameMessages.Text = currentItem.Item2.InteractionMessage;
                    UpdateInventoryImages(currentItem.Item2, Interactions.Destroy_Item);
                    HideMenu();
                    break;
            }
        }

        /// <summary>Loops through all interactions for an item</summary>
        /// <param name="item">current item</param>
        private void InteractionFound(Items item) 
        {
            for (int i = 0; i < item.Interaction.Length; i++)
            {
                Interact(item.Interaction[i], item);
            }
        }

        /// <summary>Corresponding interactions when player interacts, through inventory, with objects</summary>
        /// <param name="interaction">Interaction to be made</param>
        /// <param name="item">Item that causes interaction</param>
        private void Interact(Interactions? interaction, Items item)
        {
            switch (interaction)
            {
                case Interactions.New_Item:
                    Game.Player.PlayerInventory.AddItem((QuestItems)item.Reward);
                    Items newItem = Game.Player.PlayerInventory.GetItemFromQuestItem((QuestItems)item.Reward);
                    UpdateInventoryImages(newItem, item.Interaction[0]); // updates inventory for new item to colored image, always located first in interactions array
                    break;
                case Interactions.Destroy_Item:
                    Point itemLocation = Game.GameMenu.GetMenuLocation();
                    Tuple<bool, Items> currentItem = Game.Player.PlayerInventory.FindInventoryItemFromPoint(itemLocation);

                    Game.Player.PlayerInventory.DeleteItem(item.Name);
                    tbGameMessages.Text = item.InteractionMessage; // displays message after item has been destroyed
                    UpdateInventoryImages(item, interaction);
                    HideMenu();
                    break;
                case Interactions.Event:
                    AnimationEvent = new AnimationEvents(item.Name);
                    animationEventTimer.Interval = 500; // half second initial delay before animation;
                    animationEventTimer.Start();
                    break;
                case Interactions.ErrorMessage:
                    string errMsg = tbGameMessages.Text;

                    while (tbGameMessages.Text == errMsg) // re-randoms error message until it's not the same
                    {
                        Random rnd = new Random();
                        int rand = rnd.Next(item.ErrorMessage.Length);
                        errMsg = item.ErrorMessage[rand];
                    }
                    tbGameMessages.Text = errMsg;
                    break;

                case Interactions.NPC_Talk:
                    break;
                default:
                    break;
            }
        }

        /// <summary>After picking up or destroying an item, updates image to reflect the change</summary>
        /// <param name="item">item being picked up or destroted</param>
        /// <param name="interaction">destroy or new item</param>
        private void UpdateInventoryImages(Items item, Interactions? interaction)
        {
            // logic for getting 0-14 array position from 3*5 array
            int inventorylocation = item.InventoryLocation.X > 0 ? item.InventoryLocation.X * 5 + item.InventoryLocation.Y : item.InventoryLocation.Y;

            pbPlayerInventory[inventorylocation].Image = null; // clears image to free memory
            pbPlayerInventory[inventorylocation].Image = interaction == Interactions.Destroy_Item ? item.ItemImages.Item1 : item.ItemImages.Item2; // toggle updates
            pbPlayerInventory[inventorylocation].BackColor = Color.Transparent;
        }



        /// <summary>While browsing player inventory updates inventorymessages for owned items.</summary>
        private void UpdateInventoryMessages()
        {
            Point itemLocation = Game.GameMenu.GetMenuLocation(); // gets location of current item in menu

            Tuple<bool, Items> currentItem = Game.Player.PlayerInventory.FindInventoryItemFromPoint(itemLocation);
            bool found = currentItem.Item1;
            Items item = currentItem.Item2;

            if (!found) // clears inventory message if no item found
            {
                lblInventoryInfo.Text = string.Empty;
                return;
            }

            string itemName = HelperMethods.ReplaceUnderscoreToString<QuestItems>(item.Name);
            lblInventoryInfo.Text = $"[{itemName}] {item.Description}"; // displays item information
        }
        #endregion

        #region ----- EVENTS
        /// <summary>Player movement animation</summary>
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            animationTimer.Stop();
            PlayerAction playerAction = Game.PlayerAction;

            // animates player image and location
            if (animator != animationCount) // if current animation itteration is not max
            {
                Tuple<Point, Image> newLocation = Game.MovePlayer(playerAction, pbPlayer.Location);
                pbPlayer.Location = newLocation.Item1;
                pbPlayer.Image = newLocation.Item2;
            }
            else // last loop itteration to reset image
            {
                Tuple<Point, Image> newLocation = Game.MovePlayer(playerAction, pbPlayer.Location, true); 
                pbPlayer.Location = newLocation.Item1;
                pbPlayer.Image = newLocation.Item2;
            }

            if (animator++ <= animationCount - 1) // restarts if maxitterations not met
            {
                animationTimer.Start();
            }
            else // resets after maxitterations
            {
                animator = 1;
                pbPlayer.BackColor = Color.Transparent;
            }

            if (debug) Debugger(Game.Player.PlayerPosition);
        }

        /// <summary>The portrait cycles through 3 images changes interval</summary>
        private void portraitTimer_Tick(object sender, EventArgs e)
        {
            portraitTimer.Stop();
            if (portraitTimer.Interval == 2500)
            {
                pbPlayerPortrait.Image = GameResources.Hero1_Portrait2;
                portraitTimer.Interval = 300;
            }
            else if (portraitTimer.Interval == 300)
            {
                pbPlayerPortrait.Image = GameResources.Hero1_Portrait3;
                portraitTimer.Interval = 200;
            }
            else if (portraitTimer.Interval == 200)
            {
                pbPlayerPortrait.Image = GameResources.Hero1_Portrait1;
                portraitTimer.Interval = 2500;
            }

            portraitTimer.Start(); // restarts itself - runs as long as application is
        }

        private void animationEventTimer_Tick(object sender, EventArgs e)
        {
            animationEventTimer.Stop(); // stops self and runs animation

            PictureBox pb = null;

            switch (AnimationEvent.QuestItem) // sets picturebox to animate and updates its properties deepending on current animation
            {
                case QuestItems.Cat:
                    pb = pbCat;
                    pb.Visible = false;
                    break;
                case QuestItems.Raindeer_Dung:
                    pb = pbCat;
                    break;
                case QuestItems.Fishing_Rod:
                    pb = pbAnimation;
                    pb.Image = InventoryImages.knighthelmet_color;
                    pb.Width = pb.Height = 16;
                    pb.Visible = true;
                    break;
                case QuestItems.Burger:
                    pb = pbAnimation;
                    pb.Image = GameResources.tony;
                    pb.Width = pb.Height = 32;
                    pb.Visible = true;
                    break;
                case QuestItems.Snake_Skin:
                    pb = pbAnimation;
                    pb.Image = GameResources.EvilElf;
                    pb.Width = pb.Height = 32;
                    pb.Visible = true;
                    break;
            }

            // updates animation values location, duration, flip (if one), message (if one), and visibility, lastly increments for next animation ***
            pb.Location = AnimationEvent.AnimationPath[AnimationEvent.Itterations];
            animationEventTimer.Interval = AnimationEvent.AnimationDelay[AnimationEvent.Itterations];
            if (AnimationEvent.ImageRotation[AnimationEvent.Itterations] != null)
                pb.Image.RotateFlip((RotateFlipType)AnimationEvent.ImageRotation[AnimationEvent.Itterations]);

            if (AnimationEvent.Message[AnimationEvent.Itterations] != string.Empty)
                tbGameMessages.Text = AnimationEvent.Message[AnimationEvent.Itterations];

            pb.Visible = AnimationEvent.Visible[AnimationEvent.Itterations];

            AnimationEvent.Itterations++;
            // ***

            if (AnimationEvent.Itterations < AnimationEvent.Count) // restarts self when maxitterations not reached
            {
                animationEventTimer.Start(); 
            }
            else
            {
                if (AnimationEvent.QuestItem != QuestItems.Cat) // hides the animation picturebox
                    pb.Visible = false;

                if (AnimationEvent.QuestItem == QuestItems.Cat) // starts Game Over event when the cat animation is over
                {
                    pbExclaimation.Location = new Point(455, 137);
                    pbExclaimation.Visible = true;
                    endGameTimer.Start();
                }
            }
        }
        #endregion

        #region ----- DEBUG
        private void btnDebug_Click(object sender, EventArgs e)
        {
            bool toggle = debug ? false : true; // simple toggle to set debug boolean
            debug = toggle;
            lblDebug.Visible = toggle;

            if (debug)
                Debugger(Game.Player.PlayerPosition);
        }

        /// <summary>Returns player location data while moving</summary>
        /// <param name="playerLocation">Current Player location</param>
        private void Debugger(Point playerLocation)
        {
            Point loc = Game.Player.PlayerPosition;
            Point imgLoc = pbPlayer.Location;

            lblDebug.Text = $"Player Location: {loc.X},{loc.Y} <<<>>> {imgLoc.X},{imgLoc.Y} <<<>>> {Game.Player.PlayerFacing}";
        }
        #endregion

        private void GateLockoutTimer_Tick(object sender, EventArgs e)
        {
            GateLockoutTimer.Stop();
        }

        private void endGameTimer_Tick(object sender, EventArgs e)
        {
            endGameTimer.Stop();
            gameOver = true;

            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }

            string n = Environment.NewLine;
            Font f = new Font("Times New Roman", 18.0f);
            TextBox tb = new TextBox() {
                Text = $"GAME OVER{n}{n}MADE BY: Alexander Dahqvist 2022{n}{n}© Tony the Goat Corporation",
                Font = f,
                Width = 500, Height = 500,                
                Multiline = true,
                BackColor = Color.FromArgb(0, 0, 0),
                ForeColor = Color.FromArgb(255, 255, 255),
                Location = new Point(250, 250),
                BorderStyle = BorderStyle.None
            };

            this.Controls.Add(tb);
        }
    }
}