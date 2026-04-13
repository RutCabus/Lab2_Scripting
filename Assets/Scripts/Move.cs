using UnityEngine;

public class Move : MonoBehaviour
{
    //Variables
    public Vector3 movementSpeed; //1
    public Space space;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}
