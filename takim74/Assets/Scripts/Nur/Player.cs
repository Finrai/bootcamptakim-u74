using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void savePlayer()
    {
        savesystem.save(this);
    }

    public void loadPlayer()
    {
        playerData data = savesystem.load();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }
}
