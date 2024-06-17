using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_Button : Interactable
{
    [SerializeField]
    private Book book; // Reference to the Book script

    public override void Interact()
    {
        if (gameObject.CompareTag("NextButton"))
        {
            book.NextPage();
        }
        else if (gameObject.CompareTag("PrevButton"))
        {
            book.PrevPage();
        }
    }
}
