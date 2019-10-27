using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public double speed = 0.01;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * (float)speed, ForceMode.Impulse);
    }

    void Update()
    {
        
    }
}
