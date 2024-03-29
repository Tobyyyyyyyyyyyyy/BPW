using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endtransition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ending()); 
    }

    IEnumerator ending()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("quit");
    }
}
