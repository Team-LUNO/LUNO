using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameData
{
    public int sceneNum;
}

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public GameData gameData = new GameData();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.dataPath + "/Resources/Data/GameData.json", data);
        Debug.Log("Save data: " + gameData.sceneNum);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(Application.dataPath + "/Resources/Data/GameData.json");
        gameData = JsonUtility.FromJson<GameData>(data);
        Debug.Log("Load data: " + gameData.sceneNum);
    }
}
