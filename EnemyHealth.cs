using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public Slider HealthSlider;
    public float maxHP = 100;
    public float hp;
    private Animator anim;
    private NavMeshAgent agent;
    private EnemyMove move;
    private CapsuleCollider capsuleCollider;
    public AudioClip deathClip;
    private new ParticleSystem particleSystem;
    public int point;


    private void Awake()
    {

        hp = maxHP;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        move = GetComponent<EnemyMove>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (this.hp <= 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
            if (transform.position.y <= -3) 
            {
                Destroy(this.gameObject);
            }
        }    
        
    }

    public void TakeDamage(float damage,Vector3 hitPoint)
    {
        if (this.hp <= 0) return;
        GetComponent<AudioSource>().Play();
        particleSystem.transform.position = hitPoint;
        particleSystem.Play();
        this.hp -= damage;
        HealthSlider.value = hp / (float)maxHP;
        if (this.hp <= 0)
        {   
            Dead();
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().KillPointManager(point);
        }
    }

    void Dead()
    {
        HealthSlider.GetComponentInParent<Canvas>().enabled = false;
        anim.SetBool("Dead", true);
        agent.enabled = false;
        move.enabled = false;
        capsuleCollider.enabled = false;
        AudioSource.PlayClipAtPoint(deathClip, transform.position);
    }
}
