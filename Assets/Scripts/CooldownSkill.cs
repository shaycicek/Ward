using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CooldownSkill : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;
    private bool isCoolDown = false;
    private float coolDownTime = 10.0f;
    private float coolDownTimer = 0.0f;

    void Start()
    {
        GetComponent<Button>().interactable = false;
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
        //
    }

    // Update is called once per frame
    void Update()
    {

        if(isCoolDown)
        {
            ApplyCooldown();
        }
    }

    /*public void Initialize(float cooldownTime)
    {
        this.coolDownTime = cooldownTime;
    } */
    void ApplyCooldown()
    {
        coolDownTimer -= Time.deltaTime;

        if(coolDownTimer<=0.0f)
        {
            GetComponent<Button>().enabled = true;
            isCoolDown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(coolDownTimer).ToString();
            imageCooldown.fillAmount = coolDownTimer / coolDownTime;
        }
    }

    public void StartCooldDown()
    {
        if(isCoolDown)
        {
            
        } else
        {
            GetComponent<Button>().enabled = false; // 
            isCoolDown = true;
            textCooldown.gameObject.SetActive(true);
            coolDownTimer = coolDownTime;
        }
    }
}
