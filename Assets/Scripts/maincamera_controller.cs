using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincamera_controller : MonoBehaviour
{
    Transform myTransform;
    Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);

    // Update is called once per frame
    void Update()
    {
        myTransform = this.transform;
        // 左に回転
        if (Input.GetKey (KeyCode.LeftArrow)) {
            myTransform.RotateAround(target, Vector3.up, 1.0f);
        }
        // 右に回転
        if (Input.GetKey (KeyCode.RightArrow)) {
            myTransform.RotateAround(target, Vector3.up, -1.0f);
        }
    }
}
