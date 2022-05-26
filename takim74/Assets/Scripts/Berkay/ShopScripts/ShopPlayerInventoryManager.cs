using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPlayerInventoryManager : MonoBehaviour
{
    public PlayerInventory playerInventory;

    private void Awake()
    {
        FillParentGameObjectsWithInventoryItems();
    }

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
            transform.GetChild(i).gameObject.GetComponent<ShopItemManager>().item = playerInventory.items[i];
            transform.GetChild(i).gameObject.SetActive(true);
        }

    }
}
