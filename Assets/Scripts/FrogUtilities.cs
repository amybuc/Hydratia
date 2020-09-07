using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FrogUtilities : MonoBehaviour
{

    public GameObject feelsPrefab;
    public Sprite happyFrog;
    public Sprite fineFrog;
    public Sprite thirstyFrog;

    public static FrogUtilities instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    /*
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
    */

    public string getFrogHappiness()
    {
        //First, lets check yesterday:

        if (System.DateTime.Now.Hour <= 11)
        {
            Debug.Log("It's earlier than 11:59");

            if (GameManager.instance.getDailyWaterCountPercentage() <= 0)
            {
                //CHECK IF THERE ARE PREVIOUS LOGS TO GO OFF

                if (GameManager.instance.findPreviousLogByDate(System.DateTime.Today.AddDays(-1)) != null)
                {
                    if (GameManager.instance.getPreviousWaterCountPercentage(GameManager.instance.findPreviousLogByDate(System.DateTime.Today.AddDays(-1))) < 60)
                    {
                        return "thirsty";
                    }
                    if (GameManager.instance.getPreviousWaterCountPercentage(GameManager.instance.findPreviousLogByDate(System.DateTime.Today.AddDays(-1))) > 60)
                    {
                        return "fine";
                    }
                }
                else
                {
                    return "thirsty";
                }
            }

            if (GameManager.instance.getDailyWaterCountPercentage() >= 15)
            {
                return "happy";
            }

            if (GameManager.instance.getDailyWaterCountPercentage() < 15)
            {
                return "fine";
            }
        }


        if (System.DateTime.Now.Hour < 15 && System.DateTime.Now.Hour >= 12)
        {
            Debug.Log("It's later than 12:59 but earlier than 3:00");

            if (GameManager.instance.getDailyWaterCountPercentage() >= 60)
            {
                return "happy";
            }
            if (GameManager.instance.getDailyWaterCountPercentage() >= 25 && GameManager.instance.getDailyWaterCountPercentage() < 60)
            {
                return "fine";
            }
            if (GameManager.instance.getDailyWaterCountPercentage() < 25)
            {
                return "thirsty";
            }

        }


        if (System.DateTime.Now.Hour < 18 && System.DateTime.Now.Hour >= 15)
        {
            Debug.Log("It's later than 3:00 but earlier than 6:00pm");

            if (GameManager.instance.getDailyWaterCountPercentage() >= 80)
            {
                return "happy";
            }
            if (GameManager.instance.getDailyWaterCountPercentage() >= 60 && GameManager.instance.getDailyWaterCountPercentage() < 80)
            {
                return "fine";
            }
            if (GameManager.instance.getDailyWaterCountPercentage() < 60)
            {
                return "thirsty";
            }


        }


        if (System.DateTime.Now.Hour > 19)
        {
            Debug.Log("It's later than 7:00");

            if (GameManager.instance.getDailyWaterCountPercentage() >= 90)
            {
                return "happy";
            }
            if (GameManager.instance.getDailyWaterCountPercentage() >= 60 && GameManager.instance.getDailyWaterCountPercentage() < 90)
            {
                return "fine";
            }
            if (GameManager.instance.getDailyWaterCountPercentage() < 60)
            {
                return "thirsty";
            }

        }
        return null;


    }


    public void onFrogTap(GameObject frog)
    {
        string feelsString = getFrogHappiness();

        GameObject feelsObject = Instantiate(feelsPrefab);
        feelsObject.transform.SetParent(frog.transform);
        ConstraintSource constraint = new ConstraintSource();
        constraint.sourceTransform = Camera.main.transform;
        constraint.weight = 1;
        feelsObject.GetComponent<LookAtConstraint>().AddSource(constraint);

        if (feelsString == "happy")
        {
            feelsObject.GetComponent<SpriteRenderer>().sprite = happyFrog;
        }

        if (feelsString == "fine")
        {
            feelsObject.GetComponent<SpriteRenderer>().sprite = fineFrog;
        }

        if (feelsString == "thirsty")
        {
            feelsObject.GetComponent<SpriteRenderer>().sprite = thirstyFrog;
        }

        feelsObject.GetComponent<Animator>().SetTrigger("Animate");

        StartCoroutine(deleteAfterDelay(feelsObject, 2));




        //InstantiateCanvas
        //Change Image
        //Animate
    }

    public IEnumerator deleteAfterDelay(GameObject objectToDestroy, int delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject.Destroy(objectToDestroy);
    }





}
