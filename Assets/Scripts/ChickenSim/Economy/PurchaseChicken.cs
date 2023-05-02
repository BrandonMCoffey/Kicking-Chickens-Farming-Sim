using UnityEngine;
using TMPro;

public class PurchaseChicken : MonoBehaviour
{
    [SerializeField] private SO_ChickenDataBase _chickenToPurchase;
	[SerializeField] private ButtonInvalid _invalidResponse;
    [SerializeField] private ButtonPurchase _purchaseResponse;
	[SerializeField] private TMP_Text _costText;

    private void OnValidate()
    {
        if (!_invalidResponse) _invalidResponse = GetComponent<ButtonInvalid>();
        if (!_invalidResponse) _invalidResponse = GetComponentInChildren<ButtonInvalid>();
    }
    
	private void Start()
	{
		if (_costText) _costText.text = _chickenToPurchase.ChickenCost.ToString();
	}

    [Button]
    public void AttemptPurchase()
    {
        if (GameManager.Economy.AttemptPurchase(_chickenToPurchase.ChickenCost))
        {
            GameManager.SpawnChicken(_chickenToPurchase);
            _purchaseResponse.ConfirmPurchaseBtn();
        }
        else
        {
            if (_invalidResponse) _invalidResponse.ShakeButton();
        }
    }
}
