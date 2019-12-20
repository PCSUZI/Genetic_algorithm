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

    public float m_forwardDistance = 10.0f;
    public Vector3 m_rotTemp=new Vector3(0,0,0);

    private void Start()
    {
        tr = gameObject.GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        Ray();


        if(m_forwardDistance<1.0f)
        {
          //  tr.rotation = Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0);

          //  m_rotTemp.y = Random.Range(0.0f, 360.0f);

         //   tr.Rotate(m_rotTemp);
        }
        else
        {
             tr.position += tr.forward * Time.deltaTime * m_speed;
        }

    }

    void Ray()
    {
        Debug.DrawRay(tr.position, tr.forward * m_maxDistance, Color.blue);
        Debug.DrawRay(tr.position, (tr.forward+tr.right) * m_maxDistance, Color.red);
        Debug.DrawRay(tr.position, (tr.forward+-tr.right) * m_maxDistance, Color.green);

        if (Physics.Raycast(tr.position, tr.forward, out hit))
        {
            m_forwardDistance = Vector3.Distance(hit.point, tr.position);
        }

        if (Physics.Raycast(tr.position, (tr.forward + tr.right), out hit, m_maxDistance))
        {
            Debug.Log("오 : " + Vector3.Distance(hit.point, tr.position));
        }

        if (Physics.Raycast(tr.position, (tr.forward + -tr.right), out hit, m_maxDistance))
        {
            Debug.Log("왼 : " + Vector3.Distance(hit.point, tr.position));
        }
    }

}
