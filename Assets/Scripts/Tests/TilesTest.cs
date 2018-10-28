using NUnit.Framework;
using Tiboo;

public class TilesTest
{
    [Test]
    public void CheckTileAnimalIsCorrect()
    {
        // All corners are owl
        Assert.AreEqual(Tile.Animal.OWL, Tile.GetAnimal(0, 0, 4));
        Assert.AreEqual(Tile.Animal.OWL, Tile.GetAnimal(0, 3, 4));
        Assert.AreEqual(Tile.Animal.OWL, Tile.GetAnimal(3, 0, 4));
        Assert.AreEqual(Tile.Animal.OWL, Tile.GetAnimal(3, 3, 4));

        // All center are bats
        Assert.AreEqual(Tile.Animal.BAT, Tile.GetAnimal(1, 1, 4));
        Assert.AreEqual(Tile.Animal.BAT, Tile.GetAnimal(1, 2, 4));
        Assert.AreEqual(Tile.Animal.BAT, Tile.GetAnimal(2, 1, 4));
        Assert.AreEqual(Tile.Animal.BAT, Tile.GetAnimal(2, 2, 4));

        // Centipedes
        Assert.AreEqual(Tile.Animal.CENTIPEDE, Tile.GetAnimal(1, 0, 4));
        Assert.AreEqual(Tile.Animal.CENTIPEDE, Tile.GetAnimal(3, 1, 4));
        Assert.AreEqual(Tile.Animal.CENTIPEDE, Tile.GetAnimal(0, 2, 4));
        Assert.AreEqual(Tile.Animal.CENTIPEDE, Tile.GetAnimal(2, 3, 4));

        // Frogs
        Assert.AreEqual(Tile.Animal.FROG, Tile.GetAnimal(2, 0, 4));
        Assert.AreEqual(Tile.Animal.FROG, Tile.GetAnimal(0, 1, 4));
        Assert.AreEqual(Tile.Animal.FROG, Tile.GetAnimal(3, 2, 4));
        Assert.AreEqual(Tile.Animal.FROG, Tile.GetAnimal(1, 3, 4));
    }
}
