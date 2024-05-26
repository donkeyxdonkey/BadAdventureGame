using System.Drawing;
using Assignment7_V2.Enumerations;

namespace Assignment7_V2;

class AnimationEvents
{
    #region ----- PROPERTIES        
    /// <summary>An array of point where targeted image will move</summary>
    public Point[] AnimationPath { get => animationPath; set => animationPath = value; }
    private Point[] animationPath;

    /// <summary>An array of integer with delay between each animation step</summary>
    public int[] AnimationDelay { get => animationDelay; set => animationDelay = value; }
    private int[] animationDelay;

    /// <summary>An array of rotateflip setting each flip for the animation (if one)</summary>
    public RotateFlipType?[] ImageRotation { get => imageRotation; set => imageRotation = value; }
    private RotateFlipType?[] imageRotation;

    /// <summary>An array of bool indicating if image is to be visible or not each animation step</summary>
    public bool[] Visible { get => visible; set => visible = value; }
    private bool[] visible;

    /// <summary>An array of messages that can be displayed during the animation</summary>
    public string[] Message { get => message; set => message = value; }
    private string[] message;

    /// <summary>Getter for animation itterations</summary>
    public int Count { get => count; }
    private int count;

    /// <summary>Current itteration for looping the animation</summary>
    public int Itterations { get => itterations; set => itterations = value; }
    private int itterations;

    /// <summary>Questitem tied to the animation</summary>
    public QuestItems QuestItem { get => questItem; set => questItem = value; }
    private QuestItems questItem;
    #endregion

    #region ----- CONSTRUCTOR
    /// <summary>Constructor constructing an animation based in input QuestItem</summary>
    /// <param name="qItem">Questitem tied to the animation</param>
    public AnimationEvents(QuestItems qItem)
    {
        SetAnimationEvent(qItem);
    }
    #endregion

    #region ----- METHODS
    /// <summary>Selects method for creating animation based on input questitem</summary>
    /// <param name="qItem">Questitem tied to the animation</param>
    private void SetAnimationEvent(QuestItems qItem)
    {
        switch (qItem)
        {
            case QuestItems.Cat:
                GetCatAnimationEvent();
                break;
            case QuestItems.Fishing_Rod:
                GetHelmAnimationEvent();
                break;
            case QuestItems.Burger:
                GetGoatAnimationEvent();
                break;
            case QuestItems.Raindeer_Dung:
                GetCat2AnimationEvent();
                break;
            case QuestItems.Snake_Skin:
                GetElfAnimationEvent();
                break;
        }

        questItem = qItem;
        itterations = 0; // start value
        count = animationPath.Length; // #of itterations
    }

    /// <summary>Less code to create a new point to make code more readable</summary>
    /// <param name="x">X-Axis</param>
    /// <param name="y">Y-Axis</param>
    private Point P(int x, int y)
    {
        return new Point(x, y);
    }
    #endregion

    #region ----- CAT ANIMATION
    private void GetCatAnimationEvent()
    {
        animationPath = new Point[] {
            P(640, 350),
            P(630, 352),
            P(620, 350),
            P(640, 350),
            P(640, 350),
            P(640, 350),
            P(630, 352),
            P(640, 350),
            P(640, 350),
            P(576, 160),
            P(576, 140),
            P(576, 110),
            P(576, 80),
            P(576, 40),
            P(576, 80),
            P(576, 100),
            P(576, 130),
            P(576, 160)
        };
        animationDelay = new int[] {
            100,
            150,
            100,
            150,
            100,
            150,
            100,
            2500,
            3500,
            100,
            50,
            50,
            50,
            50,
            50,
            50,
            50,
            50
        };
        imageRotation = new RotateFlipType?[] {
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.RotateNoneFlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            null,
            null,
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.RotateNoneFlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY
        };
        visible = new bool[] {
            false,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            false,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true
        };
        message = new string[] {
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            "[You] No, not in there!",
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            "[You] Shit on a shingle! A secret passage!"
        };
    }
    #endregion

    #region ----- CAT ANIMATION 2
    private void GetCat2AnimationEvent()
    {
        animationPath = new Point[] {
            P(64, 86),
            P(70, 92),
            P(64, 97),
            P(64, 110),
            P(64, 128)
        };
        animationDelay = new int[] {
            100,
            150,
            100,
            150,
            100
        };
        imageRotation = new RotateFlipType?[] {
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            null
        };
        visible = new bool[] {
            true,
            true,
            true,
            true,
            false,
        };
        message = new string[] {
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
        };
    }
    #endregion

