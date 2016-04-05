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

        if (completeList.ContainsKey(BuildingType.House))
        {
            for (int i = 0; i < completeList[BuildingType.House].Length; i++)
            {
                if (completeList[BuildingType.House][i] != null && completeList[BuildingType.House][i].Id != -1)
                {
                    Debug.Log(completeList[BuildingType.House][i].level);

                    //give people
                }
            }
        }
        if (completeList.ContainsKey(BuildingType.Shopping))
        {
            for (int i = 0; i < completeList[BuildingType.Shopping].Length; i++)
            {
                if (completeList[BuildingType.Shopping][i] != null && completeList[BuildingType.Shopping][i].Id != -1)
                {
                    Debug.Log(completeList[BuildingType.Shopping][i].level);
                    //give money
                }
            }
        }


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
        buildingInfo.Id = CountArray(type)+1;

        Debug.Log("Created building "+ buildingInfo.Id+" at position: "+ buildingInfo.position);

        return buildingInfo;
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
