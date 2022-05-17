using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInventoryManager : MonoBehaviour
{
    public PlayerInventory NPCInventory;
   
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
            transform.GetChild(j).gameObject.SetActive(false);
        }

        for(int i=0; i< NPCInventory.items.Count; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<ItemManager>().itemType = NPCInventory.items[i];
            transform.GetChild(i).gameObject.SetActive(true);
        }

    }


   
}
