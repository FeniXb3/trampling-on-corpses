using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameEndTrigger : MonoBehaviour
{
    [SerializeField] private Animator theEndAnim;
    [SerializeField] private Animator sacrificesAnim;
    [SerializeField] private Text sacrifices;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            EventManager.Instance.TriggerEvent(EventType.EndGame, Dead.TotalDeaths);
            
            StartCoroutine(ShowEndScreen());
        }
    }

    IEnumerator ShowEndScreen()
    {
        yield return new WaitForSeconds(1.5f);
        EventManager.Instance.TriggerEvent(EventType.ChangeLevel, null);
        theEndAnim.SetTrigger("Show");
        sacrificesAnim.SetTrigger("Show");
        sacrifices.text = $"you sacrificed {Dead.TotalDeaths} lives";
    }
}