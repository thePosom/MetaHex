using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 1.0f;
    public float dragSpeed = 5.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 10.0f;
    private Vector3 dragOrigin;

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.orthographicSize += scroll * zoomSpeed*-1;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
            Vector3 move = new Vector3(pos.x * dragSpeed / 90*Camera.main.orthographicSize, pos.y * dragSpeed / 160* Camera.main.orthographicSize, 0);
            transform.Translate(move, Space.World);
            dragOrigin = Input.mousePosition;
        }

    }
}
