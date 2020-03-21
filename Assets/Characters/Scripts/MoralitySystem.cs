using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MoralitySystem : MonoBehaviour
{
    // Morality Metrics

    [field: SerializeField]
    public float Compassion
    {
        get;
        private set;
    } = 0.0f;
    [field: SerializeField]
    public float Intimidation
    {
        get;
        private set;
    } = 0.0f;
    [field: SerializeField]
    public float Rationality
    {
        get;
        private set;
    } = 0.0f;

    // AccessorMethods
    [YarnCommand("increaseCompassion")]
    void IncreaseCompassion(float val)
    {
        Compassion += val;
    }
    [YarnCommand("decreaseCompassion")]
    void DecreaseCompassion(float val)
    {
        Compassion -= val;
    }
    [YarnCommand("increaseIntimidation")]
    void IncreaseIntimidation(float val)
    {
        Intimidation += val;
    }
    [YarnCommand("decreaseIntimidation")]
    void DecreaseIntimidation(float val)
    {
        Intimidation -= val;
    }
    [YarnCommand("increaseRationality")]
    void IncreaseRationality(float val)
    {
        Rationality += val;
    }
    [YarnCommand("decreaseRationality")]
    void DecreaseRationality(float val)
    {
        Rationality -= val;
    }
}
