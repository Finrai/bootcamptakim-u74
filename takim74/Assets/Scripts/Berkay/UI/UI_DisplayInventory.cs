using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_DisplayInventory : MonoBehaviour
{
   public PlayerInventory _playerInventory;
  
    private void Update()
    {
        Debug.Log(_playerInventory.coin);
    }
}
