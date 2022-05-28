using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Village", menuName = "Village")]
public class Village : ScriptableObject
{
    public Item fish;           public float fishPriceMultipler;
    public Item honey;          public float honeyPriceMultipler;
    public Item bread;          public float breadPriceMultipler;
    public Item milk;           public float milkPriceMultipler;
    public Item bluePotion;     public float bluePotionPriceMultipler;
    public Item redPotion;      public float redPotionPriceMultipler;
    public Item yellowPotion;   public float yellowPotionPriceMultipler;
    public Item greenPotion;    public float greenPotionPriceMultipler;
    public Item cheese;         public float cheesePriceMultipler;
    public Item sword;          public float swordPriceMultipler;


   
    public float CalculatePriceMultipler(Item itemType) // returns 0 if fails
    {
        float price;

        if(itemType == fish)
        {
            price = fishPriceMultipler;
        }
        else if(itemType == honey)
        {
            price = honeyPriceMultipler;
        }
        else if(itemType == bread)
        {
            price = breadPriceMultipler;
        }
        else if(itemType == bluePotion)
        {
            price = bluePotionPriceMultipler;
        }
        else if(itemType == redPotion)
        {
            price = redPotionPriceMultipler;
        }
        else if(itemType == greenPotion)
        {
            price = greenPotionPriceMultipler;
        }
        else if(itemType == yellowPotion)
        {
            price = yellowPotionPriceMultipler;
        }
        else if(itemType == cheese)
        {
            price = cheesePriceMultipler;
        }
        else if(itemType == sword)
        {
            price = swordPriceMultipler;
        }
        else
        {
            return 0;
        }
        
        return price;

    }


}
