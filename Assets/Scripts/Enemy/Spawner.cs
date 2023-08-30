using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Spawner : MonoBehaviour
{
    public GameObject zombie;
    public static int nOfZombies = 0;
    public static int MAXZOMBIES = 5;
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
            Debug.Log(nOfZombies);
            GameObject z;
            if(spawnSpecifiedWord == true){
                Debug.Log("objective " + po.objective.text);

                z = Instantiate(zombie, transform.position, transform.rotation);
                z.GetComponent<EnemyControler>().auxWord = getWord(po.objective.text);
                z.GetComponent<EnemyControler>().startWord = false;
                wordsInWorld.Add(z.GetComponent<EnemyControler>().word);
                nOfZombies++;
            }else{
                nOfZombies++;
                z = Instantiate(zombie, transform.position, transform.rotation);
                z.transform.GetChild(1).GetChild(2).gameObject.GetComponent<TMP_Text>().text = zombie.GetComponent<EnemyControler>().word;
                wordsInWorld.Add(z.GetComponent<EnemyControler>().word);
            }            
        }
        
        Invoke("SpawnZombie", spawnInterval);
    }

    public WordClass getWord(string obj){
        string wtl = "";
        foreach(WordClass wc in SaveManager.allTheWords){
            if(string.Compare(wc.wordToLearn, obj) == 0){
                wtl = wc.word;
                break;
            }
        }
        
        Debug.Log(wtl +" "+ obj);
        WordClass wordClass = new WordClass(wtl, obj, 1);
        return wordClass;
    }

}
