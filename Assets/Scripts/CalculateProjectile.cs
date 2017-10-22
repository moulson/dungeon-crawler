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
	private System.Random randint = new System.Random();

	void Update () {
		
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
	 if(!shootingPointFound){
			FindShootingPoint();
		}
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
			//theBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-bulletVelocity, CalculateSpread(), CalculateSpread()));
			theBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-bulletVelocity, 0, 0));
			//Once the bullet has fired, update the ammo count
			ammoUI.SendMessage("UpdateAmmoCount", -1);
			AudioSource.PlayClipAtPoint(bulletSound, this.transform.position);
			ApplyRecoil();
			//
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
		shootingPoint = theWeapon.transform.GetChild(5).Find("bullet_start");
	}

	void FindWeapon(){
		theWeapon = transform.Find("WeaponCreateLocation");
	}

	void ApplyRecoil(){
		float stabilityValue = ARStats.spreadModifier;
		//Find the camera
		GameObject theGun = GameObject.Find("ar_slot");

		int theRandom = randint.Next(0,1000);

		//Always up
		theGun.transform.Rotate(Vector3.left * ((stabilityValue) * Time.deltaTime));
		//Left or right
		if(theRandom < 500)
			theGun.transform.Rotate(Vector3.up * ((stabilityValue) * Time.deltaTime));
		else
			theGun.transform.Rotate(Vector3.down * ((stabilityValue) * Time.deltaTime));
		
	}
}
