using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColour;
    public Color hoverBuyColour;
    public Color selectColour;
    private Color startColour;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        //if (EventSystem.current.IsPointerOverGameObject()) { return; }

        //if (!buildManager.CanBuild) { return; }

        if (Time.timeScale == 0) { return; }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            //rend.material.color = selectColour;
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        //if (EventSystem.current.IsPointerOverGameObject()) { return; }

        if (Time.timeScale == 0) { return; }

        if (buildManager.CanBuild)
        {
            rend.material.color = hoverBuyColour;
        }
        else
        {
            rend.material.color = hoverColour;
        }
    }
    
    void OnMouseExit()
    {
        // if (rend.material.color != selectColour) {}

        if (Time.timeScale == 0) { return; }
            
        rend.material.color = startColour;
    }
}
