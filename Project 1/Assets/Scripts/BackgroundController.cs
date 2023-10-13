using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private GameObject backgroundPanel;

    private SpriteRenderer backgroundImage;
    

    private void Start()
    {
        // the background image is equal to the background game object's first child's sprite renderer
        backgroundImage = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // chack if the player has crossed out of the bounds of the center background pannel
        if(player.transform.position.x >= this.transform.position.x + (backgroundImage.size.x / 2) || // has the player gone beyond the right edge? 
            player.transform.position.x <= this.transform.position.x - (backgroundImage.size.x / 2) || // has the player gone beyond the left edge?
            player.transform.position.y >= this.transform.position.y + (backgroundImage.size.y / 2) || // has the player gone above the top edge?
            player.transform.position.y <= this.transform.position.y - (backgroundImage.size.y / 2)) // has the player gone below the bottom edge?
        {

        }
    }
}
