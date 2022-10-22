using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent MoveSwordOnTargetPositionEvent;

    [HideInInspector]
    public UnityEvent<Vector3, Vector3> GetBaseAndTargetPositionEvent;


    protected Vector3 _basePosition;
    protected Vector3 _targetPosition;

    protected int _healthActor;

    [SerializeField]
    protected float _speedMoveSword;
    public enum SwordBehavior
    {
        Up = -1,
        Middle = 0,
        Down = 1,
    }

    protected void StartGetKindHitEvent()
    {
        Referee.GetKindHitEvent.Invoke(this.gameObject);
    }

    protected void GetAndSetPositionSword(Vector3 basePosition, Vector3 targetPosition)
    {
        _basePosition = basePosition;
        transform.position = _basePosition;
        _targetPosition = targetPosition;
    }

    protected Vector3 MoveSword(Vector3 targetPosition)
    {
      return Vector3.Lerp(gameObject.transform.position, targetPosition, _speedMoveSword * Time.deltaTime);
    }

}