using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUtilities : MonoBehaviour
{

    public static UIUtilities instance;

    [Header ("Records Screen")]
    public GameObject recordsScreen;
    public GameObject recordsContent;
    public GameObject logPrefab;

    [Header("Main Screen")]
    public TextMeshProUGUI dailyCountText; //Debug, will be replaced with progress bar

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void updateMainUI()
    {
        dailyCountText.text = "" + GameManager.instance.dailyCount + " / " + GameManager.instance.dailyGoal;
    }

    public void DEBUGAddLogButton()
    {
        WaterLog newlog = new WaterLog();
        newlog.dateTime = System.DateTime.Today.AddDays(1);
        newlog.waterGoal = 2000;
        newlog.waterDrank = 1020;

        GameManager.instance.pastDailyLogs.Add(newlog);
        
        Debug.Log("Adding log to log");

    }

    public void fillRecordsScreen()
    {
        foreach (WaterLog log in GameManager.instance.pastDailyLogs)
        {
            GameObject logEntry = Instantiate(logPrefab);

            logEntry.transform.SetParent(recordsContent.transform, false);

            foreach (Transform child in logEntry.transform)
            {
                if (child.gameObject.name == "Log_Numbers")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = "" + log.waterDrank + " / " + log.waterGoal;
                }
                if (child.gameObject.name == "Log_Date")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = "" + log.dateTime;
                }
            }
            //Add a checkmark if water goal was met, cross if not, also add more art

        }
    }

    public void DEBUGPrintLogs()
    {
        if (GameManager.instance.pastDailyLogs != null)
        {
            Debug.Log("There are " + GameManager.instance.pastDailyLogs.Count + " numbers of logs in the daily logs");
            foreach (WaterLog log in GameManager.instance.pastDailyLogs)
            {
                Debug.Log("Date of log is " + log.dateTime + " and water drank is " + log.waterDrank);
            }
            

        }
        else
        {
            Debug.Log("pastDailyLogs is returning null");
        }

        

    }


}
