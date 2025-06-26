using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField]private List<Sword> swords;
    void Start()
    {
        swords = FindObjectsOfType<Sword>().ToList();
        SwordSpawn();
    }

    // Update is called once per frame
    public void SwordSpawn()
    {
        List<Sword> swordsSelection = new List<Sword>();
        foreach (var x in swords)
        {
            if (x.enabled == false)
            {
                swordsSelection.Add(x);
            }
            else
            {
                x.enabled = false;
            }
        }
        Debug.Log(swordsSelection.Count);
        swordsSelection[Random.Range(0, swordsSelection.Count)].enabled = true;
    }
}
