using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = _player.transform.position.x + _xOffset;
        transform.position = currentPosition;
    }
}