using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStopable
{
    void StopWorking();

    void ResetCondition();

    void StartWorking();
}
