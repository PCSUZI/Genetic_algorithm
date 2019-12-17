using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    RaycastHit hit;
    public float MaxDistance = 2f;

    Transform tr;

    Vector3 m_Rvector = new Vector3(1, 0, 1);
    Vector3 m_Lvector = new Vector3(-1, 0, 1);

    public float m_speed = 1.0f;

    private void Start()
    {
        tr = gameObject.GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(tr.position, tr.forward * MaxDistance, Color.blue, 0.3f);
        Debug.DrawRay(tr.position, m_Rvector * MaxDistance, Color.red, 0.3f);
        Debug.DrawRay(tr.position, m_Lvector * MaxDistance, Color.green, 0.3f);

        if (Physics.Raycast(tr.position, tr.forward, out hit, MaxDistance))
        {
            
        }

        tr.position += Vector3.forward*Time.deltaTime* m_speed;
        
    }
}
