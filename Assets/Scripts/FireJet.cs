using UnityEngine;

[RequireComponent(typeof(Animator))]

public class FireJet : MonoBehaviour
{
    private readonly string _jetFireStartTrigger = "IsAccelerateStart";
    private readonly string _isAccelerateLoopPermit = "isAccelerateLoop";

    private Animator _fire;

    private void Start()
    {
        _fire = GetComponent<Animator>();
    }

    public void Ignite()
    {
        _fire.SetTrigger(_jetFireStartTrigger);
        _fire.SetBool(_isAccelerateLoopPermit, true);
    }

    public void PutOut()
    {
        _fire.SetBool(_isAccelerateLoopPermit, false);
    }
}
