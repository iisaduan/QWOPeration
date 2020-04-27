
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector] 
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;


    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    /* Start() - called at beginning of game
     *
     * sets up instance  variables
     *
     */
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    /* GetBuildPosition()
     *
     * gets build position
     *
     */
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    /* OnMouseDown()
     *
     * When user clicks on a node, determines what to do
     *
     * If they can't build, does nothing
     *
     * else, it will build a new turret
     *
     * TODO:display message on screen if you can't build a turret at node
     * 
     */

    private void OnMouseDown()
    {
        // if a turret is already on a node, do nothing
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        // if there is already a turret there, return error message
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        // if user has not selected a turret to build, do nothing
        if (!buildManager.CanBuild)
        {
            return;
        }

        // else, build turret
        
        BuildTurret(buildManager.GetTurretToBuild());

        buildManager.SelectTurretToBuild(null);

    }

    /*
     * BuildTurret takes in a turret blueprint and builds the turret without having to reference a node
     */

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money <  blueprint.cost)
        {
            // TODO: add some text to user
            Debug.Log("Not Enough Money");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        // build  turret
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        // instantiate build  effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        // each time a new turret is built, we increase the count for the type of
        // the turret that is built in the dictionary
        if (!PlayerStats.turretsBuilt.ContainsKey(blueprint.prefab.name))
        {
            PlayerStats.turretsBuilt.Add(blueprint.prefab.name, 1);
        }
        else
        {
            PlayerStats.turretsBuilt[blueprint.prefab.name] += 1;
        }

    }


    /* UpgradeTurret()
     *
     * upgrades existing turret (on this node)
     * 
     */
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            // TODO: add some text to user
            Debug.Log("Not Enough Money to Upgrade That");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);  // destroy the old turret before upgrading

        // build the new upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        // instantiate build  effect
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;


        // TODO: display on screen to user
        Debug.Log("Turret Upgraded!");
    }

    /* SellTurret()
     *
     * sells existing turret (on this node)
     * 
     */
    public void SellTurret()
    {

        if (isUpgraded)
        {
            PlayerStats.Money += turretBlueprint.GetSellAmount();
        }
        else
        {
            PlayerStats.Money += turretBlueprint.GetSellAmount();
        }

        // Spawn cool effect

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }


    /* OnMouseEnter() - when mouse hovers over node
     *
     * changes color of node if player can build a turret there
     * 
     */
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
    }

    /* OnMouseExit() - when mouse leaves node
     *
     * returns color of node to basic color
     *
     */
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
