using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Camer : MonoBehaviour {


    public CharacterController cc;
    public Ball ball;
    public Flag flag;
    public Flag flag2;
    public Flag flag3;
    public GameObject start1;
    public GameObject start2;
    public GameObject start3;
    public GameObject arrow;
    public Text text_par;
    public Text text_parv;
    public Text text_parc;
    public RectTransform scoretab;
    public Text scoretext;
    public Text scorepartext;
    public RectTransform oops;
    public Vector3 savedoops;
    public Vector3 savedballpos;
    AudioSource  mus;

    public bool is_in_green = false;

    public int club = 1;

    public int parv = 3;
    public int scorefinal = 0;
    int lol = 0;
    public int par = 0;

    public int parcours = 1;

    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    float speed = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public bool is_playing = false;
    Quaternion orient;
    Vector3 orientpos;
    public RectTransform panel;
    public RectTransform panelinc;
    Vector3 showpanel;
    float count;
    bool is_shooting = false;
    bool move_up;
    float savedscaley;
    Vector3 savedscalearrow;
    Vector3 lastpos;

    public Vector3 savescoretab;

    public int score_1 = 0;
    public int score_2 = 0;
    public int score_3 = 0;



    // Use this for initialization


    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 0.5F;
    public float sensitivityY = 0.5F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;


    public RectTransform panelscorefinal;
    public Vector3 savepanelfin;
    public Text text_par1;
    public Text text_par2;
    public Text text_par3;
    public Text text_scfin;
    public AudioSource audio;
    public Text club_text;


    public AudioClip tap;
    public AudioClip applause;
    public AudioClip water;
    public AudioClip inhole;

    public AudioSource music;


    void Start () {
        cc = GetComponent<CharacterController>();
        showpanel = panel.transform.localScale;
        savedscaley = panel.transform.localScale.y;
        savedscalearrow = arrow.transform.localScale;
        panelinc.transform.localScale = new Vector3(0F, 0F, 0F);
        arrow.transform.localScale = new Vector3(0F, 0F, 0F);
        panel.transform.localScale = new Vector3(0F, 0F, 0F);
        savescoretab = scoretab.transform.localScale;
        scoretab.transform.localScale = new Vector3(0F, 0F, 0F);
        savepanelfin = panelscorefinal.transform.localScale;
        panelscorefinal.transform.localScale = new Vector3(0F, 0F, 0F);
        savedoops = oops.transform.localScale;
        oops.transform.localScale = new Vector3(0F, 0F, 0F);
        audio = GetComponent<AudioSource>();
        audio.clip = tap;
        music.Play();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("[+]") || Input.GetKeyDown("c"))
        {
            if (club < 3)
                club++;
            else
                club = 1;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            panelscorefinal.transform.localScale = savepanelfin;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            panelscorefinal.transform.localScale = new Vector3(0F, 0F, 0F);
        }
        if (Input.GetKeyDown("e"))
        {
            is_shooting = false;
            panel.transform.localScale = new Vector3(0F, 0F, 0F);
            panelinc.transform.localScale = new Vector3(0F, 0F, 0F);
            arrow.transform.localScale = new Vector3(0F, 0F, 0F);
            is_playing = false;
        }


        if (is_playing == false) {
            if (Input.GetKey("w"))
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                cc.Move(moveDirection * Time.deltaTime);
            }
            if (Input.GetKey("q"))
            {
                if (cc.transform.localPosition.y < 20)
                {
                    moveDirection = new Vector3(0F, 1F, 0F);
                    moveDirection *= speed;
                    cc.Move(moveDirection * Time.deltaTime);
                }
            }
            if (Input.GetKey("e"))
            {
                moveDirection = new Vector3(0F, -1F, 0F);
                moveDirection *= speed;
                cc.Move(moveDirection * Time.deltaTime);
            }
            if (Input.GetKey("s"))
            {
                moveDirection = new Vector3((Input.GetAxis("Horizontal")) * -1F, 0, (Input.GetAxis("Vertical"))) * -1F;
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                cc.Move(moveDirection * Time.deltaTime * -1F);
            }
            if (Input.GetKey("a"))
            {
                moveDirection = new Vector3((Input.GetAxis("Horizontal")) * -1F, 0, 0);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                cc.Move(moveDirection * Time.deltaTime * -1F);
            }
            if (Input.GetKey("d"))
            {
                moveDirection = new Vector3((Input.GetAxis("Horizontal")), 0, 0);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                cc.Move(moveDirection * Time.deltaTime);
            }
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
            if (cc.transform.localPosition.y > 20)
                cc.transform.localPosition = new Vector3(cc.transform.localPosition.x, 20F, cc.transform.localPosition.z);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (is_shooting == false)
                {
                    if (!is_moving(ball.transform.position, lastpos))
                    {
                        count = 0;
                        count = count + 0.02F;
                        is_shooting = true;
                    }
                }
                else
                {
                    audio.clip = tap;
                    audio.Play();
                    par += 1;
                    if (parcours == 1)
                        score_1++;
                    else if (parcours == 2)
                        score_2++;
                    else
                        score_3++;
                    savedballpos = ball.transform.localPosition;
                   Rigidbody b = ball.GetComponent<Rigidbody>();
                    if (club == 2)
                    b.AddForce((transform.forward + transform.up) * (count * 2000));
                    if (club == 1)
                        b.AddForce((transform.forward * (count * 3000) + transform.up * (count * 1800)));
                    if (club == 3)
                        b.AddForce((transform.forward * (count * 500) + transform.up * (count * 3000)));
                    if (club == 4)
                        b.AddForce((transform.forward * (count * 1500) - transform.up * (count * 50)));
                    is_shooting = false;
                   count = 0;
                }
            }
            if (Input.GetKey("d"))
            {
                transform.Rotate(Vector3.up * 0.5F);
                arrow.transform.Rotate(Vector3.up * 0.5F);
            }
            if (Input.GetKey("a"))
            {
                transform.Rotate(Vector3.down * 0.5F);
                arrow.transform.Rotate(Vector3.down * 0.5F);
            }
            if (Input.GetKeyDown("r"))
            {
                panel.transform.localScale = showpanel;
                if (parcours == 1)
                {
                    transform.LookAt(flag.transform);
                    arrow.transform.LookAt(flag.transform);
                }
                else if (parcours == 2)
                {
                    transform.LookAt(flag2.transform);
                    arrow.transform.LookAt(flag2.transform);
                }
                else if (parcours == 3)
                {
                    transform.LookAt(flag3.transform);
                    arrow.transform.LookAt(flag3.transform);
                }
                arrow.transform.localScale = savedscalearrow;
                arrow.transform.Rotate(Vector3.right * 20.5F);
            }
            if (is_shooting == true)
            {
                if (count > savedscaley - 0.02F)
                    move_up = false;
                if (count < 0F)
                    move_up = true;
                if (move_up)
                    count += 0.02F;
                else
                    count -= 0.02F;
                panelinc.transform.localScale = new Vector3 (showpanel.x, count, showpanel.z);
             
            }
            transform.localPosition = new Vector3(ball.transform.localPosition.x, ball.transform.localPosition.y, ball.transform.localPosition.z);
            transform.localPosition += (transform.up * 1F - transform.forward * 2F);
            arrow.transform.localPosition = transform.localPosition;
            arrow.transform.localPosition += transform.forward * 2F - transform.up * 0.1F;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (is_playing == false)
            {
                panel.transform.localScale = showpanel;
                if (parcours == 1)
                {
                    transform.LookAt(flag.transform);
                    arrow.transform.LookAt(flag.transform);
                }
                else if (parcours == 2)
                {
                    transform.LookAt(flag2.transform);
                    arrow.transform.LookAt(flag2.transform);
                }
                else if (parcours == 3)
                {
                    transform.LookAt(flag3.transform);
                    arrow.transform.LookAt(flag3.transform);
                }
                arrow.transform.localScale = savedscalearrow;
                arrow.transform.Rotate(Vector3.right * 20.5F);
                is_playing = true;
                is_shooting = false;
            }
        }
        lol++;
        if (lol == 30)
        {
            lastpos = ball.transform.localPosition;
            lol = 0;
        }
        text_par.text = par.ToString();
        text_parv.text = parv.ToString();
        text_parc.text = parcours.ToString();
        text_par1.text = score_1.ToString();
        text_par2.text = score_2.ToString();
        text_par3.text = score_3.ToString();
        text_scfin.text = (score_1 + score_2 + score_3 - 4 - 3 - 2).ToString();
        if (club == 1)
            club_text.text = "Bois";
        else if (club == 2)
            club_text.text = "Fer";
        else if (club == 3)
            club_text.text = "Wedge";
        else if (club == 4)
            club_text.text = "Putter";
    }

   public void change_parcours()
    {
        Rigidbody b = ball.GetComponent<Rigidbody>();
        b.velocity = Vector3.zero;
        b.angularVelocity = Vector3.zero;
        par = 0;
        scoretab.transform.localScale = new Vector3(0F, 0F, 0F);
        panelscorefinal.transform.localScale = new Vector3(0F, 0F, 0F);
        if (parcours == 1)
        {
            transform.localPosition = new Vector3(ball.transform.localPosition.x, ball.transform.localPosition.y, ball.transform.localPosition.z);
            transform.localPosition += (transform.up * 1F - transform.forward * 2F);
            parcours = 2;
            transform.LookAt(flag2.transform);
            arrow.transform.localPosition = transform.localPosition;
            arrow.transform.localPosition += transform.forward * 2F - transform.up * 0.1F;
            parv = 4;
            club = 1;
        }
        else if (parcours == 2)
        {
            transform.localPosition = new Vector3(ball.transform.localPosition.x, ball.transform.localPosition.y, ball.transform.localPosition.z);
            transform.localPosition += (transform.up * 1F - transform.forward * 2F);
            parcours = 3;
            transform.LookAt(flag3.transform);
            arrow.transform.localPosition = transform.localPosition;
            arrow.transform.localPosition += transform.forward * 2F - transform.up * 0.1F;
            parv = 2;
            club = 1;
        }
        else if (parcours == 3)
        {
            transform.localPosition = new Vector3(ball.transform.localPosition.x, ball.transform.localPosition.y, ball.transform.localPosition.z);
            transform.localPosition += (transform.up * 1F - transform.forward * 2F);
            parcours = 1;
            transform.LookAt(flag.transform);
            arrow.transform.localPosition = transform.localPosition;
            arrow.transform.localPosition += transform.forward * 2F - transform.up * 0.1F;
            parv = 3;
            club = 1;
        }
    }

    bool is_moving(Vector3 one, Vector3 two)
    {
        if (one.x > two.x - 0.01 && one.x < two.x + 0.01 && one.y > two.y - 0.01 && one.y < two.y + 0.01 && one.z > two.z - 0.01 && one.z < two.z + 0.01)
            return false;
        return true;
    }

    public void restart_level()
    {
        Rigidbody b = ball.GetComponent<Rigidbody>();
        b.velocity = Vector3.zero;
        b.angularVelocity = Vector3.zero;
        oops.transform.localScale = new Vector3(0F, 0F, 0F);
        if (parcours == 1)
        {
            ball.transform.localPosition = savedballpos;
            transform.LookAt(flag.transform);
            arrow.transform.LookAt(flag.transform);
            arrow.transform.localScale = savedscalearrow;
            arrow.transform.Rotate(Vector3.right * 20.5F);
        }
        else if (parcours == 2)
        {
            ball.transform.localPosition = savedballpos;
            transform.LookAt(flag2.transform);
            arrow.transform.LookAt(flag2.transform);
            arrow.transform.localScale = savedscalearrow;
            arrow.transform.Rotate(Vector3.right * 20.5F);
        }
        else if (parcours == 3)
        {
            ball.transform.localPosition = savedballpos;
            transform.LookAt(flag3.transform);
            arrow.transform.LookAt(flag3.transform);
            arrow.transform.localScale = savedscalearrow;
            arrow.transform.Rotate(Vector3.right * 20.5F);
        }
    }
}
