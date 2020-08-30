using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft;
using System.IO;
using Newtonsoft.Json;

public class TimeSaveManager : MonoBehaviour
{

    public static TimeSaveManager instance;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadPreviousLogs()
    {
        loadData();
    }

    public void AdaptNewDay() // to be checked every time the app is opened
    {
        if (GameManager.instance.Today == null)
        {
            GameManager.instance.Today = System.DateTime.Today;

        }
        else if (GameManager.instance.Today == System.DateTime.Today)
        {
            return;
        }
        else if (GameManager.instance.Today != System.DateTime.Today)
        {
            //LOG CURRENT DAY, START NEW DAY
            WaterLog previousLog = new WaterLog();
            previousLog.dateTime = GameManager.instance.Today;
            previousLog.waterDrank = GameManager.instance.dailyCount;
            previousLog.waterGoal = GameManager.instance.dailyGoal;
            GameManager.instance.pastDailyLogs.Add(previousLog);
            GameManager.instance.Today = System.DateTime.Today;
        }

    }

    public void OnApplicationPause(bool pause)
    {
        //saveLog();
    }

    public void OnApplicationQuit()
    {
        saveLog();
    }


    public void saveLog()
    {
        Debug.Log("Saving data!");
        Debug.Log("Saving at " + Application.persistentDataPath);

        SaveLog saveLog = new SaveLog();
        saveLog.listToSave = gameObject.GetComponent<GameManager>().pastDailyLogs;

        string pastLogsString = JsonUtility.ToJson(saveLog);
        WriteToFile("saveLogs.json", pastLogsString);
       
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

    public void loadData()
    {
        SaveLog loadLog = new SaveLog();
        loadLog = JsonConvert.DeserializeObject<SaveLog>(Resources.Load<TextAsset>("JSON/cardDatabase").ToString());
        //loadLog = JsonUtility.FromJson<SaveLog>(File.ReadAllText(Application.persistentDataPath + "/saveLogs.json"));
        GameManager.instance.pastDailyLogs = loadLog.listToSave;
        Debug.Log("loaded listy test " + GameManager.instance.pastDailyLogs[0].dateTime);
        //loadLog = JsonConvert.DeserializeObject<SaveLog>(Resources.Load<TextAsset>("JSON/cardDatabase").ToString());
    }
}
