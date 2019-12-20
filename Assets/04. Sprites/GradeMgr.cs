using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GradeMgr : MonoBehaviour
{
    public static GradeMgr S;
    public GameObject mvpMarker;

    public bool isLoop = false;
    LineRenderer line;

    public Vector3[] positions;
    public Grade[] objs;
    public Grade topObj;

    public int maxCheck = 0;
    List<Grade> maxGrades = new List<Grade>();


    private void Awake() {
        S = this;

        if (!mvpMarker) {
            Debug.LogError("GradeMgr hasn't 'MVP marker'. Set 'MVP marker' in inspector.");
        }
    }

    private void Start() {
        line = GetComponent<LineRenderer>();
        Init();


         if (Application.isPlaying) {
            line.enabled = false;
        }
         else {
            line.enabled = true;
        }

    }

    public void FindGrades() {
        objs = FindObjectsOfType<Grade>();
    }


    private void Update() {
        DrawLine();
        GradeCalc();
        MVPMarker();
    }

    public void Reset()
    {
        maxCheck = 0;
        foreach (var i in objs)
        {
            i.checkPoint = 0;
        }
    }

    private void Init() {
        maxGrades = new List<Grade>(objs);
    }
      

    void MVPMarker() {
        if(topObj)
            mvpMarker.transform.position = topObj.transform.position;
    }

    public void GradeCalc() {
        float min = 10000;
        Grade obj = null;

        foreach (var i in maxGrades) {
            if (i.dist2 < min) {
                min = i.dist2;
                obj = i;
            }
        }

        topObj = obj;
    }

    public void GradeChanged(int check, Grade obj) {
        if (maxCheck > check)
            return;

        if (maxCheck == check) {
            maxGrades.Add(obj);
            return;
        }

        maxCheck = check;
        maxGrades.Clear();
        maxGrades.Add(obj);
    }

    void DrawLine() {
        int childCnt = transform.childCount;

        if (childCnt < 3)
            return;

        positions = new Vector3[childCnt];

        for (int i = 0; i < childCnt; i++) {
            positions[i] = transform.GetChild(i).transform.position;
        }

        line.positionCount = childCnt;
        line.SetPositions(positions);
    }

}
