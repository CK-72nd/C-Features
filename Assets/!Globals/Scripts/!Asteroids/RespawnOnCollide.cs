using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Respawn))]
public class RespawnOnCollide : MonoBehaviour
{
    public string colliderTag;

    private Respawn res;

    void Awake()
    {
        res = GetComponent<Respawn>();
    }

    void OnCollisionPaper(Collision2D col)
    {
        //If collided object's tag is colliderTag
        if (col.collider.tag == colliderTag)
        {
            //Respawn object
            res.Spawn();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
