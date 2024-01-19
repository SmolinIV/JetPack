using UnityEngine;

public class Player : MonoBehaviour
{
    private Mover _mover;

    private void Start()
    {
        _mover = GetComponent<Mover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _mover.FlyUp();
    }
}