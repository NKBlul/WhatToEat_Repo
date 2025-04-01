using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roll : MonoBehaviour
{
    ChoiceList choiceList;
    WhatToEat whatToEat;
    [SerializeField] private float rollDuration = 3f; 
    [SerializeField] private float rollSpeed = 0.2f;
    [SerializeField] GameObject confettiPrefab;

    private void Awake()
    {
        choiceList = GetComponent<ChoiceList>();
        whatToEat = GetComponent<WhatToEat>();
    }

    public void RollForFood()
    {
        StartCoroutine(RollAnimation(choiceList.lists));
    }

    private IEnumerator RollAnimation(List<ChoiceSO> lists)
    {
        whatToEat.ButtonInteractable(false);
        float elapsedTime = 0f;
        int finalIndex = Random.Range(0, lists.Count);

        while (elapsedTime < rollDuration)
        {
            int randomIndex = Random.Range(0, lists.Count);
            whatToEat.ChangeImageAndText(lists[randomIndex].choiceicon, lists[randomIndex].choicename);

            yield return new WaitForSeconds(rollSpeed);
            elapsedTime += rollSpeed;
        }

        // Show the final selected food item
        whatToEat.ChangeImageAndText(lists[finalIndex].choiceicon, lists[finalIndex].choicename);
        Debug.Log("Final selection: " + lists[finalIndex].choicename);
        StartCoroutine(PlayConfetti());
        whatToEat.ButtonInteractable(true);
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
