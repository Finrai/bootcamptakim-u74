using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceRandomizer : MonoBehaviour
{
    // add each item manually

    public Item fish;           
    public Item honey;         
    public Item bread;          
    public Item milk;           
    public Item bluePotion;     
    public Item redPotion;     
    public Item yellowPotion;   
    public Item greenPotion;    
    public Item cheese;         
    public Item sword;         

   public Village villageA;
  
   public float inEverySeconds;
   private float inEverySecondsInitialValue;

   public float downScale;
   public float upScale;

   private void Start()
   {
       inEverySecondsInitialValue = inEverySeconds;
   }


   private void Update()
   {   
            ItemPriceRandomizer(fish, downScale , upScale);
            ItemPriceRangeManager(fish);

            ItemPriceRandomizer(honey, downScale , upScale);
            ItemPriceRangeManager(honey);

            ItemPriceRandomizer(bread, downScale , upScale);
            ItemPriceRangeManager(bread);

            ItemPriceRandomizer(milk, downScale , upScale);
            ItemPriceRangeManager(milk);

            ItemPriceRandomizer(bluePotion, downScale , upScale);
            ItemPriceRangeManager(bluePotion);

            ItemPriceRandomizer(redPotion, downScale , upScale);
            ItemPriceRangeManager(redPotion);

            ItemPriceRandomizer(yellowPotion, downScale , upScale);
            ItemPriceRangeManager(yellowPotion);

            ItemPriceRandomizer(greenPotion, downScale , upScale);
            ItemPriceRangeManager(greenPotion);

            ItemPriceRandomizer(cheese, downScale , upScale);
            ItemPriceRangeManager(cheese);

            ItemPriceRandomizer(sword, downScale , upScale);
            ItemPriceRangeManager(sword); 

   }

   private void ItemPriceRandomizer(Item item,float x1, float x2)
   {
        item._price += Random.Range
        (
        x1 * (-item._initialPrice*0.1f) + item._price * 0.05f
        , 
        x2 * (item._initialPrice*0.1f) - item._price * 0.05f
        );

        if(item._price <= 0)
        {
            item._price = item._initialPrice * 0.01f;
        }    
   }

   private void ItemPriceRangeManager(Item item)
   {
       if(item._price > item._initialPrice * 2f)
        {
            downScale = 1.6f;

            upScale = 1;
        }

        else if(item._price > item._initialPrice * 5f)
        {
            downScale = 1.3f;

            upScale = 1f;
        }

        else if(item._price > item._initialPrice * 1.3f)
        {
            downScale = 1.25f;

            upScale = 1.05f;
        }

        else if(item._price > item._initialPrice * 1.1f)
        {
            upScale = 1.1f;
            downScale = 1.22f;
        }
        else if(item._price == item._initialPrice)
        {
            upScale = 1.15f;
            downScale = 1.15f;
        }

        else if(item._price < item._initialPrice * 0.9f)
        {
            upScale = 1.22f;

            downScale = 1.1f;
        }
        else if(item._price < item._initialPrice * 0.7f)
        {
            upScale = 1.25f;

            downScale = 1.05f;
        }
        else if(item._price < item._initialPrice * 0.5f)
        {
            upScale = 1.3f;

            downScale = 1f;
        }
   }


}
