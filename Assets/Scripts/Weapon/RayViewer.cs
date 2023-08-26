using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour
{
    /*
    this script will show us the zombie info when aiming at it*/
    public float weaponRange = 50f;
    public Camera fpsCam;
    public Canvas zombieUI;
    void Start()
    {
        //fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 shotOrigen = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
        Debug.DrawLine(shotOrigen,fpsCam.transform.forward * weaponRange, Color.green);
        RaycastHit hit;
        Canvas newZombieUI;
        if(Physics.Raycast(shotOrigen, fpsCam.transform.forward, out hit, weaponRange)){
            newZombieUI = hit.collider.GetComponentInChildren<Canvas>();
            if (newZombieUI != null){//IF AIMING TO ZOMBIE
                if(zombieUI!=null ){//IF I AIMED A ZOMBIE BEFORE
                    zombieUI.enabled = false;
                }
                newZombieUI.enabled = true;
                zombieUI = newZombieUI;
            }else if (zombieUI!= null){//IF I'M NOT AIMING A ZOMBIE ANYMORE, BUT TO A WALL
                zombieUI.enabled = false;
            }
        }else if (zombieUI != null){//IF I'M NOT AIMING A ZOMBIE ANYMORE, BUT TO THE SKY
            zombieUI.enabled = false;
        }

    }
}
