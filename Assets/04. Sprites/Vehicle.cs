using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    #region Genetic
    public float minSpeed = 1;
    public float maxSpeed = 3;
    public float speedDisMax = 10;

    public float minRotPower = 0;
    public float maxRotPower = 100;
    public float rotDistMax = 10;
    #endregion

    #region Status
    public float speed = 1;
    public float rotPower = 1;

    public float minSpeedNow = 3;
    public float maxSpeedNow = 1;
    public float minRotPowerNow = 100;
    public float maxRotPowerNow = 0;
    #endregion

    #region Ray
    Ray forwardRay;
    Ray rightRay;
    Ray leftRay;

    float forwardDist;
    float rightDist;
    float leftDist;
    #endregion

    private void OnEnable()
    {
        minSpeedNow = maxSpeed;
        maxSpeedNow = minSpeed;
        minRotPowerNow = maxRotPower;
        maxRotPowerNow = minRotPower;

    }

    private void Start()
    {
        maxSpeed = Random.Range(1, 100);
        maxRotPower = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        RayUpdate();
        Accel();
        Rotate();
    }

    void Accel()
    {
        speed = Mathf.Lerp(minSpeed, maxSpeed, forwardDist / speedDisMax);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (speed < minSpeedNow)
            minSpeedNow = speed;

        if (speed > maxSpeedNow)
            maxSpeedNow = speed;
    }

    void Rotate()
    {
        int dir = rightDist > leftDist ? 1 : -1;
        float dist = rightDist > leftDist ? leftDist : rightDist;

        rotPower = Mathf.Lerp(maxRotPower, minRotPower, dist*3 / rotDistMax);
        transform.Rotate(Vector3.up * Time.deltaTime * dir * rotPower);


        if (rotPower < minRotPowerNow)
            minRotPowerNow = rotPower;

        if (rotPower > maxRotPowerNow)
            maxRotPowerNow = rotPower;
    }

    void RayUpdate()
    {
        forwardRay.origin = transform.position;
        forwardRay.direction = transform.forward;

        rightRay.origin = transform.position;
        rightRay.direction = transform.forward + transform.right;

        leftRay.origin = transform.position;
        leftRay.direction = transform.forward - transform.right;

        DrawRay(forwardRay);
        DrawRay(rightRay);
        DrawRay(leftRay);

        GetRayDist(forwardRay, out forwardDist);
        GetRayDist(rightRay, out rightDist);
        GetRayDist(leftRay, out leftDist);
    }

    void DrawRay(Ray ray)
    {
        Debug.DrawRay(ray.origin, ray.direction, Color.white);
    }



    void GetRayDist(Ray ray, out float _dist)
    {
        RaycastHit hit;

        _dist = Mathf.Infinity;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            _dist = Vector3.Distance(transform.position, hit.point);
        }

    }



}
