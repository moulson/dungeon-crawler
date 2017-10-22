using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public class PlaceRooms : MonoBehaviour {
	public List<GameObject> floorRooms = new List<GameObject>();
    public List<GameObject> sourceRooms = new List<GameObject>();
	public int roomSize = 25;
    // Use this for initialization
    void Start() {
        List<Vector3> InUseCoords = new List<Vector3>();
        bool canPosX = true, canPosZ = true, canNegZ = true, canNegX = true;
        bool isDupe;
        Vector3 coords = new Vector3(0,0,0), posX, posZ, negX, negZ;
        GameObject currentRoom;
        //Generate an instance of Random which we will use to select room coordinates
        System.Random rnd = new System.Random();
        //Create a list of all the possible coordinates, so far this is each side of the spawn room
        List<Vector3> possibleLocations = new List<Vector3>();
        possibleLocations.Add(coords);//Initial
        foreach(var room in floorRooms)
        {
            foreach(var c in InUseCoords)
            {
                possibleLocations.RemoveAll(i => i == c);
            }
           
            foreach (var dupeCheckRoom in floorRooms)
            {
                if (coords != new Vector3(0, 0, 0))
                {
                    possibleLocations.RemoveAll(i => i == dupeCheckRoom.transform.position);
                }
            }
            isDupe = true;
            canPosX = true; canPosZ = true; canNegZ = true; canNegX = true;
            
            while (isDupe)
            {
                isDupe = false;
                coords = possibleLocations[rnd.Next(0, possibleLocations.ToArray().Length)];
                foreach (var dupeCheckRoom in floorRooms)
                {
                    if (dupeCheckRoom.transform.position == coords && coords != new Vector3(0,0,0)) isDupe = true;
                }
                if (isDupe)
                {
                    possibleLocations.Remove(coords);
                }
            }
            if(coords == new Vector3(0, 0, 0))
            {
                currentRoom = (GameObject)Instantiate(room);
            }
            else
            {
                currentRoom = (GameObject)Instantiate(sourceRooms[rnd.Next(0, sourceRooms.ToArray().Length)]);
            }
            
            //check if there is already a room in 'coords'
            currentRoom.transform.position = coords;
            InUseCoords.Add(coords);
            possibleLocations.RemoveAll(z => z == currentRoom.transform.position);
            //Consider putting the positiveX in
			posX = new Vector3(currentRoom.transform.position.x + roomSize, 0, currentRoom.transform.position.z);
			posZ = new Vector3(currentRoom.transform.position.x, 0, currentRoom.transform.position.z + roomSize);
			negX = new Vector3(currentRoom.transform.position.x - roomSize, 0, currentRoom.transform.position.z);
			negZ = new Vector3(currentRoom.transform.position.x, 0, currentRoom.transform.position.z - roomSize);
            //Check to see if any room currently is in this position
            foreach (var checkRoom in floorRooms)
            {
                if (checkRoom.transform.position == posX) canPosX = false;
                if (checkRoom.transform.position == posZ) canPosZ = false;
                if (checkRoom.transform.position == negX) canNegX = false;
                if (checkRoom.transform.position == negZ) canNegZ = false;
            }
            if (canPosX) possibleLocations.Add(posX);
            if (canPosZ) possibleLocations.Add(posZ);
            if (canNegX) possibleLocations.Add(negX);
            if (canNegZ) possibleLocations.Add(negZ);
            possibleLocations.RemoveAll(z => z == currentRoom.transform.position);
            possibleLocations = possibleLocations.Distinct().ToList();

        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
