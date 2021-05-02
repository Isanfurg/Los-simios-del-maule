using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestCardMaker
{
    private GameObject gameObject;
    private CardMaker cardMaker;

    // A Test behaves as an ordinary method

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        cardMaker = gameObject.AddComponent<CardMaker>();
    }
    [Test]
    public void TestReadCardName()
    {
        string test = "Carta Hyper Magica";
        Assert.True(test.Length <= 23);
        string test2 = "Carta Ultra Hyper Mega Magica Edicion 2";
        Assert.False(test2.Length <= 23);
    }

    [Test]
    public void TestReadCardDescription()
    {
        string test = "Carta Hyper Magica";
        Assert.True(test.Length <= 107);
        string test2 = "Carta Ultra Hyper Mega Magica Edicion 2 Quinta Fase Sayayin Shiny Supercalifragilisticoespialidoso Legendario";
        Assert.False(test2.Length <= 107);
    }

    [Test]
    public void TestReadCardAtk()
    {
        string test = "2021";
        int.TryParse(test, out int testInt);
        Assert.AreEqual(testInt, 2021);
    }

    [Test]
    public void TestReadCardDef()
    {
        string test = "1202";
        int.TryParse(test, out int testInt);
        Assert.AreEqual(testInt, 1202);
    }


}
