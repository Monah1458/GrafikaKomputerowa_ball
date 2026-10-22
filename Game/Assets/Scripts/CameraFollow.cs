using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset= new Vector3(2, 2, 2);
    void Start()
    {
         transform.Rotate(30,0,0);
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(15, 15, 0);// + offset;
       
    }

}