using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public Item itemType;
    private Image image;
    private TextMeshProUGUI text;
    private ShopManager shopManager;
    public float localPrice;

    private void Awake()
    {
        shopManager = GetComponentInParent<ShopManager>();
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        image.sprite = itemType._sprite;
    }
    private void Update()
    {
        localPrice = shopManager.village.CalculatePrice(itemType);

        text.text = itemType._name + " " + localPrice.ToString(); 
    }   
}
