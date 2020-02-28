
using UnityEngine;

// idk how this really works but for some reason we need it?
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;


    /* Awake() - done right before  game starts
     *
     * instantiates BuildManager
     *
     */
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

}
