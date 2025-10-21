using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColour;
    private Color startColour;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;
    }

    public void OnPointerEnter(PointerEventData eventdata)
    {
        rend.material.color = hoverColour;
    }

    public void OnPointerExit(PointerEventData eventdata)
    {
        rend.material.color = startColour;
    }
}
