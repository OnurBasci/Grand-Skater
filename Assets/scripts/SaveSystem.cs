using UnityEngine;
using System.IO;  //dosyalarla calisildiginda kullanilmalidir
using System.Runtime.Serialization.Formatters.Binary;  //binary formatter'a ulasmamizi saglar

public static class SaveSystem
{
    public static void SavePlayer(e_information player, wayPoinText score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.values";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, score);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.values";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
