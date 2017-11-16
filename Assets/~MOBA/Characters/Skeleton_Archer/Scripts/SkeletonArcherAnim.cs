using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOBA
{
    [RequireComponent(typeof(AIAgent))]
    public class SkeletonArcherAnim : MonoBehaviour
    {
        public Animator anim;

        private AIAgent aiAgent;

        void Start()
        {
            aiAgent = GetComponent<AIAgent>();
            //Dont update the position unitl later
            aiAgent.updatePosition = false;
        }

        void Update()
        {
            //Get the current animator state information on the base Layer(0)
            AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
            //Is the current state NOT "spawn"
            if (!state.IsName("spawn"))
            {
                //Update position
                aiAgent.updatePosition = true;
                //Set the moveSpeed of the anim
                float moveSpeed = aiAgent.velocity.magnitude;
                anim.SetFloat("MoveSpeed", moveSpeed);
            }
        }
    }
}