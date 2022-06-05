using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCoin : MonoBehaviour
{
    private TextMeshProUGUI text;
    public PlayerInventory Inventory;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        text.text = Inventory.coin.ToString();
    }
}
