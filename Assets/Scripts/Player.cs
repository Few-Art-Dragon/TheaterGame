using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Player : Actor
{
    private SwordBehavior _swordBehavior;

    public SwordBehavior swordBehavior
    {
        get
        {
            return _swordBehavior;
        }
        set
        {
            swordBehavior = _swordBehavior;
        }
    }


    private void CheckPressButton()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            _swordBehavior = SwordBehavior.Up;
            StartGetKindHitEvent();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            _swordBehavior = SwordBehavior.Middle;
            StartGetKindHitEvent();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            _swordBehavior = SwordBehavior.Down;
            StartGetKindHitEvent();
        }
    }

    

    private void StartCoroutineMoveUpSword()
    {
        StartCoroutine("IStartMoveSword", _targetPosition);
    }
    private void StartCoroutineMoveDownSword()
    {
        StartCoroutine("IStartMoveSword", _basePosition);
    }
    private void SetStandartParam()
    {
        _healthActor = 3;

        _swordBehavior = SwordBehavior.Middle;
    }

    private void StartStandartFunctions()
    {

    }

    private void Awake()
    {
        GetBaseAndTargetPositionEvent = new UnityEvent<Vector3, Vector3>();
        GetBaseAndTargetPositionEvent.AddListener(GetAndSetPositionSword);

        MoveSwordOnTargetPositionEvent = new UnityEvent();
        MoveSwordOnTargetPositionEvent.AddListener(StartCoroutineMoveUpSword);
    }

    private void Start()
    {
        SetStandartParam();
        StartStandartFunctions();
    }

    private void Update()
    {
        CheckPressButton();
    }

    private void OnDisable()
    {
        MoveSwordOnTargetPositionEvent.RemoveListener(StartCoroutineMoveUpSword);

    }

    IEnumerator IStartMoveSword(Vector3 targetPosition)
    {
        while (true)
        {
            yield return null;
            gameObject.transform.localPosition = MoveSword(targetPosition);
            
            if (Math.Round(gameObject.transform.localPosition.x,2) == Math.Round(targetPosition.x,2))
            {
                yield break;
            }  
        }
    }
}