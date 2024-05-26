using System.Drawing;

namespace Assignment7_V2.Animations;

public class AnimationEvent
{
    public Point Path => _path;

    public int Delay => _delay;

    public bool Visible => _visible;

    public string Message => _message;

    public RotateFlipType? FlipType => _flipType;

    private Point _path;
    private int _delay;
    private bool _visible;
    private string _message;
    private RotateFlipType? _flipType;

    /// <summary>Default constructor</summary>
    public AnimationEvent(Point path, int delay, bool visible = true, string message = "", RotateFlipType? flipType = null)
    {
        _path = path;
        _delay = delay;
        _flipType = flipType;
        _visible = visible;
        _message = message;
    }
}
