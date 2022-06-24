using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally_IdleState : State

{
    public Ally_FollowState followState;

    public override void OnEnterState()
    {
        self.animator.SetBool("isMoving", false);
    }

    public override void OnExitState()
    {

    }

    public override State RunCurrentState()
    {
        if(player.isMoving)
        {
            return followState;
        }
        else
        {
            return this;
        }
    }

}
