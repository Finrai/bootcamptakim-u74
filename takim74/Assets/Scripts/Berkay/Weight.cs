using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weight : MonoBehaviour
{
    public PlayerInventory playerInventory;

    private TextMeshProUGUI text;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        text.text = playerInventory.currentWeight.ToString() + "\\" + playerInventory.maxWeight.ToString();
    }
}
