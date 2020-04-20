
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint poisonTurret;

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
        Debug.Log("Posion Turret Selected");
        buildManager.SelectTurretToBuild(poisonTurret);
    }
}
