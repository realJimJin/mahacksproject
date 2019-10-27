using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public double speed = 0.1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.Translate(Vector2.right * (float)speed);
    }

    void Update()
    {
        
    }
}
