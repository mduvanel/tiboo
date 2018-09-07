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
        players.Add(new Player(Player.Animal.MOUSE, Player.Color.BLUE, new Player.Position(0, 0)));
        Assert.That(() => new Game(players),
                    Throws.Exception.TypeOf<System.Exception>());
    }

    [Test]
    public void GameThrowsWithoutRabbit()
    {
        List<Player> players = new List<Player>();
        players.Add(new Player(Player.Animal.RABBIT, Player.Color.BLUE, new Player.Position(0, 0)));
        Assert.That(() => new Game(players),
                    Throws.Exception.TypeOf<System.Exception>());
    }

    [Test]
    public void GameConstructsWithBothMouseAndRabbit()
    {
        List<Player> players = new List<Player>();
        players.Add(new Player(Player.Animal.RABBIT, Player.Color.BLUE, new Player.Position(0, 0)));
        players.Add(new Player(Player.Animal.MOUSE, Player.Color.RED, new Player.Position(0, 0)));
        Game game = new Game(players);
    }
    
    [Test]
    public void TestRabbitMovements()
    {
        Board board = new Board();
        board.SetWall(new Wall(Wall.Type.OPEN), 0, 0, Tile.Direction.EAST);
        board.SetWall(new Wall(Wall.Type.CLOSED), 0, 0, Tile.Direction.SOUTH);
        board.SetWall(new Wall(Wall.Type.RABBIT), 1, 0, Tile.Direction.EAST);
        board.SetWall(new Wall(Wall.Type.MOUSE), 1, 0, Tile.Direction.SOUTH);
        
        Player rabbit = new Player(Player.Animal.RABBIT, Player.Color.BLUE, new Player.Position(0, 0));
        List<Player> players = new List<Player>();
        players.Add(rabbit);
        players.Add(rabbit);
        Game game = new Game(players, board);

        Assert.AreEqual(rabbit.Position, new Position(0, 0));

        // Cannot move through CLOSED door
        game.Move(Tile.Direction.SOUTH);
        Assert.AreEqual(rabbit.Position, new Position(0, 0));
        
        // Can move through OPEN door
        game.Move(Tile.Direction.EAST);
        Assert.AreEqual(rabbit.Position, new Position(1, 0));

        // Cannot move through MOUSE door
        game.Move(Tile.Direction.SOUTH);
        Assert.AreEqual(rabbit.Position, new Position(1, 0));
        
        // Can move through RABBIT door
        game.Move(Tile.Direction.EAST);
        Assert.AreEqual(rabbit.Position, new Position(2, 0));
    }
    
    [Test]
    public void TestMouseMovements()
    {
        Board board = new Board();
        board.SetWall(new Wall(Wall.Type.OPEN), 0, 0, Tile.Direction.EAST);
        board.SetWall(new Wall(Wall.Type.CLOSED), 0, 0, Tile.Direction.SOUTH);
        board.SetWall(new Wall(Wall.Type.RABBIT), 1, 0, Tile.Direction.EAST);
        board.SetWall(new Wall(Wall.Type.MOUSE), 1, 0, Tile.Direction.SOUTH);
        
        Player mouse = new Player(Player.Animal.MOUSE, Player.Color.BLUE, new Player.Position(0, 0));
        List<Player> players = new List<Player>();
        players.Add(mouse);
        players.Add(mouse);
        Game game = new Game(players, board);

        Assert.AreEqual(rabbit.Position, new Position(0, 0));

        // Cannot move through CLOSED door
        game.Move(Tile.Direction.SOUTH);
        Assert.AreEqual(rabbit.Position, new Position(0, 0));
        
        // Can move through OPEN door
        game.Move(Tile.Direction.EAST);
        Assert.AreEqual(rabbit.Position, new Position(1, 0));

        // Cannot move through RABBIT door
        game.Move(Tile.Direction.EAST);
        Assert.AreEqual(rabbit.Position, new Position(1, 0));
        
        // Can move through MOUSE door
        game.Move(Tile.Direction.SOUTH);
        Assert.AreEqual(rabbit.Position, new Position(1, 1));
    }

}
