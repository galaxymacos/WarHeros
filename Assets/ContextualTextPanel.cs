using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ContextualTextPanel : MonoBehaviour
{
    [SerializeField] Text message;
    [SerializeField] private int maxInfoToDisplay = 4;

    public Queue<string> messagesToShow;
    private StringBuilder sb;
    
    private void OnEnable()
    {
        sb = new StringBuilder();
        messagesToShow = new Queue<string>();
    }
    

    public void Print(string s)
    {
        messagesToShow.Enqueue(s);
        if (messagesToShow.Count > maxInfoToDisplay)
        {
            messagesToShow.Dequeue();
        }
        sb.Clear();
        foreach (var messageToShow in messagesToShow)
        {
            sb.AppendLine(messageToShow);
        }
        message.text = sb.ToString();
    }
}
