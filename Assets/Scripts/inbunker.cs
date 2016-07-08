using UnityEngine;
using System.Collections;

public class inbunker : MonoBehaviour {
    public Ball ball;
    public Camer c;
    public PhysicMaterial a;
    public PhysicMaterial b;
    int save;
    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        save = c.club;
        Rigidbody b = ball.GetComponent<Rigidbody>();

        b.angularDrag = 1000;
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody b = ball.GetComponent<Rigidbody>();
        b.velocity = b.velocity*0.99F;
        b.angularVelocity = b.angularVelocity * 0.99F;
        c.club = 3;
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody b = ball.GetComponent<Rigidbody>();
        b.angularDrag = 20;
        c.club = save;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
