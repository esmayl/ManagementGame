using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
    public BuildingType buildingType;
    internal BuildingData buildingData;

	void Start ()
	{
	    buildingData = new BuildingData(transform.position, transform.rotation, 10, 4, 3f);
        Buildings.AddBuilding(buildingData,buildingType);
	    StartCoroutine("AddLevel", buildingData);
	}

    void Update()
    {

        if (buildingData.level > 1)
        {
            Debug.Log("level2");
            if (!transform.GetChild(0).gameObject.activeInHierarchy)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        if (buildingData.level > 2)
        {
            Debug.Log("level3");

            if (!transform.GetChild(1).gameObject.activeInHierarchy)
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }

    }


    public IEnumerator AddLevel(BuildingData buildingToLevel)
    {
        Debug.Log("Leveling to " + (buildingToLevel.level + 1));

        yield return new WaitForSeconds(buildingToLevel.tickCount * buildingToLevel.level);

        if (buildingToLevel.LevelUp())
        {
            Debug.Log("Level up complete");
            yield break;
        }

        yield break;

    }
}
