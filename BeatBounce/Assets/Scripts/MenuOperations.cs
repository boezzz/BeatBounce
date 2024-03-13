using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOperations : MonoBehaviour
{


    // for ball launcher
    public GameObject _firingPosition;
    public GameObject _cannonBall;
    //public Slider mySlider;
    public Slider mySlider;
    public Slider massSlider;


    // this refer to the hand menu, add in world operations
    public void OnClearButtonClicked() {
        // clear all panels in space
        foreach (var each_panel in GameObject.FindGameObjectsWithTag("SineWave")){
            Destroy(each_panel);
        }

        foreach (var each_panel in GameObject.FindGameObjectsWithTag("SawtoothWave"))
        {
            Destroy(each_panel);
        }

        foreach (var each_panel in GameObject.FindGameObjectsWithTag("TriangleWave"))
        {
            Destroy(each_panel);
        }

        foreach (var each_panel in GameObject.FindGameObjectsWithTag("SquareWave"))
        {
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
        
        GameObject ball = Instantiate(_cannonBall, _firingPosition.transform.position, _firingPosition.transform.rotation);
        CannonBall cannonBallInstance = ball.GetComponent<CannonBall>();
        if (cannonBallInstance != null)
        {
            cannonBallInstance.SetMass(massSlider.value);
            // changes velocity and destroys ball
            cannonBallInstance.SetVelocity(mySlider.value);
        }
        // ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 700f, 0));
    }


}
