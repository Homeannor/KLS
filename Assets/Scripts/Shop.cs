using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    public TurretBlueprint cannonTower;
    public TurretBlueprint archerTower;
    public TurretBlueprint magicTower;


    void Start()
    {
        buildManager = BuildManager.instance;
    }

    void Update()
    {
        cannonTower.button.GetComponent<Image>().fillCenter = PlayerStats.Money >= cannonTower.cost;
        archerTower.button.GetComponent<Image>().fillCenter = PlayerStats.Money >= archerTower.cost;
        magicTower.button.GetComponent<Image>().fillCenter = PlayerStats.Money >= magicTower.cost;
    }

    public void SelectCannonTower()
    {
        if (PlayerStats.Money >= cannonTower.cost)
        {
            Debug.Log("Cannon Tower Selected");
            buildManager.SelectTurretToBuild(cannonTower);
        }
    }

    public void SelectArcherTower()
    {
        if (PlayerStats.Money >= cannonTower.cost)
        {
            Debug.Log("Archer Tower Selected");
            buildManager.SelectTurretToBuild(archerTower);
        }
    }

    public void SelectMagicTower()
    {
        if (PlayerStats.Money >= cannonTower.cost)
        {
            Debug.Log("Magic Tower Selected");
            buildManager.SelectTurretToBuild(magicTower);
        }
    }
}
