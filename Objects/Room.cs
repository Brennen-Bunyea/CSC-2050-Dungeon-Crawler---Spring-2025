using System;
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

    public string getName()
    {
        return this.name;
    }

    public void tryToTakeExit(string direction)    
    {
        //remove the player from the current room
        //place them in the destination room in that direction
        //update the room the player is currently in so the room exits visually update
        if (this.hasExit(direction))
        {
            for (int i = 0; i < this.currNumberOfExits; i++)
            {
                if (this.availableExits[i].getDirection() == direction)
                {
                    Room destinationRoom = this.availableExits[i].GetDestinationRoom();
                    this.removePlayer(thePlayer);
                    thePlayer.setCurrentRoom(destinationRoom);
                    destinationRoom.setPlayer(thePlayer);
                    Debug.Log("Player moved to: " + thePlayer.getCurrentRoom().getName());
                    return; // Exit loop once found
                }
            }
        }
        else
        {
            Debug.Log("There is no exit in that direction");
        }
    }

    public bool hasExit(string direction)
    {
        for (int i = 0; i < this.currNumberOfExits; i++)
        {
            if (String.Equals(this.availableExits[i].getDirection(), direction)) //== is true because the memory address in the two strings are the same
            {
                return true;
            }
        }
        return false;
    }

    public void removePlayer(Player p)
    {
        Room r = new Room("Empty");
        this.thePlayer = p;
        this.thePlayer.setCurrentRoom(r);
    }

    public void setPlayer(Player p)
    {
        this.thePlayer = p;
        this.thePlayer.setCurrentRoom(this);
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
