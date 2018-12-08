﻿using UnityEngine;

public class Dead : MonoBehaviour
{
    public static int TotalDeaths;
    
    private void Start()
    {
        ClearSavedPlayerColor();
        DisableInput();
        FadeOutCorpse();
        PlayDyingAnimation();
        MakeCorpseWalkable();
        BlockPosition();
        TotalDeaths++;
    }

    private void ClearSavedPlayerColor()
    {
        PlayerPrefsExtensions.DeleteColorKey("playerColor");
    }

    private void BlockPosition()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.constraints |= RigidbodyConstraints2D.FreezePositionX;
        rb.mass = 999999f; // my suggestion of fixing being able to move dead corpse around
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