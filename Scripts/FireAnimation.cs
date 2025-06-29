using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    [SerializeField] private Texture[] fire;
    private MeshRenderer meshRenderer;
    private int index;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(NextFrame());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator NextFrame()
    {
        yield return new WaitForSeconds(0.2f);
        index++;
        if (index >= fire.Length)
        {
            index = 0;
        }
        meshRenderer.material.mainTexture = fire[index];
        StartCoroutine(NextFrame());
    }
}
