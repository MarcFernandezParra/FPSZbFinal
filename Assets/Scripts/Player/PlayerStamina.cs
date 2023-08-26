using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    private static float stamina;
    public float cheapSpeed = 2f;
    public static float fatigueTimer = 0f;
    public Image frontSTB;
    public Image backSTB;
    private static float timer;
    static PlayerMotor pm;
    
    private PlayerInput.OnFootActions onFoot;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        updateStaminaUI();  
    }

    void updateStaminaUI(){
        float fillF = frontSTB.fillAmount;
        float fillB = backSTB.fillAmount;
        float staminaFraction = stamina/maxStamina;
        if(fillB>staminaFraction){ //if sprinting
            frontSTB.fillAmount = staminaFraction;
            backSTB.color = Color.green;
            timer += Time.deltaTime;
            float percent = timer/cheapSpeed;
            backSTB.fillAmount = Mathf.Lerp(fillB, staminaFraction, percent);
        }
        if(fillF<staminaFraction){ //recover stamina
            backSTB.color = Color.green;
            timer += Time.deltaTime;
            float percent = timer/cheapSpeed;
            frontSTB.fillAmount = Mathf.Lerp(fillF, staminaFraction, stamina);
        }
        if(fillF>fillB){
            backSTB.fillAmount = frontSTB.fillAmount;
        }
    }


    public static void loseStamina(float stLoss){
        stamina-=stLoss;
        timer = 0f;
        if(stamina <= 0f){
            fatigueTimer = 100;
            pm.setTired(true);
        }
    }

    public static void healStamina(float stHeal){
        stamina+=stHeal;
        timer = 0f;
        fatigueTimer --;
         if (fatigueTimer >= 5)
        {
            fatigueTimer = 0;
            pm.setTired(false);
        }
    }
    
}
