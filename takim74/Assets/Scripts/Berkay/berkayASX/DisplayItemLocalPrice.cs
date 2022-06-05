using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayItemLocalPrice : MonoBehaviour
{
   
   private ShopItemManager shopItemManager;
   private TextMeshProUGUI text;


    private void Start()
    {
        shopItemManager = GetComponentInParent<ShopItemManager>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        if(transform.parent.GetChild(0).gameObject.activeInHierarchy == true)
        {
            text.text = shopItemManager.localPrice.ToString();
        }
        else
        {
            text.text = "";
        }
    }
}
