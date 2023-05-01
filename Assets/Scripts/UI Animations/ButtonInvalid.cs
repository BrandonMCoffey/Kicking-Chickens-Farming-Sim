using System.Collections;
using UnityEngine;

public class ButtonInvalid : MonoBehaviour
{
    [SerializeField] private float shakeAmount;
    [SerializeField] private float vertShake;
    [SerializeField] private float duration;
    [SerializeField] private GameObject denyText;

    [SerializeField] private float growAmount;
    [SerializeField] private float growDuration;

    public void ShakeButton()
    {
        var pos = transform.position;

        LeanTween.moveX(gameObject, pos.x + shakeAmount, duration * .25f).setEaseInQuint();
        LeanTween.moveX(gameObject, pos.x-shakeAmount, duration * .5f).setEaseInOutQuint().setDelay(duration *.25f);
        LeanTween.moveX(gameObject, pos.x + shakeAmount*.5f, duration * .25f).setEaseOutQuint().setDelay(duration *.75f);

        LeanTween.moveY(gameObject, pos.y + vertShake, duration * .25f).setEaseInQuint();
        LeanTween.moveY(gameObject, pos.y -vertShake, duration * .5f).setEaseInOutQuint().setDelay(duration * .25f);
        LeanTween.moveY(gameObject, pos.y + vertShake * .5f, duration * .25f).setEaseOutQuint().setDelay(duration * .75f);

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
}
