using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage")]
    [SerializeField] private string fileName;

    private GameData gameData; // GameData Class
    private List<IDataPersistance> dataPersistancesObjects; // List for storing any GameObject script that uses IDataPersistance
    private FileDataHandler fileDataHandler;

    public static DataPersistanceManager instance { get; private set; }

    #region Singleton
    public void Awake()
    {
        if(instance != null)
        {
            Debug.Log("There are more than 1 DataPersistanceManager");
        }
        instance = this;
    }
    #endregion

    public void Start()
    {
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName); // To Do: only use this when player enter level
        this.dataPersistancesObjects = FindAllDataPersistanceObjects();
        LoadGame(); // To Do: Delete this function from void start when finish this system,
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void LoadGame()
    {
        // Load any Save data from a file using dataHandler
        this.gameData = fileDataHandler.Load();

        // If there is no data to load, Initialize NewGame
        if(this.gameData == null)
        {
            Debug.Log("There is no Data to Load.");
            NewGame();
        }

        // Push loaded data to other scripts that need it
        foreach(IDataPersistance datapersistanceobj in dataPersistancesObjects)
        {
            datapersistanceobj.LoadData(gameData); // Load data from all objects that use IDatapersistance to store the data
        }
        
    }
    public void SaveGame()
    {
        // Pass Data to other scripts so they can update it
        foreach (IDataPersistance datapersistanceobj in dataPersistancesObjects)
        {
            datapersistanceobj.SaveData(gameData); // Save data for each object that use IDataPersistance
        }

        // Save those data to a file using fileDataHandler
        fileDataHandler.Save(gameData);
    }

    // Save when quit the game
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    public List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        // Find All objects that use MonoBehavior with IDataPersistance script and add them to the list
        IEnumerable<IDataPersistance> dataPersistancesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistancesObjects);
    }
}
