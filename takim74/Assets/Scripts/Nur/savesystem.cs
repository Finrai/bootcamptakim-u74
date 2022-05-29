using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public  static class savesystem
{
 public static void save(Player player)
    {
        BinaryFormatter format = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(player);

        format.Serialize(stream, data);
        stream.Close();
    }

    public static  playerData load()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter format = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerData data = format.Deserialize(stream) as playerData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found!");
            return null;
        }
    }
}
