using UnityEngine;

public class animControl : MonoBehaviour
{
    Animator anim;
    [SerializeField] float jumpCooldown = 1;
    float lastJump = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");
        if (movementX != 0 || movementZ != 0){
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time - lastJump > jumpCooldown)){
            lastJump = Time.time;
            anim.SetTrigger("hasJumped");
        }
    }
}
