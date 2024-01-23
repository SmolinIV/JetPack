using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action RecievedFatalTouch;
    public event Action TouchedUpperBlock;
    public event Action ComeDown;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IInteractable interactable))
            RecievedFatalTouch?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out UpperBlocker upperBlocker))
            TouchedUpperBlock?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out UpperBlocker upperBlocker))
            ComeDown?.Invoke();
    }
}
