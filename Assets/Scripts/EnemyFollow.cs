using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public float TargetDistance;
    public float LookDistance;
    public float MoveSpeed;
    public float AttackDistance;

    public Transform target;
    public NavMeshAgent nav;
    public bool Dead = false;

    private Animator anim;

    private void Start()
    {
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        TargetDistance = Vector3.Distance(target.position, transform.position);

        //Idle
        if (LookDistance < TargetDistance)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Damaged", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Following", false);
        }

        //Follow
        if (LookDistance >= TargetDistance && Dead != true)
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

            LookAtPlayer();
            MoveSpeed = 1.5f;
            transform.LookAt(target);
            anim.SetBool("Idle", false);
            anim.SetBool("Damaged", false);
            anim.SetBool("Following", true);
            anim.SetBool("Attacking", false);
        }

        //Attack
        if (AttackDistance >= TargetDistance)
        {
            MoveSpeed = 0;
            anim.SetBool("Idle", false);
            anim.SetBool("Attacking", true);
            anim.SetBool("Following", false);
            anim.SetBool("Damaged", false);
            anim.SetBool("Kicked", false); 

        }
    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime + 2);
    }
}