using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    
    public Village village;
    public PlayerInventory playerInventory;
    public PlayerInventory NPCInventory;
    [HideInInspector] public  ShopItemManager selectedItem;

    public GameObject playerShopInventory;
    public GameObject npcShopInventory;

    public void GetSelectedItem()
    {
        selectedItem = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInParent<ShopItemManager>();
    }

    // buy item

    public bool CheckIfHasEnoughSpace(PlayerInventory inventory)
    {
        if(inventory.items.Count >= inventory.maxSize)
        {
            return false;
        }

        return true;
    }

    public bool CheckIfPlayerCoinEnoughToPurchase()
    {
        if(selectedItem != null)
        {
            if(selectedItem.localPrice < playerInventory.coin)
            {
                return true;
            }
        }

        return false;
    }
    public void CoinManagerBuy()
    {
        playerInventory.coin -= selectedItem.localPrice;
        NPCInventory.coin += selectedItem.localPrice;
    }

    public void AddItemToPlayerInventory()
    {
        playerInventory.items.Add(selectedItem.item);
    }

    public void DeleteSelectedItemFromNPCInventory()
    {
        for(int i=0; i<NPCInventory.items.Count; i++)
        {
            if(selectedItem.item == NPCInventory.items[i])
            {
                NPCInventory.items.RemoveAt(i);
                return;
            }
        }
    }

    public void PurchaseItem()
    {
        GetSelectedItem();

        if(CheckIfPlayerCoinEnoughToPurchase() == true && CheckIfHasEnoughSpace(playerInventory))
        {
            CoinManagerBuy();
            AddItemToPlayerInventory();
            SetItemDurationBuy();
            DeleteSelectedItemFromNPCInventory();
        }
    }

    // sell item

    public bool CheckIfPlayerInventoryHasSelectedItem()
    {
        if(selectedItem != null)
        {
            for(int i=0; i<playerInventory.items.Count; i++)
            {
                if(playerInventory.items[i]._name == selectedItem.item._name)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void CoinManagerSell()
    {
        playerInventory.coin += selectedItem.durationBasedPrice;
        NPCInventory.coin -= selectedItem.durationBasedPrice;
    }

    public void DeleteSelectedItemFromInventory()
    {
       

        for(int i=0; i<playerInventory.items.Count; i++)
        {
            if(playerInventory.items[i]._name == selectedItem.item._name)
            {
                playerInventory.items.RemoveAt(i);
                break;
            }
        }

        
    }

    public void AddItemToNPCInventory()
    {
        NPCInventory.items.Add(selectedItem.item);
    }

    public void SellItem()
    {
        GetSelectedItem();

        if(CheckIfPlayerInventoryHasSelectedItem() == true && CheckIfHasEnoughSpace(NPCInventory))
        {
            CoinManagerSell();
            AddItemToNPCInventory();
            SetItemDurationSell();
            DeleteSelectedItemFromInventory();
        }
    }

    public void SetItemDurationBuy()
    {
        playerShopInventory.transform.GetChild(playerInventory.items.Count -1).GetComponent<ShopItemManager>().duration 

        = playerInventory.items[playerInventory.items.Count -1 ]._initialDuration;
    }

     public void SetItemDurationSell()
    {
       npcShopInventory.transform.GetChild(NPCInventory.items.Count -1).GetComponent<ShopItemManager>().duration = 

       NPCInventory.items[NPCInventory.items.Count -1]._initialDuration;
    }
    
}
