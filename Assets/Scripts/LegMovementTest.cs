using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovementTest:MonoBehaviour {
    [SerializeField] GameObject targetPos, rayPos, body;
    Vector3 oldPos, newPos, constRayPos = new Vector3();

    Ray rayToGround;
    RaycastHit hitPos;

    void Start() {
        rayToGround = new Ray(rayPos.transform.position, Vector3.down);

        Physics.Raycast(rayToGround, out hitPos, 10);

        targetPos.transform.position = hitPos.point;

        Debug.Log(hitPos.point);
    }

    void Update() {

    }
}
