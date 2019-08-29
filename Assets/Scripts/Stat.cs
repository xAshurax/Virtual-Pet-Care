using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Stat : MonoBehaviour
{
    private Image content; 
    private float currentFill; //different from value since it works from 0 to 1
    private float currenValue; //How much numerical points I have right now
    private float MaxValue = 100; 
    public float CurrenValue 
    {
        get
        {
            return currenValue; 
        }
        set
        {
            if(value > MaxValue) 
            {
                currenValue = MaxValue;
            }
            else if(value<0) 
            {
                currenValue = 0;
            }
            else 
            {
                currenValue = value;
            }

            currentFill = currenValue / MaxValue; 


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>(); 
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        content.fillAmount = currentFill; 
    }

    public void Initialize(float _currentValue) 
    {
        
        CurrenValue = _currentValue;
    } 

  
}
