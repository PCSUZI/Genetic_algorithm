
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mVehicle : MonoBehaviour
{
    public GeneticStats geneticStats;

    int layer;

    #region Status
    [Header("Status")]
    float speed = 1;
    float rotPower = 1;
    #endregion

    #region Ray
    Ray forwardRay;
    Ray rightRay;
    Ray leftRay;

    [Header("Ray")]
    public float forwardDist;
    public float rightDist;
    public float leftDist;
    #endregion

    public bool isAlive = true;

    private void Start() {
        geneticStats = new GeneticStats();
        layer = 1 << LayerMask.NameToLayer("Wall");
    }

    private void FixedUpdate() {
        if (!isAlive)
            return;

        RayUpdate();
        Accel();
        Rotate();
    }

    void Accel() {
        speed = Mathf.Lerp(geneticStats.minSpeed, geneticStats.maxSpeed, forwardDist / geneticStats.speedDistMax);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Rotate() {
        int dir = rightDist > leftDist ? 1 : -1;
        float dist = rightDist > leftDist ? leftDist : rightDist;

        if (dir == 1) {
            DrawRay(leftRay, Color.red);
        }
        else {
            DrawRay(rightRay, Color.red);
        }

        rotPower = Mathf.Lerp(geneticStats.maxRotPower, geneticStats.minRotPower, dist / geneticStats.rotDistMax);
        transform.Rotate(Vector3.up * Time.deltaTime * dir * rotPower);
    }

    void RayUpdate() {
        forwardRay.origin = transform.position;
        forwardRay.direction = transform.forward;

        rightRay.origin = transform.position;
        rightRay.direction = transform.forward + transform.right;
        leftRay.origin = transform.position;
        leftRay.direction = transform.forward + transform.right * -1;

        DrawRay(forwardRay, Color.white);
        DrawRay(rightRay, Color.white);
        DrawRay(leftRay, Color.white);

        GetRayDist(forwardRay, out forwardDist);
        GetRayDist(rightRay, out rightDist);
        GetRayDist(leftRay, out leftDist);
    }

    void GetRayDist(Ray ray, out float _dist) {
        RaycastHit hit;
        _dist = Mathf.Infinity;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer)) {
            _dist = (transform.position - hit.point).sqrMagnitude;
        }
    }

    void DrawRay(Ray ray, Color color) {
        Debug.DrawRay(ray.origin, ray.direction, color);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Wall") {
            isAlive = false;
            mVehicleManager.S.VehicleDead(this);
        }
    }
}