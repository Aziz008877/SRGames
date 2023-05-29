using DG.Tweening;
using UnityEngine;

public class PlanetSelfRotate : MonoBehaviour
{
    [SerializeField] private DOTweenSettings _dotweenSettings;

    private void Start()
    {
        transform.DORotate(new Vector3(0f, 360f, 0f), _dotweenSettings.Duration, RotateMode.FastBeyond360)
            .SetEase(_dotweenSettings.AnimationType)
            .SetLoops(-1, LoopType.Incremental);
    }
}
