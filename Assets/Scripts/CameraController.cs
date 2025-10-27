using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((Vector3.forward + Vector3.left) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((Vector3.back + Vector3.right) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate((Vector3.right + Vector3.forward) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate((Vector3.left + Vector3.back) * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
