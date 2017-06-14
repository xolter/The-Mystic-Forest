using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class Inventory : MonoBehaviour {

    private RectTransform inventoryRect;

    private float inventoryWidth, inventoryHight;

    public int slots;

    public int rows;

    public float slotPaddingLeft, slotPaddingTop;

    public float slotSize;

    public GameObject slotPrefab;

    private List<GameObject> allSlots;

    void Start()
    {
        CreateLeyout();
    }
    void Update()
    {
            
    }
    private void CreateLeyout()
    {
        allSlots = new List<GameObject>();

        inventoryWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;
        inventoryHight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;
        inventoryRect = GetComponent<RectTransform>();
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHight);
    }

}

