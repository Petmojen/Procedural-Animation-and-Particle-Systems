using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posInverter:MonoBehaviour {
    [SerializeField] GameObject position2, position3;

    Vector3 position1 = new Vector3();

    void Start() {
        position1 = transform.position;
    }

    void Update() {
        position3.transform.localPosition = -position2.transform.localPosition / 2;
        Debug.DrawLine(position2.transform.position, transform.position, Color.green);
        Debug.DrawLine(position1, position3.transform.position, Color.blue);
    }
}
