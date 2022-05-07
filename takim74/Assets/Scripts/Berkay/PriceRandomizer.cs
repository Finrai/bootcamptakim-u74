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
            SummItemPriceWithRandomNumberInRange(food, downScale , upScale);

            inEverySeconds = inEverySecondsInitialValue;
       }
   }

   private void SummItemPriceWithRandomNumberInRange(Item item,float x1, float x2)
   {
        item._price += Random.Range
        (
        x1 * (-food._initialPrice*0.1f) + food._price * 0.05f
        , 
        x2 * (food._initialPrice*0.1f) - food._price * 0.05f
        );
   }
}
