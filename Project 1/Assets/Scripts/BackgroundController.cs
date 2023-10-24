using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
     private GameObject player;

    //[SerializeField] private List<GameObject> backgroundPanels;
    //[SerializeField] private GameObject backgroundPanel;

    private SpriteRenderer backgroundImage;

    // this (should) be the accurate height and width of the background panels
    private Vector2 backgroundSize = new Vector2(24.8f, 15.5f);

    private void Start()
    {
        // the background image is equal to the background game object's first child's sprite renderer
        backgroundImage = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // chack if the player has crossed out of the bounds of the center background pannel
        if(player.transform.position.x >= this.transform.position.x + (backgroundImage.size.x / 2) || // has the player gone beyond the right edge? 
            player.transform.position.x <= this.transform.position.x - (backgroundImage.size.x / 2) || // has the player gone beyond the left edge?
            player.transform.position.y >= this.transform.position.y + (backgroundImage.size.y / 2) || // has the player gone above the top edge?
            player.transform.position.y <= this.transform.position.y - (backgroundImage.size.y / 2)) // has the player gone below the bottom edge?
        {

        }
        */

        //get a reference to the player if you do not have one already
        if(player == null)
        {
            player = GameManager.Instance.Player;
        }

        if(GameManager.Instance.currentState == GameState.Gameplay)
        {
            // check if the player is beyond gone beyond the right edge
            if (player.transform.position.x >= this.transform.position.x + (backgroundSize.x / 2))
            {
                // move the background right by 1 background panel width
                this.transform.position = new Vector2(
                    this.transform.position.x + backgroundSize.x,
                    this.transform.position.y); // background y value is preserved
            }

            // check if the player is beyond gone beyond the left edge
            if (player.transform.position.x <= this.transform.position.x - (backgroundSize.x / 2))
            {
                // move the background left by 1 background panel width
                this.transform.position = new Vector2(
                    this.transform.position.x - backgroundSize.x,
                    this.transform.position.y); // background y value is preserved
            }

            // check if the player is beyond gone above the top edge
            if (player.transform.position.y >= this.transform.position.y + (backgroundSize.y / 2))
            {
                // move the background up by 1 background panel width
                this.transform.position = new Vector2(
                    this.transform.position.x, // background x is preserved
                    this.transform.position.y + backgroundSize.y);
            }

            // check if the player is beyond gone below the bottom edge
            if (player.transform.position.y <= this.transform.position.y - (backgroundSize.y / 2))
            {
                // move the background down by 1 background panel width
                this.transform.position = new Vector2(
                    this.transform.position.x, // background x is preserved
                    this.transform.position.y - backgroundSize.y);
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(this.transform.position, backgroundSize);
    }
}
