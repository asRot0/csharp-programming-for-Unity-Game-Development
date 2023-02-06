using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class newmove : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public Transform cam;
    public Transform groundcheck;
    public LayerMask groundmask;
    public float grounddistance = 0.2f;
    public float walkspeed = 3f;
    public float runspeed = 5f;
    public float jumpdeistance = 2f;
    public float jumpSpeed = 1.5f;
    public float gravity = -9.81f;
    public float turnsmoothtime = 0.1f;
    private float turnsmoothvelocity;
    float targetangle;
    float angle;
    private Vector3 velocity;
    //private Vector3 diraction = Vector3.zero;
    private bool isGrounded;
    private bool isRunning;
    private bool kefire;
    public float walktime = .5f;
    public bool walkmomnt = true;

    void Start() 
    {
        //gunshoot impactscript = GetComponent<gunshoot>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        isRunning = Input.GetKey(KeyCode.LeftShift);
        float speed = isGrounded ? (isRunning ? runspeed : walkspeed) : (walkspeed + jumpdeistance);
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        Vector3 diraction = new Vector3(horizontal, 0f, Vertical).normalized;
        if(diraction.magnitude>0.1f && walkmomnt)
            StartCoroutine(walksound());

        if (diraction.magnitude >0.1f || diraction.magnitude ==0.0f)
        {
            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)

            if(isGrounded)
            {
                targetangle = Mathf.Atan2(diraction.x, diraction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvelocity, turnsmoothtime);

                if(diraction.magnitude >0.1f || Input.GetButton("Fire1"))
                {
                    
		            transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }
            }
            if(diraction.magnitude >0.1f && !Input.GetButton("Fire1") && !Input.GetButton("Fire2"))
            {

                Vector3 movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
                controller.Move(movedir.normalized * speed * Time.deltaTime);

            }
        
        }
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //StartCoroutine(method());
            velocity.y = Mathf.Sqrt(jumpSpeed * -2.0f * gravity);
            FindObjectOfType<AudioManager>().Play("jump");

        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }

    /**IEnumerator method()
    {
        yield return new WaitForSeconds(1);
    }**/
    IEnumerator walksound()
    {
        walkmomnt = false;
        yield return new WaitForSeconds(walktime);
        FindObjectOfType<AudioManager>().Play("playerwalk");
        walkmomnt = true;
    }
}
