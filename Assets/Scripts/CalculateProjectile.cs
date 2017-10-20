using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateProjectile : MonoBehaviour {
	public int bulletVelocity;
	public AudioClip bulletSound;
	public bool isAutomatic;
	//TODO: change this to private and automatically use current weapon's ammo type
	public GameObject theProjectile;
	private bool autoFiring = false;
	private bool shootingPointFound;
	private Transform theWeapon;
	private Transform shootingPoint;

	void Update () {
		if(!shootingPointFound){
			FindShootingPoint();
		}
		if(Input.GetMouseButtonDown(0)){
			if(isAutomatic)
				StartCoroutine(AutoFire(0.5f));
			else{
				FireSingle();
			}
		}
		if(Input.GetMouseButtonUp(0) && isAutomatic){
			autoFiring = false;
		}
	}

	IEnumerator AutoFire(float time)
 {
	 do{
	 	FireSingle();
     	yield return new WaitForSeconds(time);
	 }while(autoFiring);
	 
 }
	void FireSingle(){
		GameObject theBullet;
		switch(PickupWeapon.AmmoType){
			case "ToxicAmmo":
				Debug.Log("Toxic Shot!");
			break;
			case "IncindiaryAmmo":
				Debug.Log("Incindiary Shot");
			break;
			case "ShockAmmo":
				Debug.Log("Shock Shot!");
			break;
		}
		theBullet = Instantiate(theProjectile, shootingPoint);
		theBullet.transform.position = shootingPoint.position;
		theBullet.transform.parent = null;
		theBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-bulletVelocity, 0, 0));
		//Play firing noise
		AudioSource.PlayClipAtPoint(bulletSound, this.transform.position);
	}

	void FindShootingPoint(){
		FindWeapon();
		shootingPoint = theWeapon;
	}

	void FindWeapon(){
		theWeapon = this.transform.Find("WeaponCreateLocation");
	}
}
