using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StockMarket : MonoBehaviour
{
    public PlayerInventory playerInventory;

    public List<Item> items = new List<Item>();
    public List<PlayerInventory> npcInventories = new List<PlayerInventory>();
    public List<Village> villages = new List<Village>();
    
    public List<WorldEvent> worldEvents = new List<WorldEvent>();    
    public List<GameObject> soldiers = new List<GameObject>();

   [HideInInspector]  public bool flag = true;
    [HideInInspector] public float eventDuration;
    float timeBeforeGameStarted;
    float nextEventTime;

    float updatePriceTimer=0;
    public float updatePriceEverySeconds;

    [HideInInspector] public Village randomVillage;
   [HideInInspector]  public WorldEvent randomEvent;


    private void Start()
    {
        foreach(Item item in items)
        {
            item._price = item._initialPrice;
        }

        foreach(GameObject obj in soldiers) 
        {
            obj.SetActive(false);
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
                
                DynamicShopInventory(npcInventories,items);

                randomEvent = PickRandomWorldEvent(worldEvents);
                randomVillage = PickRandomVillage(villages);

                Debug.Log(randomEvent);
                Debug.Log(randomVillage);

                if(randomEvent.name == "War")
                {
                    soldiers[ReturnVillageIndex(randomVillage)].SetActive(true);
                    Debug.Log("war time");
                }

                StartWorldEventForGivenVillage(randomEvent,randomVillage);
                eventDuration = randomEvent.duration;

                nextEventTime = timeBeforeGameStarted + 80;
                flag = false;

            }

            eventDuration -= Time.deltaTime;
            
            if(eventDuration < 0 && flag == false) 
            {
                eventDuration = 0;

                if(soldiers[ReturnVillageIndex(randomVillage)].activeInHierarchy == true)
                {
                     soldiers[ReturnVillageIndex(randomVillage)].SetActive(false);
                }

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


    public void DynamicShopInventory(List<PlayerInventory> inventories, List<Item> items) 
    {
        for(int i=0; i<inventories.Count; i++) 
        {
            // add item 

            int random;

            if(inventories[i].items.Count < inventories[i].maxSize)
            {
                for(int k=0; k<Random.Range(0,5); k++) 
                {
                    random = Random.Range(0,items.Count);

                    Item item = items[random];

                    if(item._initialPrice < inventories[i].coin)
                    {
                        inventories[i].items.Add(item);
                        inventories[i].coin -= item._initialPrice;
                    }
                }
            }

            // remove item

            for(int j=0; j<Random.Range(0,3); j++)
            {
                if(inventories[i].items.Count != 0) 
                {
                    random = Random.Range(0,inventories[i].items.Count - 2);
                    

                    if(inventories[i].items[random] != null) 
                    {
                        Item item = inventories[i].items[random];
                        inventories[i].items.RemoveAt(random);  
                        inventories[i].coin += item._initialPrice * 1.2f;     
                    }
                }
            }
        }
    }

    public int ReturnVillageIndex(Village village)  
    {
        for(int i=0; i<villages.Count; i++) 
        {
            if(village.name == villages[i].name)
            {
                return i;
            }
        }

        return -1;
    }
}


