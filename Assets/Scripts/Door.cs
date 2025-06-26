using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Action
{
    private Quaternion baseRotation;
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    private bool isOpened = false;
    void Start()
    {
        baseRotation = transform.rotation;
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
            openSound.Play();
            yield return new WaitForSeconds(1.5f);
            closeSound.Play();
            transform.rotation = baseRotation;
            isOpened = false;
        }
    }
}
