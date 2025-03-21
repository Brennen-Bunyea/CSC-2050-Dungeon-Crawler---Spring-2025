using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;

    public Fight()
    {
        int roll = Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = new Monster("DaveTheMonster");
            this.defender = Core.thePlayer;
        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = new Monster("DaveTheMonster");
        }
    }

    public void startFight()
    {
        //should have the attacker and defender fight each other until one of them dies
        //the attacker and defender should alternate between each fight round
        //the one who goes first was determined in the constructor
        //make sure to print it to console
        //basically the same thing as "deathmatch"

        while(true)
        {
            //Displays the stats of both players
            attacker.display();
            defender.display();

            //rolls for damage
            int damage = Random.Range(1, 20) + 1;
            if(damage >= defender.getAC())
            {
                //hits
                defender.takeDamage(damage);
                Debug.Log(attacker.getName() + " hits " + defender.getName() + " for " + damage + " damage!");
            }
            else
            {
                //miss
                Debug.Log(attacker.getName() + " misses " + defender.getName());
            }

            if (defender.isDead())
            {
                Debug.Log(defender.getName() + " has been defeated!    " + attacker.getName() + " has won!");
                break;
            }

            //swap attacker and defender
            Inhabitant temp = attacker;
            attacker = defender;
            defender = temp;
            Debug.Log("Next Round!");
        }
    }
}
