using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingFlash : MonoBehaviour
{
    [SerializeField] private float _startScaleRatio = 0.1f;
    [SerializeField] private float _endScaleRatio = 2f;
    [SerializeField] private float _growingSpeed = 1f;

    private Vector3 _defaultScale;
    private Vector3 _endScale;

    private void Awake()
    {
        _defaultScale = transform.localScale;
        _endScale = transform.localScale * _endScaleRatio;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (transform.localScale == _endScale)
        {
            transform.localScale = _defaultScale * _startScaleRatio;
            gameObject.SetActive(false);
        }

        transform.localScale = Vector3.MoveTowards(transform.localScale, _endScale, _growingSpeed * Time.deltaTime);
    }
}
