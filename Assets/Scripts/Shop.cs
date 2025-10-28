using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseCannonTower()
    {
        Debug.Log("Cannon Tower Selected");
        buildManager.SetTurretToBuild(buildManager.cannonTowerPrefab);
    }

    public void PurchaseArcherTower()
    {
        Debug.Log("Archer Tower Selected");
        buildManager.SetTurretToBuild(buildManager.archerTowerPrefab);
    }

    public void PurchaseMagicTower()
    {
        Debug.Log("Magic Tower Selected");
        buildManager.SetTurretToBuild(buildManager.magicTowerPrefab);
    }
}
