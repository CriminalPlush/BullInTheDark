using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int HP = 1;
    [SerializeField] private GameObject deathPanel;
    void Update()
    {
        if (HP <= 0)
        {
            StartCoroutine(Die());
        }
    }


    public void GetDamage()
    {
        HP--;
    }

    private IEnumerator Die()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
