using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    public static int nOfZombies = 0;
    public static int MAXZOMBIES = 24;
    private static int round = 1;
    public static List<string> wordsInWorld;
    
    private float startDelay = 3;
    private float spawnInterval;
    public PlayerObjective po;


    private void Start() {
        spawnInterval = Random.Range(3, 5);
        Invoke("SpawnZombie", startDelay);
    }

    private void SpawnZombie(){
        bool spawnSpecifiedWord = false;
        if(wordsInWorld == null){
            wordsInWorld = new List<string>();
        }
        if(!wordsInWorld.Contains(po.objective.text) && nOfZombies == MAXZOMBIES){
            spawnSpecifiedWord = true;
        }
        if(nOfZombies < MAXZOMBIES || spawnSpecifiedWord == true){
            GameObject z;
            if(spawnSpecifiedWord == true){
                z = Instantiate(zombie, transform.position, transform.rotation);
                z.transform.GetChild(1).GetChild(2).gameObject.GetComponent<TMP_Text>().text = po.objective.text;
                zombie.GetComponent<EnemyControler>().SetWord(po.objective.text);
                wordsInWorld.Add(zombie.GetComponent<EnemyControler>().word);
            }else{
                nOfZombies++;
                z = Instantiate(zombie, transform.position, transform.rotation);
                z.transform.GetChild(1).GetChild(2).gameObject.GetComponent<TMP_Text>().text = zombie.GetComponent<EnemyControler>().word;
                wordsInWorld.Add(zombie.GetComponent<EnemyControler>().word);
            }            
            spawnInterval = Random.Range(3, 5);
        }
        
        Invoke("SpawnZombie", spawnInterval);
    }

}
