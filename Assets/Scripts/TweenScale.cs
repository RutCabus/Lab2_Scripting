using UnityEngine;

public class TweenScale : MonoBehaviour
{

    public float targetScale;
    public float timeToReachTarget;
    public float startScale;
    private float percentScaled;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startScale = transform.localScale.x; 
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f)
        {
            percentScaled += Time.deltaTime / timeToReachTarget;

            float scale = Mathf.Lerp(startScale, targetScale, percentScaled);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
