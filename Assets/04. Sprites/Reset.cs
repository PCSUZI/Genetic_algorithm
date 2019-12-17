using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    Transform tr;

    Vector3 m_startPos;
    Vector3 m_startRot;
   
    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();
        m_startPos = tr.position;
        m_startRot = tr.rotation.eulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        tr.position = m_startPos;
        tr.rotation = Quaternion.Euler(m_startRot);
    }
}
