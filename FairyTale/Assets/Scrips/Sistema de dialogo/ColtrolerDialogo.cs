using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColtrolerDialogo : MonoBehaviour
{
    public TMP_Text nameText;

    public TMP_Text dialogText;

    public GameObject menuDialogo;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void ComecaDialogo(Dialogo dialogo)
    {        
        nameText.text = dialogo.name;

        sentences.Clear();

        foreach(string sentence in dialogo.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }
    void EndDialogue()
    {
        menuDialogo.SetActive(false);
    }
}
