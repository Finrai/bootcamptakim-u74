using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    
    public float _initialPrice;
    public float _price;
    public float _initialDuration;
    public float _weight;

    public string _name;
    public Sprite _sprite;
}
