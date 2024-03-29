using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class triggervfx : MonoBehaviour
{
    public VisualEffect visualEffect;

    private void Start()
    {
        // Make sure the Visual Effect GameObject is initially inactive
        visualEffect.gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the GameObject entering the trigger zone has a specific tag (optional)
        if (other.CompareTag("Player"))
        {
            // Activate the Visual Effect
            visualEffect.gameObject.SetActive(true);

            // You can also play the Visual Effect if it's a particle system
            // visualEffect.Play();
        }
    }




}
