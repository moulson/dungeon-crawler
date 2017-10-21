using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop{
	public int LootClass;
	public GameObject Entity;
}
public class DropList : MonoBehaviour {

	public static List<Drop> ListOfDrops = new List<Drop>();
	
	public GameObject ammoBoxEntity;

	void Start(){
		Drop AmmoBox = new Drop{
			LootClass = 1,
			Entity = ammoBoxEntity
		};
		ListOfDrops.Add(AmmoBox);
	}
}
