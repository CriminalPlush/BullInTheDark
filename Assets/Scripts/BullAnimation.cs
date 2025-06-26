using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullAnimation : MonoBehaviour
{
    [SerializeField] private Texture[] bullFront;
    [SerializeField] private Texture[] bullBack;
    [SerializeField] private Texture[] bullRight;
    [SerializeField] private Texture[] bullLeft;
    [SerializeField] private Texture[] bullStunned;
    private MeshRenderer meshRenderer;
    private GameObject bull;
    private GameObject player;
    private int index;
    private enum Side
    {
        front,
        back,
        right,
        left,
        stunned
    }
    [SerializeField] private Side side;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        bull = GameObject.FindGameObjectWithTag("Bull");
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(NextFrame());
    }
    void Update()
    {
        Vector3 relativePos = bull.transform.InverseTransformPoint(player.transform.position);
        float maxCord = MathF.Max(Mathf.Abs(relativePos.x), MathF.Abs(relativePos.z));
        if (maxCord == Mathf.Abs(relativePos.x))
        {
            if (relativePos.x < 0)
            {
                side = Side.left;
            }
            else
            {
                side = Side.right;
            }
        }
        else
        {
            if (relativePos.z < 0)
            {
                side = Side.back;
            }
            else
            {
                side = Side.front;
            }
        }
        if (bull.GetComponent<BullMovement>().isStunned)
        {
            side = Side.stunned;
        }
    }

    // Update is called once per frame
    private IEnumerator NextFrame()
    {
        yield return new WaitForSeconds(0.2f);
        Texture[] textures;
        switch (side)
        {
            case Side.left:
                textures = bullLeft;
                break;
            case Side.right:
                textures = bullRight;
                break;
            case Side.front:
                textures = bullFront;
                break;
            case Side.back:
                textures = bullBack;
                break;
            case Side.stunned:
                textures = bullStunned;
                break;
            default:
                textures = bullFront;
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


