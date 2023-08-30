using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControler : MonoBehaviour
{
    public float maxHealth = 3f;
    private float currentHealth;
    public static int dmg = 30;
    //falta el caracter a aprender
    public Image frontSTB;
    public Image backSTB;
    public string word;
    public static int deadZombies = 0;
    public static int totalZombies = 30;
    public WordClass wordClass;    
    public TMP_Text text;
    public System.Action OnDeath;
    public bool startWord = true;
    public WordClass auxWord;

    // Start is called before the first frame update
    void Start()
    { 
        
        if(PlayerPrefs.GetInt("zombies", -2) ==-2){
            totalZombies = 30;
        }else{
            totalZombies = PlayerPrefs.GetInt("zombies");
        }

        currentHealth = maxHealth;
        
        var random = new System.Random();
        int rndIndex = random.Next(GameMng.SortedList.Count);
        
        gameObject.transform.GetChild(1).GetChild(2).gameObject.GetComponent<TMP_Text>().outlineWidth = 0.2f;
        gameObject.transform.GetChild(1).GetChild(2).gameObject.GetComponent<TMP_Text>().outlineColor = Color.black;
        
        if(startWord){    
            word = GameMng.SortedList[rndIndex].word;
            wordClass = GameMng.SortedList[rndIndex];
        }else{
            word = auxWord.word;
            wordClass = auxWord;
        }
        gameObject.transform.GetChild(1).GetChild(2).gameObject.GetComponent<TMP_Text>().text = word;
    }

    // Update is called once per frame
    void Update()
    {
        updateZombiUI();
    }

    
    public void getDmg(int dmg, PlayerObjective po){
        
        currentHealth -= dmg;
        updateZombiUI();
        if(currentHealth<=0){
            
            deadZombies++;
            if(deadZombies == totalZombies){//1){
                DeathCamera.typeOfScreen = 2;
                DeathCamera.deathCamera.me.ShowDeathAnim();
                deadZombies = 0;
            }

            gameObject.SetActive(false);
            po.ChangeObjective();
            Spawner.nOfZombies --;
        }
    }

    void updateZombiUI()
    {
        float timer = 1f;
        float cheapSpeed = .2f;
        float fillF = frontSTB.fillAmount;
        float fillB = backSTB.fillAmount;
        float healthFraction = currentHealth/maxHealth;

        frontSTB.fillAmount = healthFraction;
        backSTB.color = Color.black;
        timer += Time.deltaTime;
        float percent = timer/cheapSpeed;

        if(startWord==false){
            word = auxWord.word;
            wordClass = auxWord;
        }

        backSTB.fillAmount = Mathf.Lerp(fillB, healthFraction, percent);
    }

    
}
