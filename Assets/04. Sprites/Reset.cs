using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    Transform tr;

    Vector3 startPos;
    Vector3 startRot;

   
    // Start is called before the first frame update
    void Awake()
    {
        tr = gameObject.GetComponent<Transform>();
        startPos = tr.position;
        startRot = tr.rotation.eulerAngles;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            gameObject.SetActive(false);
            GradeMgr.S.dieCheck += 1;
        }
    }

    private void OnEnable()
    {
        Init();
    }

    void Init()
    {
        tr.position = startPos;
        tr.rotation = Quaternion.Euler(startRot);
    }
}
