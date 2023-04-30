using UnityEngine;

public class PurchaseFeed : MonoBehaviour
{
    [SerializeField] private SO_FeedDataBase _feedToPurchase;
    [SerializeField] private ButtonInvalid _invalidResponse;

    private void OnValidate()
    {
        if (!_invalidResponse) _invalidResponse = GetComponent<ButtonInvalid>();
        if (!_invalidResponse) _invalidResponse = GetComponentInChildren<ButtonInvalid>();
    }

    [Button]
    public void AttemptPurchase()
    {
        if (GameManager.Economy.AttemptPurchase(_feedToPurchase.FeedCost))
        {
            GameManager.SetFeed(_feedToPurchase);
        }
        else
        {
            if (_invalidResponse) _invalidResponse.ShakeButton();
        }
    }
}
