using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HistoryControl : MonoBehaviour
{
    public GameObject dialogObj;
    public GameObject[] scenes;
    public Text speechText;

    public float typingSpeed;
    private string[] sentences;
    private int index, sceneIndex = 0;

    public void Speech(string[] txt)
    {
        dialogObj.SetActive(true);
        sentences = txt;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(string nextLvl)
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogObj.SetActive(false);
                
                // Próxima cena
                if(sceneIndex < scenes.Length - 1)
                {
                    scenes[sceneIndex].SetActive(false);
                    sceneIndex++;
                    scenes[sceneIndex].SetActive(true);
                }
                else
                {
                    SceneManager.LoadScene(nextLvl);
                }
            }
        }
    }

}
