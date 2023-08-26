using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class MainMenu : MonoBehaviour
{

    private void Start() {
        SettingsMenu.LoadSavedConfig();
    }
    public void PlayGame(){
        //playable deck

        int count = 0;
        count = SaveManager.allTheWords == null?0:SaveManager.allTheWords.Count;


        if(count<5){
            Debug.Log("No words to play, add at least 5 words to start learning");
        }else{

            GameMng.SortedList = SaveManager.allTheWords.OrderByDescending(o=>o.level).ToList();
            count = count>=20?20:count;
            GameMng.SortedList.GetRange(0,count);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame(){
        Application.Quit();
    }
}
