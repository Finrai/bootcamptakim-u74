using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Village", menuName = "Village")]
public class Village : ScriptableObject
{
    public Item food;
    public Item sword;
    public Item armor;
    public Item potion;

    public float FoodPriceMultipler;
    public float SwordPriceMultipler;
    public float ArmorPriceMultipler;
    public float PotionPriceMultipler;

    public float CalculatePrice(Item itemType) // returns 0 if fails
    {
        float price;

        if(itemType == food)
        {
            price =  food._price * FoodPriceMultipler;
        }
        else if(itemType == sword)
        {
            price = sword._price * SwordPriceMultipler;
        }
        else if(itemType == armor)
        {
            price = armor._price * ArmorPriceMultipler;
        }
        else if(itemType == potion)
        {
            price = potion._price * PotionPriceMultipler;
        }
        else
        {
            return 0;
        }

        return price;
    }


}
