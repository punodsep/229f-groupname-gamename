using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollingCredits : MonoBehaviour
{
    public RectTransform creditTransform; 
    public float scrollSpeed = 100f;      
    public float endPositionY = 2000f;    

    void Update()
    {
        
        if (creditTransform.anchoredPosition.y < endPositionY)
        {
            creditTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        }
        else
        {
            
        }
    }
}
