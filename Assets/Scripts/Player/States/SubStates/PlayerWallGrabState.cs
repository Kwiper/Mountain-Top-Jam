using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    private Vector2 holdPosition;

    public bool isHoldingFallingBlock;

    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        holdPosition = player.transform.position;
        HoldPosition();
        if (isHoldingFallingBlock)
        {
            player.RB.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.RB.bodyType = RigidbodyType2D.Dynamic;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        if (!isExitingState)
        {
            HoldPosition();

            if (yInput > 0)
            {
                stateMachine.ChangeState(player.WallClimbState);
            }
            else if (yInput < 0 || !grabInput)
            {
                stateMachine.ChangeState(player.WallSlideState);
            }
        }
    }

    private void HoldPosition()
    {
        if (!isHoldingFallingBlock)
        {
            player.transform.position = holdPosition;

            player.SetVelocityX(0);
            player.SetVelocityY(0);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
