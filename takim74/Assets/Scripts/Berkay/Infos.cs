using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Infos : MonoBehaviour
{
    public TextMeshProUGUI coin;
    public TextMeshProUGUI weight;
    private PlayerInGameInventoryManager playerInGameInventoryManager;

    private void Start()
    {
        playerInGameInventoryManager = transform.parent.GetComponentInChildren<PlayerInGameInventoryManager>();
    }
    private void Update()
    {
        coin.text = playerInGameInventoryManager.playerInventory.coin.ToString();
        weight.text = playerInGameInventoryManager.playerInventory.currentWeight.ToString() + "\\" + playerInGameInventoryManager.playerInventory.maxWeight.ToString();
    }
}
