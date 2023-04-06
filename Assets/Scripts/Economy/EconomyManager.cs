using UnityEngine;
using System;

namespace Economy
{
    public class EconomyManager : MonoBehaviour
    {
        private int _eggsAmount;
        
        public void AddEggs(int amount)
        {
            _eggsAmount += amount;
        }
        
        public void RemoveEggs(int amount)
        {
            if (_eggsAmount <= 0)
            {
                _eggsAmount = 0;
                return;
            }
            
            _eggsAmount -= amount;
        }
        
        public bool CanAfford(int amount)
        {
            return _eggsAmount >= amount;
        }
        
        public void BuyFeed(int amount)
        {
            if (CanAfford(amount))
            {
                RemoveEggs(amount);
            }
            else
            {
                throw new Exception("Not enough eggs");
            }
        }
        
        
    }
}