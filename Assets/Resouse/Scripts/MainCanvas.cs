using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    public GameObject Player;
    public GameObject currimage;
    public List<Sprite> images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<Player01>().pickupObj!=null)
        {
            if(Player.GetComponent<Player01>().pickupObj.tag=="Prop")
            {
                currimage.GetComponent<Image>().sprite = images[0];
            }
            else if(Player.GetComponent<Player01>().pickupObj.tag == "Prop2")
            {
                currimage.GetComponent<Image>().sprite = images[1];
            }
            else if (Player.GetComponent<Player01>().pickupObj.tag == "Prop3")
            {
                currimage.GetComponent<Image>().sprite = images[2];
            }
        }
        else
        {
            currimage.GetComponent<Image>().sprite = null;
        }
    }
}
