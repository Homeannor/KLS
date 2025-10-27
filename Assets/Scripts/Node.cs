using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColour;
    private Color startColour;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse entered");

        rend.material.color = hoverColour;
    }
    
    void OnMouseExit()
    {
        Debug.Log("Mouse exited");

        rend.material.color = startColour;
    }
}
