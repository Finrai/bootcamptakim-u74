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
    private int index;
    public float duration;
    [HideInInspector] public bool flag;
   

    

    private void Awake()
    {
        index = transform.GetSiblingIndex();

        image = GetComponentInChildren<Image>();

        shopManager = GetComponentInParent<ShopManager>();

        if(item != null)
            localPrice = shopManager.village.CalculatePrice(item);
    }

    private void Start()
    {
        localPrice = shopManager.village.CalculatePrice(item);   
    }

    private void Update()
    {
        image = GetComponentInChildren<Image>();

        if(item == null)
        {
            
        }
        else
        {
            if(transform.GetChild(0).gameObject.activeInHierarchy == true)
            {
                image.sprite = item._sprite;
            }
        }
    }   
}
