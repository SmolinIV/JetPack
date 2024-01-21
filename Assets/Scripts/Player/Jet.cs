using UnityEngine;

public class Jet : MonoBehaviour
{
    [SerializeField] private FireJet[] _fireJets;

    private JetSoundPlayer _sound;
    private float _lastPositionY;
    private bool _isTurboModeOn;

    private void Start()
    {
        _sound = GetComponent<JetSoundPlayer>();

        _lastPositionY = transform.position.y;
        _isTurboModeOn = false;
    }

    private void FixedUpdate()
    {
        if (_isTurboModeOn && transform.position.y < _lastPositionY)
        {
            foreach (FireJet jet in _fireJets)
                jet.PutOut();

            _isTurboModeOn = false;
            _sound.TurnOff();
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

        _sound.TurnOn();
        _lastPositionY = transform.position.y;
    }
}
