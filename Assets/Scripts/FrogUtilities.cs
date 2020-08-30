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
        if (GameManager.instance.getDailyWaterCountPercentage() <= 25)
        {
            //thirsty
        }
        if (GameManager.instance.getDailyWaterCountPercentage() > 25 && GameManager.instance.getDailyWaterCountPercentage() <= 75)
        {
            //fine
        }
        if (GameManager.instance.getDailyWaterCountPercentage() > 75 && GameManager.instance.getDailyWaterCountPercentage() <= 100)
        {
            //happy
        }
    }
}
