using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlackholeState : PlayerState
{
    private float flyTime = .4f;
    private bool skiilUsed;

    private float defultGravity;
    
    public PlayerBlackholeState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        defultGravity = player.rb.gravityScale;
        
        skiilUsed = false;
        stateTimer = flyTime;
        rb.gravityScale = 0;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer > 0)
            rb.velocity = new Vector2(0, 15);

        if (stateTimer < 0)
        {
            rb.velocity = new Vector2(0, -.1f);

            if (!skiilUsed)
            {
                if (player.skill.blackhole.CanUseSkill())
                    skiilUsed = true;
            }
        }

        if (player.skill.blackhole.SkillCompleted())
            stateMachine.ChangeState(player.airState);
    }

    public override void Exit()
    {
        base.Exit();

        player.rb.gravityScale = defultGravity;
        player.fx.MakeTransperent(false);
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}
