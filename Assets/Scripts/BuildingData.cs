using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class BuildingData
{
    public BuildingData()
    {
        Id = -1;
        position = Vector3.one;
        rotation = Quaternion.identity;
        worth = 0;
        level = 1;
        maxLevel = 1;
        tickCount = 0.2f;
    }

    public BuildingData(Vector3 pos, Quaternion orientation)
    {
        Id = -1;
        position = pos;
        rotation = orientation;
        worth = 0;
        level = 1;
        maxLevel = 1;
        tickCount = 0.2f;
    }

    public BuildingData(Vector3 pos, Quaternion orientation, int worth)
    {
        Id = -1;
        position = pos;
        rotation = orientation;
        this.worth = worth;
        level = 1;
        maxLevel = 1;
        tickCount = 0.2f;
    }

    public BuildingData(Vector3 pos, Quaternion orientation, int worth, int maxLevel)
    {
        Id = -1;
        position = pos;
        rotation = orientation;
        this.worth = worth;
        level = 1;
        this.maxLevel = maxLevel;
        tickCount = 0.2f;
    }
    public BuildingData(Vector3 pos, Quaternion orientation, int worth, int maxLevel,float tickAmount)
    {
        Id = -1;
        position = pos;
        rotation = orientation;
        this.worth = worth;
        level = 1;
        this.maxLevel = maxLevel;
        tickCount = tickAmount;
    }

    public bool LevelUp()
    {
        if (level < maxLevel)
        {

            level += 1;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int Id;
    public Vector3 position;
    public Quaternion rotation;
    public float tickCount;
    public int worth;
    public int level;
    internal int maxLevel;
}
