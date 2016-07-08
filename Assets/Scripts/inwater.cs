using UnityEngine;
using System.Collections;

public class inwater : MonoBehaviour {
    public Camer c;
    public bool ini = false;
    // Use this for initialization
    void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        ini = true;
        c.oops.transform.localScale = c.savedoops;
        Rigidbody b = c.ball.GetComponent<Rigidbody>();
        b.velocity = Vector3.zero;
        b.angularVelocity = Vector3.zero;
        c.audio.clip = c.water;
        c.audio.Play();
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody b = c.ball.GetComponent<Rigidbody>();
        b.velocity = Vector3.zero;
        b.angularVelocity = Vector3.zero;
    }

    void OnTriggerExit(Collider other)
    {
        ini = false;
    }

    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyDown(KeyCode.Space) && ini == true)
        {
            c.restart_level();
        }
	}
}
