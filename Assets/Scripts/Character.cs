using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //Anim State Variables
    public Animator animator;
    public bool isDead;
    public bool isAttacking;
    public bool isMoving;
    //Player Var
    public Button spawnAllyButton;
    public Button damageMultiplier;
    //Char Variables
    public float charHealth;
    public float currentHealth;
    public float damageFactor; // Damage Çarpaný
    public Weapon myWeapon;
    public float movementSpeed;
    public float attackRange;
    public float sightRange;
    public GameObject model;
    //
    public LayerMask player;
    public LayerMask enemy;
    public LayerMask ally;
    //
    public int crystalCount;
    public int maxMineral;
    public float minRange;

    float timer=0;
    public HealthBar healthBar;
    public TextMeshProUGUI tmesh;
    public ParticleSystem deathParticle;

    private void Start()
    {
        timer = 0;
        currentHealth = charHealth;
        crystalCount = 0;
        if(gameObject.tag == "Player")
        {
            tmesh.SetText(crystalCount + "");
        }        
        healthBar.SetMaxHealth(charHealth);
        //mineralBar.SetMaxHealth(maxMineral);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            //Animation
            //DÜZENLENECEK
            Die();
            //Destroy(gameObject , 0.2f);
        }

        
        
    }
    public void Attack ()
    {
        timer += Time.deltaTime;
        
        if (timer>=.2f && Physics.CheckSphere(transform.position, myWeapon.range, enemy)) {
            //mainCharacter.LookAt(FindClosestEnemy(transform.position, myWeapon.range).position);
            myWeapon.InitializeWeapon(this, enemy, damageFactor);
            myWeapon.Attack();
            timer = 0;
        }

    }

    public void Move(Vector2 movementInput)
    {
                //Yapýlacak!!!!
    }

    // defaultMove fonksiyonuyla karakterin verdiðimiz Vector3 pozisyonuna direkt olarak gitmesini saðlayacagýz.
    public void DefaultMove(Vector3 vector)  
    {
        //Yapýlacak!!
    }

    public void Interact(Interactable interactable)
    {
        /*Mineral Toplama ve Ekleme, Character Sýnýfýný genel bir sýnýf yaptýgýmýz için 
        interactable objelerle temas durumunda tag check ettim ??? */
        if(interactable.tag == "Mineral" && gameObject.tag == "Player") {
            /*crystalCount+= interactable.GetComponent<Mineral>().amount;            
            tmesh.SetText(crystalCount + "");
            if (crystalCount < 10)
            {
                spawnAllyButton.interactable = false;
                damageMultiplier.interactable = false;

            }
            else if (crystalCount >= 10 && crystalCount < 20)
            {
                spawnAllyButton.interactable = true;
                damageMultiplier.interactable = false;
            }
            else
            {
                spawnAllyButton.interactable = true;
                damageMultiplier.interactable = true;
            } */
            //mineralBar.SetHealth(crystalCount);
        }
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        //deathParticle.gameObject.SetActive(true); // Bir kez çalýþtýr!        
        Instantiate(deathParticle , transform.position , Quaternion.identity).gameObject.SetActive(true);
        if(gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
            
        }else
        {
            Destroy(gameObject);
        }
        
        

    }

    public void GetDamage(float damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void LookAtDirection(/*içine bir þey gelecek mi ?*/ )
    {

    }

    public void SetWeapon(Weapon weapon)
    {
        myWeapon = weapon;
    }

    public void MultiplyDamage()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            Interact(other.GetComponent<Interactable>());            
        }
    }

    public Transform FindClosestEnemy(Vector3 center , float radius)
    {        
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        Collider[] hitColliders = Physics.OverlapSphere(center, radius, enemy);
        foreach (var hitCollider in hitColliders)
        {
            if (enemy == (enemy | (1 << hitCollider.gameObject.layer)))
            {
                Vector3 directionToTarget = hitCollider.gameObject.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;

                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = hitCollider.gameObject.transform;
                }
            }            
        }
        return bestTarget;
    }
    
    public void Initialize(float charHealth , float damageFactor , float movementSpeed , float attackRange , float sightRange)
    {
        this.charHealth = charHealth;
        this.damageFactor = damageFactor;
        this.movementSpeed = movementSpeed;
        this.attackRange = attackRange;
        this.sightRange = sightRange;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, minRange);
    }




}
