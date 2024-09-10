using UnityEngine;

public class Garfield_Walk_Run : MonoBehaviour
{
    bool Garfield_Moving;
    bool Garfield_Run;
    public float Garfield_Speed;
    public float Garfield_Move_X;
    public float Garfield_Move_Y;
    Rigidbody2D rb;
    Animator anim;
    public float facingDirectionX;
    public float facingDirectionY;
    public float interval = 3f;  // เวลาที่ต้องการให้เพิ่มค่า (3 วินาที)
    private float timer = 0f;    // ตัวแปรสำหรับนับเวลา

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationController();

        Garfield_Move_X = Input.GetAxisRaw("Horizontal");
        Garfield_Move_Y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // ทำสิ่งที่ต้องการเมื่อ LeftShift ถูกกด
            Garfield_Run = true;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // ทำสิ่งที่ต้องการเมื่อ LeftShift ถูกปล่อย
            Garfield_Run = false;
        }



        Garfield_Moving = Garfield_Move_X != 0 || Garfield_Move_Y != 0;

        RotateCharacterToMouse();



    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Garfield_Move_X, Garfield_Move_Y) * Garfield_Speed;
    }
    void AnimationController()
    {
        anim.SetFloat("GarfieldX", Garfield_Move_X);
        anim.SetFloat("GarfieldY", Garfield_Move_Y);
        anim.SetFloat("X", facingDirectionX);
        anim.SetFloat("Y", facingDirectionY);

        anim.SetBool("ismoving", Garfield_Moving);
        anim.SetBool("Run", Garfield_Run);
    }
    private void RotateCharacterToMouse()
    {
        // Get mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure z is 0 to keep the character on the same plane

        // Calculate direction from character to mouse
        Vector3 direction = mousePosition - transform.position;

        // Determine the direction to rotate
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // More horizontal movement
            if (direction.x > 0)
            {
               // Facing right
                facingDirectionX = 1; // Store facing direction
                facingDirectionY = 0;
            }
            else
            {
              
                facingDirectionX = -1; // Store facing direction
                facingDirectionY = 0;
            }
        }
        else
        {
            // More vertical movement
            if (direction.y > 0)
            {
                 // Facing up
                facingDirectionX = 0; // Store facing direction
                facingDirectionY = 1;
            }
            else
            {
                 // Facing down
                facingDirectionX = 0; // Store facing direction
                facingDirectionY = -1;
            }
        }
    }
}
