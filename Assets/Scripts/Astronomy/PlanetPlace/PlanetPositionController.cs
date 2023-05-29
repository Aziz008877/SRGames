using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlanetPositionController : MonoBehaviour
{
    [SerializeField] private List<PlanetPositionChecker> _allPlanetSockets;
    [SerializeField] private UnityEvent _onPlanetPositionDone;

    public void TryCompleteQuiz()
    {
        var allTrue = _allPlanetSockets.All(socket => socket.IsCorrectPlacement == true);

        if (allTrue)
        {
            _onPlanetPositionDone?.Invoke();
        }
    }
}
