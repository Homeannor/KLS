using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColour;
    private Color startColour;

    private GameObject turret;

    private Renderer rend;
    private BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't Build there");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        rend.material.color = hoverColour;
    }
    
    void OnMouseExit()
    {
        Debug.Log("Mouse exited");

        rend.material.color = startColour;
    }
}
