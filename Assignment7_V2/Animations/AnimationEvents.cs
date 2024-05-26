using Assignment7_V2.Enumerations;
using System.Drawing;
using System.Linq;

namespace Assignment7_V2.Animations;

class AnimationEvents
{
    #region ----- PROPERTIES        
    /// <summary>An array of point where targeted image will move</summary>
    public Point[] AnimationPath { get => _animationPath; }

    /// <summary>An array of integer with delay between each animation step</summary>
    public int[] AnimationDelay { get => _animationDelay; }

    /// <summary>An array of rotateflip setting each flip for the animation (if one)</summary>
    public RotateFlipType?[] ImageRotation { get => _imageRotation; }

    /// <summary>An array of bool indicating if image is to be visible or not each animation step</summary>
    public bool[] Visible { get => _visible; }

    /// <summary>An array of messages that can be displayed during the animation</summary>
    public string[] Message { get => _message; }

    /// <summary>Getter for animation itterations</summary>
    public int Count { get => _count; }

    /// <summary>Current itteration for looping the animation</summary>
    public int Itterations { get => _itterations; set => _itterations = value; }

    /// <summary>Questitem tied to the animation</summary>
    public QuestItems QuestItem { get => _questItem; }
    #endregion

    #region ----- FIELDS
    private readonly Point[] _animationPath;
    private readonly int[] _animationDelay;
    private readonly RotateFlipType?[] _imageRotation;
    private readonly bool[] _visible;
    private readonly string[] _message;
    private readonly int _count;
    private readonly QuestItems _questItem;

    private int _itterations;
    #endregion

    #region ----- CONSTRUCTOR
    /// <summary>Constructor constructing an animation based in input QuestItem</summary>
    /// <param name="questItem">Questitem tied to the animation</param>
    public AnimationEvents(QuestItems questItem) : this(AnimationEventFactory.Create(questItem))
    {
        _questItem = questItem;
        _itterations = 0;
        _count = _animationPath.Length;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    private AnimationEvents(AnimationEvent[] eventObject)
    {
        _animationPath = eventObject.Select(x => x.Path).ToArray();
        _animationDelay = eventObject.Select(x => x.Delay).ToArray();
        _visible = eventObject.Select(x => x.Visible).ToArray();
        _imageRotation = eventObject.Select(x => x.FlipType).ToArray();
        _message = eventObject.Select(x => x.Message).ToArray();
    }
    #endregion
}