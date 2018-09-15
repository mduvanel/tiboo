using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using Tiboo;

public class GameTest
{
    [Test]
    public void GameThrowsWithoutMouse()
    {
        List<Player> players = new List<Player> {
            new Player(Player.Animal.MOUSE, Player.Color.BLUE, new Player.Position(0, 0))
        };
        Assert.That(() => new Game(players, new Board()),
                    Throws.Exception.TypeOf<System.Exception>());
    }

    [Test]
    public void GameThrowsWithoutRabbit()
    {
        List<Player> players = new List<Player> {
            new Player(Player.Animal.RABBIT, Player.Color.BLUE, new Player.Position(0, 0))
        };
        Assert.That(() => new Game(players, new Board()),
                    Throws.Exception.TypeOf<System.Exception>());
    }

    [Test]
    public void GameConstructsWithBothMouseAndRabbit()
    {
        List<Player> players = new List<Player>()
        {
            new Player(Player.Animal.RABBIT, Player.Color.BLUE, new Player.Position(0, 0)),
            new Player(Player.Animal.MOUSE, Player.Color.RED, new Player.Position(0, 0))
        };
        Game game = new Game(players, new Board());
    }

    [Test]
    public void TestPossibleRabbitMovements()
    {
        Board board = new Board();

        // Create rabbit on the top-left tile, with holes that let him go from (0, 0)
        // to (2, 0)
        Player rabbit = new Player(Player.Animal.RABBIT, Player.Color.BLUE, new Player.Position(0, 0));
        board.SetWall(new Wall(Wall.Type.OPEN), 0, 0, Tile.Direction.EAST);
        board.SetWall(new Wall(Wall.Type.CLOSED), 0, 0, Tile.Direction.SOUTH);
        board.SetWall(new Wall(Wall.Type.RABBIT_HOLE), 1, 0, Tile.Direction.EAST);
        board.SetWall(new Wall(Wall.Type.MOUSE_HOLE), 1, 0, Tile.Direction.SOUTH);

        // Create dummy mouse on the (3, 3) tile
        Player mouse = new Player(Player.Animal.MOUSE, Player.Color.GREEN, new Player.Position(3, 3));
        List<Player> players = new List<Player> { rabbit, mouse };
        Game game = new Game(players, board);

        // Verify starting position
        Assert.AreEqual(rabbit.Pos, new Player.Position(0, 0));

        // Rabbit cannot move through CLOSED wall
        Assert.IsFalse(game.Move(Tile.Direction.SOUTH));
        Assert.AreEqual(rabbit.Pos, new Player.Position(0, 0));

        // Rabbit can move through OPEN wall
        Assert.IsTrue(game.Move(Tile.Direction.EAST));
        Assert.AreEqual(rabbit.Pos, new Player.Position(1, 0));

        // Rabbit cannot move through MOUSE_HOLE wall
        Assert.IsFalse(game.Move(Tile.Direction.SOUTH));
        Assert.AreEqual(rabbit.Pos, new Player.Position(1, 0));

        // Rabbit can move through RABBIT_HOLE wall
        Assert.IsTrue(game.Move(Tile.Direction.EAST));
        Assert.AreEqual(rabbit.Pos, new Player.Position(2, 0));
    }

    [Test]
    public void TestPossibleMouseMovements()
    {
        Board board = new Board();

        // Create mouse on the top-left tile, with holes that let him go from (0, 0)
        // to (2, 0)
        Player mouse = new Player(Player.Animal.MOUSE, Player.Color.GREEN, new Player.Position(0, 0));
        board.SetWall(new Wall(Wall.Type.OPEN), 0, 0, Tile.Direction.EAST);
        board.SetWall(new Wall(Wall.Type.CLOSED), 0, 0, Tile.Direction.SOUTH);
        board.SetWall(new Wall(Wall.Type.RABBIT_HOLE), 1, 0, Tile.Direction.SOUTH);
        board.SetWall(new Wall(Wall.Type.MOUSE_HOLE), 1, 0, Tile.Direction.EAST);

        // Create dummy rabbit
        Player rabbit = new Player(Player.Animal.RABBIT, Player.Color.BLUE, new Player.Position(3, 3));
        List<Player> players = new List<Player> { mouse, rabbit };
        Game game = new Game(players, board);

        // Verify starting position
        Assert.AreEqual(mouse.Pos, new Player.Position(0, 0));

        // Mouse cannot move through CLOSED wall
        Assert.IsFalse(game.Move(Tile.Direction.SOUTH));
        Assert.AreEqual(mouse.Pos, new Player.Position(0, 0));

        // Mouse can move through OPEN wall
        Assert.IsTrue(game.Move(Tile.Direction.EAST));
        Assert.AreEqual(mouse.Pos, new Player.Position(1, 0));

        // Mouse cannot move through RABBIT_HOLE wall
        Assert.IsFalse(game.Move(Tile.Direction.SOUTH));
        Assert.AreEqual(mouse.Pos, new Player.Position(1, 0));

        // Mouse can move through MOUSE_HOLE wall
        Assert.IsTrue(game.Move(Tile.Direction.EAST));
        Assert.AreEqual(mouse.Pos, new Player.Position(2, 0));

    }


    [Test]
    public void TestMagicDoorMovements()
    {
        Board board = new Board();

        // Create rabbit on the (0, 0) tile
        Player rabbit = new Player(Player.Animal.RABBIT, Player.Color.BLUE, new Player.Position(0, 0));

        // Create mouse on the (2, 0) tile
        Player mouse = new Player(Player.Animal.MOUSE, Player.Color.GREEN, new Player.Position(2, 0));

        // Set Magic door next to the rabbit, and an OPEN wall to move the mouse
        board.SetWall(new MagicDoor(), 0, 0, Tile.Direction.EAST);
        board.SetWall(new Wall(Wall.Type.OPEN), 1, 0, Tile.Direction.EAST);

        List<Player> players = new List<Player> { rabbit, mouse };
        Game game = new Game(players, board);

        // Verify starting positions
        Assert.AreEqual(rabbit.Pos, new Player.Position(0, 0));
        Assert.AreEqual(mouse.Pos, new Player.Position(2, 0));

        // Rabbit cannot move through closed MagicDoor
        Assert.IsFalse(game.Move(Tile.Direction.EAST));
        Assert.AreEqual(rabbit.Pos, new Player.Position(0, 0));

        // Mouse moves to (1, 0) through OPEN wall
        game.NextPlayer();
        Assert.IsTrue(game.Move(Tile.Direction.WEST));
        Assert.AreEqual(mouse.Pos, new Player.Position(1, 0));

        // Rabbit can move through MagicDoor
        game.NextPlayer();
        Assert.IsTrue(game.Move(Tile.Direction.EAST));
        Assert.AreEqual(rabbit.Pos, new Player.Position(1, 0));

        // Mouse can also move through MagicDoor now that it is opened
        game.NextPlayer();
        Assert.IsTrue(game.Move(Tile.Direction.WEST));
        Assert.AreEqual(mouse.Pos, new Player.Position(0, 0));
    }
}