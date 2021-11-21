using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest:MonoBehaviour {
    [SerializeField] GameObject startPoint, endPoint, moveObject;
    public float lerp;
    float height = 5;

    void Update() {
        Vector3 lerpPos = Vector3.Lerp(startPoint.transform.position, endPoint.transform.position, lerp);
        lerpPos.y += Mathf.Sin(lerp * Mathf.PI) * height;


        moveObject.transform.position = lerpPos;
    }
}
