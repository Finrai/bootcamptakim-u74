using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventoryManager : MonoBehaviour
{
    public PlayerInventory playerInventory;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI potionText;
    public TextMeshProUGUI swordText;
    public TextMeshProUGUI foodText;

    public Item armor;
    public Item potion;
    public Item sword;
    public Item food;

    private int armorNumber;
    private int potionNumber;
    private int swordNumber;
    private int foodNumber;
   
    void Update()
    {
        coinText.text = "Current Coins: " + playerInventory.coin.ToString();

        GetNumberOfItems();
        DisplayNumberOfItems();
    }


    public void GetNumberOfItems()
    {
        armorNumber  = 0;
        potionNumber = 0;
        swordNumber  = 0;
        foodNumber   = 0;

        if(playerInventory.items != null)
        {
            for(int i=0; i<playerInventory.items.Count; i++)
            {
                if(playerInventory.items[i]._name == armor._name )
                {
                    armorNumber += 1;
                }
                if(playerInventory.items[i]._name == sword._name )
                {
                    swordNumber += 1;
                }
                if(playerInventory.items[i]._name == food._name )
                {
                    foodNumber += 1;
                }
                if(playerInventory.items[i]._name == potion._name )
                {
                    potionNumber += 1;
                }
            }
        }
    }

    public void DisplayNumberOfItems()
    {
        armorText.text  = armorNumber.ToString();
        swordText.text  = swordNumber.ToString();
        potionText.text = potionNumber.ToString();
        foodText.text   = foodNumber.ToString();
    }
    
}
