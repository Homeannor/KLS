using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColour;
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
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't Build there");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/

        if (!buildManager.CanBuild)
        {
            return;
        }

        rend.material.color = hoverColour;
    }
    
    void OnMouseExit()
    {
        rend.material.color = startColour;
    }
}
