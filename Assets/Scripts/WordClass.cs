using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordClass
{
    // Start is called before the first frame update
    public string wordToLearn;
    public string word;
    public int level;
    
    public WordClass(string w, string wtl, int lvl){
        wordToLearn = wtl;
        word = w;
        level = lvl;
    } 

}
