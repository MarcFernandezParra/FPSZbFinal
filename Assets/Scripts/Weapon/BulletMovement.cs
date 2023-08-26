    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
   public float speed = 50f;
   public Transform bulletSpawnPos;
 
    void Start()
    {
        GameObject aux = GameObject.Find("BulletSpawnPoint");
        if(aux != null){
            bulletSpawnPos = aux.transform;
        }
    }
    // Update is called once per frame
    void Update ()
    {
        transform.Translate(bulletSpawnPos.forward * Time.deltaTime * speed);
    }
}
