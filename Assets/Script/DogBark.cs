using UnityEngine;
using System.Collections;

public class DogBark : MonoBehaviour
{
    [Header("Random Bark Interval")]
    public float minInterval = 3f;
    public float maxInterval = 7f;

    private void Start()
    {
        StartCoroutine(RandomBarkLoop());
    }

    IEnumerator RandomBarkLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            PlayDogBark();
        }
    }

    public void PlayDogBark()
    {
        AudioManager.instance.PlayDogBarkSound();
    }
}
