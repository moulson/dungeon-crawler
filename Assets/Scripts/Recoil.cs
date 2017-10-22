using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour {

	private Transform from;
    private Transform to;
    private float speed = 2.5f;

	void Update () {
		to = GameObject.Find("FirstPersonCharacter").transform;
		//make sure the object affected by recoil keeps trying to recover
        transform.rotation = Quaternion.Lerp(transform.rotation, to.rotation, Time.deltaTime * speed);
	}
}
