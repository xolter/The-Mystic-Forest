using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Enemy_Health : NetworkBehaviour
{
    public Image healthbar;
    public GameObject target;
    Player_Exp target_xp;
    [SyncVar]
    public float max_health = 100;
    [SyncVar]
    public float current_health = 100;
    public float regen_health = 0f;
    private bool xpGiven = false;
    //private Item healthpopo;
    //public Inventory inventory; // ici

    public override void OnStartServer()
    {
        //healthpopo.type = ItemType.HEALTH;//la
        //inventory = GameObject.FindGameObjectWithTag("TheInventory").GetComponent<Inventory>();//la
        base.OnStartServer();        
        healthbar.fillAmount = (float)current_health / max_health;
    }
    // Use this for initialization
    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;
        Update_currentHealth(regen_health);
        healthbar.fillAmount = (float)current_health / max_health;
    }


    public void Update_currentHealth(float n)
    {
        current_health += n;
        if (current_health <= 0)
        {
            current_health = 0;
            if (!xpGiven)
            {
                target_xp.Update_EXP();
                //inventory.AddItem(GameObject.FindGameObjectWithTag("popovie").GetComponent<Item>());//la

                xpGiven = true;
            }
        }
        if (current_health > max_health)
        {
            current_health = max_health;
        }
        if (max_health < 1)
        {
            max_health = 1;
        }
    }
}
