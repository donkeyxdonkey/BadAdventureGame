using Assignment7_V2.Animations;
using Assignment7_V2.Enumerations;
using System.Drawing;
using System.Linq;

namespace Assignment7_V2;

class AnimationEvents
{
    #region ----- PROPERTIES        
    /// <summary>An array of point where targeted image will move</summary>
    public Point[] AnimationPath { get => animationPath; set => animationPath = value; }

    /// <summary>An array of integer with delay between each animation step</summary>
    public int[] AnimationDelay { get => animationDelay; set => animationDelay = value; }

    /// <summary>An array of rotateflip setting each flip for the animation (if one)</summary>
    public RotateFlipType?[] ImageRotation { get => imageRotation; set => imageRotation = value; }

    /// <summary>An array of bool indicating if image is to be visible or not each animation step</summary>
    public bool[] Visible { get => visible; set => visible = value; }

    /// <summary>An array of messages that can be displayed during the animation</summary>
    public string[] Message { get => message; set => message = value; }

    /// <summary>Getter for animation itterations</summary>
    public int Count { get => count; }

    /// <summary>Current itteration for looping the animation</summary>
    public int Itterations { get => itterations; set => itterations = value; }

    /// <summary>Questitem tied to the animation</summary>
    public QuestItems QuestItem { get => questItem; set => questItem = value; }
    #endregion

    #region ----- FIELDS
    private Point[] animationPath;
    private int[] animationDelay;
    private RotateFlipType?[] imageRotation;
    private bool[] visible;
    private string[] message;
    private int count;
    private int itterations;
    private QuestItems questItem;
    #endregion

    #region ----- CONSTRUCTOR
    /// <summary>Constructor constructing an animation based in input QuestItem</summary>
    /// <param name="qItem">Questitem tied to the animation</param>
    public AnimationEvents(QuestItems qItem) : this(AnimationEventFactory.Create(qItem))
    {
        questItem = qItem;
        itterations = 0;
        count = animationPath.Length;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    private AnimationEvents(AnimationEvent[] eventObject)
    {
        animationPath = eventObject.Select(x => x.Path).ToArray();
        animationDelay = eventObject.Select(x => x.Delay).ToArray();
        visible = eventObject.Select(x => x.Visible).ToArray();
        imageRotation = eventObject.Select(x => x.FlipType).ToArray();
        message = eventObject.Select(x => x.Message).ToArray();
    }
    #endregion
}