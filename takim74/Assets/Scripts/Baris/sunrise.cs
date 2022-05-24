using UnityEngine;

public class sunrise : MonoBehaviour
{
    public float _directionalSpeed = 10f;
    
    void Update()
    {
        transform.RotateAround(new Vector3(250f, 0, 250f), Vector3.right, _directionalSpeed * Time.deltaTime);
    }
}
