using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegGroundTest:MonoBehaviour {

    [SerializeField] GameObject distanceRay, body;
    [SerializeField] LegGroundTest moveBool1, moveBool2, moveBool3;
    Vector3 oldPos, newPos, rayCastPos, footPosition = new Vector3();

    float stepHight = 1, speed = 5, lerp;
    bool move = false;

    Ray rayToGround;
    RaycastHit hitInfo;
    Rigidbody rgbd;

    void Start() {
        rgbd = body.GetComponent<Rigidbody>();
        rayToGround = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(rayToGround, out hitInfo, 5)) {
            transform.position = oldPos = footPosition = hitInfo.point;
        }
    }

    void Update() {
        rayToGround = new Ray(distanceRay.transform.position, Vector3.down);
        Physics.Raycast(rayToGround, out hitInfo, 5);
        rayCastPos = hitInfo.point;
        newPos = (rgbd.velocity / 2.5f) + rayCastPos;

        if(Vector3.Distance(transform.position, rayCastPos) > 3.5f && !moveBool1.move && !moveBool2.move && !moveBool3.move) {
            move = true;
        }

        if(move) {
            if(lerp >= 1) {
                oldPos = hitInfo.point;
                move = false;
                lerp = 0;
            } else {
                footPosition = Vector3.Lerp(oldPos, newPos, lerp);
                footPosition.y += Mathf.Sin(lerp * Mathf.PI) * stepHight;
                transform.position = footPosition;
                lerp += Time.deltaTime * speed;
            }
        }
    }
}
