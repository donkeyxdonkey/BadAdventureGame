using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment7_V2
{
    class Items
    {
        #region ----- PROPERTIES
        /// <summary>Name of item</summary>
        public QuestItems Name { get => name; set => name = value; }
        private QuestItems name;

        /// <summary>Item description</summary>
        public string Description { get => description; set => description = value; }
        private string description;

        /// <summary>Tuple for inventory images, Item1 greyed out image, Item2 active image</summary>
        public Tuple<Image, Image> ItemImages { get => itemImages; set => itemImages = value; }
        private Tuple<Image, Image> itemImages;

        /// <summary>Items location in player inventory</summary>
        public Point InventoryLocation { get => inventoryLocation; set => inventoryLocation = value; }
        private Point inventoryLocation;

        /// <summary>If item has interaction, it's target location</summary>
        public Point? TargetLocation { get => targetLocation; set => targetLocation = value; }
        private Point? targetLocation;

        /// <summary>Items interactions, if any</summary>
        public Interactions?[] Interaction { get => interaction; set => interaction = value; }
        private Interactions?[] interaction;

        /// <summary>Message on interaction</summary>
        public string InteractionMessage { get => interactionMessage; set => interactionMessage = value; }
        private string interactionMessage;

        /// <summary>Error message if bad interaction</summary>
        public string[] ErrorMessage { get => errorMessage; set => errorMessage = value; }
        private string[] errorMessage;

        /// <summary>Property for name of objective</summary>
        public QuestItems? Reward { get => reward; set => reward = value; }
        private QuestItems? reward;
        #endregion

        #region ----- FIELDS
        private string you = "[You]";
        #endregion

        #region ----- CONSTRUCTOR
        /// <summary>Constructor creating item with predefined properties</summary>
        /// <param name="item">enum coresponding to predefined properties</param>
        public Items(QuestItems item)
        {
            this.name = item;
            switch (item)
            {
                case QuestItems.Rubber_Duck:
                    this.description = "Now what does this have to do with anything?";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.rubberduck_gray, InventoryImages.rubberduck_color);
                    this.InventoryLocation = new Point(0, 0);
                    this.ErrorMessage = new string[] {
                        $"[{HelperMethods.ReplaceUnderscoreToString(name)}] Quack quack!!! ... {you} Did the duck just speak?... To me?... QUACK!!",
                        $"{you} Nah.",
                        $"{you} The idea was great, execution not so much",
                        $"{you} What's a nice {HelperMethods.ReplaceUnderscoreToString(name)} like you doing in a place like this?",
                        $"{you} Back to the drawing board.",
                        $"{you} Hamburgers!"
                    };
                    this.TargetLocation = new Point(14, 7);
                    this.Interaction = new Interactions?[] { Interactions.Destroy_Item };
                    this.InteractionMessage = $"{you} If it Quacks like a.. then it quacks like a... I was tired of your methodology anyway..";
                    break;
                case QuestItems.Snake_Skin:
                    this.description = "Just a snake skin..";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.snakeskin_gray, InventoryImages.snakeskin_color);
                    this.InventoryLocation = new Point(0, 1);
                    this.ErrorMessage = new string[] {
                        $"{you} Like a slithering sna-a-a-ke! *hiss*",
                        $"{you} If I could only remember the name of that Samuel L. Jackson movie.",
                        $"{you} If I keep trying then maybe something will happen."
                    };
                    this.TargetLocation = new Point(4, 13);
                    this.Interaction = new Interactions?[] { Interactions.Destroy_Item, Interactions.Event }; // animation
                    this.InteractionMessage = $"[Evil Christmas Elf] Not so fast sir!";
                    break;
                case QuestItems.Rusty_Key:
                    this.description = "The inscription reads. Passed down through generations";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.rustykey_gray, InventoryImages.rustykey_color);
                    this.InventoryLocation = new Point(0, 2);
                    this.ErrorMessage = new string[] {
                        $"{you} You thought that was going to work? You crazy?! Oh wait, it's me who's doing this.",
                        $"{you} On any other lock.",
                        $"{you} Close. Sooo close.",
                        $"{you} Dangit!"
                    };
                    this.TargetLocation = new Point(17, 7);
                    this.Interaction = new Interactions?[] { Interactions.Destroy_Item };
                    this.InteractionMessage = $"*the key snaps in the lock* {you} What now?!";
                    break;
                case QuestItems.Shard:
                    this.description = "A relic shard.";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.shard_gray, InventoryImages.shard_color);
                    this.InventoryLocation = new Point(0, 3);
                    this.ErrorMessage = new string[] {
                        $"{you} I better be careful, this item is holy.",
                        $"{you} Graverobber *hmpfs* nah, more like an archeologist.",
                        $"{you} *Ouch* it's sharp.",
                        $"{you} Shiny things might belong to shiny people, or how what's the saying. I better hold on to this."
                    };
                    this.TargetLocation = new Point(21, 1);
                    this.Interaction = new Interactions?[] { Interactions.New_Item, Interactions.Destroy_Item };
                    this.InteractionMessage = $"[Tony] Well I snuck up on that Rudy fellerh earlier and I got this *bäääh*. You can have this piece of {HelperMethods.ReplaceUnderscoreToString(QuestItems.Raindeer_Dung)}, but we be trading yo! Give me my Relic.";
                    this.reward = QuestItems.Raindeer_Dung;
                    break;
                case QuestItems.Cat:
                    this.description = "Hey there little fellow, no scratching.";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.cat_gray, InventoryImages.cat_color);
                    this.InventoryLocation = new Point(0, 4);
                    this.ErrorMessage = new string[] {
                        $"{you} Here kitty kitty!... *OuCh!* no biting daddy told you!",
                        $"{you} I'm gonna catify this thing *alakazam*!.. That's weird, it always works when Jackson Galaxy does it..??",
                        $"{you} Now who's a good boy? Yes you are, yes you are!",
                        $"{you} I wish this game had customer service, this makes perfect sense."
                    };
                    this.TargetLocation = new Point(20, 12);
                    this.Interaction = new Interactions?[] { Interactions.Destroy_Item, Interactions.Event };
                    this.InteractionMessage = $"{you} there goes the cat, I guess this is our destiny. Adieu friend! YEAH!";
                    break;
                case QuestItems.Red_Mushroom:
                    this.description = "A red mushroom, looks peculiar.";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.redmushroom_gray, InventoryImages.redmushroom_color);
                    this.InventoryLocation = new Point(1, 0);
                    this.ErrorMessage = new string[] {
                        $"{you} Where is Paul Stamets when you need him?",
                        $"{you} Really think so eh? We can do better then that!",
                        $"{you} This is definately not an Amanita Muscaria.",
                        $"{you} *Rubber rubber rubber* I summon thy!.. oh great one!.. of the forest!.."
                    };
                    this.TargetLocation = new Point(0, 14);
                    this.Interaction = new Interactions?[] { Interactions.New_Item, Interactions.Destroy_Item };
                    this.InteractionMessage = $"{you} *Rub the { HelperMethods.ReplaceUnderscoreToString(QuestItems.Red_Mushroom)} against the treebranches* OooH hey! A { HelperMethods.ReplaceUnderscoreToString(QuestItems.Green_Mushroom)} how did I find this?, definately edible.";
                    this.reward = QuestItems.Green_Mushroom;
                    break;
                case QuestItems.Green_Mushroom:
                    this.description = "A green mushroom, looks funky.";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.greenmushroom_gray, InventoryImages.greenmushroom_color);
                    this.InventoryLocation = new Point(1, 1);
                    this.ErrorMessage = new string[] {
                        $"{you} Could this be a Morchella Esculenta or Gyromitra Esculenta?",
                        $"{you} From the forest you came, to the forest thy shall return! ... !! On second though, I better hold on to this, it might be edible afterall.",
                        $"{you} Maybe I can just gnaw of a little piece and test if it's posonous or not.",
                        $"{you} Hotdiggety, now that's a funky smell. Like a garden snail with butter, and some salt... and some pepper... fried for 10-15 minutes... on a wooden stove... On a breezy summerday... AaaAaaaah!"
                    };
                    this.TargetLocation = new Point(19, 14);
                    this.Interaction = new Interactions?[] { Interactions.New_Item, Interactions.Destroy_Item };
                    this.InteractionMessage = $"[Rudy] *Chews on the { HelperMethods.ReplaceUnderscoreToString(QuestItems.Green_Mushroom)}* - Here pal, here you go, take this { HelperMethods.ReplaceUnderscoreToString(QuestItems.Yellow_Mushroom)}.. you know they say i'm the best? And as a mather of fact I think it's not far from the truth!";
                    this.reward = QuestItems.Yellow_Mushroom;
                    break;
                case QuestItems.Yellow_Mushroom:
                    this.description = "A yellow mushroom, combined from a red and a green one.. makes sense..";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.yellowmushroom_gray, InventoryImages.yellowmushroom_color);
                    this.InventoryLocation = new Point(1, 2);
                    this.ErrorMessage = new string[] {
                        $"{you} Smells like raindeer breath.",
                        $"{you} The evolution of fungi, I wonder what taxonomy database I can report my findings to.",
                        $"{you} Did you know Paul Stamets have a hat made out of a mushroom? Pretty neat if you ask me.",
                        $"{you} Another time, another place."
                    };
                    this.TargetLocation = new Point(12, 3);
                    this.Interaction = new Interactions?[] { Interactions.New_Item, Interactions.Destroy_Item };
                    this.InteractionMessage = $"{you} I'll just put this here for now.. *and as you put down the mushroom carefully* *actually being very careful* *to the point of not even making a sound* - {you} What! A { HelperMethods.ReplaceUnderscoreToString(QuestItems.Fishing_Rod)} stuck in the soil! Better grab this before the fishes does!";
                    this.reward = QuestItems.Fishing_Rod;
                    break;
                case QuestItems.Goat_Meat:
                    this.description = "Hey here's the chunk of goat meat Tony kindly donated.";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.goatmeat_gray, InventoryImages.goatmeat_color);
                    this.InventoryLocation = new Point(1, 3);
                    this.ErrorMessage = new string[] {
                        $"{you} HOT!",
                        $"{you} TOASTY!",
                        $"{you} FAR OUT!",
                        $"{you} OH YEAH!"
                    };
                    this.TargetLocation = null;
                    this.Interaction = null;
                    break;
                case QuestItems.Fishing_Rod:
                    this.description = "Fishing Rod XL2000";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.fishingrod_gray, InventoryImages.fishingrod_color);
                    this.InventoryLocation = new Point(1, 4);
                    this.ErrorMessage = new string[] {
                        $"{you} I always knew I wanted to become an angler, or maybe that's a spur of the moment thing.",
                        $"{you} Maggots or larva? Which is better? These kind of choices are just to complicated.",
                        $"{you} Wonder what's the best spot for King trout in these regions.",
                        $"{you} *singing* \"Gamla nordsjön den svallar och brusar\"..."
                    };
                    this.TargetLocation = new Point(6, 0);
                    this.Interaction = new Interactions?[] { Interactions.New_Item, Interactions.Destroy_Item, Interactions.Event }; //
                    this.InteractionMessage = $"{you} Damn, stuck on the log! -- *the line snaps and something is flying towards you!* --";
                    this.reward = QuestItems.Knight_Helmet;
                    break;
                case QuestItems.Burger:
                    this.description = "A chunky burger, with extra cheese.";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.burger_gray, InventoryImages.burger_color);
                    this.InventoryLocation = new Point(2, 0);
                    this.ErrorMessage = new string[] {
                        $"{you} Now.. If I just had a camera, some lights, a studio, some waterspray, a black luminescent glass table.. Then maybe I could take some pictures and make this a hot sale... Oh the wonder's of modern mankind, or was it peoplekind? I better go Newfoundland and find out.",
                        $"{you} This is just to El Mucho for me! HEHHE, see what I did there?",
                        $"{you} Maybe ill just have one bite before trying that.",
                        $"{you} The cheese smells like it's been in someones pocket."
                    };
                    this.TargetLocation = new Point(9, 3);
                    this.Interaction = new Interactions?[] { Interactions.New_Item, Interactions.Destroy_Item, Interactions.Event };
                    this.InteractionMessage = $"{you} Here goes nothing...";
                    this.reward = QuestItems.Goat_Meat;
                    break;
                case QuestItems.Pickaxe:
                    this.description = "Ouch, better be careful with this one.";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.pickaxe_gray, InventoryImages.pickaxe_color);
                    this.InventoryLocation = new Point(2, 1);
                    this.ErrorMessage = new string[] {
                        $"{you} *KIYAAH*!. Nope that's didnt work.",
                        $"{you} *AOUUH*!. Nope that's didnt work.",
                        $"{you} *COWABUNGA*!. Nope that's didnt work.",
                        $"{you} *AAAAAAAAAAAAAAAAH*!. Nope that's didnt work."
                    };
                    this.TargetLocation = new Point(15, 6);
                    this.Interaction = new Interactions?[] { Interactions.Destroy_Item };
                    this.InteractionMessage = $"{you} That broke easily, guess I won't be digging for gold any time soon...";
                    break;
                case QuestItems.Knight_Helmet:
                    this.description = "Fit for a king, or me?";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.knighthelmet_gray, InventoryImages.knighthelmet_color);
                    this.InventoryLocation = new Point(2, 2);
                    this.ErrorMessage = new string[] {
                        $"{you} My arms are to big.",
                        $"{you} My head is to big.",
                        $"{you} Won't fit on my big feet either.",
                        $"{you} Maybe ill just put this on my stomach and use it as a bucket for truffle chips."
                    };
                    this.TargetLocation = new Point(1, 11);
                    this.Interaction = new Interactions?[] { Interactions.New_Item, Interactions.Destroy_Item };
                    this.InteractionMessage = $"{you} *Dug up a shard using the helmet* - Now wasn't there someone who wanted this?";
                    this.reward = QuestItems.Shard;
                    break;
                case QuestItems.Raindeer_Nose:
                    this.description = "Rudy outdid himself this time.";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.raindeernose_gray, InventoryImages.raindeernose_color);
                    this.InventoryLocation = new Point(2, 3);
                    this.ErrorMessage = new string[] {
                        $"{you} Fit for a clown.",
                        $"{you} Last time I checked raindeers didn't have detachable noses.",
                        $"{you} This is not gonna work.",
                        $"{you} I wanna beat up the game designer."
                    };
                    this.TargetLocation = new Point(6, 7);
                    this.Interaction = new Interactions?[] { Interactions.New_Item, Interactions.Destroy_Item };
                    this.InteractionMessage = $"{you} Hey El Macho, what are you thinking about? [El Macho] I'm thinking about salsasauce and sour cream and... Yoyo esse, why don't you take this Burger?";
                    this.reward = QuestItems.Burger;
                    break;
                case QuestItems.Raindeer_Dung:
                    this.description = "Ewww.. to many blueberries..";
                    this.ItemImages = new Tuple<Image, Image>(InventoryImages.raindeerdung_gray, InventoryImages.raindeerdung_color);
                    this.InventoryLocation = new Point(2, 4);
                    this.ErrorMessage = new string[] {
                        $"{you} Yuck!",
                        $"{you} Soft and moist, hey what am I doing?!?!",
                        $"{you} With the things Bear Grylls have done for survival, if push comes to shove then maybe ill do it.",
                        $"{you} Not touching that with a 10 feet pole {you} But I just did, but not with a pole though, so I guess it's alright."
                    };
                    this.TargetLocation = new Point(2, 3);
                    this.Interaction = new Interactions?[] { Interactions.New_Item, Interactions.Destroy_Item, Interactions.Event };
                    this.InteractionMessage = $"{you} Here kitty kitty. {you} *fed { HelperMethods.ReplaceUnderscoreToString(QuestItems.Raindeer_Dung)} to the cat* [cat] Meoooowww! *purrs and jumps right into your backpack*";
                    this.reward = QuestItems.Cat;
                    break;
            }
        }
    }
    #endregion
}