using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpDown : MonoBehaviour
{
    int a;

    bool isBibber = true;
    bool isSmaller = false;

    private void OnEnable()
    {
        isBigger();
    }

    private void isBigger()
    {
        if (isBibber)
        {
            transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y + 1, 1);
            isSmaller = true;
            isBibber = false;
            Invoke("Smaller", 1f);
        }
    }

    private void Smaller()
    {
        if(isSmaller)
        {
            transform.localScale = new Vector3(transform.localScale.x - 1, transform.localScale.y - 1, 1);
            isSmaller = false;
            isBibber=true;
            Invoke("isBigger", 1f);
        }
    }
}
