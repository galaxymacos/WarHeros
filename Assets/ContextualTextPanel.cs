using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextualTextPanel : MonoBehaviour
{
    [SerializeField] float lifetime;
    [SerializeField] Text message;

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Print(string s)
    {
        message.text = s;
    }
}
