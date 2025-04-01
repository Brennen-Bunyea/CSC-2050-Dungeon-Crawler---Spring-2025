using UnityEngine;

public class hpBarController : MonoBehaviour
{
    //this.gameobject is the gameobject associated with the red hp bar

    private Vector3 leftMove = new Vector3(.005f, 0, 0);

    public bool isPlayer;

    private Inhabitant theInhabitant;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        if (this.isPlayer)
        {
            this.theInhabitant = Core.thePlayer;
        }
        else
        {
            this.theInhabitant = Core.theMonster;
        }
        */
    }
    // Update is called once per frame
    void Update()
    {
        /*
        print(this.theInhabitant.getName());
        float hpPercent = this.theInhabitant.getCurrHp() / this.theInhabitant.getMaxHp();
        this.gameObject.transform.localScale = new Vector3(hpPercent, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        */

        
    }
}
