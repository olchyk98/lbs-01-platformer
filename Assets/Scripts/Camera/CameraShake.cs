using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region Inspector Exposed Fields
    [SerializeField] [Range(.01f, .8f)] private float myDuration;
    [SerializeField] [Range(.01f, .8f)] private float myMagnitude;
    #endregion

    #region Private Fields

    private Transform myTransform;

    #endregion
    
    #region RP Methods

    private void Start()
    {
        // Cache transform
        myTransform = GetComponent<Transform>();
    }
    #endregion
    
    #region Methods

    /// <summary>
    /// Exposed method that can be used to shake the camera
    /// </summary>
    public void Shake()
    {
        StartCoroutine(StartShake());
    }
    
    /// <summary>
    /// Coroutine that shakes camera within the magnitude range.
    /// </summary>
    /// <returns>
    /// Coroutine Enumerator
    /// </returns>
    private IEnumerator StartShake()
    {
        // Save start position
        Vector3 startPosition = myTransform.localPosition;
            
        // Declare variable for elapsed millis
        float elapsed = 0f;
            
        // Shake the camera
        while (elapsed < myDuration)
        {
            float x = Random.Range(-1f, 1f) * myMagnitude;
            float y = Random.Range(-1f, 1f) * myMagnitude;
                
            myTransform.localPosition = new Vector3(x, y, startPosition.z);

            elapsed += Time.deltaTime;
                
            yield return null;
        }
            
        // Restore camera position
        myTransform.localPosition = startPosition;
    }
    #endregion
}
