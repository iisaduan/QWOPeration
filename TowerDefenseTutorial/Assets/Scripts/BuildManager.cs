
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

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    // weird syntax - basically like a little method
    public bool CanBuild { get { return turretToBuild != null;  } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    // selects a node (so that the upgrade/sell menu can appear on top)
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;  // so that we will only build the node

        nodeUI.SetTarget(node);
    }


    /*
     * If node is clicked again after being selected, it will be deselected
     * and the upgrade/sell menu will disappear
     */
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    /* SelectTurretToBuild(TurretBlueprint turret)
     *
     * selects a turret
     */
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
