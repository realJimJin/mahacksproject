using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ProjectileContactBehavior : NetworkBehaviour
{
    public Text P1Score, P2Score;

    // Start is called before the first frame update
    void Start()
    {
        P1Score.text = "0";
        P2Score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -100 || transform.position.x > 100 || transform.position.y < -100 || transform.position.y > 100)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            other.transform.position = new Vector3(0, 12, 0);
        }
    }
}
