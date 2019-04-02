using System.Collections;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float seeDistance = 30.5f;
    public float attackDistance = 5.0f;
    private UnityEngine.AI.NavMeshAgent nav;
    public Transform target;
    public Animation anim;
    public AnimationClip a_Idle;
    public float a_IdleSpeed = 1;
    public AnimationClip a_Walk;
    public float a_WalkSpeed = 2;
    public AnimationClip a_Attack;
    public float a_AttackSpeed = 2;
    public AnimationClip a_Death;
    private bool walk;
    private bool Attacka;
    public int Damage;

    void Start()
    {
        GetComponent<Animation>()[a_Idle.name].speed = a_IdleSpeed;
        GetComponent<Animation>()[a_Attack.name].speed = a_AttackSpeed;
        GetComponent<Animation>()[a_Walk.name].speed = a_WalkSpeed;
        GetComponent<Animation>().CrossFade(a_Idle.name);

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void IdleState()
    {
        nav.enabled = false;
        GetComponent<Animation>().CrossFade(a_Idle.name);
    }
    void Update()
    {
      if (anim[a_Attack.name].enabled == false)
        {
            Attacka = true;
        }
      if (Vector3.Distance(transform.position, target.transform.position) <= seeDistance)
        {
               if(anim[a_Attack.name].time > 0.9 * anim[a_Attack.name].length & target.tag == "Player")
            {
                target.GetComponent<PlayerHP>().health -= Damage;
            }
        }
      if (target == null)
        {
            IdleState();
        }
        if (Vector3.Distance(transform.position, target.transform.position) <= seeDistance & Attacka == true)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance & anim[a_Attack.name].enabled == false)
            {
                GetComponent<Animation>().CrossFade(a_Walk.name);
                walk = true;
                nav.enabled = true;
                nav.SetDestination(target.position);
            }
            else
            {
                if (target.tag == "Player")
                {
                    nav.enabled = false;
                    GetComponent<Animation>().CrossFade(a_Attack.name);
                    walk = false;
                    Vector3 lookAtPosition = target.position;
                    lookAtPosition.y = transform.position.y;
                    transform.LookAt(lookAtPosition);
                }
            }
        }
        else
        {
            GetComponent<Animation>().CrossFade(a_Idle.name);
            walk = false;
            nav.enabled = false;
        }
    }
}