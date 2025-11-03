using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    public TurretBlueprint cannonTower;
    public TurretBlueprint archerTower;
    public TurretBlueprint magicTower;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectCannonTower()
    {
        Debug.Log("Cannon Tower Selected");
        buildManager.SelectTurretToBuild(cannonTower);
    }

    public void SelectArcherTower()
    {
        Debug.Log("Archer Tower Selected");
        buildManager.SelectTurretToBuild(archerTower);
    }

    public void SelectMagicTower()
    {
        Debug.Log("Magic Tower Selected");
        buildManager.SelectTurretToBuild(magicTower);
    }
}
