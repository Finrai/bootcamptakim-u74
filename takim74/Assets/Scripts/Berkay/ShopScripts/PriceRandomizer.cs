using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceRandomizer : MonoBehaviour
{
    // add each item manually

   public Item food;
   public Item sword;
   public Item armor;
   public Item potion;

   public Village villageA;
   public Village villageB;
   public Village villageC;
   public Village villageD;

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
       //ControlItemPriceIfTooLowOrHigh(food);

       inEverySeconds -= Time.deltaTime;

       if(inEverySeconds <= 0)
       {    
            ItemPriceRandomizer(food, downScale , upScale);
            ItemPriceRangeManager(food);

            inEverySeconds = inEverySecondsInitialValue;
       }
   }

   private void ItemPriceRandomizer(Item item,float x1, float x2)
   {
        item._price += Random.Range
        (
        x1 * (-food._initialPrice*0.1f) + food._price * 0.05f
        , 
        x2 * (food._initialPrice*0.1f) - food._price * 0.05f
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
