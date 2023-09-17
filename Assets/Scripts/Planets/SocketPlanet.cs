using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[Serializable]
public class SocketEnteredData
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private PlanetOrbitRotation _planetOrbit;

    public void ActivateOrbit()
    {
        _lineRenderer.enabled = true;
        _planetOrbit.enabled = true;
    }
}
public class SocketPlanet : MonoBehaviour
{
    [SerializeField] private GameObject _correctPlanet;
    [SerializeField] private SocketEnteredData _socketEnteredData;
    private XRSocketInteractor _socketInteractor;
    private bool _isDone = false;
    public bool IsDone => _isDone;
    public static event Action OnItemCorrecltyPasted;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _socketInteractor = GetComponent<XRSocketInteractor>();
        _socketInteractor.selectEntered.AddListener(OnItemEntered);
    }

    private void OnItemEntered(SelectEnterEventArgs arg0)
    {
        var connectedObject = arg0.interactableObject.transform.gameObject;
        Debug.Log(connectedObject);

        if (connectedObject == _correctPlanet)
        {
            Destroy(connectedObject.gameObject);
            _isDone = true;
            _socketEnteredData.ActivateOrbit();
            OnItemCorrecltyPasted?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _correctPlanet)
        {
            Destroy(other.gameObject);
            _isDone = true;
            _socketEnteredData.ActivateOrbit();
            OnItemCorrecltyPasted?.Invoke();
        }
    }

    private void OnDestroy()
    {
        _socketInteractor.selectEntered.RemoveAllListeners();
    }
}
