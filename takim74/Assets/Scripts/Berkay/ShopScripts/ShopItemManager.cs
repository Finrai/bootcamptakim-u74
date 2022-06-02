using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemManager : MonoBehaviour
{
    public Item item;
    private Image image;
    private ShopManager shopManager;
    public float localPrice; 
    public float durationBasedPrice;
    public float duration;
    private Slider slider;

    private void Awake()
    {
        image = GetComponentInChildren<Image>();

        slider = GetComponentInChildren<Slider>();

        shopManager = GetComponentInParent<ShopManager>();

    }

    private void Update()
    {
        image = GetComponentInChildren<Image>();

        if(item != null && transform.GetChild(0).gameObject.activeInHierarchy == true)
        {
            image.sprite = item._sprite;
        }

        if(item != null) 
        {
            localPrice = item._price * shopManager.village.CalculatePriceMultipler(item);   
            durationBasedPrice = localPrice * (duration/item._initialDuration);
        }
        
        duration -= Time.deltaTime;

        if(duration <= 0) 
        {
            duration = 0;
        }

        slider.gameObject.SetActive(transform.GetChild(0).transform.gameObject.activeInHierarchy);

        if(slider.gameObject.activeInHierarchy == true)
        {
            slider.maxValue = item._initialDuration;
            slider.minValue = 0;
            slider.value = duration;
        }

        
    }   
}
