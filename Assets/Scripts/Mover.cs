using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _flyUpForce = 10;
    [SerializeField] private float _movingSpeed = 1f;
    [SerializeField] private Jet _jet;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;

    public void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void FlyUp()
    {
        _rigidbody2D.velocity = new Vector2(_movingSpeed, _flyUpForce);
        _jet.TurnOnTurboMode();
    } 

    public void ResetPosition() => transform.position = _startPosition;

    public void StartMovingForward() => _rigidbody2D.velocity = new Vector2(_movingSpeed, 0);

    public void Stop() => _rigidbody2D.velocity = new Vector2(0, 0);
}
