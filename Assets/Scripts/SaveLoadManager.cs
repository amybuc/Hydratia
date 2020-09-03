using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;


    private void Awake()
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


    public void OnApplicationPause(bool pause = true)
    {
        //saveData();
    }

    public void OnApplicationQuit()
    {
        saveData();
    }

    public void checkDay()
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
            //GameManager.instance.pastDailyLogs.Add(previousLog);

            GameManager.instance.dailyCount = 0;
            GameManager.instance.Today = System.DateTime.Today;
        }
    }

    public void saveData()
    {
        Debug.Log("Saving");

        //Saving Data
        ES3.Save<List<WaterLog>>("waterData", GameManager.instance.pastDailyLogs);

        WaterLog todayLog = new WaterLog();
        todayLog.dateTime = System.DateTime.Today;
        todayLog.waterDrank = GameManager.instance.dailyCount;
        todayLog.waterGoal = GameManager.instance.dailyGoal;

        ES3.Save<WaterLog>("todayData", todayLog);

        
    }

    public void loadData()
    {
        if (ES3.KeyExists("waterData"))
        {
            Debug.Log("Loading waterData");

            //Clearing the gameManager list to refill with loaded data
            GameManager.instance.pastDailyLogs.Clear();

            //Loading data
            gameObject.GetComponent<GameManager>().pastDailyLogs = ES3.Load<List<WaterLog>>("waterData");
        }
        else
        {
            Debug.Log("ES3 key 'waterData' doesnt exist, not loading");
        }

        if (ES3.KeyExists("todayData"))
        {
            Debug.Log("Loading todayData");

            WaterLog log = ES3.Load<WaterLog>("todayData");

            GameManager.instance.dailyCount = log.waterDrank;
            GameManager.instance.dailyGoal = log.waterGoal;
            GameManager.instance.Today = log.dateTime;

        }
        else
        {
            Debug.Log("ES3 key 'todayData' doesnt exist, not loading");
        }


    }




}
