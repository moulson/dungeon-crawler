using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour {

	private Transform from;
    private Transform to;
    private float speed = 4f;
	public string objectToFind;
	void Update () {
		to = GameObject.Find(objectToFind).transform;
		//make sure the object affected by recoil keeps trying to recover
        transform.rotation = Quaternion.Lerp(transform.rotation, to.rotation, Time.deltaTime * speed);
	}
}
