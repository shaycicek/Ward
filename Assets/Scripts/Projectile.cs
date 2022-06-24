using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject model;
    public float speed;
    public int damage;
    float damageFactor;
    private Weapon weapon;
    public LayerMask enemy;
    private Character hitCharacter;
    public float lifetime;
    public ParticleSystem destroyingParticle;
    public ParticleSystem onFireParticle;
    
    private void Start()
    {

        GetComponent<Rigidbody>().AddForce(-weapon.transform.forward * speed, ForceMode.Impulse);

        onFireParticle.gameObject.SetActive(true);
        Destroy(gameObject, lifetime);
    }

    public void OnTriggerEnter(Collider other)
    {
     
        //Debug.Log("Collider layer = " + other.gameObject.layer + "Enemy layer = " + enemy);
        if (enemy == (enemy | (1 << other.gameObject.layer)))
        {

            hitCharacter = other.GetComponent<Character>();
            OnHit();
        }   
    }

    public void OnHit()
    {
        onFireParticle.gameObject.SetActive(false);
        hitCharacter.GetDamage(damage * damageFactor);
        //destroyingParticle.gameObject.SetActive(true);
        model.SetActive(false);
        Destroy(gameObject,1f);
    } 

    public void Initialize(LayerMask enemy, float damageFactor, Weapon weapon )
    {
        this.weapon = weapon;
        this.enemy = enemy;
        this.damageFactor = damageFactor;

    }

    
    //timer yaz !

}
