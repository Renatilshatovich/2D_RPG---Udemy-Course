using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    public int comboCounter { get; private set; }

    private float lastTimeAttacked;
    private float combooWindow = 2;
    
    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {}

    public override void Enter()
    {
        base.Enter();
        
        AudioManager.instance.PlaySFX(2);
        
        xInput = 0;

        if (comboCounter > 2 || Time.time >= lastTimeAttacked + combooWindow)
            comboCounter = 0;
        
        player.anim.SetInteger("ComboCounter", comboCounter );

        float attackDir = player.facingDir;
        if (xInput != 0)
            attackDir = xInput;
        
        player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);
        stateTimer = 0.1f;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            player.SetZeroVelocity();        
        if(triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }

    public override void Exit()
    {
        base.Exit();
        
        player.StartCoroutine("BusyFor", .15f);

        comboCounter++;
        lastTimeAttacked = Time.time;
    }
}
