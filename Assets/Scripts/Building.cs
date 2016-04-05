using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
    public BuildingType buildingType;

	void Start ()
    {
        Buildings.AddBuilding(new BuildingData(transform.position,transform.rotation,10,4,1f),buildingType);
	}
	
}
