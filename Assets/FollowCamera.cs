using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;
    public Vector3 playerPos;
    // Update is called once per frame
    void Update()
    {
           playerPos =  new Vector3(target.transform.position.x, target.transform.position.y, -10);
           transform.position = playerPos;

    }
}
