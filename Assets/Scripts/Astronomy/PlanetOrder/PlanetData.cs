using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    [SerializeField] private AudioSource _planetAudio;
    [SerializeField] private DOTweenSettings _doTweenSettings;
    public event Action OnPlanetDataEnded; 
    
    public void SetPlanetPosition(Vector3 planetPosition)
    {
        transform
            .DOLocalMove(planetPosition, _doTweenSettings.Duration)
            .SetEase(_doTweenSettings.AnimationType)
            .OnComplete(delegate
            {
                StartCoroutine(StartPlanetExplanation());
            });
    }

    private IEnumerator StartPlanetExplanation()
    {
        _planetAudio.Play();
        yield return new WaitForSeconds(_planetAudio.clip.length + 1);
        OnPlanetDataEnded?.Invoke();
    }
}
