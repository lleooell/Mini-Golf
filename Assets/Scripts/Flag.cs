using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
    // Use this for initialization

    public Camer c;
    public int nb;
    bool isin = false;
	void Start () {

    }

    string getscorename()
    {
        if (c.par == 1)
            return ("ace");
        int caseSwitch = c.par - c.parv;
        switch (caseSwitch)
        {
            case -3:
                return "Albatross";
            case -2:
                return "Eagle ";
            case -1:
                return "Birdie ";
            case 0:
                return "Par";
            case 1:
                return "Bogey";
            case 2:
                return "Double Bogey";
            case 3:
                return "Triple Bogey";
            default:
                return "+"+(c.par - c.parv).ToString();
        }
    }

    void OnTriggerEnter(Collider other)
    {
		if (c.parcours == nb)
		{
	        c.scoretext.text = getscorename();
	        c.scorepartext.text = (c.par).ToString();
	        c.scoretab.transform.localScale = c.savescoretab;
	        c.panelscorefinal.transform.localScale = c.savepanelfin;
	        isin = true;
	        c.audio.clip = c.inhole;
	        c.audio.Play();
		}
    }

    void OnTriggerStay(Collider other)
    {
		if (c.parcours == nb) {
			Rigidbody b = c.ball.GetComponent<Rigidbody> ();
			b.velocity = Vector3.zero;
			b.angularVelocity = Vector3.zero;
		}
    }

    void OnTriggerExit(Collider other)
    {
		if (c.parcours == nb) {
	        isin = false;
	        c.audio.clip = c.applause;
	        c.audio.Play();
		}
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && isin == true)
        {
            if (c.parcours == nb)
            {
                if (c.parcours == 1)
                    c.ball.transform.localPosition = c.start2.transform.localPosition;
                else if (c.parcours == 2)
                    c.ball.transform.localPosition = c.start3.transform.localPosition;
                else if (c.parcours == 3)
                    c.ball.transform.localPosition = c.start1.transform.localPosition;
                c.change_parcours();
            }
        }
    }
}
