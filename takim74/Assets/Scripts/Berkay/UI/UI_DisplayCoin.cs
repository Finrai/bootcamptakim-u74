using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_DisplayCoin : MonoBehaviour
{
   public PlayerCoin playerCoin;

   public TextMeshProUGUI text;
   public Image image;

   private void Update()
   {
       image.sprite = playerCoin._sprite;
       text.text = playerCoin.coin.ToString();
   }


}
