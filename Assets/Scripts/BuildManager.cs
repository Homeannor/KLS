using UnityEngine;

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

    public GameObject cannonTowerPrefab;
    public GameObject archerTowerPrefab;
    public GameObject magicTowerPrefab;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
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

