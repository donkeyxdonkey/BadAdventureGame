using Assignment7_V2.Enumerations;
using Assignment7_V2.Extensions;
using System.Drawing;

namespace Assignment7_V2.Animations;

public class AnimationEventFactory
{
    public static AnimationEvent[] Create(QuestItems questItem)
    {
        return questItem switch
        {
            QuestItems.Cat => GetCatAnimationEvent(),
            QuestItems.Fishing_Rod => GetHelmAnimationEvent(),
            QuestItems.Burger => GetGoatAnimationEvent(),
            QuestItems.Raindeer_Dung => GetCat2AnimationEvent(),
            QuestItems.Snake_Skin => GetElfAnimationEvent(),
            _ => [],
        };
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    private static AnimationEvent[] GetCat2AnimationEvent()
    {
        return
        [
            new(new Point(64, 86), delay: 100, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(70, 92), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(64, 97), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(64, 110), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(64, 128), delay: 100, visible: false, flipType: RotateFlipType.Rotate180FlipY)
        ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    private static AnimationEvent[] GetElfAnimationEvent()
    {
        return
        [
            new(new Point(32, 64), delay: 100, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(32, 75), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(32, 85), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(32, 95), delay: 150, flipType: RotateFlipType.RotateNoneFlipXY),
            new(new Point(32, 105), delay: 100, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(32, 115), delay: 150, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(32, 125), delay: 100, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(32, 135), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(32, 145), delay: 100, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(32, 155), delay: 150, flipType: RotateFlipType.Rotate270FlipY),
            new(new Point(32, 165), delay: 100, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(32, 175), delay: 150, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(32, 185), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(32, 195), delay: 100, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(32, 205), delay: 150, true, message: "[Evil Christmas Elf] That belong to Ton.. That belongs to me, and I am here to reclaim it", flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(32, 215), delay: 100, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(32, 225), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(32, 235), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(32, 245), delay: 150, flipType: RotateFlipType.RotateNoneFlipXY),
            new(new Point(32, 255), delay: 100, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(32, 265), delay: 150, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(32, 275), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(32, 285), delay: 100, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(32, 295), delay: 100, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(32, 305), delay: 150, flipType: RotateFlipType.Rotate270FlipY),
            new(new Point(32, 315), delay: 100, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(32, 325), delay: 150, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(32, 335), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(32, 345), delay: 150, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(32, 352), delay: 100, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(42, 352), delay: 150, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(52, 352), delay: 100, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(62, 352), delay: 150, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(72, 352), delay: 1500, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(82, 352), delay: 150, visible: true, message: "[You] No! Not the snakeskin! NooOooo...", flipType: RotateFlipType.Rotate270FlipNone),
        ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    private static AnimationEvent[] GetHelmAnimationEvent()
    {
        return
        [
            new(new Point(32, 32), delay: 100, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(64, 42), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(86, 32), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(128, 42), delay: 150, flipType: RotateFlipType.RotateNoneFlipXY),
            new(new Point(164, 32), delay: 100, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(186, 42), delay: 150, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(228, 32), delay: 100, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(274, 7), delay: 500, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(270, 10), delay: 500, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(265, 15), delay: 500, flipType: RotateFlipType.Rotate270FlipY),
            new(new Point(245, 20), delay: 500, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(228, 32), delay: 3000, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(228, 12), delay: 500, visible: true, message: "[You] A Knight Helm! Wonder what McGyver-esque magic I can cook up with this one!", flipType: RotateFlipType.Rotate180FlipY)
        ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    private static AnimationEvent[] GetGoatAnimationEvent()
    {
        return
        [
            new(new Point(320, -5), delay: 100, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(320, 5), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(320, 25), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(320, 35), delay: 150, flipType: RotateFlipType.RotateNoneFlipXY),
            new(new Point(320, 65), delay: 100, visible: true, message: "[Tony] BääääääääääääääääHHH!", flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(320, 75), delay: 150, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(320, 95), delay: 100, visible: true, message: "[Tony] BääääHHH!", flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(320, 105), delay: 500, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(320, 105), delay: 500, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(320, 105), delay: 500, visible: true, message: "[Tony] BäääääääääääääHHH!", flipType: RotateFlipType.Rotate270FlipY),
            new(new Point(320, 105), delay: 350, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(325, 105), delay: 500, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(320, 95), delay: 500, visible: true, message: "[You] BääääHHH?", flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(325, 95), delay: 350, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(320, 85), delay: 1000, visible: true, message: "[Tony] BäääääääääääääHHH!", flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(325, 80), delay: 100, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(320, 75), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(325, 70), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(320, 65), delay: 150, flipType: RotateFlipType.RotateNoneFlipXY),
            new(new Point(320, 60), delay: 100, visible: true, message: "[Tony] BääääääääääääääääHHH!", flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(320, 55), delay: 150, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(320, 50), delay: 100, visible: true, message: "[Tony] BääääHHH!", flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(320, 45), delay: 500, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(320, 35), delay: 500, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(320, 30), delay: 500, visible: true, message: "[Tony] BäääääääääääääHHH!", flipType: RotateFlipType.Rotate270FlipY),
            new(new Point(320, 25), delay: 350, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(320, 15), delay: 500, flipType: RotateFlipType.Rotate270FlipNone),
            new(new Point(320, 5), delay: 500, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(320, -5), delay: 350, visible: true, message: $"[You] Sweet got some {QuestItems.Goat_Meat.ReplaceUnderscore()}! Now if I only had some garlic, coriander, curry, cinnamon and yoghurt.", flipType: RotateFlipType.Rotate270FlipNone),
        ];
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    private static AnimationEvent[] GetCatAnimationEvent()
    {
        return
        [
            new(new Point(640, 350), delay: 100, visible: false, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(630, 352), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(620, 350), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(640, 350), delay: 150, flipType: RotateFlipType.RotateNoneFlipXY),
            new(new Point(640, 350), delay: 100, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(640, 350), delay: 150, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(630, 352), delay: 100, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(640, 350), delay: 2500, visible: true),
            new(new Point(640, 350), delay: 3500, visible: false, message: "[You] No, not in there!"),
            new(new Point(576, 160), delay: 100, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(576, 140), delay: 50, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(576, 110), delay: 50, flipType: RotateFlipType.Rotate180FlipY),
            new(new Point(576, 80), delay: 50, flipType: RotateFlipType.RotateNoneFlipXY),
            new(new Point(576, 40), delay: 50, flipType: RotateFlipType.Rotate270FlipX),
            new(new Point(576, 80), delay: 50, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(576, 100), delay: 50, flipType: RotateFlipType.Rotate90FlipX),
            new(new Point(576, 130), delay: 50, flipType: RotateFlipType.Rotate270FlipXY),
            new(new Point(576, 160), delay: 50, visible: true, message: "[You] Shit on a shingle! A secret passage!", RotateFlipType.Rotate180FlipY)
        ];
    }
}
