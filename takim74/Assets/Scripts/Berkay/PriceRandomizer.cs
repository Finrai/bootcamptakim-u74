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

   private void Start()
   {
       inEverySecondsInitialValue = inEverySeconds;
   }


   private void Update()
   {
       inEverySeconds -= Time.deltaTime;

       if(inEverySeconds <= 0)
       {    
           Debug.Log("randomizer works");

           MultipleItemPriceWithRandomNumberInRange(food, -5f , 5f);
           inEverySeconds = inEverySecondsInitialValue;
       }
   }

   private void MultipleItemPriceWithRandomNumberInRange(Item item,float x1, float x2)
   {
       item._price += Random.Range(x1,x2);

       
   }



}
