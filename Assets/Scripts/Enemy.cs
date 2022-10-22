using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Actor
{
    public SwordBehavior swordBehavior;


    private void StartCoroutineMoveUpSword()
    {
        StartCoroutine("IStartMoveSword", _targetPosition);
    }



    private void SetStandartParam()
    {
        _healthActor = 3;

        swordBehavior = SwordBehavior.Middle;
        
    }

    private void StartStandartFunctions()
    {
        StartGetKindHitEvent();
    }

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        MoveSwordOnTargetPositionEvent = new UnityEvent();
        MoveSwordOnTargetPositionEvent.AddListener(StartCoroutineMoveUpSword);
    }

    private void Start()
    {
        SetStandartParam();
        StartStandartFunctions();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            Referee.GetKindHitEvent.Invoke(this.gameObject);
        }
    }

    IEnumerator IStartMoveSword(Vector3 targetPosition)
    {
        while (true)
        {
            yield return null;
            gameObject.transform.localPosition = MoveSword(targetPosition);

            if (Math.Round(gameObject.transform.localPosition.x, 2) == Math.Round(targetPosition.x, 2))
            {
                yield break;
            }
        }
    }
}


    