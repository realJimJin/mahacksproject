using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ProjectileContactBehavior : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -100 || transform.position.x > 100 || transform.position.y < -100 || transform.position.y > 100)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collider other)
    {
        if(other.tag == "Player" && !other.GetComponent<MovePlayer1>().isLocalPlayer)
            Destroy(gameObject);
    }
}
