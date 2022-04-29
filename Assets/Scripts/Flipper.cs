using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flipper : MonoBehaviour
{
    [SerializeField] float force = 10f;
    [SerializeField] float rotSpeed = 10f;
    [SerializeField] TMP_Text myDisp;
    [SerializeField] float startPosY;
    public int Scorecounter = 0;

    private float angle;
    private Rigidbody rg;
    private bool inAir = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;
        anim = GetComponentInChildren<Animator>();
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q"))
            Spin(-1);
        if (Input.GetKey("e"))
            Spin(1);

        Move();

        if (Input.GetKeyDown("space") && inAir == false)
            PhysicJump();
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            inAir = false;
        }
    }

    //Moves Object
    private void Move()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * force;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * force;
        float y = 0;

        transform.Translate(x, y, z);
        //transform.position += new Vector3(x, y, z);
    }

    //Rotates Object
    private void Spin(int v)
    {
        angle += Time.deltaTime * rotSpeed * v;
        Vector3 targetDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    //Force jumping
    private void PhysicJump()
    {
        rg.AddForce(new Vector3(0, force, 0), ForceMode.Impulse);
        anim.Play("Jump");
        inAir = true;
    }

    //Updates Score
    public void IncrementScore()
    {
        Scorecounter += 1;
        myDisp.text = "Score: " + Scorecounter.ToString();
    }

    //Object Rotate
    /*
    private void PhysicSalto()
    {
        transform.Rotate(RotForce*Time.deltaTime, 0, 0);
    }
    */
    //Object moving
    /*
    private void Jump()
    {
        if (ReachedMax)
        {
            if (transform.position.y <= startPosY)
                ReachedMax = false;
        }
        else
        {
            if (transform.position.y >= startPosY + MaxPosY)
                ReachedMax = true;
        }

        int direction = ReachedMax ? -1 : 1;
        transform.position += new Vector3(0, direction * Force * Time.deltaTime, 0);
    }
    */
}
