using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent MoveSwordOnTargetPositionEvent = new UnityEvent();

    [HideInInspector]
    public UnityEvent<Vector3, Vector3> GetBaseAndTargetPositionEvent =  new UnityEvent<Vector3, Vector3>();

    public SwordBehavior SwordState;

    protected Vector3 _basePosition;
    protected Vector3 _targetPosition;

    protected int _healthActor;

    [SerializeField]
    protected float _speedMoveSword;
    



    protected void StartGetKindHitEvent()
    {
        BattleAccountant.GetKindHitEvent.Invoke(this);
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
public enum SwordBehavior
{
    Up = -1,
    Middle = 0,
    Down = 1,
}