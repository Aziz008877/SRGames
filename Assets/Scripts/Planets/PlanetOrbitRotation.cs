using System;
using UnityEngine;

public class PlanetOrbitRotation : MonoBehaviour
{
    [SerializeField] private Transform _centerOfOrbit;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private float orbitSpeed = 20.0f;
    private void Update()
    {
        _line.SetPosition(0, _centerOfOrbit.position);
        _line.SetPosition(1, transform.position);
        transform.RotateAround(_centerOfOrbit.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
