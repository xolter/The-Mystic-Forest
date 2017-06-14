using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.Generic;
using UnityEngine.UI;
public class Inventory : MonoBehaviour {

    public Item[] items;
    public PlayerStats playerstats;
    public GameObject Slot1;
    public Image imageItem1;

    public Sprite healthpopo;

    void Start()
    {
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        items = new Item[5];
        Slot1 = GameObject.FindGameObjectWithTag("Slot1");
        healthpopo = GameObject.FindGameObjectWithTag("Item1").GetComponent<Image>().sprite;
        imageItem1.sprite = healthpopo;
    }
    
    void Update()
    {
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        items = new Item[5];
        Slot1 = GameObject.FindGameObjectWithTag("Slot1");
        healthpopo = GameObject.FindGameObjectWithTag("Item1").GetComponent<Image>().sprite;
        
    }

    public void UpdateDisplay()
    {
    }

    public void Use()
    {
    }

    public void addItem(Item item)
    {
        
    }

}
[System.Serializable]
public class Item
{
    public enum type { ManaPopo, HealthPopo };
    public Sprite itemIcon;
}

