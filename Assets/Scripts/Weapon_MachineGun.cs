using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_MachineGun : Weapon
{

    

    public override void Attack()
    {
        Projectile proj = Instantiate(projectile);
        proj.Initialize(enemy, damageFactor , this);
        //gameObject.transform.LookAt(character.FindClosestEnemy(character.transform.position, 50)); // KALDIR!
        proj.transform.position = bulletHole.position;


    }

}
