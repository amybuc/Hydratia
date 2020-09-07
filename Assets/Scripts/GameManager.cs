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

        SaveLoadManager.instance.loadData();
        SaveLoadManager.instance.checkDay();

        gameObject.GetComponent<FrogUtilities>().getFrogHappiness();

        Debug.Log("Current hour is " + System.DateTime.Now.Hour);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMLToDailyCount(int mlAmount)
    {
        dailyCount += mlAmount;
    }

    public float getDailyWaterCountPercentage()
    {
        float percentage = (float)dailyCount / (float)dailyGoal * 100;
        Debug.Log("Percentage is " + percentage);
        return percentage;
    }

    public float getPreviousWaterCountPercentage(WaterLog log)
    {
        float percentage = (float)log.waterDrank / (float)log.waterGoal * 100;
        Debug.Log("Percentage is " + percentage);
        return percentage;
    }

    public WaterLog findPreviousLogByDate(DateTime dateTime)
    {
        foreach(WaterLog log in pastDailyLogs)
        {
            if (dateTime == log.dateTime)
            {
                return log;
            }
            else
            {
                Debug.Log("Log for Datetime " + dateTime + " not found");
            }
        }
        return null;
    }


}
