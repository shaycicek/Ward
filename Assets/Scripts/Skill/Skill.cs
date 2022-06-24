using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill 
{

    public Character character;
    public int skillLevel; // ??
    public int upgradeCost; // ??

    public abstract void UseSkill();


    public virtual void Initialize(Character player)
    {
        character = player;
    }

    public virtual void FinishSkill()
    {

    }


}
