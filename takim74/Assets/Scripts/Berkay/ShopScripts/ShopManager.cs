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
    public GameObject audioSources;
   
    private void Start()
    {
        audioSources = transform.parent.parent.transform.GetChild(0).gameObject;
    }

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
            BuyItemSound();
            CoinManagerBuy();
            AddItemToPlayerInventory();
            SetItemDurationBuy();
            DeleteSelectedItemFromNPCInventory();
        }
        else
        {
            DeniedSound();
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
            SellItemSound();
            CoinManagerSell();
            AddItemToNPCInventory();
            DeleteSelectedItemFromInventory();
            SetItemDurationSell();
        }
        else
        {
            DeniedSound();
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

        for(int i=selectedItem.transform.GetSiblingIndex(); i<playerInventory.maxSize; i++) 
        {
           if(i != playerInventory.maxSize - 1)
           {
                playerShopInventory.transform.GetChild(i).GetComponent<ShopItemManager>().duration =
                playerShopInventory.transform.GetChild(i+1).GetComponent<ShopItemManager>().duration;
           }
           else
           {
               Debug.Log("last item");
           }
        }
    }

    public void BuyItemSound() 
    {
        AudioSource gold_slack = audioSources.transform.GetChild(0).transform.GetComponent<AudioSource>();
        AudioSource randomNpcSound = audioSources.transform.GetChild(Random.Range(1,3)).transform.GetComponent<AudioSource>();
        gold_slack.Play();
        randomNpcSound.Play();
    }

    public void SellItemSound()
    {
        AudioSource gold_slack = audioSources.transform.GetChild(0).transform.GetComponent<AudioSource>();
        AudioSource randomSellSou = audioSources.transform.GetChild(Random.Range(3,5)).transform.GetComponent<AudioSource>();

        gold_slack.Play();
        randomSellSou.Play();
    }

    public void DeniedSound()
    {
         AudioSource denied = audioSources.transform.GetChild(11).transform.GetComponent<AudioSource>();
         denied.Play();
    }

}
