using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this line needs to be here
[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;


    // TODO: get a better sell amount (takes upgrades into account)
    public int GetSellAmount()
    {
        return cost / 2;
    }

    public int GetUpgradedSellAmount()
    {
        return (cost + upgradeCost) / 2;
    }

    // TODO: add info about turrets, etc here
}
