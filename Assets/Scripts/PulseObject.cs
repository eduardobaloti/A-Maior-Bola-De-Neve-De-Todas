using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PulseObject : MonoBehaviour
{
    public float scaleDuration = 3f;
    public float maxScale = 1.05f;
    public Ease easeType = Ease.OutQuad;

    public void Awake()
    {
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(0.00f,0.50f));
        Vector3 myScale = transform.localScale;

        Tween t = transform.DOScale(myScale*maxScale, scaleDuration / 2)
            .SetEase(easeType)
            .SetLoops(-1, LoopType.Yoyo);

        t.Play().SetDelay(Random.Range(0.00f, 1.00f));
    }
}