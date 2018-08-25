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
        Assert.AreEqual(Tiboo.Tile.Animal.OWL, Tiboo.Tile.GetAnimal(0, 0));
        Assert.AreEqual(Tiboo.Tile.Animal.OWL, Tiboo.Tile.GetAnimal(0, 3));
        Assert.AreEqual(Tiboo.Tile.Animal.OWL, Tiboo.Tile.GetAnimal(3, 0));
        Assert.AreEqual(Tiboo.Tile.Animal.OWL, Tiboo.Tile.GetAnimal(3, 3));

        // All center tiles are bats
        Assert.AreEqual(Tiboo.Tile.Animal.BAT, Tiboo.Tile.GetAnimal(1, 3));
        Assert.AreEqual(Tiboo.Tile.Animal.BAT, Tiboo.Tile.GetAnimal(1, 2));
        Assert.AreEqual(Tiboo.Tile.Animal.BAT, Tiboo.Tile.GetAnimal(2, 1));
        Assert.AreEqual(Tiboo.Tile.Animal.BAT, Tiboo.Tile.GetAnimal(2, 2));
    }
}
