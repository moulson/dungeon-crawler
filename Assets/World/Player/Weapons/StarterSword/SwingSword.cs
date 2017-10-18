using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingSword : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			this.GetComponent<Animation> ().Play ("SwingSword");
		}
	}
	public Vector3 rayCastLoc;
	public void SwordHit(string s){
		RaycastHit rch;
		Vector3 fwd = transform.TransformDirection (rayCastLoc);
		if (Physics.Raycast (transform.position, fwd, 10)) {
			Debug.Log ("Hit a thing!");
		}
	}
}
