using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpen : MonoBehaviour
{
    [SerializeField] private float scale;
    [SerializeField] private float duration;

    public void OpenAnim()
    {
        LeanTween.scale(this.gameObject, new Vector2(0, 0), 0);
        LeanTween.scale(this.gameObject, new Vector2(scale, scale), duration * .5f).setEaseOutBack();
        LeanTween.scale(this.gameObject, new Vector2(1, 1), duration * .55f).setEaseOutExpo().setDelay(duration * .45f);
        StartCoroutine(WaitForAnim(duration));
    }

    public void CloseAnim()
    {

        LeanTween.scale(this.gameObject, new Vector2(scale, scale), duration * .2f).setEaseOutBack();
        LeanTween.scale(this.gameObject, new Vector2(0, 0), duration * .25f).setEaseOutExpo().setDelay(duration * .2f);
        
        StartCoroutine(WaitForClose(duration));
        
    }

    public IEnumerator WaitForAnim(float duration)
    {

        yield return new WaitForSeconds(duration);

    }

    public IEnumerator WaitForClose(float duration)
    {

        yield return new WaitForSeconds(duration);
        this.gameObject.SetActive(false);

    }

}
