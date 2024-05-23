using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Assignment7_V2
{
    public class ObjectiveData
    {
        #region ----- PROPERTIES
        /// <summary>Property for objective message</summary>
        public string Message { get => message; set => message = value; }
        private string message;

        /// <summary>Property for name of objective</summary>
        public Point Location { get => location; set => location = value; }
        private Point location;

        /// <summary>Property for the map the object belongs to</summary>
        public GameMaps Map { get => map; set => map = value; }
        private GameMaps map;

        /// <summary>Property for the map the object belongs to</summary>
        public ObjectiveNames ObjectiveName { get => objectiveName; set => objectiveName = value; }
        private ObjectiveNames objectiveName;

        /// <summary>Property for name of objective</summary>
        public Interactions? Interaction { get => interaction; set => interaction = value; }
        private Interactions? interaction;

        /// <summary>Property for name of objective</summary>
        public Tuple<QuestItems?, string> Reward { get => reward; set => reward = value; }
        private Tuple<QuestItems?, string> reward;

        /// <summary>If the objective has an interaction either map or inventory</summary>
        public InteractionType InteractionType { get => interactionType; set => interactionType = value; }
        private InteractionType interactionType;

        /// <summary>If the objective is NPC or not</summary>
        public string[] NpcMessages { get => npcMessages; set => npcMessages = value; }
        private string[] npcMessages;
        #endregion

        #region ----- FIELDS
        string you = "[You]";
        int recursion;
        #endregion

        #region ----- CONSTRUCTOR
        /// <summary>Constructor where recursion corresponds to switch in objective data generation.</summary>
        /// <param name="recursion"></param>
        public ObjectiveData(int recursion)
        {
            this.recursion = recursion;
        }
        #endregion

        #region ----- METHODS
        /// <summary>Generates objective data</summary>
        /// <returns>bool to indicate if the recursive loop should continue</returns>
        public bool CreateObjectiveData()
        {
            bool keepGoing = true;

            switch (recursion)
            {
                case 0:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Old_Pot;
                    message = $"{you} An old pot.. What's this? Ancient China? You mumble to yourself, loudly.";
                    location = new Point(20, 12);
                    npcMessages = null;
                    break;
                case 1:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Suspicious_Looking_Cat;
                    message = $"{you} Hmmm, that's a strange looking cat. What's his problem?";
                    location = new Point(2, 3);
                    npcMessages = new string[] { "[Cat] *Meow*", "[Cat] *Meow*-*Meow*-*Meow* ... *Meow* ... *Me-me-meow*", "[Cat] I said MEOW!", "[Cat] They call me milkhunter!", "[Cat] My previous owner used to call me copro, I wonder why?" };
                    break;
                case 2:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Sign;
                    message = "THE SIGN READS: READ THE OTHER SIGN!!!";
                    location = new Point(0, 3);
                    npcMessages = null;
                    break;
                case 3:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Sign;
                    message = "THE SIGN READS: DO NOT FEED THE CAT!!! UNDER NO CIRCUSTANCES!!! OF COURSE, UNLESS YOU FEEL LIKE YOU HAVE TO!!!";
                    location = new Point(4, 3);
                    npcMessages = null;
                    break;
                case 4:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Benji;
                    message = $"{you} Just some weird guy it seems. [{HelperMethods.ReplaceUnderscoreToString(objectiveName).ToUpper()}] looks into his own reflection in the well \"You talking to me? talking to me? well i'm the only one here...\"";
                    location = new Point(14, 5);
                    npcMessages = new string[] {"[Benji] Howdy howdy, how are you? [You] Me who? [Benji] Yes ok so ill get to the point, if you want to beat this game you have to find me back my lost pet. And no, it's not what you're think that he's been kidnapped or been taken care of by the government. It's just that one day he dissapeared and now i can't find him. Oh my goood!", "[Benji] Wanna beat the game? I have something important to tell you!"};
                    break;
                case 5:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Plant;
                    message = $"{you} Smells kinda nice.";
                    location = new Point(12, 3);
                    npcMessages = null;
                    break;
                case 6:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Sign;
                    message = "THE SIGN READS: Make an offering to the gods. You shall be greatly rewarded.";
                    location = new Point(10, 2);
                    npcMessages = null;
                    break;
                case 7:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Bowl;
                    message = $"{you} An empty bowl. Kinda smells like catfood.. or?.. what is that smell?";
                    location = new Point(9, 3);
                    interaction = Interactions.New_Item;
                    interactionType = InteractionType.Inventory;
                    reward = new Tuple<QuestItems?, string>(QuestItems.Goat_Meat, $"{you} placed the hamburger in the bowl... *the wind chiming*");
                    npcMessages = null;
                    break;
                case 8:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Gravestone;
                    message = "\"Here lies King Arthur the III.\"";
                    location = new Point(2, 12);
                    npcMessages = null;
                    break;
                case 9:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Gravestone;
                    message = "\"Here lies Benji, son of King Arthur the III.\"";
                    location = new Point(1, 11);
                    interaction = Interactions.New_Item;
                    interactionType = InteractionType.Inventory;
                    reward = new Tuple<QuestItems?, string>(QuestItems.Shard, $"{you} OooH! A {HelperMethods.ReplaceUnderscoreToString(QuestItems.Green_Mushroom)}.");
                    npcMessages = null;
                    break;
                case 10:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Tree;
                    message = $"{you} No, it's not christmas yet.";
                    location = new Point(0, 14);
                    interaction = Interactions.New_Item;
                    interactionType = InteractionType.Inventory;
                    reward = new Tuple<QuestItems?, string>(QuestItems.Green_Mushroom, $"{you} OooH! A {HelperMethods.ReplaceUnderscoreToString(QuestItems.Green_Mushroom)}.");
                    npcMessages = null;
                    break;
                case 11:
                    objectiveName = ObjectiveNames.Bush;
                    map = GameMaps.Map1;
                    message = $"{you} Looks like something in there. Should I...?";
                    location = new Point(5, 10);
                    interaction = Interactions.New_Item;
                    interactionType = InteractionType.Map;
                    reward = new Tuple<QuestItems?, string>(QuestItems.Red_Mushroom, $"{you} OooH! A {HelperMethods.ReplaceUnderscoreToString(QuestItems.Red_Mushroom)}, I wonder if it's edible.");
                    npcMessages = null;
                    break;
                case 12:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Old_Well;
                    message = $"{you} Just an old well, not modern enough for me.";
                    location = new Point(14, 7);
                    npcMessages = null;
                    break;
                case 13:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Rudy;
                    message = $"{you} Now where have I seen this guy before?";
                    location = new Point(19, 14);
                    npcMessages = new string[] { "[Rudy] Yes I know, i'm the best", "[Rudy] One day ill show the world whos the best (raindeer in the raindeer world)", "[Rudy] Hey go away you scum! I'm so much better then you!", "[Rudy] *sings* Rudolf the red nose raindeer na-na-na-na-na-na!", "[Rudy] Some call me a nice guy, i'm WaaAAaay cooler then that.", "[Rudy] That goat snuck up on me one day and took something I was chewing on, he said I was full of myself." };
                    break;
                case 14:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Tony_the_Goat;
                    message = $"{you} Here goatie goatie.. *reaches* ... *ouch*..";
                    location = new Point(21, 1);
                    npcMessages = new string[] { "[Tony the Goat] Who am I *bäääH*", "[Tony the Goat] I Are You, You Am Me [You] Oh you mean that Nobuhiko Obayashi movie from 1982? [Tony the Goat] Yes.. I meaan no! no no no! *bäääH*", "[Tony the Goat] *bääÄÄÄÄÄÄÄÄÄÄääääääääääääääH!!!!!*", "[Tony the Goat] My balls are shiny *bääH!! bääH!!* Bells, I mean bells ofcourse. [You] I see no bells! [Tony the Goat] ???" };
                    break;
                case 15:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Plant;
                    message = $"{you} Now what if?...";
                    location = new Point(16, 2);
                    interaction = Interactions.New_Item;
                    interactionType = InteractionType.Map;
                    reward = new Tuple<QuestItems?, string>(QuestItems.Raindeer_Nose, $"{you} Ohboy ohboy! A {HelperMethods.ReplaceUnderscoreToString(QuestItems.Raindeer_Nose)}");
                    npcMessages = null;
                    break;
                case 16:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Prehistoric_King;
                    message = "\"A frog is not a man, a man is a frog\"";
                    location = new Point(15, 6);
                    npcMessages = null;
                    break;
                case 17:
                    map = GameMaps.Map1;
                    objectiveName = ObjectiveNames.Chopped_Down_Trees;
                    message = $"{you} Well.. well.. to bad I can't reach whatever is beyond this pile of junk.";
                    location = new Point(6, 0);
                    npcMessages = null;
                    break;
                case 18:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Rock;
                    message = $"{you}  Just a rock, move along now. {you} What who said that?";
                    location = new Point(4, 13);
                    npcMessages = null;
                    break;
                case 19:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.El_Macho;
                    message = "[El Macho] Hey there Hombre *burp*.. I used to work at a farm, at some old guys place..";
                    location = new Point(6, 7);
                    interaction = Interactions.New_Item;
                    interactionType = InteractionType.Inventory;
                    reward = new Tuple<QuestItems?, string>(QuestItems.Burger, $"[El Macho] Hey there Gringo *burp*.. Take this Burger, i've had it for a long time and it's time to pass the torch. I wonder where my sweet Tony went, I was gonna give it to him as a birthday present.");
                    npcMessages = new string[] { "[El Macho] Eeey macarena..", "[El Macho] Aserje he-de-ha-he-dehebidebi..", "[El Macho] EEEL MACHO!! Nu på McDonalds! [You] Vad tänker du på? [El Macho] ???", "[El Macho] Despacito dudududududu Despacito dudududududu-du-du-du!!" };
                    break;
                case 20:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Holy_Statue;
                    message = "\"The third is the holy one who ascended down the mountain, find him by making an offering to the gods.\"";
                    location = new Point(7, 7);
                    npcMessages = null;
                    break;
                case 21:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Holy_Tomb;
                    message = "\"Here lies Capra Hircus I\"";
                    location = new Point(5, 4);
                    npcMessages = null;
                    break;
                case 22:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Holy_Tomb;
                    message = "\"Here lies Capra Hircus II\"";
                    location = new Point(7, 4);
                    npcMessages = null;
                    break;
                case 23:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Holy_Tomb;
                    message = $"\"Expose the fake king, then return me my relic and be rewarded.\"";
                    location = new Point(9, 4);
                    npcMessages = null;
                    break;
                case 24:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Holy_Treasury;
                    message = $"\"The royal chest of the Capra Hircus family.\"";
                    location = new Point(17, 7);
                    npcMessages = null;
                    break;
                case 25:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Prehistoric_Son_of_King;
                    message = "\"Manboyfrog\"";
                    location = new Point(13, 6);
                    interaction = Interactions.New_Item;
                    interactionType = InteractionType.Map;
                    reward = new Tuple<QuestItems?, string>(QuestItems.Pickaxe, $"{you} A {HelperMethods.ReplaceUnderscoreToString(QuestItems.Pickaxe)}, now this is handy. Id even go as far as calling it \"Handy-Handy-Lito\". Or \"Handylicious\". OR.. \"Handylotion\".. uhm no wait..");
                    npcMessages = null;
                    break;
                case 26:
                    map = GameMaps.Map2;
                    objectiveName = ObjectiveNames.Pointless_Thing;
                    message = $"{you} Now what is this {HelperMethods.ReplaceUnderscoreToString(ObjectiveNames.Pointless_Thing).ToLower()}. If you compare the first map to this one, you may think that the game developer ran out of time. There is not much of a composed image.. we can observe some gravestones in the horizontal line with some some deadspace below.. although there are leading lines between the gravestones and these pointless non interactive pillars.. Or is that a treasure chest located right in the eye of a golden rule composition? Is this a gameclue or not, I must find out!.";
                    location = new Point(9, 13);
                    npcMessages = null;
                    break;
                default:
                    keepGoing = false;
                    break;
            }

            return keepGoing;
        }
        #endregion
    }
}