using NUnit.Framework;
using Tiboo;

public class BoardTest
{
    [Test]
    public void SetWallEastOf0Works()
    {
        Board board = new Board();
        Wall testWall = new Wall(Wall.Type.CLOSED);

        Assert.AreEqual(null, board.GetTile(0, 0).GetWall(Tile.Direction.EAST));
        Assert.AreEqual(null, board.GetTile(1, 0).GetWall(Tile.Direction.WEST));

        board.SetWall(testWall, 0, 0, Tile.Direction.EAST);

        Assert.AreSame(testWall, board.GetTile(0, 0).GetWall(Tile.Direction.EAST));
        Assert.AreSame(testWall, board.GetTile(1, 0).GetWall(Tile.Direction.WEST));
    }

    [Test]
    public void SetWallWestOf0Throws()
    {
        Board board = new Board();
        Assert.That(() => board.SetWall(new Wall(Wall.Type.CLOSED), 0, 0, Tile.Direction.WEST),
                    Throws.Exception.TypeOf<System.IndexOutOfRangeException>());
    }

    [Test]
    public void SetWallWestOf3Works()
    {
        Board board = new Board();
        Wall testWall = new Wall(Wall.Type.CLOSED);

        Assert.AreEqual(null, board.GetTile(3, 0).GetWall(Tile.Direction.WEST));
        Assert.AreEqual(null, board.GetTile(2, 0).GetWall(Tile.Direction.EAST));

        board.SetWall(testWall, 3, 0, Tile.Direction.WEST);

        Assert.AreSame(testWall, board.GetTile(3, 0).GetWall(Tile.Direction.WEST));
        Assert.AreSame(testWall, board.GetTile(2, 0).GetWall(Tile.Direction.EAST));
    }

    [Test]
    public void SetWallEastOf3Throws()
    {
        Board board = new Board();
        Assert.That(() => board.SetWall(new Wall(Wall.Type.CLOSED), 3, 0, Tile.Direction.EAST),
                    Throws.Exception.TypeOf<System.IndexOutOfRangeException>());
    }

    [Test]
    public void SetWallNorthOf3Works()
    {
        Board board = new Board();
        Wall testWall = new Wall(Wall.Type.CLOSED);

        Assert.AreEqual(null, board.GetTile(0, 3).GetWall(Tile.Direction.NORTH));
        Assert.AreEqual(null, board.GetTile(0, 2).GetWall(Tile.Direction.SOUTH));

        board.SetWall(testWall, 0, 3, Tile.Direction.NORTH);

        Assert.AreSame(testWall, board.GetTile(0, 3).GetWall(Tile.Direction.NORTH));
        Assert.AreSame(testWall, board.GetTile(0, 2).GetWall(Tile.Direction.SOUTH));
    }

    [Test]
    public void SetWallSouthOf3Throws()
    {
        Board board = new Board();
        Assert.That(() => board.SetWall(new Wall(Wall.Type.CLOSED), 0, 3, Tile.Direction.SOUTH),
                    Throws.Exception.TypeOf<System.IndexOutOfRangeException>());
    }

    [Test]
    public void SetWallSouthOf0Works()
    {
        Board board = new Board();
        Wall testWall = new Wall(Wall.Type.CLOSED);

        Assert.AreEqual(null, board.GetTile(0, 0).GetWall(Tile.Direction.SOUTH));
        Assert.AreEqual(null, board.GetTile(0, 1).GetWall(Tile.Direction.NORTH));

        board.SetWall(testWall, 0, 0, Tile.Direction.SOUTH);

        Assert.AreSame(testWall, board.GetTile(0, 0).GetWall(Tile.Direction.SOUTH));
        Assert.AreSame(testWall, board.GetTile(0, 1).GetWall(Tile.Direction.NORTH));
    }

    [Test]
    public void SetWallNorthOf0Throws()
    {
        Board board = new Board();
        Assert.That(() => board.SetWall(new Wall(Wall.Type.CLOSED), 0, 0, Tile.Direction.NORTH),
                    Throws.Exception.TypeOf<System.IndexOutOfRangeException>());
    }

    [Test]
    public void MoveThroughBorderDoesNotThrow()
    {
        Board board = new Board();
        Player movingPlayer = new Player(
            Player.Animal.MOUSE,
            Player.Color.RED,
            new Position(0, 0)
        );
        MoveDetails moveDetails = new MoveDetails(movingPlayer);
        board.Move(Tile.Direction.WEST, movingPlayer, null, moveDetails);

        Assert.AreEqual(MoveDetails.MoveStatus.ABORTED, moveDetails.Status);
        Assert.AreEqual(false, moveDetails.PlayAgain);
        Assert.AreSame(movingPlayer, moveDetails.Player);
    }

    [Test]
    public void NewBoardIsNotFullyConnected()
    {
        Board board = new Board();
        Assert.IsFalse(board.IsFullyConnected());
    }

    [Test]
    public void DummyBoardIsFullyConnected()
    {
        Board board = BoardGenerator.GenerateDummyBoard();
        Assert.IsTrue(board.IsFullyConnected());
    }

    [Test]
    public void GeneratedBoardOneDoorIsFullyConnected()
    {
        Board board = BoardGenerator.GenerateValidBoard(1);
        Assert.IsTrue(board.IsFullyConnected());
    }

    [Test]
    public void GeneratedBoardTwoDoorsIsFullyConnected()
    {
        Board board = BoardGenerator.GenerateValidBoard(2);
        Assert.IsTrue(board.IsFullyConnected());
    }

    [Test]
    public void GeneratedBoardThreeDoorsIsFullyConnected()
    {
        Board board = BoardGenerator.GenerateValidBoard(3);
        Assert.IsTrue(board.IsFullyConnected());
    }
}