using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileDataHandler
{
    private string dataDir = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string fileName)
    {
        this.dataDir = dataDirPath;
        this.dataFileName = fileName;
    }
    public GameData Load()
    {
        // Using Path.Combine to account for different OS's having different path seperator
        string fullPath = Path.Combine(dataDir, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                // Load a Serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // Deserialize JSON to C# Object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch(Exception e)
            {
                Debug.LogError("Error Occured When Trying to Load a file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }
    public void Save(GameData data)
    {
        // Using Path.Combine to account for different OS's having different path seperator
        string fullPath = Path.Combine(dataDir, dataFileName);

        try
        {
            // Create a file Dir Path if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Serialized C# GameData Object to JSON
            string dataToStore = JsonUtility.ToJson(data, true);

            // Write a Serialized data to the file
            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error Occured When Trying to Save a file: " + fullPath + "\n" + e);
        }
    }
}
