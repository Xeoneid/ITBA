using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour {

    public bool copyX, copyY, copyZ, copyW;
    public Transform target;
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion(
            x: copyX ? target.rotation.x : transform.rotation.x,
            y: copyY ? target.rotation.y : transform.rotation.y,
            z: copyZ ? target.rotation.z : transform.rotation.z,
            w: copyW ? target.rotation.w : transform.rotation.w
            );
    }
}
