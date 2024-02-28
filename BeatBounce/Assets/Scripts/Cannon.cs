using UnityEngine;

public class Cannon : MonoBehaviour
{
    //[SerializeField] private Transform _turret;
    //[SerializeField] private GameObject _firingPosition;
    //[SerializeField] private GameObject _cannonBall;

    public Transform _turret;
    public Transform _barrel;
    public GameObject _firingPosition;

    public GameObject _cannonBall;

    public void Fire() => Instantiate(_cannonBall, _firingPosition.transform.position, _firingPosition.transform.rotation);
    public void MoveUp() => _barrel.transform.Rotate(Vector3.right, 1);
    public void DownUp() => _barrel.transform.Rotate(Vector3.right, -1);
    public void RightUp() => _turret.transform.Rotate(Vector3.up, -1);
    public void LeftUp() => _turret.transform.Rotate(Vector3.up, 1);

}