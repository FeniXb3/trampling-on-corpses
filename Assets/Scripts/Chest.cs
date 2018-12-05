using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] private ParticleSystem shineBurst;
    [SerializeField] private Animator fadePanel;
    [SerializeField] private Animator theEndAnim;
    [SerializeField] private Animator sacrificesAnim;
    [SerializeField] private Text sacrifices;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            shineBurst.Emit(100);
            StartCoroutine(HidePlayerBody());
            StartCoroutine(ShowEndScreen());
        }
    }

    IEnumerator HidePlayerBody()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject.FindWithTag("Player").GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
    
    IEnumerator ShowEndScreen()
    {
        yield return new WaitForSeconds(1.5f);
        fadePanel.SetTrigger("SceneExit");
        theEndAnim.SetTrigger("Show");
        sacrificesAnim.SetTrigger("Show");
        sacrifices.text = $"you sacrificed {Dead.TotalDeaths} lives";
    }
}