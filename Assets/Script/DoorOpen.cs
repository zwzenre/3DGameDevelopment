using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NavKeypad
{
    public class DoorOpen : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        public bool IsOpen => isOpen;
        private bool isOpen = false;

        public void ToggleDoor()
        {
            isOpen = !isOpen;
            anim.SetBool("isOpen", isOpen);
        }

        public void OpenDoor()
        {
            Debug.Log("OpenDoor called!");
            isOpen = true;
            anim.SetBool("isOpen", isOpen);
        }
        public void CloseDoor()
        {
            isOpen = false;
            anim.SetBool("isOpen", isOpen);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("O pressed!");
                isOpen = true;
                anim.SetBool("isOpen", isOpen);
                Debug.Log("Bool sent to animator");
            }
        }

    }

    

}