using UnityEngine;

public class PurchaseChicken : MonoBehaviour
{
    [SerializeField] private SO_ChickenDataBase _chickenToPurchase;
    [SerializeField] private ButtonInvalid _invalidResponse;

    private void OnValidate()
    {
        if (!_invalidResponse) _invalidResponse = GetComponent<ButtonInvalid>();
        if (!_invalidResponse) _invalidResponse = GetComponentInChildren<ButtonInvalid>();
    }

    [Button]
    public void AttemptPurchase()
    {
        if (GameManager.Economy.AttemptPurchase(_chickenToPurchase.ChickenCost))
        {
            GameManager.SpawnChicken(_chickenToPurchase);
        }
        else
        {
            if (_invalidResponse) _invalidResponse.ShakeButton();
        }
    }
}
