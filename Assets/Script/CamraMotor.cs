using UnityEngine;

public class CamraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    private void Start()
    {
        lookAt = GameObject.Find("player_0").transform;
    }
    
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        
        float delataX = lookAt.position.x - transform.position.x;
        if (delataX > boundX || delataX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = delataX - boundX;
            }
            else
            {
                delta.x = delataX + boundX;
            }
        }

        float delataY = lookAt.position.y - transform.position.y;
        if (delataY > boundY || delataY < -boundY)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.y = delataY - boundY;
            }
            else
            {
                delta.y = delataY + boundY;
            }
        }
        
        transform.position += new Vector3(delta.x,delataY,0);

    }
}
