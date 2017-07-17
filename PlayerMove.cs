using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 5;
    private Animator anim;
    private int groundLayerIndex = -1;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        groundLayerIndex = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //transform.Translate(new Vector3(h, 0, v) * speed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);
        */

        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 500, groundLayerIndex))
        {
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
        */
    }


    public void StartMove()
    {
        anim.SetBool("Move", true);
    }

    public void EndMmove()
    {
        anim.SetBool("Move", false);
    }
}
