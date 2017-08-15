using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays
{
    public class Turretscript : MonoBehaviour
    {
        public Transform target;

        private Weaponscript currentWeapon;

        // Use this for initialization
        void Start()
        {
            currentWeapon = GetComponentInChildren<Weaponscript>();
            currentWeapon.SetTarget(target);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
