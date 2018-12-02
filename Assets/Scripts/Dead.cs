using UnityEngine;

public class Dead : MonoBehaviour
{
    private void Start()
    {
        DisableInput();
        FadeOutCorpse();
    }

    private void DisableInput()
    {
        gameObject.GetComponent<Player>().enabled = false;
    }

    private void FadeOutCorpse()
    {
        gameObject.GetComponent<GrayOut>().enabled = true;
    }
}