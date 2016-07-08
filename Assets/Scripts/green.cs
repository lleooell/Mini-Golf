using UnityEngine;
using System.Collections;

public class green : MonoBehaviour {
    public int clu;
    public Camer c;
	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        clu = c.club;
    }

    void OnTriggerStay(Collider other)
    {
        c.club = 4;
    }

    void OnTriggerExit(Collider other)
    {
        c.club = clu;
    }
    // Update is called once per frame
    void Update () {
	
	}
}
