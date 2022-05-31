using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New World Event", menuName = "World Event")]
public class WorldEvent : ScriptableObject
{
    public Item[] items;
    public float priceMultiplier;
    public float duration;
    public float[] initialPriceses;

}
