using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;   // the upgrade/sell button

    private Node target;

    /*
     * Sets the node above which the upgrade/sell buttons should hover
     * Makes the buttons appear
     */
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
