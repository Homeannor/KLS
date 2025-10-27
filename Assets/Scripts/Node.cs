using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColour;
    private Color startColour;

    private GameObject turret;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;
    }

    void OnMouseDown()
    {
       if (turret != null)
        {
            Debug.Log("Can't Build there");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse entered");

        if (turret == null)
        {
            rend.material.color = hoverColour;
        }
    }
    
    void OnMouseExit()
    {
        Debug.Log("Mouse exited");

        rend.material.color = startColour;
    }
}
