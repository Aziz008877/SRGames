using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Zenject;
public class WarpBoostVFX : MonoBehaviour
{
    [SerializeField] private List<VisualEffect> _warpBoostEffect;
    [SerializeField] private List<float> _neededValues;
    [SerializeField] private List<float> _amounts;
    [SerializeField] private float _warpRate = 0.02f;
    [SerializeField] private float _boostTime;
    [Inject] private PokeButton _pokeButton;
    private bool _isFlying = false;
    public event Action OnFinishedWarpBoosting;

    private void Awake()
    {
        _pokeButton.OnButtonPressed += OnButtonClicked;
    }

    private void OnButtonClicked()
    {
        StartCoroutine(ActivateWarp());
    }

    private IEnumerator ActivateWarp()
    {
        for (int i = 0; i < _warpBoostEffect.Count; i++)
        {
            _amounts[i] = _warpBoostEffect[i].GetFloat("WarpAmount");
            _warpBoostEffect[i].Play();
        }
        
        for (int i = 0; i < _warpBoostEffect.Count; i++)
        {
            while (_amounts[i] < _neededValues[i])
            {
                IncreaseWarpEffect(0);
                IncreaseWarpEffect(1);
                IncreaseWarpEffect(2);
                yield return new WaitForSeconds(0.1f);
            }
        }

        yield return new WaitForSeconds(_boostTime);
        
        for (int i = 0; i < _warpBoostEffect.Count; i++)
        {
            while (_amounts[i] > 0)
            {
                DecreaseWarpEffect(0);
                DecreaseWarpEffect(1);
                DecreaseWarpEffect(2);
                yield return new WaitForSeconds(0.1f);
            }
        }
        
        OnFinishedWarpBoosting?.Invoke();
    }
    
    private void IncreaseWarpEffect(int index)
    {
        _amounts[index] += _warpRate;
        _warpBoostEffect[index].SetFloat("WarpAmount", _amounts[index]);
    }

    private void DecreaseWarpEffect(int index)
    {
        _amounts[index] -= _warpRate;
        _warpBoostEffect[index].SetFloat("WarpAmount", _amounts[index]);
    }

    private void OnDestroy()
    {
        _pokeButton.OnButtonPressed -= OnButtonClicked;
    }
}
