using Assignment7_V2.Enumerations;
using System.Drawing;

namespace Assignment7_V2.Animations;

public class Events
{
    public static AnimationEvent[] AnimationEventFactory(QuestItems questItem)
    {
        switch (questItem)
        {
            case QuestItems.Cat:
                return GetCatAnimationEvent();
            case QuestItems.Fishing_Rod:
                //return GetHelmAnimationEvent();
                break;
            case QuestItems.Burger:
                //return GetGoatAnimationEvent();
                break;
            case QuestItems.Raindeer_Dung:
                return GetCat2AnimationEvent();
            case QuestItems.Snake_Skin:
                //return GetElfAnimationEvent();
                break;
        }

        return [];
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
            new(new Point(64, 128), delay: 100, visible: false, flipType: RotateFlipType.Rotate180FlipY),

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
