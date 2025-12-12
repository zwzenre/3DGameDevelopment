using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public static WaterManager instance;

    public GameObject waterLeakEffect;   // Already placed in scene
    public GameObject waterBeamEffect;

    public PipeSlot firstSlot;
    private PipeSlot currentSlot;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        WaterManager.instance.StartFlow(firstSlot);
    }

    public void StartFlow(PipeSlot firstSlot)
    {
        currentSlot = firstSlot;

        MoveLeakToSlot(currentSlot);
    }

    public void OnPipeSnapped(PipeSlot slot)
    {
        if (slot != currentSlot) return;

        // Move to next slot
        currentSlot = slot.nextSlot;

        // If no more slots → finish
        if (currentSlot == null)
        {
            waterLeakEffect.SetActive(false); // Hide leak
            waterBeamEffect.SetActive(true);  // Enable fountain water
            return;
        }

        MoveLeakToSlot(currentSlot);
    }

    private void MoveLeakToSlot(PipeSlot slot)
    {
        if (slot == null) return;

        waterLeakEffect.transform.position = slot.leakPoint.position;
        waterLeakEffect.transform.rotation = slot.leakPoint.rotation;
        waterLeakEffect.SetActive(true);
    }
}
