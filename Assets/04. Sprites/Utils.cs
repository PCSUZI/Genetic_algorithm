using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Utils S;

    private void Awake() {
        S = this;
    }
    public Vector2 Vector3ToVector2(Vector3 vec3) {
        return new Vector2(vec3.x, vec3.z);
    }
}
