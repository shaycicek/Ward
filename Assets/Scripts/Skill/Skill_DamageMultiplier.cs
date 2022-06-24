using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_DamageMultiplier : Skill
{
    float skillTimer = 10.0f;
    public override void FinishSkill()
    {
        character.damageFactor /= 5;
    }

    public override void UseSkill()
    {
        if(character.crystalCount >=20)
        {
            character.crystalCount -= 20;
            character.tmesh.SetText(character.crystalCount + "");
            character.GetComponent<SkillManager>().StartSkillCountdown(this, skillTimer);
            character.damageFactor *= 5;
        }

        //Süre dolunca resetlenecek ???
    }

}
