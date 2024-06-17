using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Interactable
{
    [SerializeField]
    private Material[] pages;
    [SerializeField]
    private GameObject nextPageBtn;
    [SerializeField]
    private GameObject prevPageBtn;

    private Material _currentMat;
    private int _currentPageIndex = 0;

    private void Start()
    {
        _currentMat = pages[0];
        prevPageBtn.SetActive(false);
        if (pages.Length <= 1)
        {
            nextPageBtn.SetActive(false);
        }
    }

    public void NextPage()
    {
        if (_currentPageIndex < pages.Length - 1)
        {
            _currentPageIndex++;
            _currentMat = pages[_currentPageIndex];
            UpdatePage();
            AkSoundEngine.PostEvent("Play_Book_Page_Turn", gameObject);
        }
    }

    public void PrevPage()
    {
        if (_currentPageIndex > 0)
        {
            _currentPageIndex--;
            _currentMat = pages[_currentPageIndex];
            UpdatePage();
            AkSoundEngine.PostEvent("Play_Book_Page_Turn", gameObject);
        }
    }

    private void UpdatePage()
    {
        // Assuming the material is applied to the same object as this script
        GetComponent<Renderer>().material = _currentMat;

        // Update button states
        prevPageBtn.SetActive(_currentPageIndex > 0);
        nextPageBtn.SetActive(_currentPageIndex < pages.Length - 1);
    }
}
