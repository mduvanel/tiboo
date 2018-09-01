using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using Tiboo;

public class GameTest
{
    [Test]
    public void GameThrowsWithoutMouse()
    {
        List<Player> players = new List<Player>();
        players.Add(new Player(Player.Animal.MOUSE, Player.Color.BLUE));
        Assert.That(() => new Game(players),
                    Throws.Exception.TypeOf<System.Exception>());
    }

    [Test]
    public void GameThrowsWithoutRabbit()
    {
        List<Player> players = new List<Player>();
        players.Add(new Player(Player.Animal.RABBIT, Player.Color.BLUE));
        Assert.That(() => new Game(players),
                    Throws.Exception.TypeOf<System.Exception>());
    }

    [Test]
    public void GameConstructsWithBothMouseAndRabbit()
    {
        List<Player> players = new List<Player>();
        players.Add(new Player(Player.Animal.RABBIT, Player.Color.BLUE));
        players.Add(new Player(Player.Animal.MOUSE, Player.Color.RED));
        Game game = new Game(players);
    }
}
