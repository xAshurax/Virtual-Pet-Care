using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Stat : MonoBehaviour
{
    [SerializeField] private string myName;
    private Image content; 
    private float currentFill; //different from value since it works from 0 to 1
    private float currenValue; 
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

    public string MyName { get => myName; private set => myName = value; }



    
    void Start()
    {
        content = GetComponent<Image>(); 
       
        
        
    }

    
    void Update()
    {
        content.fillAmount = currentFill; 
    }

    public void Initialize(float _currentValue) 
    {
        
        CurrenValue = _currentValue;
    } 

  
}
