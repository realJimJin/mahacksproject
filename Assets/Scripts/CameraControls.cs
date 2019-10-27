using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float MinX, MaxX, MinY, MaxY, SensitivityX, SensitivityY, Offset;

    private float RotationX, RotationY;

    public Camera Cam;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RotationX += Input.GetAxis("Mouse Y") * SensitivityX;
        RotationY += Input.GetAxis("Mouse X") * SensitivityY;

        RotationX = Mathf.Clamp(RotationX, MinX, MaxX);

        transform.localEulerAngles = new Vector3(0, RotationY, 0);

        Cam.transform.localEulerAngles = new Vector3(-RotationX, RotationY, 0);

        Cam.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y + Offset, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }
}
