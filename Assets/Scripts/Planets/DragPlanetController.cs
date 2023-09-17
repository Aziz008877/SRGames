using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DragPlanetController : MonoBehaviour
{
    [SerializeField] private List<SocketPlanet> _socketPlanets;
    public event Action OnAllPlanetsDone;

    private void Awake()
    {
        SocketPlanet.OnItemCorrecltyPasted += CheckAllDone;
    }

    private void CheckAllDone()
    {
        bool isAllDone = _socketPlanets.All(done => done.IsDone);

        if (isAllDone)
        {
            OnAllPlanetsDone?.Invoke();
        }
    }

    private void OnDestroy()
    {
        SocketPlanet.OnItemCorrecltyPasted -= CheckAllDone;
    }
}
