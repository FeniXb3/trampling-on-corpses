﻿using UnityEngine;

public class KillOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ShouldKill(other))
        {
            EventManager.Instance.TriggerEvent(EventType.Kill, other.gameObject);
        }
    }

    private bool ShouldKill(Collider2D other)
    {
        return other.CompareTag("Player") && other.GetComponent<Dead>() == null;
    }
}