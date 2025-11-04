using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene");
            return;
        }

        instance = this;
    }

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (!HasMoney)
        {
            Debug.Log("Not enough money");
            return;
        }

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        PlayerStats.Money -= turretToBuild.cost;

        if (!HasMoney)
        {
            turretToBuild.button.GetComponent<Image>().fillCenter = false;
        }

        turretToBuild = null;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    /* == Kaden colour change code example ==
     public void colourChange(GameObject sprite)
    {
        Renderer spriteRenderer = sprite.GetComponent<Renderer>();
        spriteRenderer.material.color = Color.blue;
    }*/
}

