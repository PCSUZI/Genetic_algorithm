using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grade : MonoBehaviour
{
    public int checkPoint = 0;
    public float dist1;
    public float dist2;

    private void Update() {
        DistCal();
    }

    void DistCal( ) {
        Vector2 pos = Vector3ToVector2(transform.position);
        Vector2 nowCheck = Vector3ToVector2(GradeMgr.S.positions[checkPoint]);
        Vector2 nextCheck = Vector3ToVector2(GradeMgr.S.positions[checkPoint + 1]);

        dist1 = Vector2.Distance(pos, nowCheck);
        dist2 = Vector2.Distance(pos, nextCheck);
        
        if(dist2 < dist1) {
            CheckPointUp();
        }
    }

    void CheckPointUp() {
        checkPoint++;
        GradeMgr.S.GradeChanged(checkPoint, this);
    }

    Vector2 Vector3ToVector2(Vector3 vec3) {
        return new Vector2(vec3.x, vec3.z);
    }
}
