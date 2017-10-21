using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateProjectile : MonoBehaviour {
	public GameObject toxicEffect;
	public GameObject shockEffect;
	public GameObject incindiaryEffect;
	public GameObject ammoUI;
	public int bulletVelocity;
	public AudioClip bulletSound;
	//TODO: change this to private and automatically use current weapon's ammo type
	public GameObject theProjectile;
	private bool autoFiring = false;
	private bool shootingPointFound;
	private Transform theWeapon;
	private Transform shootingPoint;
	private bool isCoroutining = false;

	void Update () {
		if(!shootingPointFound){
			FindShootingPoint();
		}
		if(Input.GetButtonDown("Fire1")){
			autoFiring = true;
			if(!isCoroutining)
				//TODO: Use calculated firerate as the delay modifier
				StartCoroutine(AutoFire(CalculateFireRate()));
		}
		if(Input.GetButtonUp("Fire1")){
			autoFiring = false;
		}
	}

	IEnumerator AutoFire(float time)
 {
	 while(autoFiring){
		 isCoroutining = true;
	 	FireSingle();
     	yield return new WaitForSeconds(time);
	 }
	 isCoroutining = false;
 }
	void FireSingle(){
		GameObject theBullet;
		GameObject theEffect;
		if(CalculateAmmo.CurrentAmmo > 0){ //Make sure we have ammo before trying to shoot
			theBullet = Instantiate(theProjectile, shootingPoint);
			
			theBullet.transform.position = shootingPoint.position;
			switch(PickupWeapon.AmmoType){
				case "ToxicAmmo":
					theEffect = Instantiate(toxicEffect, theBullet.transform);
					theEffect.transform.position = theBullet.transform.position;
				break;
				case "IncindiaryAmmo":
					theEffect = Instantiate(incindiaryEffect, theBullet.transform);
					theEffect.transform.position = theBullet.transform.position;
				break;
				case "ShockAmmo":
					theEffect = Instantiate(shockEffect, theBullet.transform);
					theEffect.transform.position = theBullet.transform.position;
				break;
			}
			theBullet.transform.parent = null;
			theBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-bulletVelocity, CalculateSpread(), CalculateSpread()));
			//Once the bullet has fired, update the ammo count
			ammoUI.SendMessage("UpdateAmmoCount", -1);
			AudioSource.PlayClipAtPoint(bulletSound, this.transform.position);

			//
		}
		else{
			ammoUI.GetComponent<UnityEngine.UI.Text>().color = new Color(255,0,0);
		}
	}
	float CalculateSpread(){
		System.Random rnd = new System.Random();
		return rnd.Next(-1000, 1000) / ARStats.spreadModifier;
	}
	float CalculateFireRate(){
		float defaultRate = 1f;
		float theFireRate = defaultRate - ARStats.fireRateModifier;
		if(theFireRate <= 0)
			theFireRate = 0.1f;	
		return theFireRate;
	}
	void FindShootingPoint(){
		FindWeapon();
		shootingPoint = theWeapon;
	}

	void FindWeapon(){
		theWeapon = this.transform.Find("WeaponCreateLocation");
	}
}
