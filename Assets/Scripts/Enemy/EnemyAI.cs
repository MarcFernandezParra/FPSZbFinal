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
    public bool alreadyDamaged = false;
    bool hurdling = false;
    
    public bool istriggered = false; 
    void Start()
    {
        nvm = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

/**
    Disabling the collider: i do this to only recive damage when the zombie is attacking.
    alreadyDamaged: i use this so the zombie does not deal damage more than once per attack
**/
    void Update()
    {
        if(nvm.isOnOffMeshLink){
            OffMeshLinkData mld = nvm.currentOffMeshLinkData;
            if(!hurdling && mld.offMeshLink.area == NavMesh.GetAreaFromName("Hurdle")){
                StopEnemy();
                animator.Play("Vault");
                hurdling = true;
            }
        }


        float dist = Vector3.Distance(transform.position,target.transform.position);
        RaycastHit hit;
        if(Physics.Raycast(Pov.position, Pov.forward, out hit, stopDistance)){               
                if(hit.collider.tag == "Player"){
                    StopEnemy();
                    handCollider.enabled = true;
                    ZombieAttack();
                }
        }
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Vault")){
                
            nvm.enabled = true; //if not attacking or vault, and not in range, and not close to the player, or the animation ended, move, disable hand collider and not damaged the target yet
            nvm.SetDestination(target.position);
            handCollider.enabled = false;
            alreadyDamaged = false;
        }
    }


    void ZombieAttack(){
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")){
            animator.ResetTrigger("inRange");
            animator.SetTrigger("inRange"); //attack anim on if not attacking already
        }
    }

    void StopEnemy(){
        nvm.enabled = false;
    }
}
