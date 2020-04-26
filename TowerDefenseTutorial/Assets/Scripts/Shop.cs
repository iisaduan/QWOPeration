
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint poisonTurret;
    public TurretBlueprint goldTower;

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

    /* SelectStandardTurret()
     *
     * makes standard turret the turretToBuild
     * 
     */
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    /* SelectMissileLauncher
     *
     * makes missile launcher the turretToBuild
     * 
     */
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

    public void SelectPoisonTurret()
    {
        Debug.Log("Poison Tower Selected");
        buildManager.SelectTurretToBuild(poisonTurret);
    }

    public void SelectGoldTower()
    {
        Debug.Log("Gold Tower Selected");
        buildManager.SelectTurretToBuild(goldTower);
    }


}
