using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roll : MonoBehaviour
{
    FoodList foodList;
    [SerializeField] private float rollDuration = 3f; 
    [SerializeField] private float rollSpeed = 0.2f;
    [SerializeField] GameObject confettiPrefab;

    private void Awake()
    {
        foodList = GetComponent<FoodList>();
    }

    public void RollForFood()
    {
        StartCoroutine(RollAnimation(foodList.foods));
    }

    private IEnumerator RollAnimation(List<FoodSO> foods)
    {
        UIManager.instance.ButtonInteractable(false);
        float elapsedTime = 0f;
        int finalIndex = Random.Range(0, foods.Count);

        while (elapsedTime < rollDuration)
        {
            int randomIndex = Random.Range(0, foods.Count);
            UIManager.instance.ChangeImageAndText(foods[randomIndex].foodIcon, foods[randomIndex].foodName);

            yield return new WaitForSeconds(rollSpeed);
            elapsedTime += rollSpeed;
        }

        // Show the final selected food item
        UIManager.instance.ChangeImageAndText(foods[finalIndex].foodIcon, foods[finalIndex].foodName);
        Debug.Log("Final selection: " + foods[finalIndex].foodName);
        StartCoroutine(PlayConfetti());
        UIManager.instance.ButtonInteractable(true);
    }

    IEnumerator PlayConfetti()
    {
        GameObject confetti = Instantiate(confettiPrefab, new Vector2(Screen.width / 2, 0), Quaternion.identity);
        ParticleSystem particleSystem = confetti.GetComponent<ParticleSystem>();
        particleSystem.Play();
        yield return new WaitForSeconds(particleSystem.main.duration);
        Destroy(confetti);
    }
}
