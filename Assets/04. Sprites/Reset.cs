using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    Transform tr;

    Vector3 m_startPos;
   
    // Start is called before the first frame update
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();
        m_startPos = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        tr.position = m_startPos;
    }
}
