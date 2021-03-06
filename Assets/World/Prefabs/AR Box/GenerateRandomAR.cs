﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomAR : MonoBehaviour {
	private bool inRange = false;
	private bool weaponSpawned = false;
	public AudioClip leverPullClip;
	public GameObject uiPrompt;
	public GameObject[] spawnLocations;
	public GameObject baseWeapon;
	public string ammoType;

	public List<GameObject> stockList;
	public List<GameObject> gripList;
	public List<GameObject> fireModeList;
	public List<GameObject> fuelCellList;
	public List<GameObject> underBarrelList;
	public List<GameObject> barrelList;
	public List<GameObject> opticList;
	public List<GameObject> ammoList;

	private bool isShowing = true;
	private bool hasSpawnedUI = false;
	private bool hasDestroyedUI = false;

	private GameObject spawnedStock;
	private GameObject spawnedGrip;
	private GameObject spawnedFireMode;
	private GameObject spawnedFuelCell;
	private GameObject spawnedUnderBarrel;
	private GameObject spawnedBarrel;
	private GameObject spawnedOptic;
	private GameObject spawnedAmmoType;

	void ActivateUI(){
		if(!hasSpawnedUI){
			//Create the ui object, but only ever once.
			uiPrompt = Instantiate(uiPrompt);
			hasSpawnedUI = true;
		}
		if(isShowing && !hasDestroyedUI){
			//set state to in range, also activate the UI
			inRange = true;
			uiPrompt.SetActive(isShowing);
		}
	}

	void OnTriggerEnter(Collider hit){
		if(hit.gameObject.tag == "Activator")
			ActivateUI();
	}
	void OnTriggerExit(){
		//when not looking/being near the object, make sure the UI isn't showing
		inRange = false;
		if(!hasDestroyedUI)
			uiPrompt.SetActive(false);
		
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.E) && inRange && !weaponSpawned){
			SpawnWeapon();
			isShowing = false;
			//Clean up this mess afterwards
			Destroy(uiPrompt);
			hasDestroyedUI = true;
		}
	}
	void SpawnWeapon(){
		//Play the sound of rolling the machine.
		AudioSource.PlayClipAtPoint(leverPullClip, this.transform.position);
		SpawnParts();
		//Combine parts (visual)

		//Create a weapon out of the parts
		CreateWeapon( spawnedStock, spawnedGrip, spawnedFireMode, spawnedFuelCell, spawnedUnderBarrel, spawnedBarrel, spawnedOptic, spawnedAmmoType);

		//Set the state to make sure machine won't be used again
		weaponSpawned = true;
	}



	int RandomNumber(int min, int max){
		System.Random randInt = new System.Random();
		try{
			return randInt.Next(min, max);
		}
		catch{
			//Failsafe in case of oob
			Debug.Log("Error genning weapon");
			return randInt.Next(min, max - 1);
		}
	}
	void SpawnParts(){
		//Create the 7 random parts
		//Spawn the Stock
		spawnedStock = Instantiate(stockList[RandomNumber(0, stockList.ToArray().Length)], spawnLocations[0].transform);
		spawnedStock.transform.position = spawnLocations[0].transform.position;

		//Spawn the Grip
		spawnedGrip = Instantiate(gripList[RandomNumber(0, gripList.ToArray().Length)], spawnLocations[1].transform);
		spawnedGrip.transform.position = spawnLocations[1].transform.position;

		//Spawn the Fire Mode
		spawnedFireMode = Instantiate(fireModeList[RandomNumber(0, fireModeList.ToArray().Length)], spawnLocations[2].transform);
		spawnedFireMode.transform.position = spawnLocations[2].transform.position;

		//Spawn the Fuel Cell
		spawnedFuelCell = Instantiate(fuelCellList[RandomNumber(0, fuelCellList.ToArray().Length)], spawnLocations[3].transform);
		spawnedFuelCell.transform.position = spawnLocations[3].transform.position;

		//Spawn the Underbarrel
		spawnedUnderBarrel = Instantiate(underBarrelList[RandomNumber(0, underBarrelList.ToArray().Length)], spawnLocations[4].transform);
		spawnedUnderBarrel.transform.position = spawnLocations[4].transform.position;

		//Spawn the Barrel
		spawnedBarrel = Instantiate(barrelList[RandomNumber(0, barrelList.ToArray().Length)], spawnLocations[5].transform);
		spawnedBarrel.transform.position = spawnLocations[5].transform.position;

		//Spawn the Optic
		spawnedOptic = Instantiate(opticList[RandomNumber(0, opticList.ToArray().Length)], spawnLocations[6].transform);
		spawnedOptic.transform.position = spawnLocations[6].transform.position;

		//Spawn the Ammo Type
		spawnedAmmoType = Instantiate(ammoList[RandomNumber(0, ammoList.ToArray().Length)], spawnLocations[7].transform);
		spawnedAmmoType.transform.position = spawnLocations[7].transform.position;
	}
	void CreateWeapon(GameObject stock, GameObject grip, GameObject fireMode, GameObject fuelCell, GameObject underBarrel, GameObject barrel, GameObject optic, GameObject ammo){
		stock = Instantiate(stock, baseWeapon.transform);
		grip = Instantiate(grip, baseWeapon.transform);
		fireMode = Instantiate(fireMode, baseWeapon.transform);
		fuelCell = Instantiate(fuelCell, baseWeapon.transform);
		underBarrel = Instantiate(underBarrel, baseWeapon.transform);
		barrel = Instantiate(barrel, baseWeapon.transform);
		optic = Instantiate(optic, baseWeapon.transform);
		string ammoType = ammo.name.Replace("(Clone)", "");
		Transform stockSlot, gripSlot, fireModeSlot, fuelCellSlot, underBarrelSlot, opticSlot;
		barrel.transform.position = new Vector3(barrel.transform.position.x - 0.05f, barrel.transform.position.y, barrel.transform.position.z + 0.7f);
		//Get locations of the barrel 'sockets'
		Transform b = barrel.transform;
		stockSlot = GetSlotTransform("stock", b);
		gripSlot = GetSlotTransform("grip", b);
		fireModeSlot = GetSlotTransform("fire_mode", b);
		fuelCellSlot = GetSlotTransform("fuel_cell", b);
		underBarrelSlot = GetSlotTransform("underbarrel", b);
		opticSlot = GetSlotTransform("optic", b);

		stock.transform.position = stockSlot.position;
		grip.transform.position = gripSlot.position;
		fireMode.transform.position =  fireModeSlot.position;
		fuelCell.transform.position = fuelCellSlot.position;
		underBarrel.transform.position = underBarrelSlot.position;
		//This is the main part of the gun, fit things around the barrel
		optic.transform.position = new Vector3(optic.transform.position.x, optic.transform.position.y + 0.07f, optic.transform.position.z);

		baseWeapon.SendMessage("SetAmmoType", ammoType);
	}

	Transform GetSlotTransform(string s, Transform b){
		return b.Find(s + "_slot").transform;
	}
}
