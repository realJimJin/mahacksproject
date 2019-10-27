using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TrackPlayerWithCamera : NetworkBehaviour
{
    public GameObject Projectile;

    public Camera Cam;

    public static Camera PlayerCam;

    public float RotationX, RotationY, SensitivityX, SensitivityY, MinX, MaxX, Offset;

    private float LastTimeCheck;

    public static float MouseX, MouseY;

    // Start is called before the first frame update
    void Start()
    {
        LastTimeCheck = 0;
        PlayerCam = Instantiate(Cam, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Camera;
    }

    // Update is called once per frame
    void Update()
    {
        MouseX = Input.GetAxis("Mouse Y") * SensitivityX;
        MouseY = Input.GetAxis("Mouse X") * SensitivityY;

        RotationX += Input.GetAxis("Mouse Y") * SensitivityX;
        RotationY += Input.GetAxis("Mouse X") * SensitivityY;

        RotationX = Mathf.Clamp(RotationX, MinX, MaxX);

        //transform.localEulerAngles = new Vector3(0, RotationY, 0);

        PlayerCam.transform.localEulerAngles = new Vector3(-RotationX, RotationY, 0);

        PlayerCam.transform.position = new Vector3(transform.position.x, transform.position.y + Offset, transform.position.z);

        Debug.Log("Mouse X and Mouse Y: " + MouseX + MouseY);
    }
}
