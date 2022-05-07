using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Inventory", menuName = "Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public Sprite _sprite;
    public float coin;
    public List<Item> items = new List<Item>();
   
 }
