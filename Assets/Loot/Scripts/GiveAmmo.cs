using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAmmo : MonoBehaviour {
	public int AmmoValue;
	public GameObject ammoUI;
	void Start(){
		ammoUI = GameObject.Find("AmmoCount");
	}
	void OnTriggerEnter(Collider hit){
		if(hit.gameObject.tag == "Player Pickup Trigger"){
			ammoUI.SendMessage("UpdateAmmoCount", AmmoValue);
			Destroy(gameObject);
		}
	}
}
