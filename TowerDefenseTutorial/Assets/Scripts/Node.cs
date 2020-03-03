
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header ("Optional")]
    public GameObject turret;


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
        buildManager.BuildTurretOn(this);

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
        if (buildManager.EnoughMoney())
        {
            rend.material.color = hoverColor;
        }
        else
        {
            // TODO: design choice - square can just not highlight when not enough money
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