    #region ----- HELM ANIMATION
    private void GetHelmAnimationEvent()
    {
        animationPath = new Point[] {
            P(32, 32),
            P(64, 42),
            P(86, 32),
            P(128, 42),
            P(164, 32),
            P(186, 42),
            P(228, 32),
            P(274, 7),
            P(270, 10),
            P(265, 15),
            P(245, 20),
            P(228, 32),
            P(228, 12)
        };
        animationDelay = new int[] {
            100,
            150,
            100,
            150,
            100,
            150,
            100,
            500,
            500,
            500,
            500,
            3000,
            500
        };
        imageRotation = new RotateFlipType?[] {
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.RotateNoneFlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate270FlipY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate180FlipY
        };
        visible = new bool[] {
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true
        };
        message = new string[] {
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            "[You] A Knight Helm! Wonder what McGyver-esque magic I can cook up with this one!"
        };
    }
    #endregion

    #region ----- GOAT ANIMATION
    private void GetGoatAnimationEvent()
    {
        animationPath = new Point[] {
            P(320, -5),
            P(320, 5),
            P(320, 25),
            P(320, 35),
            P(320, 65),
            P(320, 75),
            P(320, 95),
            P(320, 105),
            P(320, 105),
            P(320, 105),
            P(320, 105),
            P(325, 105),
            P(320, 95),
            P(325, 95),
            P(320, 85), //15
            P(325, 80),
            P(320, 75),
            P(325, 70),
            P(320, 65),
            P(320, 60),
            P(320, 55),
            P(320, 50),
            P(320, 45),
            P(320, 35),
            P(320, 30),
            P(320, 25),
            P(320, 15),
            P(320, 5),
            P(320, -5) //29
        };
        animationDelay = new int[] {
            100,
            150,
            100,
            150,
            100,
            150,
            100,
            500,
            500,
            500,
            350,
            500,
            500,
            350,
            1000, //15
            100,
            150,
            100,
            150,
            100,
            150,
            100,
            500,
            500,
            500,
            350,
            500,
            500,
            350
        };
        imageRotation = new RotateFlipType?[] {
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.RotateNoneFlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate270FlipY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate270FlipNone, //15
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.RotateNoneFlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate270FlipY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.Rotate270FlipNone
        };
        visible = new bool[] {
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true, //15
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true
        };
        message = new string[] {
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            "[Tony] BääääääääääääääääHHH!",
            string.Empty,
            "[Tony] BääääHHH!",
            string.Empty,
            string.Empty,
            "[Tony] BäääääääääääääHHH!",
            string.Empty,
            string.Empty,
            "BääääHHH!",
            string.Empty,
            "[Tony] BäääääääääääääHHH!", //15
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            "[Tony] BääääääääääääääääHHH!",
            string.Empty,
            "[Tony] BääääHHH!",
            string.Empty,
            string.Empty,
            "[Tony] BäääääääääääääHHH!",
            string.Empty,
            string.Empty,
            string.Empty,
            $"[You] Sweet got some {HelperMethods.ReplaceUnderscoreToString(QuestItems.Goat_Meat)}! Now if I only had some garlic, coriander, curry, cinnamon and yoghurt."
        };
    }
    #endregion

    #region ----- ELF ANIMATION
    private void GetElfAnimationEvent()
    {
        animationPath = new Point[] {
            P(32, 64),
            P(32, 75),
            P(32, 85),
            P(32, 95),
            P(32, 105),
            P(32, 115),
            P(32, 125),
            P(32, 135),
            P(32, 145),
            P(32, 155),
            P(32, 165),
            P(32, 175),
            P(32, 185),
            P(32, 195),
            P(32, 205), //15
            P(32, 215),
            P(32, 225),
            P(32, 235),
            P(32, 245),
            P(32, 255),
            P(32, 265),
            P(32, 275),
            P(32, 285),
            P(32, 295),
            P(32, 305),
            P(32, 315),
            P(32, 325),
            P(32, 335),
            P(32, 345),
            P(32, 352), //30
            P(42, 352),
            P(52, 352),
            P(62, 352),
            P(72, 352),
            P(82, 352)
        };
        animationDelay = new int[] {
            100,
            150,
            100,
            150,
            100,
            150,
            100,
            150,
            100,
            150,
            100,
            150,
            100,
            100,
            150, //15
            100,
            150,
            100,
            150,
            100,
            150,
            150,
            100,
            100,
            150,
            100,
            150,
            100,
            150,
            100, //30
            150,
            100,
            150,
            1500,
            150
        };
        imageRotation = new RotateFlipType?[] {
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.RotateNoneFlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate270FlipY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate270FlipNone, //15
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.RotateNoneFlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate90FlipX,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipX,
            RotateFlipType.Rotate270FlipY,
            RotateFlipType.Rotate270FlipXY,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate180FlipY,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate270FlipNone, //30
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate270FlipNone,
            RotateFlipType.Rotate270FlipNone
        };
        visible = new bool[] {
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true, //15
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true,
            true, //30
            true,
            true,
            true,
            true,
            true
        };
        message = new string[] {
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            "[Evil Christmas Elf] That belong to Ton.. That belongs to me, and I am here to reclaim it", //15
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty, //30
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            $"[You] No! Not the snakeskin! NooOooo..."
        };
    }
    #endregion
}