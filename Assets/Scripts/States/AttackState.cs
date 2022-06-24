using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public FollowState FollowState;
    public bool isInAttackRange;

    public override void OnEnterState()
    {
        self.animator.SetBool("isAttacking", true);    
    }

    public override void OnExitState()
    {
        self.animator.SetBool("isAttacking", false);
    }

    public override State RunCurrentState()
    {
        isInAttackRange = Physics.CheckSphere(transform.position, 
            GetComponent<Character>().attackRange, 
            GetComponent<Character>().enemy);

        if (isInAttackRange)
        {           
            transform.LookAt(GetComponent<Character>().FindClosestEnemy(transform.position,GetComponent<Character>().myWeapon.range));
            transform.Rotate(0.0f, 55.0f, 0.0f);

            GetComponent<Character>().Attack();
            return this;
        }
        else {
            return FollowState;
        }

        
    }
}
