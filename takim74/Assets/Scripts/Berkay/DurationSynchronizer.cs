using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationSynchronizer : MonoBehaviour
{
    public GameObject[] shopPlayerInventorys;
    public PlayerInventory playerInventory;

    private int IndexOfLastItem;

    private void Update()
    {
        IndexOfLastItem = playerInventory.items.Count -1;

        for(int i=0; i<=IndexOfLastItem; i++)
        {
            for(int j=0; j<shopPlayerInventorys.Length; j++) 
            {
                if(shopPlayerInventorys[j].transform.GetChild(i).GetComponent<ShopItemManager>().duration != 0)
                {
                    for(int k=0; k<shopPlayerInventorys.Length; k++)
                    {
                        shopPlayerInventorys[k].transform.GetChild(i).GetComponent<ShopItemManager>().duration
                        = shopPlayerInventorys[j].transform.GetChild(i).GetComponent<ShopItemManager>().duration;

                    }
                }
            }
        }
    }
}
