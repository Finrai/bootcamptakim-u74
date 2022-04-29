using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_DisplayItem : MonoBehaviour
{
    public Item item;
    private Image image;
    public TextMeshProUGUI text;
    public PlayerCoin playerCoin;

    private void Awake()
    {
        image = GetComponent<Image>();
        //text = GetComponent<TMPro.TextMeshProUGUI>();
        
    }
    private void Update()
    {
        image.sprite = item._sprite;
        text.text = item._name + " " +item._price.ToString();
    }

    public void BuyThisItem()
    {   
        if(playerCoin.coin > item._price)
            playerCoin.coin -= item._price;
    }


}
