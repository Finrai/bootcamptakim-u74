using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairItem : MonoBehaviour
{
    public PlayerInventory playerInventory;

    public DurationSynchronizer durationSynchronizer;

    private void Update()
    {
        FillParentGameObjectsWithInventoryItems();
        FillItemImages();
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
            transform.GetChild(j).transform.GetChild(0).gameObject.GetComponent<Image>().enabled = false;
        }

        for(int i=0; i< playerInventory.items.Count; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<InGameInventoryItemManager>().item = playerInventory.items[i];
            transform.GetChild(i).transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
        }

    }

    public void FillItemImages()
    {
        for(int i=0; i<playerInventory.items.Count; i++)
        {
            transform.GetChild(i).GetComponent<InGameInventoryItemManager>().image.sprite = transform.GetChild(i).GetComponent<InGameInventoryItemManager>().item._sprite;
        }
    } 


    public void RepairThisItem()
    {
        if(GetSelectedItemType()._name == "Sword")
        {
            durationSynchronizer.shopPlayerInventorys[0].transform.GetChild(GetSelectedItemIndex()).gameObject.GetComponent<ShopItemManager>().duration 
            = 
            durationSynchronizer.shopPlayerInventorys[0].transform.GetChild(GetSelectedItemIndex()).gameObject.GetComponent<ShopItemManager>().item._initialDuration;
        }

    }

    public int GetSelectedItemIndex()
    {
        return UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();
    }

    public Item GetSelectedItemType()
    {
        return UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<InGameInventoryItemManager>().item;
    }

}
