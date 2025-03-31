using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Tube selectedTube = null;
    private List<Ball> sameBall;
    private List<MoveState> listUndo;


    private void Update()
    {
        OnClickMouse();
    }

    private void OnClickMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Camera.main == null) return ;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider == null) return ;
            if (hit.collider.CompareTag("Tube"))
            {
                Tube clickedTube = hit.collider.GetComponent<Tube>();
                if (clickedTube != null)
                {
                    HandleTubeClick(clickedTube);
                }
            }
        }
    }




    //Xử kí khi ấn chọn vào ống nghiệm.
        private void HandleTubeClick(Tube clickedTube)
        {
            //
            if (selectedTube == null)
            {
                if (clickedTube.balls.Count == 0) return;
                selectedTube = clickedTube;
                StartCoroutine(MoveToTop(selectedTube.PopBall()));
                Debug.Log("Selected Tube");


            }
            else
            {
                if (selectedTube != clickedTube)
                {
                    //Di chuyen bong
                }
                else
                {
                }
            }
        }

        IEnumerator MoveToTop(Ball ball)
        {
            Debug.Log("Di chuyen len");
            while (Vector3.Distance(transform.position,ball.tube.topPosition.position) > 0.01f)
            {
                ball.transform.position = Vector3.Lerp(transform.position, ball.tube.topPosition.position,15f *Time.deltaTime);
                yield return null;
            }
            ball.transform.position = ball.tube.topPosition.position;
        }
        
    
}


    
    
   
    







