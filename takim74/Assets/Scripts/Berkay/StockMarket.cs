using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockMarket : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<PlayerInventory> npcInventories = new List<PlayerInventory>();
    public List<Village> villages = new List<Village>();
    public List<WorldEvent> worldEvents = new List<WorldEvent>();    

    bool flag = true;
    float eventDuration;
    float timeBeforeGameStarted;
    float nextEventTime;

    float updatePriceTimer=0;
    public float updatePriceEverySeconds;

    Village randomVillage;
    WorldEvent randomEvent;


    private void Start()
    {
        foreach(Item item in items)
        {
            item._price = item._initialPrice;
        }

    }

    private void Update()
    {
        timeBeforeGameStarted += Time.deltaTime;
        updatePriceTimer += Time.deltaTime;

        if(updatePriceTimer > updatePriceEverySeconds)
        {
            updatePriceTimer = 0;
            deltaPriceRandomizer(items);
        }

        if(timeBeforeGameStarted > 10f)
        {
            if(flag == true) 
            {
                randomEvent = PickRandomWorldEvent(worldEvents);
                randomVillage = PickRandomVillage(villages);

                Debug.Log(randomEvent);
                Debug.Log(randomVillage);

                StartWorldEventForGivenVillage(randomEvent,randomVillage);
                eventDuration = randomEvent.duration;

                nextEventTime = timeBeforeGameStarted + 30;
                flag = false;
            }

            eventDuration -= Time.deltaTime;
            
            if(eventDuration < 0 && flag == false) 
            {
                eventDuration = 0;
                EndWorldEventForGivenVillage(randomEvent,randomVillage);
            }

            if(timeBeforeGameStarted > nextEventTime)
            {
                Invoke("SetFlagTrue",0);
            }
        }        
    }

    public void deltaPriceRandomizer(List<Item> items)
    {
        foreach(Item item in items)
        {
            if(item._initialPrice * 2  < item._price)
            {
                item._price -= item._price * 2.5f/100;
                continue;
            }

            if(item._initialPrice / 2  > item._price)
            {
                item._price += item._price * 2.5f/100;
                continue;
            }


            int number = Random.Range(0,2);

            if(number == 1)
            {
                item._price += item._price * 2.5f/100;
            } 
            else
            {
                item._price -= item._price * 2.5f/100;
            } 
        }
    }

    
    // WORLD EVENT WORLD EVENT WORLD EVENT WORLD EVENT WORLD EVENT 

    public void StartWorldEventForGivenVillage(WorldEvent worldEvent, Village village)
    {
        for(int i = 0; i<worldEvent.items.Length; i++)
        {
            worldEvent.initialPriceses[i] = village.ReturnRefValue(worldEvent.items[i]);

            MultiplyRefValueByGivenNumber(ref village.ReturnRefValue(worldEvent.items[i]), worldEvent);
        }
    }

    public void MultiplyRefValueByGivenNumber(ref float num, WorldEvent evt)
    {
        num *= evt.priceMultiplier;
    }

    public void ChangeRefValueByGivenNumber(ref float num, float num2)
    {
        num = num2;
    }

    public void EndWorldEventForGivenVillage(WorldEvent worldEvent, Village village) 
    {
        for(int k = 0; k<worldEvent.items.Length; k++) 
        {
            ChangeRefValueByGivenNumber(ref village.ReturnRefValue(worldEvent.items[k]), worldEvent.initialPriceses[k]);
            
        }
    }

    public Village PickRandomVillage(List<Village> vills) 
    {
        int random = Random.Range(0,vills.Count);

        return vills[random];
    }

    public WorldEvent PickRandomWorldEvent(List<WorldEvent> events) 
    {
        int random = Random.Range(0,events.Count);

        return events[random];
    }  

    public void SetFlagTrue()
    {
        flag = true;
    }
 
}


