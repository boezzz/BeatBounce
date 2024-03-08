using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOperations : MonoBehaviour
{


    // for ball launcher
    //public Transform _turret;
    //public Transform _barrel;
    public GameObject _firingPosition;

    public GameObject _cannonBall;


    // this refer to the hand menu, add in world operations
    public void OnClearButtonClicked() {
        // clear all panels in space
        foreach (var each_panel in GameObject.FindGameObjectsWithTag("panel")){
            Destroy(each_panel);
        }
    }




    // Launch settings functions
    //public void makeCannonBall()
    //{

    //    GameObject newCannonBall = Instantiate(_cannonBall, _firingPosition.transform.position, _firingPosition.transform.rotation);
    //    CannonBall cannonBallScript = newCannonBall.GetComponent<CannonBall>();
    //    if (cannonBallScript != null)
    //    {
    //        //cannonBallScript.SetVelocity(mySlider.value);
    //        cannonBallScript.SetVelocity(700f);

    //    }

    //}


    public void spawnBall()
    {
        // Instantiate(_cannonBall, _firingPosition.transform.position, _firingPosition.transform.rotation);
        GameObject ball = Instantiate(_cannonBall, _firingPosition.transform.position, _firingPosition.transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 700f, 0));
    }


}
