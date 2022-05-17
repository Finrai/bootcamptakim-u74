using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManagerShop : MonoBehaviour
{
    public PlayerInventory playerInventory;

    void Update()
    {
        FillParentGameObjectsWithInventoryItems();

        
    }

     void FillParentGameObjectsWithInventoryItems()
    {
         if(playerInventory.items.Count > transform.childCount)
        {
            int difference = playerInventory.items.Count - transform.childCount;

            for(int i = difference; i != 0; i--)
            {
                playerInventory.items.RemoveAt(playerInventory.items.Count -1);
            }
        }


        for(int j=playerInventory.items.Count; j<transform.childCount; j++)
        {
            transform.GetChild(j).gameObject.SetActive(false);
        }

        for(int i=0; i< playerInventory.items.Count; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<ItemManager>().itemType = playerInventory.items[i];
            transform.GetChild(i).gameObject.SetActive(true);
        }

    }
}
