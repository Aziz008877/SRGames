using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.VFX;

public class WarpBoostVFX : MonoBehaviour
{
    [SerializeField] private List<VisualEffect> _warpBoostEffect;
    [SerializeField] private List<float> _neededValues;
    [SerializeField] private List<float> _amounts;
    [SerializeField] private float _warpRate = 0.02f;
    [SerializeField] private float _boostTime;
    public event Action OnFinishedWarpBoosting;
    private bool _warpState = false;

    private async void Start()
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
                _amounts[0] += _warpRate;
                _warpBoostEffect[0].SetFloat("WarpAmount", _amounts[0]);
                
                _amounts[1] += _warpRate;
                _warpBoostEffect[1].SetFloat("WarpAmount", _amounts[1]);
                
                _amounts[2] += _warpRate;
                _warpBoostEffect[2].SetFloat("WarpAmount", _amounts[2]);
                yield return new WaitForSeconds(0.1f);
            }
        }

        yield return new WaitForSeconds(_boostTime);
        
        for (int i = 0; i < _warpBoostEffect.Count; i++)
        {
            while (_amounts[i] > 0)
            {
                _amounts[0] -= _warpRate;
                _warpBoostEffect[0].SetFloat("WarpAmount", _amounts[0]);
                
                _amounts[1] -= _warpRate;
                _warpBoostEffect[1].SetFloat("WarpAmount", _amounts[1]);
                
                _amounts[2] -= _warpRate;
                _warpBoostEffect[2].SetFloat("WarpAmount", _amounts[2]);
                yield return new WaitForSeconds(0.1f);
            }
        }
        OnFinishedWarpBoosting?.Invoke();
    }
}
