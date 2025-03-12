using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors;
    private Dungeon theDungeon;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Core.thePlayer = new Player("Mike");
        this.theDungeon = new Dungeon();
        this.resetRoom();
        this.setupRoom();
        
    }

    //disable all rooms
    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }

    //Show the doors appropriate to the current room
    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("north"));
        this.theDoors[1].SetActive(currentRoom.hasExit("south"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("west"));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("north");
            this.setupRoom();
            //Try to go north
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("south");
            this.setupRoom();
            //Try to go south
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("east");
            this.setupRoom();
            //Try to go west
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
            Core.thePlayer.getCurrentRoom().tryToTakeExit("west");
            this.setupRoom();
            //Try to go east
        }
    }
}
