using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour
{
    public float[] position;

    public playerData (Player player)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
