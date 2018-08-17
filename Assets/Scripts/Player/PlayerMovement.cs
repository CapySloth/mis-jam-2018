using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public int joystickNumber = 1;
    public float moveSpeed = 4f; //Change in inspector to adjust move speed

    Vector3 forward, right;
    Rigidbody rigid;
    Animator anim;
    public float jumpForce = 10f;
    bool grounded = true;
    //private float jumpPower = 15;
    private string joystickString;

    void Start()
    {
        joystickString = joystickNumber.ToString();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        forward = cam.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        //Debug.Log("LeftJoystickX_P" + joystickString);
        //Debug.Log(Input.GetAxis("LeftJoystickX_P" + joystickString));
        if (Input.GetAxis("LeftJoystickX_P" + joystickString) != 0 || Input.GetAxis("LeftJoystickY_P" + joystickString) != 0)
        {
            Move();
        } else
        {
            anim.SetBool("Moving", false);
        }
        

        if (Input.GetButtonDown("A_P" + joystickString))
        {
            JumpTowardPoint();
        }
        if (this.transform.position.y >= 4)
        {
            rigid.mass = 100f;
        } else if(grounded)
        {
            rigid.mass = 1f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            anim.SetBool("Jumping", false);
        }
    }
    void JumpTowardPoint()
    {
        if (grounded)
        {
            Debug.Log("Jump!"); 
            anim.SetBool("Jumping", true);
            grounded = false;
            rigid.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
    void Move()
    {
        //setup a direction Vector based on keyboard input. GetAxis returns a value between -1.0 and 1.0. If the A key is pressed, GetAxis(HorizontalKey) will return -1.0. If D is pressed, it will return 1.0
        Vector3 direction = new Vector3(Input.GetAxis("LeftJoystickX_P" + joystickString), 0, Input.GetAxis("LeftJoystickY_P" + joystickString));
        //Our right movement is based on the right vector, movement speed, and our GetAxis command. We multiply by Time.deltaTime to make the movement smooth.
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("LeftJoystickX_P" + joystickString);
        //Up movement uses the forward vector, movement speed, and the vertical axis inputs.
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("LeftJoystickY_P" + joystickString);
        //This creates our new direction. By combining our right and forward movements and normalizing them, we create a new vector that points in the appropriate direction with a length no greater than 1.0
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        //Sets forward direction of our game object to whatever direction we're moving in
        this.transform.forward = heading;
        //Move our transform's position right/left
        this.transform.position += rightMovement;
        //Move our transform's position up/down
        this.transform.position += upMovement;
        anim.SetBool("Moving", true);
    }
}