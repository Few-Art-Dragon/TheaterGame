using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefState : ITurnState
{

    public void �alculateTurn(Actor player, Actor enemy)
    {
        if (player.SwordState != enemy.SwordState)
        {
            //_player.Health -= 1;
        }
    }
}
