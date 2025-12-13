using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NavKeypad
{
    public class DoorOpen : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        private bool isOpen = false;

        public void OpenDoor()
        {
            Debug.Log("OpenDoor called!");
            isOpen = true;
            anim.SetBool("isOpen", isOpen);
        }

        void Update()
        {
            
        }

    }

    

}