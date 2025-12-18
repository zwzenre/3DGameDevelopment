using UnityEngine;

public class DogRoomIdle : MonoBehaviour
{
    public Animator animator;

    void OnEnable()
    {
        animator.Rebind();
        animator.Update(0f);

        animator.SetFloat("Speed", 0f);
        animator.SetBool("Wiggle", true);
    }
}