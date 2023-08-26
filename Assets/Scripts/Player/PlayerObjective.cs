using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerObjective : MonoBehaviour
{
    public TMP_Text objective;
    void Start()
    {
        
        var random = new System.Random();
        int rndIndex = random.Next(GameMng.SortedList.Count);
        objective.text = GameMng.SortedList[rndIndex].wordToLearn;
    }

    public void ChangeObjective(){
        var random = new System.Random();
        int rndIndex = random.Next(GameMng.SortedList.Count);
        objective.text = GameMng.SortedList[rndIndex].wordToLearn;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
