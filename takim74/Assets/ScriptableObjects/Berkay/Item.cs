using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public float _price;
    public float _initialPrice;
    public string _name;
    public Sprite _sprite;
}
