using UnityEngine;

public class GeneticStats {
    public float minSpeed;
    public float maxSpeed;
    public float speedDistMax ;

    public float minRotPower;
    public float maxRotPower;
    public float rotDistMax;

    public GeneticStats() {
        minSpeed = Random.Range(1, 10);
        maxSpeed = Random.Range(1, 10);
        speedDistMax = Random.Range(1, 10);

        minRotPower = Random.Range(1, 100);
        maxRotPower = Random.Range(1, 100);
        rotDistMax = Random.Range(1, 10);
    }

    public GeneticStats(mVehicle vehicle) {
        GeneticStats stats = vehicle.geneticStats;
    }
}
