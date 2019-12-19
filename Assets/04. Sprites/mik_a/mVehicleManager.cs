using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mVehicleManager : MonoBehaviour
{
    public static mVehicleManager S;

    public List<mVehicle> mVehicles = new List<mVehicle>();
    public List<mVehicle> aliveVehicles = new List<mVehicle>();

    public mVehicle vehiclePrefab;
    public int numberOfVehicles;

    private void Awake() {
        S = this;
    }

    void Start()
    {
        CreateVehicles();
        Init();
    }

    void CreateVehicles() {
        GameObject parent = new GameObject("Vehicle Parent");
        for(int i = 0; i < numberOfVehicles; i++) {
            mVehicle mv = Instantiate(vehiclePrefab, transform.position, Quaternion.identity, parent.transform);
            mVehicles.Add(mv);
        }
    }


    public void VehicleDead(mVehicle vehicle) {
        aliveVehicles.Remove(vehicle);

        if(aliveVehicles.Count == 0) {
            Init();
        }
    }

    void Init() {
        aliveVehicles = new List<mVehicle>(mVehicles);
        GradeMgr.S.Reset();
        foreach (var i in mVehicles) {
            i.transform.position = transform.position;
            i.isAlive = true;
        }
    }
}
