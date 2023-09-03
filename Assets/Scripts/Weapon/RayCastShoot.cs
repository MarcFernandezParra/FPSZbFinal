using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour
{
    public int gunDmg = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    private Animator animator;
    public float hitForce = 0f;
    public Transform gunEnd;
    public Camera fpsCam;
    private WaitForSeconds shotDurations = new WaitForSeconds(0.07f);
    private AudioSource gunAudio;
    public PlayerHealth player;
    public ParticleSystem muzzleFlash;
    public PlayerObjective po;
    private float nextFire; 
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        gunAudio = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time>nextFire){
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());

            Vector3 shotOrigen = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;


            if(Physics.Raycast(shotOrigen, fpsCam.transform.forward, out hit, weaponRange)){
                
                EnemyControler enemy = hit.collider.GetComponent<EnemyControler>();
                if(enemy != null && po.objective.text.Equals(enemy.wordClass.wordToLearn)){
                    enemy.getDmg(gunDmg, po);
                }else if (enemy != null){
                    player.takeDmg(10f);
                }

            }else{
                //no hit shotLine.SetPosition(1, shotOrigen + (fpsCam.transform.forward * weaponRange));
            }
        }
        //zoom en zombie letra? 
    }

    private IEnumerator ShotEffect(){
        gunAudio.Play();
        animator.ResetTrigger("Shooting");
        animator.SetTrigger("Shooting");
        muzzleFlash.Play();
        yield return shotDurations;
    }
}
