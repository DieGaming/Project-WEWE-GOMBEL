using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SanityManager : MonoBehaviour
{
    public Slider sanitySlider; // Reference to the Slider component
    public int fullSanity;
    public int difficulty;
    public float sanityDecreaseRate = 0.1f; // Rate at which sanity decreases
    public float detectionRange = 10f; // Range within which the enemy affects sanity

    private Transform enemyTransform; // Reference to the enemy's transform

    void Start()
    {
        // Ensure the sanitySlider is assigned in the Inspector
        if (sanitySlider == null)
        {
            Debug.LogError("SanitySlider is not assigned!");
            return;
        }

        sanitySlider.maxValue = fullSanity;
        sanitySlider.value = fullSanity;

        // Optionally, you could find the enemy if it's tagged or otherwise identifiable
        // For this example, we'll assume it's set via another method
    }

    void Update()
    {
        if (enemyTransform != null)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);
            if (distanceToEnemy <= detectionRange)
            {
                StartCoroutine(LoseSanity());
            }
            else
            {
                StopAllCoroutines(); // Stop the coroutine if the enemy is out of range
            }
        }
    }

    public void SetEnemy(Transform enemy)
    {
        enemyTransform = enemy; // Set the enemy reference from another script
    }

    public IEnumerator LoseSanity()
    {
        while (sanitySlider.value > 0)
        {
            sanitySlider.value -= sanityDecreaseRate * difficulty;
            yield return new WaitForSeconds(0.1f); // Adjust the delay as needed
        }

        // Handle game over or sanity reached zero
        Debug.Log("Game Over");
    }

    public void AffectSanity(float value)
    {
        sanitySlider.value += value;
    }
}
