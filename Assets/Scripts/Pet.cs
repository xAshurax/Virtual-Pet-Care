using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    
    private Stat health; 
    private Stat thirst; 
    private Stat happiness; 
    private bool serverTime; //
    // Start is called before the first frame update
    void Start()
    {
        //Time test
       // PlayerPrefs.SetString("then", "08/02/2019 11:20:11");
        
        //Getting the bars by name 
        health = GameObject.Find("HealthBar").GetComponent<Stat>();  
        thirst = GameObject.Find("ThirstBar").GetComponent<Stat>();
        happiness = GameObject.Find("HappinessBar").GetComponent<Stat>();
      
        
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        //For Debugging only
        if(Input.GetKeyDown(KeyCode.I))
        {
            health.CurrenValue += 5;
            thirst.CurrenValue += 5;
            happiness.CurrenValue += 10;
          
            PlayerPrefs.SetFloat("health", health.CurrenValue);
            PlayerPrefs.SetFloat("thirst", thirst.CurrenValue);
            PlayerPrefs.SetFloat("happiness", happiness.CurrenValue);
          
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            health.CurrenValue -= 5;
            thirst.CurrenValue -= 5;
            happiness.CurrenValue -= 10;
         
            PlayerPrefs.SetFloat("health", health.CurrenValue);
            PlayerPrefs.SetFloat("thirst", thirst.CurrenValue);
            PlayerPrefs.SetFloat("happiness", happiness.CurrenValue);
           
        }
    }

    private void Initialize()
    {
        //Check if the pet has some values saved

        //Health
        if (!PlayerPrefs.HasKey("health")) 
        {
            health.Initialize(100);
            PlayerPrefs.SetFloat("health", health.CurrenValue);
        } else
        {
            health.Initialize(PlayerPrefs.GetFloat("health"));
        }
        //Thirst
        if (!PlayerPrefs.HasKey("thirst"))
        {
            thirst.Initialize(100);
            PlayerPrefs.SetFloat("thirst", thirst.CurrenValue);
        }
        else
        {
            thirst.Initialize(PlayerPrefs.GetFloat("thirst"));
        }
        //Happiness
        if(!PlayerPrefs.HasKey("happiness"))
        {
            happiness.Initialize(100);
            PlayerPrefs.SetFloat("happiness", happiness.CurrenValue);
        } else
        {
            happiness.Initialize(PlayerPrefs.GetFloat("happiness"));
        }
        
        //Time then
        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", GetStringTime());
            Debug.Log(GetTimeSpan().ToString()); // debug
        } else
        {
            Debug.Log(GetTimeSpan().ToString()); // debug
        }
        //Get how much time has passed
        System.TimeSpan ts = GetTimeSpan(); 

        //Update thirst
        thirst.CurrenValue -= (int)(ts.TotalHours * 2);
        //Update happiness
        happiness.CurrenValue -= (int)((100 - thirst.CurrenValue) * (ts.TotalHours / 5));

        Debug.Log(PlayerPrefs.GetFloat("happiness"));
        Debug.Log(PlayerPrefs.GetFloat("health"));
        //Check for the last time played
        if(serverTime)
        {
            UpdateServer();
        } else
        {
            InvokeRepeating("UpdateDevice", 0f, 30f); //Save time every 30 secs
        }

    }

    private void UpdateServer() { }
    private void UpdateDevice() { PlayerPrefs.SetString("then", GetStringTime());  } //Save the time
    private string GetStringTime()
    {
        System.DateTime now = System.DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }
  private  System.TimeSpan GetTimeSpan()
    {
        if (serverTime)
        {
            return new System.TimeSpan();
        } else
        {
            return System.DateTime.Now - System.Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }
}
