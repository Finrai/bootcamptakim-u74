using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameInventoryItemManager : MonoBehaviour
{
    public Item item;
    private Image image;

    private PlayerInGameInventoryManager inventory;
   
    private void Awake()
    {
        inventory = GetComponentInParent<PlayerInGameInventoryManager>();
        image = GetComponent<Image>();
        
    }
    
    private void Update()
    {
        image.sprite = item._sprite;
    }
}
