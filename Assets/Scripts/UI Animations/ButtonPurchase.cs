using System.Collections;
using UnityEngine;

public class ButtonPurchase : MonoBehaviour
{
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject heartParent;
    [SerializeField] private float scale;
    [SerializeField] private float duration;

    private GameObject heartImg;

    public void ConfirmPurchaseBtn()
    {
        LeanTween.scale(this.gameObject, new Vector2(scale, scale), duration * .5f).setEaseOutBack();
        LeanTween.scale(this.gameObject, new Vector2(1, 1), duration * .55f).setEaseOutExpo().setDelay(duration * .45f);
        HeartAnim();
        Coroutine btnAnim = StartCoroutine(WaitForAnim(duration));

    }

    public void HeartAnim()
    {
        heartImg = Instantiate(heart,heartParent.transform);
        LeanTween.moveY(heartImg, this.transform.position.y+100, 0);
        LeanTween.scale(heartImg, new Vector3(0, 0, 0), 0);
        LeanTween.scale(heartImg, new Vector3(1,1,1), .25f).setEaseOutQuart();
        LeanTween.moveY(heartImg, this.transform.position.y+400, 1).setEaseOutQuart();
        LeanTween.scale(heartImg, new Vector3(0, 0, 0), .5f).setDelay(.25f).setEaseOutQuart();
        Coroutine heartAnim = StartCoroutine(WaitForAnim(1));
    }

    public void DestroyHeart()
    {
        if (heartImg != null)
            Destroy(heartImg);
    }

    public IEnumerator WaitForAnim(float dur)
    {
        yield return new WaitForSeconds(dur);
        DestroyHeart();

    }
}
