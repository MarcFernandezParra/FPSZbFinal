using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelLoaded : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OnLevelWasLoaded();
    }

    void OnLevelWasLoaded()
{
    if (FindObjectOfType<PlayerLook>() != null)
    {
        Cursor.visible = false;
        Screen.lockCursor = true;
    }
    else
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
    }
}
}
