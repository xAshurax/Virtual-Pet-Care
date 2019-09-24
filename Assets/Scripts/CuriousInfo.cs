using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuriousInfo : MonoBehaviour
{
    private static CuriousInfo instance;
    [SerializeField] private string[] genericWaterData, saveMethods, missusedWater;

    public static CuriousInfo Instance { get => instance; private set => instance = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }


}
