using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyImagesController : HealthImages
{
    private void OnEnable()
    {
        OnDisableHealthSprite.AddListener(DisableHealthSprite);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        OnDisableHealthSprite.RemoveListener(DisableHealthSprite);
    }
}
