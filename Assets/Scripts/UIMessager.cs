using System;
using UnityEngine;

public class UIMessager: MonoBehaviour
{
    public static UIMessager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Action<Position> onInvalidNursePosition;
}