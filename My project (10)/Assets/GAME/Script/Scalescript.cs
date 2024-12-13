using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalescript : MonoBehaviour
{
    public Transform topbox;
    public Transform bottombox; 
    public Transform leftbox;
    public Transform rightbox;
    public Vector3 Screenbounds;
    public Camera Camera;

    public AnchorGameObject leftanchor;
    public AnchorGameObject rightanchor;
    public float Area;
    public float distancex;
    public float desiredArea = 86.6115f;

    public bool check = true;

    public void Awake()
    {
        Camera = Camera.main;
        check = true;
    }

    public void Start()
    {
      StartCoroutine(Checkchecker());
    }

    public void Update()
    {
        if (check)
        {
            Camera cam = Camera.main;
            Screenbounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -1));
            topbox.transform.localScale = new Vector3(Screenbounds.x * 2, topbox.transform.localScale.y, 1);
            // topbox.transform.localScale =new( Screen.width,Screen.height);
            float distancey = Vector3.Distance(topbox.transform.position, bottombox.transform.position);
            Debug.Log("Distance between top and bottom objects: " + distancey);

            distancex = Vector3.Distance(leftbox.transform.position, rightbox.transform.position);
            Debug.Log("Distance between left and right objects: " + distancex);
            Area = distancex * distancey;
            Debug.Log("Distance area " + Area);

            //if distancex > 8.56 it means that the box scale needs to be changed
            leftanchor = leftbox.transform.GetComponent<AnchorGameObject>();
            rightanchor = rightbox.transform.GetComponent<AnchorGameObject>();

            if (distancex >= 8.56f)
            {
                //move sides cloaser toghter    
                float offset;
                offset = 8.55f - distancex;
                offset /= 2;
                leftanchor.anchorOffset = new(-offset, -2.7f, 0);
                rightanchor.anchorOffset = new(offset, -2.7f, 0);

                Debug.Log(" bigger than offset" + offset);
            }
            else if (distancex < 8.55)
            {
               
                float screenAspectRatio = (float)Screen.width / Screen.height;

                // Calculate the required orthographic size to fit the width of the box
                // Formula: cameraSize >= boxWidth / (2 * screenAspectRatio)
                float requiredCameraSizeForWidth = 8.55f / (2 * screenAspectRatio);

                // Get the current orthographic size of the camera
                float currentCameraSize = Camera.orthographicSize;

                // Ensure the height is visible (boxHeight / 2 is always less than cameraSize, so no adjustment needed)
                float requiredCameraSizeForHeight = 8.55f / 2;

                // Take the maximum of the two sizes (height is always visible, but calculate for safety)
                float finalCameraSize = Mathf.Max(requiredCameraSizeForWidth, requiredCameraSizeForHeight);

                // Apply the calculated camera size
                Camera.orthographicSize = finalCameraSize;
                float offset;
                offset = 8.55f - distancex;
                offset /= 2;
                leftanchor.anchorOffset = new(-offset, -2.7f, 0);
                rightanchor.anchorOffset = new(offset, -2.7f, 0);

                Debug.Log($"Adjusted Camera Size: {finalCameraSize}");
            }
        }
    }
        
       public IEnumerator Checkchecker()
    {
        Debug.Log("checker started" + check);
        yield return new WaitForSeconds(2);
        check= false;

        Debug.Log("checker ended" + check);
        yield return null;
    } 
    

}
