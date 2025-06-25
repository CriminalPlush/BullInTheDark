using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfDisabled : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField] private MonoBehaviour script;
    // Update is called once per frame
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();   
    }
    void Update()
    {
        meshRenderer.enabled = script.enabled;
    }
}
