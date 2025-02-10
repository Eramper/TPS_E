using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{
    [SerializeField]Animator anim;
    NavMeshAgent agent;
    [SerializeField] GameObject[] path;
    int goal = 0;
    [Header("Detection")]
    [SerializeField] GameObject player;
    [SerializeField] float visionArea = 5;
    [SerializeField] int lives = 4;
    [SerializeField] float hitArea = 1;
    float distance;
    bool follow = false;
    bool Dead = false;
    public AudioSource quejido;
    public AudioSource Muerte;
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = path[goal].transform.position;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= visionArea && !Dead){
            agent.destination = player.transform.position;
            follow = true;
            anim.SetBool("follow", true);
        } else {
            agent.destination = path[goal].transform.position;
            follow = false;
            anim.SetBool("follow", false);
        }
        if (distance <= hitArea && !Dead){
            anim.SetTrigger("hit");
        }

     if (agent.remainingDistance < 1 && !follow && !Dead){
        goal++;
        if (goal == path.Length){
            goal = 0;
        }
        agent.destination = path[goal].transform.position;
     }   
    }

    public void damage(){
        lives --;
        quejido.Play();
        if (lives < 0){
            Dead = true;
            anim.SetBool("Dead", true);
            Invoke("Destruir", 3);
            Muerte.Play();
        }
    }

    void Destruir(){
        Destroy(gameObject);
    }


}
