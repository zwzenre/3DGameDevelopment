using UnityEngine;

public class FlashlightObject : MonoBehaviour
{
    public Light flashlight;
    private bool isOn = true;

    public void Equip(Transform holder)
    {
        transform.SetParent(holder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        Collider col = GetComponent<Collider>();
        if (col != null) col.enabled = false;
    }

    public void Toggle()
    {
        isOn = !isOn;
        flashlight.enabled = isOn;
    }
}
