using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public Canvas canvas;
    public Slider HealthSlider;
    public float maxHP = 100;
    public float hp;
    private Animator anim;
    private PlayerMove playerMove;
    private SkinnedMeshRenderer bodyRenderer;
    public float smoothing = 1.0f;
    private PlayerShotting playerShoot;
    public AudioClip hurtClip;
    public AudioClip deathClip;

    private void Awake()
    {
        hp = maxHP;
        anim = this.GetComponent<Animator>();
        this.playerMove = this.GetComponent<PlayerMove>();
        this.bodyRenderer = transform.Find("Player").GetComponent<SkinnedMeshRenderer>();
        playerShoot = GetComponentInChildren<PlayerShotting>();
    }

    private void Update()
    {
       /*if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(30);
        }*/

        bodyRenderer.material.color = Color.Lerp(bodyRenderer.material.color, Color.white, smoothing * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        this.hp -= damage;
        HealthSlider.value = hp / (float)maxHP;
        bodyRenderer.material.color = Color.red;
        AudioSource.PlayClipAtPoint(hurtClip, transform.position);
        if (this.hp <= 0)
        {
            GetComponent<Animator>().SetBool("Dead", true);
            Dead();
        }
    }

    void Dead()
    {
        HealthSlider.GetComponentInParent<Canvas>().enabled = false;
        AudioSource.PlayClipAtPoint(deathClip, transform.position);
        GetComponent<PlayerMove>().enabled = false;
        this.playerShoot.enabled = false;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().TotalPointManager();
        canvas.enabled = true;
        Time.timeScale = 0;
    }
}
