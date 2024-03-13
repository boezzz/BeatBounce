using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cannon : MonoBehaviour
{
    
    public Transform _turret;
    public Transform _barrel;
    public GameObject _firingPosition;

    public GameObject _cannonBall;

    public Slider mySlider;

    //public void Fire() => Instantiate(_cannonBall, _firingPosition.transform.position, _firingPosition.transform.rotation);
    public void Fire() => makeCannonBall();
    //public void MoveUp() => _barrel.transform.Rotate(Vector3.right, 1);
    //public void DownUp() => _barrel.transform.Rotate(Vector3.right, -1);
    //public void RightUp() => _turret.transform.Rotate(Vector3.up, -1);
    //public void LeftUp() => _turret.transform.Rotate(Vector3.up, 1);


    void makeCannonBall()
    {

        //Instantiate(_cannonBall, _firingPosition.transform.position, _firingPosition.transform.rotation);
        //_cannonBall.velocity = mySlider.value;

        //GameObject newCannonBall = Instantiate(_cannonBall, _firingPosition.transform.position, _firingPosition.transform.rotation);
        //CannonBall cannonBallScript = newCannonBall.GetComponent<CannonBall>();
        //if (cannonBallScript != null)
        //{
        //    cannonBallScript.SetVelocity(mySlider.value);
        //}


        GameObject ball = Instantiate(_cannonBall, _firingPosition.transform.position,
                                                     _firingPosition.transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                             (0, 700f, 0));

    }

    //public void SetVelocity()
    //{
    //    velocity = mySlider.value;
    //}

}