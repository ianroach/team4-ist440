using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Multlvlhealth2 : MonoBehaviour
{

    public float CurrHealth { get; set; }
    public float MaxHealth { get; set; }
    public Player2 player;
    public Playerlife1 life;

    public Slider Healthbar;
    // Use this for initialization
    void Start()
    {

        MaxHealth = 100f;
        CurrHealth = MaxHealth;
        Healthbar.value = CalculateHealth();

        life = GetComponent<Playerlife1>();
        // Resets health to full on game load

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(float damage)
    {

        CurrHealth -= damage;
        Healthbar.value = CalculateHealth();
        if (CurrHealth == 0)
        {
            player.GetComponent<Player2>();

            CurrHealth = MaxHealth;

            ResetCurrentHealth();



        }



    }





    public float CalculateHealth()
    {
        return CurrHealth / MaxHealth;
    }

    public void ResetCurrentHealth()
    {


        player.GetComponent<Player1Controlls>();

        player.Reset();


        life.takeLife(1);

    }



}