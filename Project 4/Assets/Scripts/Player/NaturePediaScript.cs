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
    public Image itemImage;
    public Sprite[] sprites;

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
            itemImage.gameObject.SetActive(true);
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
            itemImage.gameObject.SetActive(false);
        }

        //shows certain items on certain pages.
        if (pages == 0)
        {

        }
        else if (pages == 1)
        {
            //Shows the first page explaining the book itself
            //and turns on the left page
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            itemImage.gameObject.SetActive(false);
            title.text = "The NaturePedia";
            discription.text = "This is the NaturePedia, here you will find information about blocks you collect.";
        }
        else if (pages == 2)
        {
            //Explains the first block
            //and turns on the right page
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            itemImage.gameObject.SetActive(true);
            title.text = "Grass";
            discription.text = "This is grass, one of the most common blocks. Plants and trees can grow on it.";
            itemImage.sprite = sprites[0];
        }
        else if (pages == 3)
        {
            //turns on the left page
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Dirt";
            discription.text = "This is dirt, it's the block below grass. It does not do much.";
            itemImage.sprite = sprites[1];
        }
        else if (pages == 4)
        {
            //turns on the right page
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Stone";
            discription.text = "This is stone, one of the first building blocks you get.";
            itemImage.sprite = sprites[2];
        }
        else if (pages == 5)
        {
            //turns on the left page
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Kapok Tree";
            discription.text = "The kapok tree is a tropicl tree, these trees can grow up to 70 m tall.";
            itemImage.sprite = sprites[3];
        }
        else if (pages == 6)
        {
            //turns on the right page
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Cotoneaster";
            discription.text = "This flower attract bees and butterflies and the fruits are eaten by birds.";
            itemImage.sprite = sprites[4];
        }
        else if (pages == 7)
        {
            //turns on the left page
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Rafflesia";
            discription.text = "The Rafflesia has no stems, leaves or roots. The only part of the plant that can be seen outside the host vine is the five-petalled flower.";
            itemImage.sprite = sprites[5];
        }
        else if (pages == 8)
        {
            //turns on the right page
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Asian Elephant";
            discription.text = "The Asian elephant is the largest living land animal in Asia.";
            itemImage.sprite = sprites[6];
        }
        else if (pages == 9)
        {
            //turns on the left page
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Albatross";
            discription.text = "Albatrosses are highly efficient in the air, using dynamic soaring and slope soaring to cover great distances with little exertion.";
            itemImage.sprite = sprites[7];
        }
        else if (pages == 10)
        {
            //turns on the right page
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Daisy";
            discription.text = "A wild flowering plant Bellis perennis of the Asteraceae family, with a yellow head and white petals.";
            itemImage.sprite = sprites[8];
        }
        else if (pages == 11)
        {
            //turns on the left page
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Rose";
            discription.text = "A rose is a woody perennial flowering plant of the genus Rosa, in the family Rosaceae, or the flower it bears. There are over three hundred species and thousands of cultivars.";
            itemImage.sprite = sprites[9];
        }
        else if (pages == 12)
        {
            //turns on the right page
            leftPage.gameObject.SetActive(false);
            rightPage.gameObject.SetActive(true);
            title.text = "Verbena";
            discription.text = "The Verbena leaves are usually opposite, simple, and in many species hairy, often densely so. The flowers are small, with five petals, and borne in dense spikes.";
            itemImage.sprite = sprites[10];
        }
        else if (pages == 13)
        {
            //turns on the left page
            leftPage.gameObject.SetActive(true);
            rightPage.gameObject.SetActive(false);
            title.text = "Amaryllis";
            discription.text = "Amaryllis is a bulbous plant, with each bulb being 5–10 cm in diameter. It has several strap-shaped, green leaves, 30–50 cm long and 2–3 cm broad, arranged in two rows.";
            itemImage.sprite = sprites[11];
        }
        else
        {
            //Goes a page back if you try to go to a page that doesn't exist
            pages--;
        }
    }
}