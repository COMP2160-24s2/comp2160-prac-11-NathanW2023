using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    private Actions actions;
    private InputAction ZoomAction;
    public float zoomSpeed = 2f;
    public float minZoom = 5f;
    public float maxZoom = 50f;

    void Awake(){
        actions = new Actions();
        ZoomAction = actions.camera.zoom;
        ZoomAction.performed += ZoomIn;

    }

    void OnEnable()
    {
        ZoomAction.Enable();
    }

    void OnDisable()
    {
        ZoomAction.Disable();
    }

    void ZoomIn(InputAction.CallbackContext context)
    {
        float zoomChange = ZoomAction.ReadValue<float>() * zoomSpeed;
        if (Camera.main.orthographic)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomChange, minZoom, maxZoom);
            Debug.Log( Camera.main.orthographicSize );
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - zoomChange, minZoom, maxZoom);
        }
    }
}
