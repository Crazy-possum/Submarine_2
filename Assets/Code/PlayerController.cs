using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PointsViewer _pointsViewer;
    private TransformSercher _transformSercher;
    public bool IsMoveAvalible;

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (IsMoveAvalible)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveToRight();
                IsMoveAvalible = false;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                MoveToLeft();
                IsMoveAvalible = false;
            }
        }
    }

    private void MoveToRight()
    {
        if (gameObject.transform.position.x != 5)
        {
            gameObject.transform.position = new Vector2(transform.position.x + 2.5f, transform.position.y);
        }

        //foreach (PointsGroup pViewer in _pointsViewer.Points)
        //{
         //   _transformSercher = pViewer.gameObject.GetComponent<TransformSercher>();
       // }
        
    }

    private void MoveToLeft()
    {
        if (gameObject.transform.position.x != -5)
        {
            gameObject.transform.position = new Vector2(transform.position.x - 2.5f, transform.position.y);
        }
    }
}
