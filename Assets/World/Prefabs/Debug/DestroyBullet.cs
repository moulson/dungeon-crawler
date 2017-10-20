using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour {
	public GameObject hitEffect;
	void Start(){
		Physics.IgnoreLayerCollision(8,8,true);
	}
	// Use this for initialization
	void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
		Instantiate(hitEffect, pos, rot);
        Destroy(gameObject);
    }
}
