using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement:MonoBehaviour {
    [SerializeField] GameObject Back_Left_Leg, Back_Right_Leg, Front_Left_Leg, Front_Right_Leg;
    Rigidbody rgbd;
    Vector3 pos, centerHeight = new Vector3();

    float speed = 6, rotate;

    void Start() {
        rgbd = GetComponent<Rigidbody>();
    }

    void Update() {
        Centroid();
        Vector3 V1 = Back_Left_Leg.transform.position - Front_Left_Leg.transform.position;
        Vector3 V2 = Back_Right_Leg.transform.position - Front_Right_Leg.transform.position;
        Vector3 cross = Vector3.Cross(V1, V2).normalized;

        pos.x = Input.GetAxis("Vertical") * speed;
        rotate = Input.GetAxis("Horizontal") / 2;

        rgbd.transform.Rotate(new Vector3(0, rotate, 0));
        rgbd.velocity = (transform.right * pos.x) + (transform.forward * -pos.z);
        rgbd.transform.position = new Vector3(transform.position.x, centerHeight.y, transform.position.z);
    }

    void Centroid() {
        centerHeight = (Back_Left_Leg.transform.position + Back_Right_Leg.transform.position + Front_Left_Leg.transform.position + Front_Right_Leg.transform.position) / 4;
    }
}
