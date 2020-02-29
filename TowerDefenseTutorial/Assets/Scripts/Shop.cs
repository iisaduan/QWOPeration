
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    /* Start() - called when game starts
     *
     * instantiates buildManager
     * 
     */
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    /* PurchaseStandardTurret() - makes standard turret the turret to buy
     * 
     */
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.setTurretToBuild(buildManager.standardTurretPrefab);
    }

    /* PurchaseAnotherTurret() - makes another turret the turret to buy
     *
     * TODO: this doesn't do anything yet - wait until there is another turret
     * 
     */
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.setTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
