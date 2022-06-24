using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_BasicEnemy : Brain
{
    public float movSpeed;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotL = false;
    private bool isRotR = false;
    private bool isWalking = false;

    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Idle()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotR == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotL == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true)
        {
            rb.transform.position += transform.forward * movSpeed;
        }
    }
    IEnumerator Wander()
    {
        float rottime = Random.Range(0.1f, 0.3f);
        float rotwait = Random.Range(0.05f, 0.1f);
        int rotatelorR = Random.Range(1, 3);
        float walkwait = Random.Range(0.2f, 0.5f);
        float walktime = Random.Range(1, 3);


        isWandering = true;

        //yield return new WaitForSeconds(walkwait);
        isWalking = true;
        yield return new WaitForSeconds(walktime);
        isWalking = false;
        yield return new WaitForSeconds(rotwait);
        if (rotatelorR == 1)
        {
            isRotR = true;
            yield return new WaitForSeconds(rottime);
            isRotR = false;
        }
        if (rotatelorR == 2)
        {
            isRotL = true;
            yield return new WaitForSeconds(rottime);
            isRotL = false;
        }
        isWandering = false;
    }

    public void RandomWander()
    {
        //gameObject.GetComponent<Character>().movementSpeed;
    }
}
