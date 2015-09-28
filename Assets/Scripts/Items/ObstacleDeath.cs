using UnityEngine;
using System.Collections;

public class ObstacleDeath : MonoBehaviour {
    //Script to kill player on collison with obstacles
	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "obstacleDown")
        {
            Application.LoadLevel(1);
        }
        if (other.gameObject.tag == "obstacleUp")
        {
            Application.LoadLevel(1);
        }
    }

}
