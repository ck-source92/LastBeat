using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    [SerializeField] GameObject horizontalScrollbar;
    [SerializeField] GameObject previousButton;
    [SerializeField] GameObject nextButton;

    float scroll_pos = 0;
    float[] pos;
    int position = 0;

    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scroll_pos = horizontalScrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    horizontalScrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(horizontalScrollbar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
                }
            }
        }
        UpdateButtonActivation();
    }
    public void Previous()
    {
        if (position > 0)
        {
            position -= 1;
            scroll_pos = pos[position];
        }
    }
    public void Next()
    {
        if (position < pos.Length - 1)
        {
            position += 1;
            scroll_pos = pos[position];
        }
    }

    void UpdateButtonActivation()
    {
        if (previousButton != null)
        {
            previousButton.SetActive(position > 0);
        }

        if (nextButton != null)
        {
            nextButton.SetActive(position < pos.Length - 1);
        }
    }

}
