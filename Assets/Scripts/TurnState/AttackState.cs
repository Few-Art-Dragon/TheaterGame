public class AttackState : ITurnState
{
    public void �alculateTurn(Actor player, Actor enemy)
    {
        if (player.SwordState != enemy.SwordState)
        {
           // _enemy.Health -= 1;
        }
    }
}
