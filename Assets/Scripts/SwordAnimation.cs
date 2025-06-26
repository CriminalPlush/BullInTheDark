using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    [SerializeField] private Texture[] sword;
    [SerializeField] private Texture[] swordActivated;
    [SerializeField] private Texture[] swordDemolished;
    private MeshRenderer meshRenderer;
    private int index;
    public enum Side
    {
        common,
        activated,
        demolished
    }
    [SerializeField] public Side side;
    private GameObject player;
    private GameObject bull;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(NextFrame());
        player = GameObject.FindGameObjectWithTag("Player");
        bull = GameObject.FindGameObjectWithTag("Bull");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(bull.transform.position, player.transform.position) < FindAnyObjectByType<Interaction>().interactionDistance)
        {
            side = Side.activated;
        }
        else
        {
            side = Side.common;
        }
    }
    private IEnumerator NextFrame()
    {
        yield return new WaitForSeconds(0.2f);
        Texture[] textures;
        switch (side)
        {
            case Side.common:
                textures = sword;
                break;
            case Side.activated:
                textures = swordActivated;
                break;
            case Side.demolished:
                textures = swordDemolished;
                break;
            default:
                textures = sword;
                break;
        }
        index++;
        if (index >= textures.Length)
        {
            index = 0;
        }
        meshRenderer.material.mainTexture = textures[index];
        StartCoroutine(NextFrame());
    }
}
