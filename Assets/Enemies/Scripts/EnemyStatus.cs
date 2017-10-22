using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {
	public int HitPoints;
	public int LootValue;

	private GameObject loot;

	void ApplyDamage(float theDamage){
		HitPoints -= (int)(theDamage * 10);
		if(HitPoints < 0)
			HitPoints = 0;
		if(HitPoints == 0){
			CalculateAndDropLoot();
			KillSelf();
		}
	}

	void CalculateAndDropLoot(){
		loot = Instantiate(DropList.ListOfDrops[0].Entity, transform.position, transform.rotation);
		loot.transform.parent = null;
		loot.transform.position = new Vector3(0, 1.5f, 0);
	}

	void KillSelf(){
		Destroy(gameObject);
	}
}
