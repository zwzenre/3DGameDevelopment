using UnityEngine;
using UnityEngine.InputSystem;

public class PickupFlashLight : MonoBehaviour
{
    public GameObject flashLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("FlashLight"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(this.gameObject);
                flashLight.SetActive(true);
            }
        }
    }
}
