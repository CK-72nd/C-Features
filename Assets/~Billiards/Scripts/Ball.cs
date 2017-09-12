using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class Ball : MonoBehaviour
    {
        public float stopSpeed = 0.2f;
        private Rigidbody rigid;


        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            //if velocity is going up on y
            if (vel.y > 0 )
            {
                //cap it down to zero
                vel.y = 0;
            }

            if (vel.magnitude < stopSpeed)
            {
                vel = Vector3.zero;
            }

            rigid.velocity = vel;
        }

        public void Hit(Vector3 direction, float speed)
        {
            rigid.AddForce(direction * speed, ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
