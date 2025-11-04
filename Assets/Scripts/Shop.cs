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
        if (cannonTower == null)
        {
            Debug.LogError("CannonTower blueprint itself is NULL!");
        }
        else if (cannonTower.prefab == null)
        {
            Debug.LogError("CannonTower.prefab is NULL!");
        }
        else
        {
            Debug.Log("CannonTower.prefab is assigned to: " + cannonTower.prefab.name);
        }

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
