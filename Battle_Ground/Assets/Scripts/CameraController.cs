using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private float panSpeed;
    [SerializeField]
    private float panBorderThickness;
    [SerializeField]
    private Vector2 limitAxis;
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;

    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100 * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -limitAxis.x, limitAxis.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -limitAxis.y, limitAxis.y);
        transform.position = pos;
    }
}
