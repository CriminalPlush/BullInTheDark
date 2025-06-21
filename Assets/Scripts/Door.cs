using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Action
{
    private Quaternion baseRotation;
    [SerializeField] private float y;
    private bool isOpened = false;
    void Start()
    {
        baseRotation = transform.rotation;
        y = transform.rotation.y;
    }
    public void Act()
    {
        StartCoroutine(Open());
    }
    private IEnumerator Open()
    {
        if (!isOpened)
        {
            isOpened = true;
            transform.rotation = baseRotation * Quaternion.Euler(0,88f,0);
            yield return new WaitForSeconds(1.5f);
            transform.rotation = baseRotation;
            isOpened = false;
        }
    }
}
