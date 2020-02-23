using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ContextualTextPanel : MonoBehaviour
{
    [SerializeField] float lifetime = 4f;
    private float lifeTimeCounter;
    [SerializeField] Text message;

    public Queue<string> messagesToShow;
    private StringBuilder sb;
    
    private void OnEnable()
    {
        lifeTimeCounter = lifetime;
        sb = new StringBuilder();
        messagesToShow = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeCounter -= Time.deltaTime;
        if (lifeTimeCounter <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Print(string s)
    {
        messagesToShow.Enqueue(s);
        if (messagesToShow.Count > 3)
        {
            messagesToShow.Dequeue();
        }
        lifeTimeCounter = lifetime;
        sb.Clear();
        foreach (var messageToShow in messagesToShow)
        {
            sb.AppendLine(messageToShow);
        }
        message.text = sb.ToString();
    }
}
