using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotting : MonoBehaviour {

    public float shootRate = 2;
    private float timer = 0;
    public float attack = 30;
    private new ParticleSystem particleSystem;
    private LineRenderer lineRenderer;


	// Use this for initialization
	void Start () {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        lineRenderer = GetComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer > 1 / shootRate)
        {
            timer -= 1 / shootRate;
           /* if (Input.GetMouseButtonDown(0))
            {*/
                shoot();
            /*}*/
        }

	}

    void shoot()
    {
        GetComponent<Light>().enabled = true;
        particleSystem.Play();
        this.lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position); //0是射线起点，设置射线起点为transform.position
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            lineRenderer.SetPosition(1, hitInfo.point);  //1是射线终点
            if (hitInfo.collider.tag == Tags.enemy) //判断子弹是否击中敌人
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(attack, hitInfo.point);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
        }
        GetComponent<AudioSource>().Play();
        
        Invoke("ClearEffect", 0.05f);
    }

    void ClearEffect()
    {
        GetComponent<Light>().enabled = false;
        this.lineRenderer.enabled = false;
    }
}
