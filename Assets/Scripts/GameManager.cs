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
