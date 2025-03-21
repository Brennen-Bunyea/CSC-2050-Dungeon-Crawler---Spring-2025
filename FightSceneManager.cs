using System;
using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Core.thePlayer == null)
        {
            Core.InitializePlayer();
        }
        Fight f = new Fight();
        f.startFight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
