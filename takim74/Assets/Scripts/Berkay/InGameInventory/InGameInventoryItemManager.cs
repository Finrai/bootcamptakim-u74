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
    private bool flag;
    


    private void Awake()
    {
        inventory = GetComponentInParent<PlayerInGameInventoryManager>();
        image = GetComponentInChildren<Image>();
    }
    private void Start()
    {
        
    }
    
    private void Update()
    {
        if(image.gameObject.activeInHierarchy == true)
        {
            image.sprite = item._sprite; 
        }

    }
}
