using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour {
	public GameObject hitEffect;
	void Start(){
		Physics.IgnoreLayerCollision(8,8,true);
		Physics.IgnoreLayerCollision(8,9,true);
	}
	// Use this for initialization
	void OnCollisionEnter(Collision collision)
    {
		GameObject thisShot;
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
		thisShot = Instantiate(hitEffect, pos, rot);
        Destroy(gameObject);
		Destroy(thisShot, 2.0f);
		if(collision.collider.transform.tag == "Enemy"){
			collision.collider.gameObject.SendMessage("ApplyDamage", ARStats.damageModifier);
		}
    }
}
