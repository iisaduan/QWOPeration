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

    // TODO: add info about turrets, etc here
}
