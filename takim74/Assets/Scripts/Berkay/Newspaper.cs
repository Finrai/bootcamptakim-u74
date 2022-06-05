using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Newspaper : MonoBehaviour
{
    public StockMarket stockMarket;

    public TextMeshProUGUI newsText;
    public TextMeshProUGUI Pricetext;

   public List<string> emptyNews = new List<string>();

   [HideInInspector] public string RandomString;

   private float everySeconds;
   private float everySecondsInitial = 20f;
   
 
    [HideInInspector] public float[] avgPrices = new float[10]; // itemlerin sayısı kadar olmalı

    
    private void Start()
    {
        for(int j=0; j<avgPrices.Length; j++) 
        {
            avgPrices[j] = 0;
        }

        everySeconds = everySecondsInitial;

        
    } 
   
    private void Update()
    {
        everySeconds -= Time.deltaTime;

        if(stockMarket.eventDuration != 0)
        {
            newsText.text = "OMG! " + stockMarket.randomEvent.name + " at " + stockMarket.randomVillage.name + " #STOPTHIS"; 
        }
        else 
        {
            if(everySeconds < 0) 
            {
                Invoke("SetRandomNew",0);
                everySeconds = everySecondsInitial;
            }
        }
            
        


        CalculateItemAveragePrices();

        Pricetext.text =
        "Blue Potion: " + avgPrices[0].ToString() + "\n" +
        "Bread: " + avgPrices[1].ToString() + "\n" + 
        "Cheese: " + avgPrices[2].ToString() + "\n" + 
        "Fish: " + avgPrices[3].ToString() + "\n" +
        "Milk: " + avgPrices[4].ToString() + "\n" +
        "Green Potion: " + avgPrices[5].ToString() + "\n" +
        "Honey: " + avgPrices[6].ToString() + "\n" +
        "Red Potion: " + avgPrices[7].ToString() + "\n" +
        "Sword: " + avgPrices[8].ToString() + "\n" +
        "Yellow Potion: " + avgPrices[9].ToString();

                        
        
        for(int k=0; k<transform.childCount; k++) 
        {
            transform.GetChild(k).gameObject.SetActive(HasNewspaper(stockMarket.playerInventory));
        }

        
       
    }

    public bool HasNewspaper(PlayerInventory inv)
    {
        for(int i=0; i<inv.items.Count; i++) 
        {
            if(inv.items[i].name == "Newspaper")
            {
                return true;
            }
        }

        return false;
    }

    public void CalculateItemAveragePrices()
    {
        for(int i=0; i<avgPrices.Length; i++) 
        {   
            avgPrices[i] = 0;

            for(int k=0; k<stockMarket.villages.Count; k++) 
            {
                avgPrices[i] += stockMarket.villages[k].ReturnRefValue(stockMarket.items[i]) * stockMarket.items[i]._price;
            }

            avgPrices[i] /= stockMarket.villages.Count;


        }
    }

    public void SetRandomNew()
    {
        RandomString = emptyNews[Random.Range(0,emptyNews.Count)];
        newsText.text = RandomString;
    }
   
}
