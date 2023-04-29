using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private GameObject panelToActivate;
    [SerializeField] private GameObject panelToDeactivate;
    [SerializeField] private float scale;
    [SerializeField] private float duration;

    public void ClickFeedback()
    {
        LeanTween.scale(this.gameObject, new Vector2(scale, scale), duration*.5f).setEaseOutBack();
        LeanTween.scale(this.gameObject, new Vector2(1, 1), duration*.55f).setEaseOutExpo().setDelay(duration*.45f);
        StartCoroutine(WaitForAnim(duration));
        
    }

    public void WaitCoroutine()
    {
        StartCoroutine(WaitForAnim(duration));
    }

    public IEnumerator WaitForAnim(float duration)
    {
        
        yield return new WaitForSeconds(duration);
        
        if(panelToActivate != null)
            panelToActivate.SetActive(true);
        if (panelToDeactivate != null)
            panelToDeactivate.SetActive(false);


    }

}
