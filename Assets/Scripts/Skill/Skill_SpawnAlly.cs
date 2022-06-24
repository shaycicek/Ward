using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_SpawnAlly : Skill
{
    
    
    public override void UseSkill()
    {
        
        if(character.crystalCount>=10)
        {
            character.crystalCount -= 10;
            character.tmesh.SetText(character.crystalCount + "");
            for (int i = 0; i < 5; i++)
            {
                SpawnManager.instance.SpawnAlly(character.transform.position);
            }
            
        }

        
    }

}
