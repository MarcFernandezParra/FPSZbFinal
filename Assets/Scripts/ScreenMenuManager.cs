using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenMenuManager : MonoBehaviour
{
    public Image backGround;
    public TMP_Text loading;
    private TMP_Text loadingPrev;
    private float startVolume;
    private Color guiColor = Color.white;
    private bool isGuiShowing;
    private Color startColor;
    void Start()
    {   
        if(backGround.color.a == 0){
            backGround.color = startColor;
        }
        if(loading.gameObject.activeSelf == false){
            loading.gameObject.SetActive(true);
        }
        
        startColor = backGround.color;
        isGuiShowing = true;
        startVolume = AudioListener.volume;
        AudioListener.volume = 0;
        StartCoroutine(LoadingAnimation());
    }

 private IEnumerator LoadingAnimation(){
        yield return new WaitForSeconds(1f);
                
        StartCoroutine(FadeOutGUI());
   }

   private IEnumerator FadeOutGUI(){
        guiColor.a = 0.0f;
        if(isGuiShowing){
            while(backGround.color.a >0){
                yield return null;
                if(backGround.color.a > 0.5) {
                        loading.gameObject.SetActive(false);
                        AudioListener.volume = startVolume;
                    }
                backGround.color = new Color(backGround.color.r, backGround.color.g, backGround.color.b, backGround.color.a - Time.deltaTime); 
            }
            isGuiShowing = false;
        }
   }
    
}
