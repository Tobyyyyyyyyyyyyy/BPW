using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public float transition_duration;
    public float transition_strenght;
    public GameObject triggerTag;
    public float someValue;
    public Material map;

    public float someValue2;
    public Material wood;
    public float transition_duration2;
    public float transition_strenght2;

    public Material mirrors;


    public void Start()
    {
        Material transition_material = GetComponent<Material>();
        map.SetFloat("_texturetrans", 0);

        Material transition_wood = GetComponent<Material>();
        wood.SetFloat("_colortrans", 0);

        Material transition_houseofmirrors = GetComponent<Material>();
        mirrors.SetFloat("_houseofmirrorsslider", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered!");

       // if (other.gameObject == triggerTag)
       //{
            Debug.Log("Trigger done!");
            StartCoroutine(transition());
        StartCoroutine(transitionwood());
        StartCoroutine(transitionhouseofmirrors());

       // }
    }


    public IEnumerator transition()
    {
        float elapsed_time = 0;

        //Material transition_material = GetComponent<Material>();
        //Debug.Log("Transition material: " + transition_material.name);

        while (elapsed_time < transition_duration)
        {
            elapsed_time += Time.deltaTime;
            transition_strenght = Mathf.Lerp(0, 1, elapsed_time / transition_duration);
            //transition_material.SetFloat("_texturetrans", transition_strenght);
            map.SetFloat("_texturetrans", transition_strenght);

            yield return null;
        }
    }

    public IEnumerator transitionwood()
    {
        float elapsed_time = 0;

        //Material transition_material = GetComponent<Material>();
        //Debug.Log("Transition material: " + transition_material.name);

        while (elapsed_time < transition_duration2)
        {
            elapsed_time += Time.deltaTime;
            transition_strenght2 = Mathf.Lerp(0, 1, elapsed_time / transition_duration2);
            wood.SetFloat("_colortrans", transition_strenght2);

            yield return null;
        }
    }

    public IEnumerator transitionhouseofmirrors()
    {
        float elapsed_time = 0;

        //Material transition_material = GetComponent<Material>();
        //Debug.Log("Transition material: " + transition_material.name);

        while (elapsed_time < transition_duration)
        {
            elapsed_time += Time.deltaTime;
            transition_strenght = Mathf.Lerp(0, 1, elapsed_time / transition_duration);
            //transition_material.SetFloat("_texturetrans", transition_strenght);
            mirrors.SetFloat("_houseofmirrorsslider", transition_strenght);

            yield return null;
        }
    }
}


