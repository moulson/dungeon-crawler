using UnityEngine;
using System.Collections;

public class BuildTheWall : MonoBehaviour {
	public GameObject trigger = new GameObject ();
	void OnTriggerEnter(Collider trigger){
		Debug.Log ("hi");
	}
}
