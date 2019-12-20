using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mVehicleManager : MonoBehaviour
{
    public int generation = 0;
    public Text genText;

    public static mVehicleManager S;

    public List<mVehicle> mVehicles = new List<mVehicle>();
    public List<mVehicle> aliveVehicles = new List<mVehicle>();

    public mVehicle vehiclePrefab;
    public int numberOfVehicles;

    private void Awake() {
        S = this;
    }

    void Start() {
        CreateVehicles();
        Init();
    }

    void CreateVehicles() {
        GameObject parent = new GameObject("Vehicle Parent");
        for(int i = 0; i < numberOfVehicles; i++) {
            mVehicle mv = Instantiate(vehiclePrefab, transform.position, Quaternion.identity, parent.transform);
            mVehicles.Add(mv);
        }
        GradeMgr.S.FindGrades();
    }

    public void VehicleDead(mVehicle vehicle) {
        aliveVehicles.Remove(vehicle);

        if(aliveVehicles.Count == 0) {
            Init();
        }
    }

    public void KillAllVehicels() {
        aliveVehicles.Clear();
        Init();
    }

    void Init() {
        genText.text = (++generation).ToString();

        aliveVehicles = new List<mVehicle>(mVehicles);
        mVehicle top = GradeMgr.S.topObj ? GradeMgr.S.topObj.GetComponent<mVehicle>() : null;

        foreach (var i in mVehicles) {
            i.transform.position = transform.position;
            i.transform.rotation = Quaternion.identity;
            i.isAlive = true;

            if (top)
                i.geneticStats = new GeneticStats(top);
            else
                i.geneticStats = new GeneticStats();
        }
        GradeMgr.S.Reset();
    }
}
