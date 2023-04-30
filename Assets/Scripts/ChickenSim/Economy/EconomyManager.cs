using UnityEngine;
using System;

public class EconomyManager : MonoBehaviour
{
    [SerializeField] private FloatVariable _eggCount;

    private DateTime _previousTime;

    private void Awake()
    {
        _eggCount.Value = 0;
    }

    public void AddEggs(int amount) => _eggCount.Add(amount);
    public void RemoveEggs(int amount) => _eggCount.Subtract(amount);

    public bool AttemptPurchase(int amount)
    {
        if (_eggCount.Value >= amount)
        {
            _eggCount.Value -= amount;
            return true;
        }
        return false;
    }

    public DateTime GetTime()
    {
        _previousTime = DateTime.Now;
        return DateTime.Now;
    }

    public TimeSpan ComparedTime()
    {
        return _previousTime.Subtract(DateTime.Now);
    }
}