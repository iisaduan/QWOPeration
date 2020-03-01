
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
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
        // if user has not selected a turret to build, do nothing
        if (!buildManager.CanBuild)
        {
            return;
        }
        // if there is already a turret there, return error message
        if (turret != null)
        {
            Debug.Log("Can't build there! -- TODO: display on screen");
            return;
        }
        // else, build turret
        buildManager.BuildTurretOn(this);

    }

    /* OnMouseEnter() - when mouse hovers over node
     *
     * changes color of node if player can build a turret there
     *
     * TODO: dont do it if turret already in square
     *
     * TODO: do something different if user doesnt have enough money
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
        rend.material.color = hoverColor;
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
