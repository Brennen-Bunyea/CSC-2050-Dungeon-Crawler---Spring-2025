using System;
using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;

    private Monster theMonster;

    private Fight fight;
    private float attackTimer = 0f;
    public float timeBetweenAttacks = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theMonster = new Monster("Goblin");
        fight = new Fight (this.theMonster);
        fight.startFight(player, monster); //we need this to be experienced over time, so we need it to be represented in update
    }

    // Update is called once per frame
    void Update()
    {
        if (!fight.IsFightOver())
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= timeBetweenAttacks)
            {
                attackTimer = 0f;
                fight.updateFight(Time.deltaTime);
            }
        }
    }
}
