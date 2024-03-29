using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    // Start is called before the first frame update
    public void start_game(string scenename)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
