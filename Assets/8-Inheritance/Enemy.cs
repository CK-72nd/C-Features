using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Inheritance
{

    public class Enemy : MonoBehaviour
    {
        public Transform target;
        public int health = 100;
        public int damage = 20;
        public float attackDuration = 2f;
        public float attackRate = 5f;
        public float attackRadius = 10f;

        private float attackTimer = 0f;

        protected NavMeshAgent nav;
        protected Rigidbody rigid;

        protected virtual void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        protected virtual void Attack() { }
        protected virtual void OnAttackEnd() { }

        IEnumerator AttackDelay(float delay)
        {
            // Stop nav
            nav.Stop();
            yield return new WaitForSeconds(delay);
            // Resume nav
            nav.Resume();
            // Call OnAttackEnd
            OnAttackEnd();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (target == null)
            {
                return;
            }

            nav.SetDestination(target.position);
            attackTimer += Time.deltaTime;
            // If timer reaches attack rate
            if(attackTimer >= attackRate)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                // If distance is within attack range
                if (distance <= attackRadius)
                {
                    // Call attack()
                    Attack();
                    // Reset attackTimer
                    attackTimer = 0f;
                    // StartCoroutine AttackDelay
                    StartCoroutine(AttackDelay(attackDuration));
                }

                
            }
        }

    }
}
