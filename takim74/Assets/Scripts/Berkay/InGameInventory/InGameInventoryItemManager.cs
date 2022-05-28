using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameInventoryItemManager : MonoBehaviour
{
    public Item item;
    public Image image;
    private PlayerInGameInventoryManager inventory;
    private bool flag;
    

    private void Awake()
    {
        inventory = GetComponentInParent<PlayerInGameInventoryManager>();
        image = GetComponentInChildren<Image>();  
    }
}
