using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteChange : MonoBehaviour
{
    private GameObject bull;
    private GameObject player;
    private PostProcessVolume postProcessVolume;
    private Vignette vignette;
    void Start()
    {
        bull = GameObject.FindGameObjectWithTag("Bull");
        player = GameObject.FindGameObjectWithTag("Player");
        postProcessVolume = FindObjectOfType<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(bull.transform.position, player.transform.position);
        if (distance < 30)
        {
            vignette.intensity.value = 1f - (distance / 30f);
        }
    }
}
