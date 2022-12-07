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

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        CheckHealthEvent.AddListener(CheckHealth);
        GetBaseAndTargetPositionEvent.AddListener(GetAndSetPositionSword);
        MoveSwordOnTargetPositionEvent.AddListener(StartCoroutineMoveUpSword);
    }

    private void Start()
    {
        _healthImages = GetComponent<HealthImages>();

        _healthActor = 3;

        swordBehavior = SwordBehavior.Middle;

        StartGetKindHitEvent();

    }

    private void Update()
    {

    }

    private void OnDisable()
    {
        CheckHealthEvent.RemoveListener(CheckHealth);
        GetBaseAndTargetPositionEvent.RemoveListener(GetAndSetPositionSword);
        MoveSwordOnTargetPositionEvent.RemoveListener(StartCoroutineMoveUpSword);
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


    