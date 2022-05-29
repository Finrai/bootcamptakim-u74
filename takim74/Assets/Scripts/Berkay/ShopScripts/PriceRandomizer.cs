using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceRandomizer : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<PlayerInventory> npcInventories = new List<PlayerInventory>();
    public List<int> numberOfItemTypes = new List<int>();

    private void Start()
    {
        foreach(Item item in items)
        {
            item._price = item._initialPrice;
        }
    }

    private void Update()
    {
        deltaPriceRandomizer(items);


    }

    public void deltaPriceRandomizer(List<Item> items)
    {
        
        foreach(Item item in items)
        {
            if(item._initialPrice * 2  < item._price)
            {
                item._price -= item._price * 1/100;
                continue;
            }

            if(item._initialPrice / 2  > item._price)
            {
                item._price += item._price * 1/100;
                continue;
            }


            int number = Random.Range(0,2);

            if(number == 1)
            {
                item._price += item._price * 1/100;
            } 
            else
            {
                item._price -= item._price * 1/100;
            } 
            
        }
    }
}


