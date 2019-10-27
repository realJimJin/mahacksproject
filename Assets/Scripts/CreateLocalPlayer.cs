using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLocalPlayer : MonoBehaviour
{
    public GameObject Player;

    public Camera Cam;

    private Camera PlayerCam;

    public float RotationX, RotationY, SensitivityX, SensitivityY, MinX, MaxX, Offset;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCam = Instantiate(Cam, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        RotationX += Input.GetAxis("Mouse Y") * SensitivityX;
        RotationY += Input.GetAxis("Mouse X") * SensitivityY;

        RotationX = Mathf.Clamp(RotationX, MinX, MaxX);

        transform.localEulerAngles = new Vector3(0, RotationY, 0);

        Cam.transform.localEulerAngles = new Vector3(-RotationX, RotationY, 0);

        Cam.transform.position = new Vector3(transform.position.x, transform.position.y + Offset, transform.position.z);
    }
}
