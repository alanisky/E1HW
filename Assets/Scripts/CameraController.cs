using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void Start()
    {
 
        if (player != null)
        {
            offset = transform.position - player.position;
            offset.x = 0;
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

 
        Vector3 targetPosition = player.position + offset;

      
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);


        transform.position = smoothPosition;

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}
