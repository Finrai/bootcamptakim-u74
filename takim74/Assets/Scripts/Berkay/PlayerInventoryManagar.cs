using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryManagar : MonoBehaviour
{
    public PlayerInventory playerInventory;
    
    public List<Image> images = new List<Image>();

    private void Start()
    {
        
    }
    private void Update()
    {
        ActivateNewSlot();
        DeactiveUnusedSlot();

        SetItemSprite();
    }

    public void ActivateNewSlot()
    {
        if(playerInventory.items.Count > 0)
            transform.GetChild(playerInventory.items.Count - 1 ).gameObject.SetActive(true);
    }

    public void DeactiveUnusedSlot()
    {
        int slotSize = transform.childCount;
        int itemSize = playerInventory.items.Count;

        for(int i = itemSize; i < slotSize; i++ )
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void SetItemSprite()
    {
        if(playerInventory.items.Count > 0)
        {
            for(int i=0; i< playerInventory.items.Count; i++ )
            {
                if(transform.GetChild(i).gameObject.activeInHierarchy == true)
                {
                    transform.GetChild(i).gameObject.GetComponent<Image>().sprite = playerInventory.items[i]._sprite;
                }
            }
        }

    }
}
