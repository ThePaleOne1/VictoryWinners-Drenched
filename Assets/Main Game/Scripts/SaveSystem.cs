using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveScore (SunGoku score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/score.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(score);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static GameData LoadScore()
    {
        string path = Application.persistentDataPath + "/score.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Score not found" + path);
            return null;
        }
    }
}
