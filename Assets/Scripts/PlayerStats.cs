using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Player player;
    private bool isKnocked = true;

    protected override void Start()
    {
        base.Start();

        player= GetComponent<Player>();
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
        
        if (isKnocked)
            player.DamageEffect();
    }

    protected override void Die()
    {
        base.Die();

        player.Die();
        isKnocked = false;
    }
}
