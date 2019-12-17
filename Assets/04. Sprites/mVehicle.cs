using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mVehicle : MonoBehaviour
{

    Ray forwardRay;
    Ray rightRay;
    Ray leftRay;

    RaycastHit hit;
    public float MaxDistance = 0.4f;

    Vector3 m_Rvector = new Vector3(1, 0, 1);
    Vector3 m_Lvector = new Vector3(-1, 0, 1);

    float speed = 1;

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate() {
        RayUpdate();
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void RayUpdate() {
        forwardRay.origin = transform.position;
        forwardRay.direction = transform.forward;

        rightRay.origin = transform.position;
        rightRay.direction = m_Rvector;

        leftRay.origin = transform.position;
        leftRay.direction = m_Lvector;

        DrawRay(forwardRay);
        DrawRay(rightRay);
        DrawRay(leftRay);
    }

    void DrawRay(Ray ray) {
        Debug.DrawRay(ray.origin, ray.direction, Color.white);
    }
}
