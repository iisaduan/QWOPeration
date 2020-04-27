using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;   // the upgrade/sell button

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    public Text shootType;

    private Node target;


    public void Start()
    {
        ui.SetActive(false);
    }


    /* SetTarget
     * 
     * Sets the node above which the upgrade/sell buttons should hover
     * Makes the buttons appear
     * 
     */
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        shootType.text = target.turret.GetComponent<Turret>().shootType + "";

        if (!(target.isUpgraded))
        {
            // display the amount the upgrade costs on the button
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
            sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        }
        else
        {
            sellAmount.text = "$" + target.turretBlueprint.GetUpgradedSellAmount();
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;  // prevents players from upgrading more than once
        }

        

        shootType.text = target.turret.GetComponent<Turret>().shootType + "";

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    /* Upgrade
     *
     * upgrades turret and deselects node
     *
     */
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); // close the menu after upgrading
    }

    /* Sell
     *
     * sells turret and deselects node
     *
     */
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

    /* ChangeShootType
     *
     * changes turret's shoot type
     *
     * first -> last -> mostHealth -> closest
     *
     */
    public void ChangeShootType()
    {
        Debug.Log("changing type");

        ShootType shootType = target.turret.GetComponent<Turret>().shootType;

        if (shootType == ShootType.First)
        {
            shootType = ShootType.Last;
        }
        else if (shootType == ShootType.Last)
        {
            shootType = ShootType.MostHealth;
        }
        else if (shootType == ShootType.MostHealth)
        {
            shootType = ShootType.Closest;
        }
        else if (shootType == ShootType.Closest)
        {
            shootType = ShootType.First;
        }

        target.turret.GetComponent<Turret>().shootType = shootType;

        SetTarget(target);

    }
}
