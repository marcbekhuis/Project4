using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaturePediaScript : MonoBehaviour
{
    private int pages;
    public Text title;
    public Text discription;

    public Image bookCover;
    public Image leftPage;
    public Image rightPage;

    public Button previousPageButton;
    public Button nextPageButton;

    public void PreviousPage()
    {
        if (pages > 0)
        {
            pages--;
        }
    }

    public void NextPage()
    {
        if (pages <= 10)
        {
            pages++;
        }
    }

    private void Update()
    {
        if (pages > 0)
        {
            bookCover.gameObject.SetActive(false);
            previousPageButton.gameObject.SetActive(true);
            title.gameObject.SetActive(true);
            discription.gameObject.SetActive(true);
        }
        else
        {
            bookCover.gameObject.SetActive(true);
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(false);
            title.gameObject.SetActive(false);
            discription.gameObject.SetActive(false);
            previousPageButton.gameObject.SetActive(false);
        }

        if (pages == 1)
        {
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "The NaturePedia";
            discription.text = "This is the NaturePedia, here you will find information about blocks you collect";
        }
        else if (pages == 2)
        {
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Grass";
            discription.text = "This is grass, one of the most common blocks. Plants and trees can grow on it";
        }
    }
}
