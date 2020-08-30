using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public int dailyGoal;
    public int dailyCount;

    public DateTime Today;

    public List<WaterLog> pastDailyLogs = new List<WaterLog>(); 


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        TimeSaveManager.instance.loadPreviousLogs();
        TimeSaveManager.instance.AdaptNewDay();

        WaterLog newlog = new WaterLog();
        newlog.dateTime = System.DateTime.Today.AddDays(1);
        newlog.waterGoal = 2000;
        newlog.waterDrank = 1020;

        pastDailyLogs.Add(newlog);

        Debug.Log("Datetime today is " + System.DateTime.Today);
        Debug.Log("Datetime of logged waterlog is " + pastDailyLogs[0].dateTime);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMLToDailyCount(int mlAmount)
    {
        dailyCount += mlAmount;
    }

    public int getDailyWaterCountPercentage()
    {
        int percentage = (dailyCount / dailyGoal) * 100;
        return percentage;
    }


}
