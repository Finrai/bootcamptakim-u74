using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Village", menuName = "Village")]
public class Village : ScriptableObject
{
    public Item fish;           public float fishPriceMultipler = 1;
    public Item honey;          public float honeyPriceMultipler= 1;
    public Item bread;          public float breadPriceMultipler= 1;
    public Item milk;           public float milkPriceMultipler= 1;
    public Item bluePotion;     public float bluePotionPriceMultipler= 1;
    public Item redPotion;      public float redPotionPriceMultipler= 1;
    public Item yellowPotion;   public float yellowPotionPriceMultipler= 1;
    public Item greenPotion;    public float greenPotionPriceMultipler= 1;
    public Item cheese;         public float cheesePriceMultipler= 1;
    public Item sword;          public float swordPriceMultipler= 1;


   
    public float CalculatePrice(Item itemType) // returns 0 if fails
    {
        float price;

        if(itemType == fish)
        {
            price =  itemType._price * fishPriceMultipler;
        }
        else if(itemType == honey)
        {
            price =itemType._price * honeyPriceMultipler;
        }
        else if(itemType == bread)
        {
            price = itemType._price * breadPriceMultipler;
        }
        else if(itemType == bluePotion)
        {
            price = itemType._price * bluePotionPriceMultipler;
        }
        else if(itemType == redPotion)
        {
            price = itemType._price * redPotionPriceMultipler;
        }
        else if(itemType == greenPotion)
        {
            price = itemType._price * greenPotionPriceMultipler;
        }
        else if(itemType == yellowPotion)
        {
            price = itemType._price * yellowPotionPriceMultipler;
        }
        else if(itemType == cheese)
        {
            price = itemType._price * cheesePriceMultipler;
        }
        else if(itemType == sword)
        {
            price = itemType._price * swordPriceMultipler;
        }
        else
        {
            return 0;
        }
        
        return price;
    }


}
