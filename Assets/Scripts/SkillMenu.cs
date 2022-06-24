using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour
{
    public static bool SkillUsed = false;
    Skill skill1;
    Skill skill2;
    Skill skill3;
    public Button spawnAllyButton;
    public Button damageMultipButton;
    public Character player;

    // Update is called once per frame
    private void Start()
    {
        player = GameManager.instance.player;
        skill1 = new Skill_SpawnAlly();
        skill1.Initialize(GameManager.instance.player);
        skill2 = new Skill_DamageMultiplier();
        skill2.Initialize(GameManager.instance.player);
    }
    void Update()
    {
        
    }

    public void SpawnAllies()
    {

        skill1.UseSkill();
        if(player.crystalCount<10)
        {
            spawnAllyButton.interactable = false;
        }
    }

    public void DamageMultiplier()
    {

        skill2.UseSkill();
        if (player.crystalCount < 20)
        {
            damageMultipButton.interactable = false;
        }
    }

    public void ArealAttack()
    {

    }
}
