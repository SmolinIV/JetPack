using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{
    [SerializeField] private FireJet[] _fireJets;

    private float _lastPositionY;

    private bool _isTurboModeOn;

    private void Start()
    {
        _lastPositionY = transform.position.y;
        _isTurboModeOn = false;
    }

    private void FixedUpdate()
    {
        Debug.Log(_lastPositionY);
        Debug.Log(transform.position.y);

        if (_isTurboModeOn && transform.position.y < _lastPositionY)
        {
            foreach (FireJet jet in _fireJets)
                jet.PutOut();

            _isTurboModeOn = false;
        }

        _lastPositionY = transform.position.y;

    }

    public void TurnOnTurboMode()
    {
        if (_isTurboModeOn)
            return;

        _isTurboModeOn = true;

        foreach (FireJet jet in _fireJets)
            jet.Ignite();

        _lastPositionY = transform.position.y;
    }

}
