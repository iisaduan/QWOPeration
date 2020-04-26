
public class EnemyPink : Enemy
{
    public float slowHealthAmt = 0;

    /* TakeDamage
     *
     * increases enemy speed when damage is taken
     *
     */
    override public void TakeDamage(float damage, float poison)
    {
        // increase enemy speed
        base.speed += damage * slowHealthAmt;
        base.startSpeed = speed;
        // call base's (enemy's) TakeDamage method
        base.TakeDamage(damage, poison);
    }
}
