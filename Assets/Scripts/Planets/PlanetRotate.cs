using UnityEngine;
public class PlanetRotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private bool _canRotate = true;
    private void Update()
    {
        if (_canRotate)
        {
            transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        }
    }
}
