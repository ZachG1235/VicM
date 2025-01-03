using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] dialogue;
    public float textSpeed;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(text.text == dialogue[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = dialogue[index];
            }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(this.gameObject);
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }
    IEnumerator TypeLine()
    {
        foreach(char c in dialogue[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index ++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        
    }
}
