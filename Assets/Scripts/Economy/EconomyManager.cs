using UnityEngine;
using System;
using TMPro;
using UnityEngine.Serialization;

namespace Economy
{
    public class EconomyManager : MonoBehaviour
    {
        public static  EconomyManager Instance;
        
        private int _eggsAmount;
        
        private DateTime _previousTime;
        
        [SerializeField] private TextMeshProUGUI eggsAmountMain;
        [SerializeField] private TextMeshProUGUI eggsAmountPurchaseScreen;
        [SerializeField] private TextMeshProUGUI eggsAmountUpgradeScreen;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddEggs(int amount)
        {
            _eggsAmount += amount;
            eggsAmountMain.text = _eggsAmount.ToString();
            eggsAmountPurchaseScreen.text = _eggsAmount.ToString();
            eggsAmountUpgradeScreen.text = _eggsAmount.ToString();
        }
        
        public void RemoveEggs(int amount)
        {
            if (_eggsAmount <= 0)
            {
                _eggsAmount = 0;
                eggsAmountMain.text = _eggsAmount.ToString();
                eggsAmountPurchaseScreen.text = _eggsAmount.ToString();
                eggsAmountUpgradeScreen.text = _eggsAmount.ToString();
                return;
            }
            
            _eggsAmount -= amount;
            eggsAmountMain.text = _eggsAmount.ToString();
            eggsAmountPurchaseScreen.text = _eggsAmount.ToString();
            eggsAmountUpgradeScreen.text = _eggsAmount.ToString();
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
                Debug.Log("Not enough eggs");
            }
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
}