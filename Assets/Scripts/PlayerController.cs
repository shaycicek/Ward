using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public FixedJoystick variableJoystick;
    public Rigidbody rb;
    public Character character;
    public Transform mainCharacter;

    private void Awake()
    {
        character = GetComponent<Character>();
    }
    private void Start()
    {
        
    }

    public void FixedUpdate()
    {

        Attack();
        if(variableJoystick.Vertical !=0 && variableJoystick.Horizontal!=0)
        {
            character.isMoving = true;
            Vector3 move = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            //transform.LookAt(transform.position + move);
            rb.MovePosition(gameObject.transform.position + move * Time.fixedDeltaTime * speed);
            Vector3 lookTarget = transform.position + move.normalized;            
            transform.LookAt(lookTarget);
            Vector3 direction = lookTarget - transform.position;
            if(!character.isAttacking)
            {
                character.model.transform.LookAt(lookTarget);
            }
        }
        else
        {
            character.isMoving = false;
        }



        //Quaternion rot = Quaternion.LookRotation(direction, transform.up);

    }

    public void InputHandler()
    {
        
    }

    public void Attack()
    {
         //BU KISIM SORULACAK?
        if (Physics.CheckSphere(transform.position, character.myWeapon.range, character.enemy))
        {
            character.isAttacking = true;
            mainCharacter.transform.LookAt(new Vector3(character.FindClosestEnemy(transform.position, character.myWeapon.range).position.x,
    character.FindClosestEnemy(transform.position, character.myWeapon.range).position.y,
    character.FindClosestEnemy(transform.position, character.myWeapon.range).position.z));
            mainCharacter.transform.Rotate(-mainCharacter.transform.rotation.x + 5.0f, mainCharacter.rotation.y + 53.0f, 0.0f); // ?? Deðiþecek
            character.Attack();
        } else
        {
            character.isAttacking = false;
        }

        
    }

    public void Aim()
    {

    }

    public void SkillUsed()
    {

    }
}
