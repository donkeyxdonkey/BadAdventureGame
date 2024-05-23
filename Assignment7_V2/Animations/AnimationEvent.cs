using System.Drawing;

namespace Assignment7_V2.Animations;

public class AnimationEvent
{
    public Point Path => _path;

    public ushort Delay => _delay;

    public bool Visible => _visible;

    public string Message => _message;

    public RotateFlipType? FlipType => _flipType;

    private Point _path;
    private ushort _delay;
    private bool _visible;
    private string _message;
    private RotateFlipType? _flipType;

    /// <summary>Default constructor</summary>
    public AnimationEvent(Point path, ushort delay, bool visible = true, string message = "", RotateFlipType? flipType = null)
    {
        _path = path;
        _delay = delay;
        _flipType = flipType;
        _visible = visible;
        _message = message;
    }

    public AnimationEvent[] GenerateEvent()
    {
        //animationPath = new Point[] {
        //    P(640, 350),
        //    P(630, 352),
        //    P(620, 350),
        //    P(640, 350),
        //    P(640, 350),
        //    P(640, 350),
        //    P(630, 352),
        //    P(640, 350),
        //    P(640, 350),
        //    P(576, 160),
        //    P(576, 140),
        //    P(576, 110),
        //    P(576, 80),
        //    P(576, 40),
        //    P(576, 80),
        //    P(576, 100),
        //    P(576, 130),
        //    P(576, 160)
        //};
        //animationDelay = new int[] {
        //    100,
        //    150,
        //    100,
        //    150,
        //    100,
        //    150,
        //    100,
        //    2500,
        //    3500,
        //    100,
        //    50,
        //    50,
        //    50,
        //    50,
        //    50,
        //    50,
        //    50,
        //    50
        //};
        //imageRotation = new RotateFlipType?[] {
        //    RotateFlipType.Rotate90FlipX,
        //    RotateFlipType.Rotate270FlipXY,
        //    RotateFlipType.Rotate180FlipY,
        //    RotateFlipType.RotateNoneFlipXY,
        //    RotateFlipType.Rotate270FlipX,
        //    RotateFlipType.Rotate90FlipX,
        //    RotateFlipType.Rotate270FlipXY,
        //    RotateFlipType.Rotate180FlipY,
        //    null,
        //    null,
        //    RotateFlipType.Rotate90FlipX,
        //    RotateFlipType.Rotate270FlipXY,
        //    RotateFlipType.Rotate180FlipY,
        //    RotateFlipType.RotateNoneFlipXY,
        //    RotateFlipType.Rotate270FlipX,
        //    RotateFlipType.Rotate90FlipX,
        //    RotateFlipType.Rotate270FlipXY,
        //    RotateFlipType.Rotate180FlipY
        //};
        //visible = new bool[] {
        //    false,
        //    true,
        //    true,
        //    true,
        //    true,
        //    true,
        //    true,
        //    true,
        //    false,
        //    true,
        //    true,
        //    true,
        //    true,
        //    true,
        //    true,
        //    true,
        //    true,
        //    true
        //};
        //message = new string[] {
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    "[You] No, not in there!",
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    string.Empty,
        //    "[You] Shit on a shingle! A secret passage!"
        //};
    }
}
