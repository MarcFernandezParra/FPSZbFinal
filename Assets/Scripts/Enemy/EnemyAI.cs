using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public float stopDistance =0.8f;
    NavMeshAgent nvm;
    private Animator animator;
    public Collider handCollider;
    private Transform target; 
    public Transform Pov;
    void Start()
    {
        nvm = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position,target.transform.position);
        RaycastHit hit;
         if( Physics.Raycast(Pov.position, Pov.forward, out hit, stopDistance)){               
                if(hit.collider.tag == "Player"){
                    StopEnemy();
                    ZombieAttack();
                }else{
                    if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
                        //handCollider.enabled = false;
                        nvm.enabled = true;
                        nvm.SetDestination(target.position);
                    }
                }

        }else{
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
                //handCollider.enabled = false;
                nvm.enabled = true;
                nvm.SetDestination(target.position);
            }
        }
    }

    void ZombieAttack(){
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
            animator.ResetTrigger("inRange");
            animator.SetTrigger("inRange");
            handCollider.enabled = true;
        }
    }

    void StopEnemy(){
        nvm.enabled = false;
    }
}
