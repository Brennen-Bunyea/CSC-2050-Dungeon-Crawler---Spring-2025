using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

public class Room
{
    private Player thePlayer;
    private GameObject[] theDoors;
    private Exit[] availableExits = new Exit[4];
    private int currNumberOfExits = 0;
    private string name;
    public Room(string name)
    {
        this.name = name;
        this.thePlayer = null;
    }

    public void setPlayer(Player p)
    {
        this.thePlayer = p;
    }

    public void addExit(string direction, Room destination) //Adds exits to the rooms
    {
        if (this.currNumberOfExits <= 4) //checks to make sure there are a correct number of rooms
        {
            Exit e = new Exit(direction, destination);
            this.availableExits[this.currNumberOfExits] = e;
            this.currNumberOfExits++;
        }
        else
        {
            Console.Error.WriteLine("There are too many exits!!!");
        }
    }
}
