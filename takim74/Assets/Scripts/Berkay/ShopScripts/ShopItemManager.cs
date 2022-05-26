using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemManager : MonoBehaviour
{
    public Item item;
    private Image image;
    private TextMeshProUGUI text;
    private ShopManager shopManager;
    [HideInInspector] public float localPrice;

    private int index;

    

    private void Awake()
    {
        index = transform.GetSiblingIndex();

        shopManager = GetComponentInParent<ShopManager>();
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        localPrice = shopManager.village.CalculatePrice(item);
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        image.sprite = item._sprite;
        
        localPrice = shopManager.village.CalculatePrice(item);     
    }   
}
