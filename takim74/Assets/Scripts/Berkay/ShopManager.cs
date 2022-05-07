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
        selectedItem = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<ItemManager>();
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
    public void CoinManager()
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
            CoinManager();
            AddItemToInventory();
        }
    }
}
