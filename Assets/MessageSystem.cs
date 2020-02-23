using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] ContextualTextPanel messagePanel;

    public static MessageSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Print(string s)
    {
        messagePanel.gameObject.SetActive(true);
        messagePanel.Print(s);
    }
}
