using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition() + new Vector3(-0.25f, 2, 0);

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
