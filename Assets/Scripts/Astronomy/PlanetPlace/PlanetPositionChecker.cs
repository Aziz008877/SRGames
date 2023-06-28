using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSocketInteractor))]
public class PlanetPositionChecker : MonoBehaviour
{
    [SerializeField] private GameObject _rightAnswer;
    [SerializeField] private PlanetPositionController _planetPositionController;
    [SerializeField] private XRSocketInteractor _xrSocketInteractor;
    [HideInInspector] public bool IsCorrectPlacement = false;

    private void Start()
    {
        _xrSocketInteractor.selectEntered.AddListener(OnSelectEnter);
        _xrSocketInteractor.selectExited.AddListener(OnSelectExit);
    }
    
    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.gameObject == _rightAnswer)
        {
            IsCorrectPlacement = true;
            _planetPositionController.TryCompleteQuiz();
        }
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        IsCorrectPlacement = false;
    }

    private void OnDestroy()
    {
        _xrSocketInteractor.selectEntered.RemoveAllListeners();
        _xrSocketInteractor.selectExited.RemoveAllListeners();
    }
}
