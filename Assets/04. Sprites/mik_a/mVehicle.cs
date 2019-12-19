using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mVehicle : MonoBehaviour
{
    #region Genetic
    [Header("Genetic")]
    public float minSpeed = 1;
    public float maxSpeed = 3;
    public float speedDistMax = 10;

    public float minRotPower = 0;
    public float maxRotPower = 100;
    public float rotDistMax = 10;
    #endregion

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
    public  float forwardDist;
    public float rightDist;
    public float leftDist;
    #endregion


    public bool isAlive = true;
    private void Start() {
        RandomStats();
    }

    private void FixedUpdate() {
        if (!isAlive)
            return;

        RayUpdate();
        Accel();
        Rotate();
    }

    void RandomStats() {
        minSpeed = Random.Range(1, 10);
        maxSpeed = Random.Range(1, 10);
        speedDistMax = Random.Range(1, 10);

        minRotPower = Random.Range(1, 100);
        maxRotPower = Random.Range(1, 100);
        rotDistMax = Random.Range(1, 10);
    }

    void Accel() {
        speed = Mathf.Lerp(minSpeed, maxSpeed, forwardDist / speedDistMax);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void Rotate() {
        int dir = rightDist > leftDist ? 1 : -1;
        float dist = rightDist > leftDist ? leftDist : rightDist;

        if(dir == 1) {
            DrawRay(leftRay, Color.red);
        }
        else {
            DrawRay(rightRay, Color.red);
        }

        rotPower = Mathf.Lerp(maxRotPower, minRotPower, dist / rotDistMax);
        transform.Rotate(Vector3.up * Time.deltaTime * dir * rotPower);
    }

    void RayUpdate() {
        forwardRay.origin = transform.position;
        forwardRay.direction = transform.forward;

        rightRay.origin = transform.position;
        rightRay.direction = transform.forward + transform.right;
        leftRay.origin = transform.position;
        leftRay.direction = transform.forward + transform.right * -1 ;

        DrawRay(forwardRay,Color.white);
        DrawRay(rightRay, Color.white);
        DrawRay(leftRay, Color.white);

        GetRayDist(forwardRay, out forwardDist);
        GetRayDist(rightRay, out rightDist);
        GetRayDist(leftRay, out leftDist);
    }

    void GetRayDist(Ray ray, out float _dist) {
        RaycastHit hit;
        _dist = Mathf.Infinity;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            _dist = (transform.position - hit.point).sqrMagnitude;
        }
    }

    void DrawRay(Ray ray, Color color) {
        Debug.DrawRay(ray.origin, ray.direction, color);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "Wall") {
            isAlive = false;
            mVehicleManager.S.VehicleDead(this);
        }
    }
}
