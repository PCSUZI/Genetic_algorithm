using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMgr : MonoBehaviour
{
    public static VehicleMgr S;

    public Vehicle[] objs;
    public Vehicle topObj;


    public int dieCheck = 0;

    private void Awake()
    {
        S = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        objs = FindObjectsOfType<Vehicle>();
    }

    // Update is called once per frame
    void Update()
    {
        Genetic();
    }

    void Genetic()
    {
        int count = objs.Length;

        if (dieCheck == count)
        {
            topObj = GradeMgr.S.topObj.GetComponent<Vehicle>();

            for (int i = 0; i < count; i++)
            {
                Vehicle obj = objs[i].GetComponent<Vehicle>();
                obj.minSpeed = Random.Range(topObj.minSpeedNow,3);
                obj.maxSpeed = Random.Range(1, topObj.maxSpeedNow);
                obj.minRotPower =Random.Range(topObj.minRotPowerNow,100);
                obj.maxRotPower = Random.Range(0,topObj.maxRotPowerNow);
            }

            for (int i = 0; i < count; i++)
            {
                objs[i].gameObject.SetActive(true);
            }

            dieCheck = 0;
            GradeMgr.S.Reset(); 
        }

    }
}
