using UnityEngine;
using TMPro;

public class PurchaseFeed : MonoBehaviour
{
    [SerializeField] private SO_FeedDataBase _feedToPurchase;
	[SerializeField] private ButtonInvalid _invalidResponse;
	[SerializeField] private TMP_Text _costText;

    private void OnValidate()
    {
        if (!_invalidResponse) _invalidResponse = GetComponent<ButtonInvalid>();
        if (!_invalidResponse) _invalidResponse = GetComponentInChildren<ButtonInvalid>();
    }
    
	private void Start()
	{
		if (_costText) _costText.text = _feedToPurchase.FeedCost.ToString();
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
