public class AttackState : ITurnState
{
   
    public void ÑalculateTurn(Actor player, Actor enemy)
    {
        if (player.SwordState != enemy.SwordState)
        {
            enemy.CheckHealthEvent.Invoke();
        }
    }
}
