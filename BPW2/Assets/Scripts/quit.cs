using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void End_game()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
