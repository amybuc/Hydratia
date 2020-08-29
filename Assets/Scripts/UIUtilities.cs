using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUtilities : MonoBehaviour
{

    public static UIUtilities instance;

    [Header("Main Screen")]
    public TextMeshProUGUI dailyCountText; //Debug, will be replaced with progress bar

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void updateMainUI()
    {
        dailyCountText.text = "" + WaterManager.instance.dailyCount + " / " + WaterManager.instance.dailyGoal;
    }

}
