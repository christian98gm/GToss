using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectScript : MonoBehaviour
{

    public Animator animator;
    public Button leftBtn;
    public Button RightBtn;

    private int current = 0;

    public void Start()
    {
        leftBtn.onClick.AddListener(SlideLeft);
        RightBtn.onClick.AddListener(SlideRight);
    }

    public void SlideRight ()
    {
        if (current == 0)
        {
            animator.SetBool("slideRight", true);
            current = 1;
        }

        if (current == -1)
        {
            animator.SetBool("slideLeft", false);
            current = 0;
        }

    }

    public void SlideLeft ()
    {
        if (current == 0)
        {
            animator.SetBool("slideLeft", true);
            current = -1;
        }
        if (current == 1)
        {
            animator.SetBool("slideRight", false);
            current = 0;
        }
    }
}
