using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInGameInventoryManager : MonoBehaviour
{
    public PlayerInventory playerInventory;
    [HideInInspector] float currentWeight;

    void Start()
    {
        FillParentGameObjectsWithInventoryItems();

        //canvas.enabled = false;
    }

    void Update()
    {
        FillParentGameObjectsWithInventoryItems();
        FillItemImages();
        CalculateWeight();
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


    public void CalculateWeight()
    {
        currentWeight = 0;

        foreach(Item item in playerInventory.items)
        {
            currentWeight += item._weight;
        }

        Debug.Log(currentWeight);
    }

    public void OpenCloseInventory()
    {
        
    }

    public void FillItemImages()
    {
        for(int i=0; i<playerInventory.items.Count; i++)
        {
            transform.GetChild(i).GetComponent<InGameInventoryItemManager>().image.sprite = transform.GetChild(i).GetComponent<InGameInventoryItemManager>().item._sprite;
        }
    }
}
