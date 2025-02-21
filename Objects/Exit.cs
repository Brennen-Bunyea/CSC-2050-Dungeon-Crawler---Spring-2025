using UnityEngine;

public class Exit
{
    private string direction;
    private Room destination;

    public Exit(string direction, Room destination)
    {
        this.direction = direction;
        this.destination = destination;
    }
}
