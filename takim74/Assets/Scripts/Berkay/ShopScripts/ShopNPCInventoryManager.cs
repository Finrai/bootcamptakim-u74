using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPCInventoryManager : MonoBehaviour
{
    public PlayerInventory NPCInventory;

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
        if(NPCInventory.items.Count > transform.childCount)
        {
            int difference = NPCInventory.items.Count - transform.childCount;

            for(int i = difference; i != 0; i--)
            {
                NPCInventory.items.RemoveAt(NPCInventory.items.Count -1);
            }
        }


        for(int j=NPCInventory.items.Count; j<transform.childCount; j++)
        {
            transform.GetChild(j).transform.GetChild(0).transform.gameObject.SetActive(false);
        }

        for(int i=0; i< NPCInventory.items.Count; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<ShopItemManager>().item = NPCInventory.items[i];
            transform.GetChild(i).transform.GetChild(0).transform.gameObject.SetActive(true);
        }

    }


   
}
