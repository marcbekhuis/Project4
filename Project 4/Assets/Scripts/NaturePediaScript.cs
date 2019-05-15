using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaturePediaScript : MonoBehaviour
{
    private int pages = 0;
    public Text title;
    public Text discription;

    public Image bookCover;
    public Image leftPage;
    public Image rightPage;

    public Button previousPageButton;
    public Button nextPageButton;

    public void PreviousPage()
    {
        //goes to the previous page
        pages--;
    }

    public void NextPage()
    {
        //goes to the next page
        pages++;
        print(pages);
    }

    private void Update()
    {
        if (pages > 0)
        {
            //disables the book cover and enables the title, discription and pages
            bookCover.gameObject.SetActive(false);
            previousPageButton.gameObject.SetActive(true);
            title.gameObject.SetActive(true);
            discription.gameObject.SetActive(true);
        }
        else
        {
            //turns on the book cover 
            bookCover.gameObject.SetActive(true);
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(false);
            title.gameObject.SetActive(false);
            discription.gameObject.SetActive(false);
            previousPageButton.gameObject.SetActive(false);
        }

        //shows certain items on certain pages.
        if (pages == 0)
        {

        }
        else if (pages == 1)
        {
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "The NaturePedia";
            discription.text = "This is the NaturePedia, here you will find information about blocks you collect.";
        }
        else if (pages == 2)
        {
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Grass";
            discription.text = "This is grass, one of the most common blocks. Plants and trees can grow on it.";
        }
        else if (pages == 3)
        {
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Dirt";
            discription.text = "This is dirt, it's the block below grass. It does not do much.";
        }
        else if (pages == 4)
        {
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Stone";
            discription.text = "This is stone, one of the first building blocks you get.";
        }
        else if (pages == 5)
        {
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Kapok Tree";
            discription.text = "The kapok tree is a tropicl tree, these trees can grow up to 70 m tall.";
        }
        else if (pages == 6)
        {
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Cotoneaster";
            discription.text = "This flower attract bees and butterflies and the fruits are eaten by birds.";
        }
        else if (pages == 7)
        {
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Rafflesia";
            discription.text = "The Rafflesia has no stems, leaves or roots. The only part of the plant that can be seen outside the host vine is the five-petalled flower.";
        }
        else if (pages == 8)
        {
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Asian Elephant";
            discription.text = "The Asian elephant is the largest living land animal in Asia.";
        }
        else if (pages == 9)
        {
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Albatross";
            discription.text = "Albatrosses are highly efficient in the air, using dynamic soaring and slope soaring to cover great distances with little exertion.";
        }
        else
        {
            pages--;
        }
    }
}