using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;
    private GameObject playerGO;
    private GameObject monsterGO;

    private Monster theMonster;
    private bool isFightOver = false;
    public Fight(Monster m)
    {
        this.theMonster = m;

        //Initially determine who goes first
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = m;
            this.defender = Core.thePlayer;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = m;
        }
    }

    public void startFight(GameObject playerGO, GameObject monsterGO)
    {
        this.playerGO = playerGO;
        this.monsterGO = monsterGO;
    }

    //Update the fight to see if I need to attack or end the fight
    //allows the time between attacks
    public void updateFight(float deltaTime)
    {
        if (isFightOver == true) return;
        attack();
    }

    private void attack()
    {
        int attackRoll = Random.Range(1, 20) + 1;
        if (attackRoll >= this.defender.getAC())
        {
            int damage = Random.Range(1, 6);
            this.defender.takeDamage(damage);
            Debug.Log(this.attacker.getName() + " hits " + this.defender.getName() + " for " + damage + " damage!");
        }
        else
        {
            Debug.Log(this.attacker.getName() + " misses " + this.defender.getName() + "!");
        }

        if (this.defender.isDead())
        {
            Debug.Log(this.defender.getName() + " has been defeated!");
            if (this.defender is Player)
            {
                Debug.Log("Player died!");
                playerGO.SetActive(false);
            }
            else
            {
                Debug.Log("Monster died!");
                GameObject.Destroy(monsterGO);
            }
            isFightOver = true;
            return;
        }

        // Swap roles
        Inhabitant temp = this.attacker;
        this.attacker = this.defender;
        this.defender = temp;
    }

    public bool IsFightOver()
    {
        return isFightOver;
    }
}
