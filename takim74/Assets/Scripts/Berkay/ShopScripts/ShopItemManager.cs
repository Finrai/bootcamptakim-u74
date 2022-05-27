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
    [HideInInspector] public float localPrice; 
    public float duration;

    private void Awake()
    {
        image = GetComponentInChildren<Image>();

        shopManager = GetComponentInParent<ShopManager>();

    }

    private void Start()
    {
        localPrice = shopManager.village.CalculatePrice(item);   
    }

    private void Update()
    {
        image = GetComponentInChildren<Image>();

        if(item != null && transform.GetChild(0).gameObject.activeInHierarchy == true)
        {
            image.sprite = item._sprite;
        }

        if(duration > 0)
        {
            duration -= Time.deltaTime;

            if(item != null)
            {
                localPrice = ( shopManager.village.CalculatePrice(item) ) *  duration/item._initialDuration;
                Debug.Log(transform.name + " " + localPrice);
            }
        }
    }   
}
