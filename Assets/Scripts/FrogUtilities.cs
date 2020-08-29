using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogUtilities : MonoBehaviour
{

    public static FrogUtilities instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    public void getFrogHappiness()
    {
        if (WaterManager.instance.getDailyWaterCountPercentage() <= 25)
        {
            //thirsty
        }
        if (WaterManager.instance.getDailyWaterCountPercentage() > 25 && WaterManager.instance.getDailyWaterCountPercentage() <= 75)
        {
            //fine
        }
        if (WaterManager.instance.getDailyWaterCountPercentage() > 75 && WaterManager.instance.getDailyWaterCountPercentage() <= 100)
        {
            //happy
        }
    }
}
