using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private MoveDirection _moveDirection;
    [SerializeField] private float _movePoint;
    [SerializeField] private DOTweenSettings _dotweenSettings;
    [SerializeField] private UnityEvent _onObjectStartedMoving;
    [SerializeField] private UnityEvent _onObjectFinishedMoving;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void MoveObject()
    {
        switch (_moveDirection)
        {
            case MoveDirection.Horizontal:
                Move(new Vector3(_movePoint, transform.position.y, transform.position.z));
                break;
            
            case MoveDirection.Vertical:
                Move(new Vector3(transform.position.x, _movePoint, transform.position.z));
                break;
            
            case MoveDirection.Forward:
                Move(new Vector3(transform.position.x, transform.position.y, _movePoint));
                break;
        }
    }

    public void MoveBack()
    {
        Move(_startPosition);
    }

    private void Move(Vector3 moveVector)
    {
        _onObjectStartedMoving?.Invoke();
        var sequence = DOTween.Sequence();
        sequence.Append(
                transform
                    .DOMove(moveVector, _dotweenSettings.Duration)
                    .SetEase(_dotweenSettings.AnimationType))
            .OnComplete(delegate
            {
                _onObjectFinishedMoving?.Invoke();
            });
    }
}


public enum MoveDirection
{
    Horizontal,
    Vertical,
    Forward
}
