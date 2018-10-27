using NUnit.Framework;
using System.Collections.Generic;
using Tiboo;

public class SoundMixerTest
{
    [Test]
    public void GetMoveSoundFXRabbitRabbitHole()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.RABBIT,
                Player.Color.BLUE,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.RABBIT_HOLE, Status = MoveDetails.MoveStatus.SUCCESS_KNOWN };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.RABBIT_HOLE, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXMouseRabbitHole()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.MOUSE,
                Player.Color.RED,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.RABBIT_HOLE, Status = MoveDetails.MoveStatus.FAILURE };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.RABBIT_HOLE, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_NOT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXRabbitMouseHole()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.RABBIT,
                Player.Color.BLUE,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.MOUSE_HOLE, Status = MoveDetails.MoveStatus.FAILURE };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.MOUSE_HOLE, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_NOT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXMouseMouseHole()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.MOUSE,
                Player.Color.RED,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.MOUSE_HOLE, Status = MoveDetails.MoveStatus.SUCCESS_KNOWN };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.MOUSE_HOLE, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXRabbitOpen()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.RABBIT,
                Player.Color.BLUE,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.OPEN, Status = MoveDetails.MoveStatus.SUCCESS_NEW };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.OPEN_WALL, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXMouseOpen()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.MOUSE,
                Player.Color.RED,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.OPEN, Status = MoveDetails.MoveStatus.SUCCESS_NEW };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.OPEN_WALL, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXRabbitClosed()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.RABBIT,
                Player.Color.BLUE,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.CLOSED, Status = MoveDetails.MoveStatus.FAILURE };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.CLOSED_WALL, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_NOT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXMouseClosed()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.MOUSE,
                Player.Color.RED,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.CLOSED, Status = MoveDetails.MoveStatus.FAILURE };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.CLOSED_WALL, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_NOT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXRabbitBorder()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.RABBIT,
                Player.Color.BLUE,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.CLOSED, Status = MoveDetails.MoveStatus.BORDER };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.BORDER, list[0]);
    }

    [Test]
    public void GetMoveSoundFXMouseBorder()
    {
        MoveDetails moveDetails = new MoveDetails(
            new Player(
                Player.Animal.MOUSE,
                Player.Color.RED,
                new Player.Position(0, 0)
            )
        )
        { WallType = Wall.Type.CLOSED, Status = MoveDetails.MoveStatus.BORDER };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSoundFX(moveDetails);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.BORDER, list[0]);
    }
}
