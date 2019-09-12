using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;
    private bool serverTime; 

    public static TimeManager Instance { get => instance; set => instance = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    public void Initialize()
    {
        //Check if the pet has some values saved

        //Health
        if (!PlayerPrefs.HasKey("health"))
        {
             Pet.Instance.Health.Initialize(100);
            PlayerPrefs.SetFloat("health", Pet.Instance.Health.CurrenValue);
        }
        else
        {
           Pet.Instance.Health.Initialize(PlayerPrefs.GetFloat("health"));
        }
        //Thirst
        if (!PlayerPrefs.HasKey("thirst"))
        {
            Pet.Instance.Thirst.Initialize(100);
            PlayerPrefs.SetFloat("thirst", Pet.Instance.Thirst.CurrenValue);
        }
        else
        {
            Pet.Instance.Thirst.Initialize(PlayerPrefs.GetFloat("thirst"));
        }
        //Happiness
        if (!PlayerPrefs.HasKey("happiness"))
        {
            Pet.Instance.Happiness.Initialize(100);
            PlayerPrefs.SetFloat("happiness", Pet.Instance.Happiness.CurrenValue);
        }
        else
        {
            Pet.Instance.Happiness.Initialize(PlayerPrefs.GetFloat("happiness"));
        }

        //Time then
        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", GetStringTime());
            Debug.Log(GetTimeSpan().ToString()); // debug
        }
        else
        {
            Debug.Log(GetTimeSpan().ToString()); // debug
        }
        //Get how much time has passed
        System.TimeSpan ts = GetTimeSpan();

        //Update thirst
        Pet.Instance.Thirst.CurrenValue -= (int)(ts.TotalHours * 2);
        //Update happiness
        Pet.Instance.Happiness.CurrenValue -= (int)((100 - Pet.Instance.Thirst.CurrenValue) * (ts.TotalHours / 5));

        Debug.Log(PlayerPrefs.GetFloat("happiness"));
        Debug.Log(PlayerPrefs.GetFloat("health"));
        
        if (serverTime)
        {
            UpdateServer();
        }
        else
        {
            InvokeRepeating("UpdateDevice", 0f, 30f); //Save time every 30 secs
        }

    }

    private void UpdateServer() { }
    private void UpdateDevice() { PlayerPrefs.SetString("then", GetStringTime()); } //Save the time
    private string GetStringTime()
    {
        System.DateTime now = System.DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }
    private System.TimeSpan GetTimeSpan()
    {
        if (serverTime)
        {
            return new System.TimeSpan();
        }
        else
        {
            return System.DateTime.Now - System.Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }
}


