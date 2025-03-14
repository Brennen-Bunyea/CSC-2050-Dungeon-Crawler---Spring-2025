using System.Security.Cryptography;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors;
    public GameObject mmRoomPrefab;
    private Dungeon theDungeon;
    private bool r2 = false;
    private bool r3 = false;
    private bool r4 = false;
    private bool r5 = false;
    private bool r6 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Core.thePlayer = new Player("Mike");
        this.theDungeon = new Dungeon();
        this.setupRoom();
    }

    //disable all doors
    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }

    //show the doors appropriate to the current room
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
        bool didChangeRoom = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //try to goto the north
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("north");
            if (didChangeRoom == true && r2 == false)
            {
                string currRoom = Core.thePlayer.getCurrentRoom().getName();
                if(currRoom == "r2")
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    Vector3 currPos = newMMRoom.transform.position;
                    Vector3 newPos;
                    newPos.x = currPos.x;
                    newPos.y = currPos.y;
                    newPos.z = currPos.z + -1.2f;
                    newMMRoom.transform.position = newPos;
                    r2 = true;
                }
            }
            else if (didChangeRoom == true && r2 == true && r3 == false)
            {
                string currRoom = Core.thePlayer.getCurrentRoom().getName();
                if (currRoom == "r3")
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    Vector3 currPos = newMMRoom.transform.position;
                    Vector3 newPos;
                    newPos.x = currPos.x;
                    newPos.y = currPos.y;
                    newPos.z = currPos.z + -2.4f;
                    newMMRoom.transform.position = newPos;
                    r3 = true;
                }
            }
            else if (didChangeRoom == true && r2 == true && r3 == true && r6 == false)
            {
                string currRoom = Core.thePlayer.getCurrentRoom().getName();
                if (currRoom == "r6")
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    Vector3 currPos = newMMRoom.transform.position;
                    Vector3 newPos;
                    newPos.x = currPos.x;
                    newPos.y = currPos.y;
                    newPos.z = currPos.z + -3.6f;
                    newMMRoom.transform.position = newPos;
                    r6 = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //try to goto the west
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("west");
            if(didChangeRoom == true && r3 == true && r4 == false)
            {
                string currRoom = Core.thePlayer.getCurrentRoom().getName();
                if (currRoom == "r4")
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    Vector3 currPos = newMMRoom.transform.position;
                    Vector3 newPos;
                    newPos.x = currPos.x + 1.2f;
                    newPos.y = currPos.y;
                    newPos.z = currPos.z + -2.4f;
                    newMMRoom.transform.position = newPos;
                    r4 = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //try to goto the east
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("east");
            if(didChangeRoom == true && r3 == true && r5 == false)
            {
                string currRoom = Core.thePlayer.getCurrentRoom().getName();
                if (currRoom == "r5")
                {
                    GameObject newMMRoom = Instantiate(this.mmRoomPrefab);
                    Vector3 currPos = newMMRoom.transform.position;
                    Vector3 newPos;
                    newPos.x = currPos.x + -1.2f;
                    newPos.y = currPos.y;
                    newPos.z = currPos.z + -2.4f;
                    newMMRoom.transform.position = newPos;
                    r5 = true;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //try to goto the south
            didChangeRoom = Core.thePlayer.getCurrentRoom().tryToTakeExit("south");
        }

        //did we change rooms?
        if (didChangeRoom)
        {
            this.setupRoom();
        }
    }
}