using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETCJoystickRotation : MonoBehaviour {

    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<RectTransform>().localPosition == new Vector3(0, 0, 0)) 
        {
            return;
        }
        //西
        if (GetComponent<RectTransform>().localPosition.x < 0 && GetComponent<RectTransform>().localPosition.y >= -20 && GetComponent<RectTransform>().localPosition.y <= 20) 
        {
            Player.transform.LookAt(new Vector3(Player.transform.position.x - 10, Player.transform.position.y, Player.transform.position.z));
            //Debug.Log("e");
        }
        //东
        if (GetComponent<RectTransform>().localPosition.x > 0 && GetComponent<RectTransform>().localPosition.y >= -10 && GetComponent<RectTransform>().localPosition.y <= 10)
        {
            Player.transform.LookAt(new Vector3(Player.transform.position.x + 10, Player.transform.position.y, Player.transform.position.z));
            //Debug.Log("w");
        }
        //南
        if (GetComponent<RectTransform>().localPosition.y < 0 && GetComponent<RectTransform>().localPosition.x >= -10 && GetComponent<RectTransform>().localPosition.x <= 10)
        {
            Player.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10));
            //Debug.Log("s");
        }
        //北
        if(GetComponent<RectTransform>().localPosition.y > 0 && GetComponent<RectTransform>().localPosition.x >= -10 && GetComponent<RectTransform>().localPosition.x <= 10)
        {
            Player.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z + 10));
            //Debug.Log("n");
        }
        
        //东北
        if (GetComponent<RectTransform>().localPosition.y > 10 && GetComponent<RectTransform>().localPosition.x > 10) 
        {
            Player.transform.LookAt(new Vector3(Player.transform.position.x + 10, Player.transform.position.y, Player.transform.position.z + 10));
            //Debug.Log("wn");
        }
        //西北
        if (GetComponent<RectTransform>().localPosition.y > 10 && GetComponent<RectTransform>().localPosition.x < -10) 
        {
            Player.transform.LookAt(new Vector3(Player.transform.position.x - 10, Player.transform.position.y, Player.transform.position.z + 10));
            //Debug.Log("en");
        }
        //东南
        if (GetComponent<RectTransform>().localPosition.y < -10 && GetComponent<RectTransform>().localPosition.x > 10)
        {
            Player.transform.LookAt(new Vector3(Player.transform.position.x + 10, Player.transform.position.y, Player.transform.position.z - 10));
            //Debug.Log("ws");
        }
        //西南
        if (GetComponent<RectTransform>().localPosition.x < -10 && GetComponent<RectTransform>().localPosition.y < -10)
        {
            Player.transform.LookAt(new Vector3(Player.transform.position.x - 10, Player.transform.position.y, Player.transform.position.z - 10));
            //Debug.Log("es");
        }
        
    }

}
