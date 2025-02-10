using UnityEngine;

public class animControl : MonoBehaviour
{
    Animator anim;
    [SerializeField] float jumpCooldown = 1;
    float lastJump = 0;
    [SerializeField] float shootCooldown = 1;
    float lastShoot = 0;
    public AudioSource disparo, noamo;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.health <= 0){
            anim.SetBool("Dead", true);
        }
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
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            anim.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            anim.SetBool("Run", false);
        }
        if (Input.GetMouseButtonDown(0) && (Time.time - lastShoot > shootCooldown) && PlayerManager.amo > 0){
            lastShoot = Time.time;
            anim.SetBool("Shoot", true);
            disparo.Play();
        } else if (Input.GetMouseButtonDown(0) && (Time.time - lastShoot > shootCooldown) && PlayerManager.amo <= 0){
            noamo.Play();
        }
        if (Input.GetMouseButtonUp(0)){
            anim.SetBool("Shoot", false);
        }
    }
}
