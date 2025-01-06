using UnityEngine;

public class EventFrequencyManager : MonoBehaviour
{
    [SerializeField] enum Frequency { None, OncePerYear, Quarterly, Monthly };
    [SerializeField] private Frequency eventFrequency;

    public bool ShouldEventOccur(int currentMonth)
    {
        return eventFrequency == Frequency.OncePerYear && currentMonth == 1;
    }
}
