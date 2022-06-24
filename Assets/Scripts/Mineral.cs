using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : Interactable
{
    public string mineralname;
    public int amount;
    public ParticleSystem crashEff;
    public GameObject model;
    public Character player;
    public override void Interact()
    {
        //SpawnManager.instance.SpawnMineral();
        //SpawnManager.instance.SpawnEnemy();
        //SpawnManager.instance.SpawnAlly();
        crashEff.gameObject.SetActive(true);
        model.SetActive(false);
        Destroy(gameObject,1f);        
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Character>();
            player.crystalCount += amount;
            player.tmesh.SetText(player.crystalCount + "");
            if (player.crystalCount < 10)
            {
                player.spawnAllyButton.interactable = false;
                player.damageMultiplier.interactable = false;

            }
            else if (player.crystalCount >= 10 && player.crystalCount < 20)
            {
                player.spawnAllyButton.interactable = true;
                player.damageMultiplier.interactable = false;
            }
            else
            {
                player.spawnAllyButton.interactable = true;
                player.damageMultiplier.interactable = true;
            }
            Interact();
        }

    }

    public void Initialize (string mineralname , int amount)
    {
        this.mineralname = mineralname;
        this.amount = amount;

    } 
}
