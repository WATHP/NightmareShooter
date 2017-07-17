using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float attack = 5;
    public float attackTime = 0.5f;
    private float timer = 0.5f;
    private EnemyHealth health;


    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
    }

    private void Start()
    {
        timer = attackTime;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.player && health.hp > 0) 
        {
            timer += Time.deltaTime;
            if (timer >= attackTime)
            {
                timer -= attackTime;    
                other.GetComponent<PlayerHealth>().TakeDamage(attack);
            }
        }
    }
    
}
