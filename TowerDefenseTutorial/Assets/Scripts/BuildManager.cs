
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
    public GameObject missileLauncherPrefab;

    private TurretBlueprint turretToBuild;

    // weird syntax - basically like a little method
    public bool CanBuild { get { return turretToBuild != null;  } }


    /* SelectTurretToBuild(TurretBlueprint turret)
     *
     * selects a turret
     */
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    /* BuildTurretOn(Node node)
     *
     * builds a turretToBuild on node parameter
     *
     * if user does not have enough money - returns
     *
     */
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            // TODO: add some text to user
            Debug.Log("Not Enough Money");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        // TODO: display on screen to user
        Debug.Log("Turret Built. Money left: " + PlayerStats.Money);

        GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;


    }


    

}
