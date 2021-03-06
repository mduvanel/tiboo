﻿using NUnit.Framework;
using System.Collections.Generic;
using Tiboo;

public class SoundMixerTest
{
    Player BLUE_RABBIT = new Player(
        Player.Animal.RABBIT,
        Player.Color.BLUE,
        new Position(0, 0)
    );

    Player RED_MOUSE = new Player(
        Player.Animal.MOUSE,
        Player.Color.RED,
        new Position(0, 0)
    );

    [Test]
    public void GetMoveSoundFXRabbitRabbitHole()
    {
        MoveDetails moveDetails = new MoveDetails(BLUE_RABBIT)
        {
            WallType = Wall.Type.RABBIT_HOLE,
            Status = MoveDetails.MoveStatus.SUCCESS_KNOWN
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.RABBIT_HOLE, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXMouseRabbitHole()
    {
        MoveDetails moveDetails = new MoveDetails(RED_MOUSE)
        {
            WallType = Wall.Type.RABBIT_HOLE,
            Status = MoveDetails.MoveStatus.FAILURE
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.RABBIT_HOLE, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_NOT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXRabbitMouseHole()
    {
        MoveDetails moveDetails = new MoveDetails(BLUE_RABBIT)
        {
            WallType = Wall.Type.MOUSE_HOLE,
            Status = MoveDetails.MoveStatus.FAILURE
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.MOUSE_HOLE, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_NOT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXMouseMouseHole()
    {
        MoveDetails moveDetails = new MoveDetails(RED_MOUSE)
        {
            WallType = Wall.Type.MOUSE_HOLE,
            Status = MoveDetails.MoveStatus.SUCCESS_KNOWN
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.MOUSE_HOLE, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXRabbitOpen()
    {
        MoveDetails moveDetails = new MoveDetails(BLUE_RABBIT)
        {
            WallType = Wall.Type.OPEN,
            Status = MoveDetails.MoveStatus.SUCCESS_NEW
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.OPEN_WALL, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXMouseOpen()
    {
        MoveDetails moveDetails = new MoveDetails(RED_MOUSE)
        {
            WallType = Wall.Type.OPEN,
            Status = MoveDetails.MoveStatus.SUCCESS_NEW
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.OPEN_WALL, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXRabbitClosed()
    {
        MoveDetails moveDetails = new MoveDetails(BLUE_RABBIT)
        {
            WallType = Wall.Type.CLOSED,
            Status = MoveDetails.MoveStatus.FAILURE
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.CLOSED_WALL, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_NOT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXMouseClosed()
    {
        MoveDetails moveDetails = new MoveDetails(RED_MOUSE)
        {
            WallType = Wall.Type.CLOSED,
            Status = MoveDetails.MoveStatus.FAILURE
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.CLOSED_WALL, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.THOU_SHALT_NOT_PASS, list[1]);
    }

    [Test]
    public void GetMoveSoundFXRabbitBorder()
    {
        MoveDetails moveDetails = new MoveDetails(BLUE_RABBIT)
        {
            WallType = Wall.Type.CLOSED,
            Status = MoveDetails.MoveStatus.ABORTED
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.BORDER, list[0]);
    }

    [Test]
    public void GetMoveSoundFXMouseBorder()
    {
        MoveDetails moveDetails = new MoveDetails(RED_MOUSE)
        {
            WallType = Wall.Type.CLOSED,
            Status = MoveDetails.MoveStatus.ABORTED
        };

        List<SoundMixer.SoundFX> list = SoundMixer.GetMoveSounds(moveDetails);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.BORDER, list[0]);
    }

    [Test]
    public void GetHelloSoundsBlueRabbit()
    {
        List<SoundMixer.SoundFX> list = SoundMixer.GetWelcomeSounds(BLUE_RABBIT);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.HELLO, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.BLUE_RABBIT, list[1]);
        Assert.AreEqual(SoundMixer.SoundFX.WHERE_TO_GO, list[2]);
    }

    [Test]
    public void GetHelloSoundsGreenRabbit()
    {
        Player player = new Player(
            Player.Animal.RABBIT,
            Player.Color.GREEN,
            new Position(0, 0)
        );

        List<SoundMixer.SoundFX> list = SoundMixer.GetWelcomeSounds(player);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.HELLO, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.GREEN_RABBIT, list[1]);
        Assert.AreEqual(SoundMixer.SoundFX.WHERE_TO_GO, list[2]);
    }

    [Test]
    public void GetHelloSoundsRedMouse()
    {
        List<SoundMixer.SoundFX> list = SoundMixer.GetWelcomeSounds(RED_MOUSE);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.HELLO, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.RED_MOUSE, list[1]);
        Assert.AreEqual(SoundMixer.SoundFX.WHERE_TO_GO, list[2]);
    }

    [Test]
    public void GetHelloSoundsYellowMouse()
    {
        Player player = new Player(
            Player.Animal.MOUSE,
            Player.Color.YELLOW,
            new Position(0, 0)
        );

        List<SoundMixer.SoundFX> list = SoundMixer.GetWelcomeSounds(player);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.HELLO, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.YELLOW_MOUSE, list[1]);
        Assert.AreEqual(SoundMixer.SoundFX.WHERE_TO_GO, list[2]);
    }

    [Test]
    public void GetNextPlayerSounds()
    {
        List<Player> players = new List<Player>() { BLUE_RABBIT, RED_MOUSE };
        Game game = new Game(players, new Board(), 1);
        MoveDetails moveDetails = new MoveDetails(RED_MOUSE);

        List<SoundMixer.SoundFX> list = SoundMixer.GetNextPlayerSounds(moveDetails, game);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.HELLO, list[0]);
        Assert.AreEqual(SoundMixer.SoundFX.BLUE_RABBIT, list[1]);
        Assert.AreEqual(SoundMixer.SoundFX.WHERE_TO_GO, list[2]);
    }

    [Test]
    public void GetNextPlayerSoundsPlayAgain()
    {
        List<Player> players = new List<Player>() { BLUE_RABBIT, RED_MOUSE };
        Game game = new Game(players, new Board(), 1);
        MoveDetails moveDetails = new MoveDetails(BLUE_RABBIT) { PlayAgain = true };

        List<SoundMixer.SoundFX> list = SoundMixer.GetNextPlayerSounds(moveDetails, game);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.PLAY_AGAIN, list[0]);
    }

    [Test]
    public void GetNextPlayerSoundsGameOver()
    {
        List<Player> players = new List<Player>() { BLUE_RABBIT, RED_MOUSE };
        Game game = new Game(players, new Board(), 1);
        game.NextPlayer();
        game.NextPlayer();

        List<SoundMixer.SoundFX> list = SoundMixer.GetNextPlayerSounds(null, game);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(SoundMixer.SoundFX.DEFEAT, list[0]);
    }
}
