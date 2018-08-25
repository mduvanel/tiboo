using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Tiboo;

public class TilesTest
{
    [Test]
    public void CheckTileAnimalIsCorrect()
    {
        // All corners are owl
        Assert.AreEqual(Tiboo.Tile.Animal.OWL, Tiboo.Tile.GetAnimal(0, 0, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.OWL, Tiboo.Tile.GetAnimal(0, 3, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.OWL, Tiboo.Tile.GetAnimal(3, 0, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.OWL, Tiboo.Tile.GetAnimal(3, 3, 4));

        // All center tiles are bats
        Assert.AreEqual(Tiboo.Tile.Animal.BAT, Tiboo.Tile.GetAnimal(1, 1, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.BAT, Tiboo.Tile.GetAnimal(1, 2, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.BAT, Tiboo.Tile.GetAnimal(2, 1, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.BAT, Tiboo.Tile.GetAnimal(2, 2, 4));

        // Centipedes
        Assert.AreEqual(Tiboo.Tile.Animal.CENTIPEDE, Tiboo.Tile.GetAnimal(1, 0, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.CENTIPEDE, Tiboo.Tile.GetAnimal(3, 1, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.CENTIPEDE, Tiboo.Tile.GetAnimal(0, 2, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.CENTIPEDE, Tiboo.Tile.GetAnimal(2, 3, 4));

        // Frogs
        Assert.AreEqual(Tiboo.Tile.Animal.FROG, Tiboo.Tile.GetAnimal(2, 0, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.FROG, Tiboo.Tile.GetAnimal(0, 1, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.FROG, Tiboo.Tile.GetAnimal(3, 2, 4));
        Assert.AreEqual(Tiboo.Tile.Animal.FROG, Tiboo.Tile.GetAnimal(1, 3, 4));
    }
}
