using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public CurrencyUI currencyUI;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene");
            return;
        }

        instance = this;
    }

    private TurretBlueprint turretToBuild = null;
    private Node selectedNode;

    public NodeUI nodeUI;

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
        currencyUI.decreaseText(turretToBuild.cost);

        if (!HasMoney)
        {
            turretToBuild.button.GetComponent<Image>().fillCenter = false;
        }

        turretToBuild = null;
    }

    public void SelectNode(Node node)
    {
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }

    /* == Kaden colour change code example ==
     public void colourChange(GameObject sprite)
    {
        Renderer spriteRenderer = sprite.GetComponent<Renderer>();
        spriteRenderer.material.color = Color.blue;
    }*/
}

