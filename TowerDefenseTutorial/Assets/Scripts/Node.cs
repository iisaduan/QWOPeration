
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;


    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    /* OnMouseDown()
     *
     * When user clicks on a node, determines what to do
     *
     * If they can't build, does nothing
     *
     * else, it will build a new turret
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
        if (buildManager.GetTurretToBuild() == null)
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
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret  = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
