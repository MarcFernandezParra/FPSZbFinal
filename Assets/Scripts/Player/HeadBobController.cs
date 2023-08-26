using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
   

    private Animator camAnim;
    Rigidbody rb;
    float pSpeed;
        
    void Start(){
        rb = GetComponentInParent<Rigidbody>();
        camAnim = GetComponent<Animator>();
    }

    void Update()
    {
        //problem here, speeds not 8
        if(Mathf.Abs(rb.velocity.magnitude)>=8){
            pSpeed = rb.velocity.magnitude;
            camAnim.ResetTrigger("Run");
            camAnim.SetTrigger("Run");
        }else if(Mathf.Abs(rb.velocity.magnitude)<=8 && Mathf.Abs(rb.velocity.magnitude)>=5 && (pSpeed!=8 || pSpeed>8)) {
            pSpeed = rb.velocity.magnitude;
            camAnim.ResetTrigger("Walk");
            camAnim.SetTrigger("Walk");
        }else{
            pSpeed = rb.velocity.magnitude;
            camAnim.ResetTrigger("Idle");
            camAnim.SetTrigger("Idle");
            
        }
    }
    
}
