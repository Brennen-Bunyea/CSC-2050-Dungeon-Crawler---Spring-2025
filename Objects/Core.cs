using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class Core
{
    public static Player thePlayer = new Player("Mike");
    public static Monster theMonster = new Monster("Goblin");

    public static Vector3 mmStartPos = new Vector3(-12, 0, -3);

    //what kind of collection lets us store an arbitrary number of room names?
    //Generic List<string>
    private static List<string> roomNames = new List<string>();
}
