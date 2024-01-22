using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action PlayerTouchedEnything;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerTouchedEnything?.Invoke();
    }
}
