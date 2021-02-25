using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITrial2 : MonoBehaviour
{
    //public Image HerbariumElement;
    public GameObject[] sprites;
    public int Number;

    // Start is called before the first frame update
    void Start()
    {
        sprites[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightButton ()
    {
        if (Number + 1 < sprites.Length)
        {
            Number++;
            sprites[Number - 1].SetActive(false);
            sprites[Number].SetActive(true);
            //HerbariumElement.GetComponent<Image>().sprite = sprites[Number].GetComponent<Image>().sprite;
        }
    }

    public void LeftButton()
    {
        if (Number > 0)
        {
            Number--;
            sprites[Number + 1].SetActive(false);
            sprites[Number].SetActive(true);
            //HerbariumElement.GetComponent<Image>().sprite = sprites[Number].GetComponent<Image>().sprite;
        }
    }
}
