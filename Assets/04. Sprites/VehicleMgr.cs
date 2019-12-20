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
                obj.minSpeed = Mathf.Clamp(topObj.minSpeed + Random.Range(-1f, 1f), 0.1f, Mathf.Infinity);
                obj.maxSpeed = Mathf.Clamp(topObj.maxSpeed + Random.Range(-1f, 1f), topObj.minSpeed, Mathf.Infinity);
                obj.minRotPower = Mathf.Clamp(topObj.minRotPower + Random.Range(-1f, 1f), 0.1f, Mathf.Infinity);
                obj.maxRotPower = Mathf.Clamp(topObj.maxRotPower + Random.Range(-1f, 1f), topObj.minRotPower, Mathf.Infinity);
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
