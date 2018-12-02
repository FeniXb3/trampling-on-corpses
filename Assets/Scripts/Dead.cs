using UnityEngine;

public class Dead : MonoBehaviour
{
    private void Start()
    {
        DisableInput();
        FadeOutCorpse();
        PlayDyingAnimation();
        MakeCorpseWalkable();
        BlockPosition();
    }

    private void BlockPosition()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
    }

    private void MakeCorpseWalkable()
    {
        gameObject.tag = "Ground";
        gameObject.layer = LayerMask.NameToLayer("Ground");
    }

    private void PlayDyingAnimation()
    {
        var animator = GetComponent<Animator>();
        animator.SetTrigger("Die");
        animator.SetBool("Dead", true);
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