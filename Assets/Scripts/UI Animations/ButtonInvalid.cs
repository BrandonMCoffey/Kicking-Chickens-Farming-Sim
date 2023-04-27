using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Economy;

public class ButtonInvalid : MonoBehaviour
{
    [SerializeField] private int cost;

    [SerializeField] private float shakeAmount;
    [SerializeField] private float vertShake;
    [SerializeField] private float duration;
    [SerializeField] private GameObject denyText;

    [SerializeField] private float growAmount;
    [SerializeField] private float growDuration;

    [SerializeField] private EconomyManager eco;

    public void ChackIfValidPurchase()
    {
        if (!eco.CanAfford(cost))
            ShakeButton();
        else if (eco.CanAfford(cost))
            PurchaseAnim();
    }

    public void ShakeButton()
    {
        float posOrigX = this.transform.position.x;
        float posOrigY = this.transform.position.y;

        LeanTween.moveX(this.gameObject, posOrigX + shakeAmount, duration * .25f).setEaseInQuint();
        LeanTween.moveX(this.gameObject, posOrigX-shakeAmount, duration * .5f).setEaseInOutQuint().setDelay(duration *.25f);
        LeanTween.moveX(this.gameObject, posOrigX + shakeAmount*.5f, duration * .25f).setEaseOutQuint().setDelay(duration *.75f);

        LeanTween.moveY(this.gameObject, posOrigY + vertShake, duration * .25f).setEaseInQuint();
        LeanTween.moveY(this.gameObject, posOrigY -vertShake, duration * .5f).setEaseInOutQuint().setDelay(duration * .25f);
        LeanTween.moveY(this.gameObject, posOrigY + vertShake * .5f, duration * .25f).setEaseOutQuint().setDelay(duration * .75f);

        //LeanTween.moveLocalY(this.gameObject, vertShake, duration / 2);
        //LeanTween.moveLocalY(this.gameObject, -vertShake, duration / 2).setDelay(duration/2);

        if (denyText != null)
            denyText.SetActive(true);
        StartCoroutine(WaitForAnim(duration));

        //Debug.Log("shake button");
    }

    private IEnumerator WaitForAnim(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (denyText != null)
            denyText.SetActive(false);
    }

    public void PurchaseAnim()
    {
        Debug.Log("valid purchase");
    }

}
