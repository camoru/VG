using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_camera : MonoBehaviour
{
    public float smoothTime = 0.1f;
    Transform target;
    float tLX, tLY, bRX, bRY;

    Vector2 velocity;


    void Awake() 
    {
        target = GameObject.FindGameObjectWithTag("Evillion").transform;
	/*EX = target.position.x;
	EY = target.position.y; */
    }


    void Update()
    {
	float posX = Mathf.Round(
		Mathf.SmoothDamp(
			transform.position.x, target.position.x, ref velocity.x, smoothTime		
		)*100)/100;
        float posY = Mathf.Round(
		Mathf.SmoothDamp(
			transform.position.y, target.position.y, ref velocity.y, smoothTime		
		)*100)/100;
	transform.position = new Vector3(
		Mathf.Clamp(posX,tLX,bRX),
		Mathf.Clamp(posY,bRY,tLY),
		transform.position.z
	);
    }
    public void SetBound(GameObject map)
    {
	SuperTiled2Unity.SuperMap config = map.GetComponent<SuperTiled2Unity.SuperMap>();
	float cameraSize = Camera.main.orthographicSize;
	tLX= map.transform.position.x + cameraSize;
	tLY= map.transform.position.y - cameraSize;
	bRX= map.transform.position.x + config.m_Width - cameraSize;
	bRY= map.transform.position.y - config.m_Height + cameraSize;

        /*FastMove();*/ 
    }
    public void FastMove()
    {
	transform.position = new Vector3(
		target.position.x,
		target.position.y,
		transform.position.z
	);
    }
}
