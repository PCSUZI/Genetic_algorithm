using UnityEngine;

public class GeneticStats {
    public float minSpeed = Random.Range(1, 10);
    public float maxSpeed = Random.Range(1, 10);
    public float speedDistMax = Random.Range(1, 10);

    public float minRotPower = Random.Range(1, 100);
    public float maxRotPower = Random.Range(1, 100);
    public float rotDistMax = Random.Range(1, 10);

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

        minSpeed = Mathf.Clamp(stats.minSpeed + Random.Range(-1f, 1f), 0.1f, Mathf.Infinity);
        maxSpeed = Mathf.Clamp(stats.maxSpeed + Random.Range(-1f, 1f), minSpeed, Mathf.Infinity);
        speedDistMax = Mathf.Clamp(stats.speedDistMax + Random.Range(-1f, 1f), 0.1f, Mathf.Infinity);

        minRotPower = Mathf.Clamp(stats.minRotPower + Random.Range(-1f, 1f), 0.1f, Mathf.Infinity);
        maxRotPower = Mathf.Clamp(stats.maxRotPower + Random.Range(-1f, 1f), minRotPower, Mathf.Infinity);
        rotDistMax = Mathf.Clamp(stats.rotDistMax + Random.Range(-1f, 1f), 0.1f, Mathf.Infinity);
    }
}
