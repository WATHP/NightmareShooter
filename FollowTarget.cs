using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public float smoothing = 3;
    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPos = player.position + new Vector3(0, 2, -2);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);
	}
}
