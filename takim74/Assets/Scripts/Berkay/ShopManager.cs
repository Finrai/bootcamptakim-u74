using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // item satın al (itemin fiyatını inventorydeki fiyattan düş)
    // itemleri display et
    // item satma ekle
    public Village village;
    public PlayerInventory playerInventory;
    public  ItemManager selectedItem;

    public void GetSelectedItem()
    {
        selectedItem = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInParent<ItemManager>();
    }

    // buy item
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
    }

    public void AddItemToInventory()
    {
        playerInventory.items.Add(selectedItem.itemType);
    }

    public void PurchaseItem()
    {
        GetSelectedItem();

        if(CheckIfPlayerCoinEnoughToPurchase() == true)
        {
            CoinManagerBuy();
            AddItemToInventory();
        }
    }

    // sell item

    public bool CheckIfPlayerInventoryHasSelectedItem()
    {
        if(selectedItem != null)
        {
            for(int i=0; i<playerInventory.items.Count; i++)
            {
                if(playerInventory.items[i]._name == selectedItem.itemType._name)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void CoinManagerSell()
    {
        playerInventory.coin += selectedItem.localPrice;
    }

    public void DeleteSelectedItemFromInventory()
    {
        for(int i=0; i<playerInventory.items.Count; i++)
        {
            if(playerInventory.items[i]._name == selectedItem.itemType._name)
            {
                playerInventory.items.RemoveAt(i);
                break;
            }
        }
    }

    public void SellItem()
    {
        GetSelectedItem();

        if(CheckIfPlayerInventoryHasSelectedItem() == true)
        {
            CoinManagerSell();
            DeleteSelectedItemFromInventory();
        }
    }
    

    
}
