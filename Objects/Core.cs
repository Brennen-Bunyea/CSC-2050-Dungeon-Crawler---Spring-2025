using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class Core
{
    public static Player thePlayer;

    public static Vector3 mmStartPos = new Vector3(-12, 0, -3);

    //what kind of collection lets us store an arbitrary number of room names?
    //Generic List<string>
    private static List<string> roomNames = new List<string>();
    private static void addRoomName(string roomName)
    {
        roomNames.Add(roomName);
    }   

    public static bool hasBeenToRoom(string roomName)
    {
        bool answer = roomNames.Contains(roomName);
        if(!answer)
        {
            Core.addRoomName(roomName);
        }
        return answer;
    }

    public static void InitializePlayer()
    {
        
            thePlayer = new Player("Mike2.0");  // Replace with your desired player name
            Debug.Log("Player initialized: " + thePlayer.getName());
        
    }
}
