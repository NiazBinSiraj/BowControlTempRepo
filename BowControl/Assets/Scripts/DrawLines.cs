using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    public GameObject lineGeneratorPrefab;
    private LineRenderer lineRendererComponent;
    private Vector3 intialPosPoint1;
    private Vector3 initialPosArrow;

    public GameObject[] points = new GameObject[5];
    public GameObject[] corners = new GameObject[5];
    public GameObject arrow;
    public GameObject arrowBack;

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject newLine = Instantiate(lineGeneratorPrefab);
        lineRendererComponent = newLine.GetComponent<LineRenderer>();
        intialPosPoint1 = points[1].transform.position;
        initialPosArrow = arrow.transform.position;
        SpawnLineGenarator();
    }

    void Update()
    {
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0.0f;
            mousePos.y = 0.0f;
            if(isValid(mousePos.x, mousePos.y)){
                points[1].transform.position = mousePos;
                mousePos.x = mousePos.x - (arrow.transform.position.x - arrowBack.transform.position.x);
                arrow.transform.position = mousePos;
            }
            else points[1].transform.position = intialPosPoint1;
        }
        else
        {
            points[1].transform.position = intialPosPoint1;
            arrow.transform.position = initialPosArrow;
        }
        SpawnLineGenarator();
    }

    private void SpawnLineGenarator()
    {
        lineRendererComponent.positionCount = 3;

        lineRendererComponent.SetPosition(0, new Vector3(points[0].transform.position.x, points[0].transform.position.y, points[0].transform.position.z));
        lineRendererComponent.SetPosition(1, new Vector3(points[1].transform.position.x, points[1].transform.position.y, points[1].transform.position.z));
        lineRendererComponent.SetPosition(2, new Vector3(points[2].transform.position.x, points[2].transform.position.y, points[2].transform.position.z));
    }

    private bool isValid(float x, float y)
    {
        return x>=corners[0].transform.position.x && x<=corners[1].transform.position.x && y<= corners[0].transform.position.y && y>= corners[2].transform.position.y;
    }
}
