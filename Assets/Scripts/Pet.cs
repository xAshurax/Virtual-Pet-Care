using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{

    private Stat health;
    private Stat thirst;
    private Stat happiness;
    private static Pet instance;
    private int clickCount;
    private Animator anim;

    public static Pet Instance { get => instance; set => instance = value; }
    public Stat Health { get => health; set => health = value; }
    public Stat Thirst { get => thirst; set => thirst = value; }
    public Stat Happiness { get => happiness; set => happiness = value; }

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

    void Start()
    {
        //Time test
        // PlayerPrefs.SetString("then", "08/02/2019 11:20:11");

        
        health = GameObject.Find("HealthBar").GetComponent<Stat>();
        thirst = GameObject.Find("ThirstBar").GetComponent<Stat>();
        happiness = GameObject.Find("HappinessBar").GetComponent<Stat>();
        anim = GetComponent<Animator>();
        TimeManager.Instance.Initialize();



    }

   
    void Update()
    {
        anim.SetBool("Jump", gameObject.transform.position.y > -2.7f);
        //PC Testing
        if(Input.GetMouseButtonUp(0))
        {
            Touch();
        }
        //For Debugging only
        if (Input.GetKeyDown(KeyCode.I))
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

        } //Debugging end
    }

    //Increase happiness and make it jump
    private void Touch()
    {
        Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
        if (hit)
        {
            Debug.Log(hit.transform.gameObject.name);
            if(hit.transform.gameObject.tag == "Pet")
            {
                clickCount++;
                if(clickCount>=3)
                {
                    clickCount = 0;
                    UpdateStat(happiness, 5);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100000));
                }
            }
        }
    }

    public void UpdateStat(Stat _stat,int _amount)
    {
        _stat.CurrenValue += _amount;
        PlayerPrefs.SetFloat(_stat.MyName, _stat.CurrenValue);
    }
    

}