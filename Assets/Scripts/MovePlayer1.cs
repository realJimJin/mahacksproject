using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovePlayer1 : NetworkBehaviour
{
    public float MinX, MaxX, MinY, MaxY, SensitivityX, SensitivityY;

    private float RotationX, RotationY;

    public double speed = 0.1;

    public Camera Cam;

    public GameObject LocalPlayer;

    private GameObject LocPlayer;

    public GameObject Projectile;

    public bool Grounded = true;
    public float SetSpeed;
    private float Speed;
    public Vector3 Pos;
    public float LeftXBound, RightXBound, FrontZBound, BackZBound;

    private float LastTimeCheck;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;
            LocPlayer = Instantiate(LocalPlayer);
        }
    }

    // Update is called once per frame
    void Update()
    {
	 if (this.isLocalPlayer) {
   
        if (!Grounded)
            Speed = SetSpeed / 2;
        else Speed = SetSpeed;

        if (Input.GetKey(KeyCode.A) && InBounds())
        {
            transform.Translate(Vector3.left * Speed);
        }
        else if (Input.GetKey(KeyCode.D) && InBounds())
        {
            transform.Translate(Vector3.right * Speed);
        }

        if (Input.GetKey(KeyCode.W) && InBounds())
        {
            transform.Translate(Vector3.forward * Speed);
        }
        else if (Input.GetKey(KeyCode.S) && InBounds())
        {
            transform.Translate(Vector3.back * Speed);
        }

        if(Grounded && Input.GetKeyDown(KeyCode.LeftShift))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));
            Grounded = false;
        }
                
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

            LocPlayer.transform.position = transform.position;

            RotationX += TrackPlayerWithCamera.MouseX * SensitivityX;
            RotationY += TrackPlayerWithCamera.MouseY * SensitivityY;

            transform.localEulerAngles = new Vector3(0, RotationY, 0);

            if (Input.GetMouseButtonDown(0) && Time.time - LastTimeCheck >= 1)
            {
                Debug.Log("Entered if statement");
                Shoot();
                LastTimeCheck = Time.time;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            Grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            Grounded = false;
    }

    private bool InBounds()
    {
        if (transform.position.x > LeftXBound && transform.position.x < RightXBound && transform.position.z > BackZBound && transform.position.z < FrontZBound)
            return true;
        return false;
    }
    
    public void Shoot()
    {
        Debug.Log("Mouse X and Mouse Y: " + TrackPlayerWithCamera.MouseX + TrackPlayerWithCamera.MouseY);
        GameObject Clone = Instantiate(Projectile, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);
        Rigidbody RB = Clone.GetComponent<Rigidbody>();
        RB.velocity = LocPlayer.GetComponent<TrackPlayerWithCamera>().GetCamPos().transform.forward * 40;
        NetworkServer.Spawn(Clone);
        LastTimeCheck = Time.time;
    }
}
