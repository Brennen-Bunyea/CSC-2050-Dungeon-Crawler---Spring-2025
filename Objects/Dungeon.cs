using UnityEngine;

public class Dungeon
{
    public Dungeon()
    {

        Room r1 = new Room("r1");
        Room r2 = new Room("r2");
        Room r3 = new Room("r3");
        Room r4 = new Room("r4");
        Room r5 = new Room("r5");
        Room r6 = new Room("r6");

        r1.addExit("north", r2);
        r2.addExit("north", r3);
        r2.addExit("south", r1);
        r3.addExit("north", r6);
        r3.addExit("south", r3);
        r3.addExit("east", r5);
        r3.addExit("west", r4);
        r4.addExit("east", r3);
        r5.addExit("west", r3);
        r6.addExit("south", r3);

        r1.setPlayer(Core.thePlayer);
    }
}
