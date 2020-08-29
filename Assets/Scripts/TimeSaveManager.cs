using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        //This is where we'll load the JSON file that we save every time the app is closed. They'll load into Watermanager.instance.pastDailyLogs.
    }

    public void AdaptNewDay() // to be checked every time the app is opened
    {
        if (WaterManager.instance.Today == null)
        {
            WaterManager.instance.Today = System.DateTime.Today;

        }
        else if (WaterManager.instance.Today == System.DateTime.Today)
        {
            return;
        }
        else if (WaterManager.instance.Today != System.DateTime.Today)
        {
            //LOG CURRENT DAY, START NEW DAY
            WaterLog previousLog = new WaterLog();
            previousLog.dateTime = WaterManager.instance.Today;
            previousLog.waterDrank = WaterManager.instance.dailyCount;
            previousLog.waterGoal = WaterManager.instance.dailyGoal;
            WaterManager.instance.pastDailyLogs.Add(previousLog);
            WaterManager.instance.Today = System.DateTime.Today;
        }

    }

    public void OnApplicationPause(bool pause)
    {
        //Save to JSON
    }
}
