using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New  Inventory", menuName = "Inventory")]
public class PlayerInventory : ScriptableObject
{
    public float coin;
    public int maxSize;
    public float maxWeight;
    public List<Item> items = new List<Item>();
    [HideInInspector]public float currentWeight;
   
 }
