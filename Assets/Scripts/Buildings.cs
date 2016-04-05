using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Buildings : MonoBehaviour
{
    static Dictionary<BuildingType,BuildingData[]> completeList;

    private float counter = 0;
    private float timer = 2;
    private bool leveling = false;

    void Update()
    {
        for (int i = 0; i < completeList[BuildingType.House].Length; i++)
        {
            if (completeList[BuildingType.House][i] != null && completeList[BuildingType.House][i].Id != -1)
            {
                if (completeList[BuildingType.House][i].level < completeList[BuildingType.House][i].maxLevel)
                {
                    StartCoroutine("AddLevel", completeList[BuildingType.House][i]);
                }
            }
        }
        
        for (int i =0;i< completeList[BuildingType.Shopping].Length;i++)
        {
            if (completeList[BuildingType.Shopping][i] != null && completeList[BuildingType.Shopping][i].Id != -1)
            {
                if (completeList[BuildingType.Shopping][i].level < completeList[BuildingType.Shopping][i].maxLevel)
                {
                    StartCoroutine("AddLevel", completeList[BuildingType.Shopping][i]);
                }
            }
        }

        

    }

    public IEnumerator AddLevel(BuildingData buildingToLevel)
    {
        if (leveling) { yield break;}

        Debug.Log("Leveling to "+(buildingToLevel.level+1));
        leveling = true;

        yield return new WaitForSeconds(buildingToLevel.tickCount);

        if (buildingToLevel.LevelUp())
        {
            Debug.Log("Level up complete");
            leveling = false;
            yield break;
        }

        leveling = false;
        yield break;
        
    }

    public static void AddBuilding(BuildingData buildingInfo,BuildingType type)
    {
        if (completeList == null)
        {
            completeList = new Dictionary<BuildingType, BuildingData[]>();
        }

        if (!completeList.ContainsKey(type))
        {
            completeList.Add(type,new BuildingData[2]);
        }

        if (CheckArray(type))
        {
            BuildingData[] tempArray = completeList[type];

            completeList[type] = new BuildingData[tempArray.Length*2];

            int i = 0;
            foreach (BuildingData buildingData in tempArray)
            {
                completeList[type][i] = buildingData;
                i++;
            }
            
            completeList[type][i] = CreateBuilding(buildingInfo,type);
        }
        else
        {
            completeList[type][CountArray(type)] = CreateBuilding(buildingInfo,type);
        }

    }


    static BuildingData CreateBuilding(BuildingData buildingInfo,BuildingType type)
    {
        BuildingData tempBuilding = new BuildingData(buildingInfo.position,buildingInfo.rotation,buildingInfo.worth,buildingInfo.maxLevel,buildingInfo.tickCount);
        tempBuilding.Id = CountArray(type)+1;

        Debug.Log("Created building "+tempBuilding.Id+" at position: "+ tempBuilding.position);

        return tempBuilding;
    }

    static bool CheckArray(BuildingType typeToCheck)
    {
        int amountEmpty = 0;

        foreach (KeyValuePair<BuildingType, BuildingData[]> buildingData in completeList)
        {
            if (buildingData.Key == typeToCheck)
            {
                for (int i = 0; i < buildingData.Value.Length; i++)
                {
                    if (buildingData.Value[i] != null)
                    {
                        if (buildingData.Value[i].Id == -1)
                        {
                            amountEmpty++;
                        }
                    }
                }
            }
        }
        if (amountEmpty < 2)
        {
            return true;
        }

        return false;
    }

    static int CountArray(BuildingType typeToCount)
    {
        int count = 0;

        for (int i = 0; i <completeList[typeToCount].Length;i++)
        {
            if (completeList[typeToCount][i]!=null && completeList[typeToCount][i].Id !=-1)
            {
                count++;
            }
        }
        return count;
    }
}
