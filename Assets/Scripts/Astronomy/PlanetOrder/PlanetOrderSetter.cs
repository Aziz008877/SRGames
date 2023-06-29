using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class PlanetOrderSetter : MonoBehaviour
{
    [SerializeField] private List<PlanetData> _planets;
    [SerializeField] private List<Vector3> _planetPositions;
    [SerializeField] private UnityEvent _onPlanetDatasEnded;
    private int _currentPlanetID = 0;

    private async void Start()
    {
        foreach (var planet in _planets)
        {
            planet.OnPlanetDataEnded += IncreasePlanetID;
        }

        await Task.Delay(11000);
        SetPlanet();
    }

    private void SetPlanet()
    {
        _planets[_currentPlanetID].SetPlanetPosition(_planetPositions[_currentPlanetID]);
    }

    private void IncreasePlanetID()
    {
        if (_currentPlanetID < _planets.Count - 1)
        {
            _currentPlanetID++;
            SetPlanet();
        }
        else
        {
            _onPlanetDatasEnded?.Invoke();
        }
    }

    private void OnDestroy()
    {
        foreach (var planet in _planets)
        {
            planet.OnPlanetDataEnded -= IncreasePlanetID;
        }
    }
}
