using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Tube selectedTube = null;
    private List<Ball> sameBalls;
    private Stack<MoveState> undoStack = new Stack<MoveState>();
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Camera.main == null ) return;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if(hit.collider == null ) return;
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
            if (clickedTube.balls.Count== 0) return;
            selectedTube = clickedTube;
            sameBalls = selectedTube.GetSameBallCanPop();
        }else
        {
            if (selectedTube != clickedTube)
            {
                Debug.Log(clickedTube.name);
                HandleBallMove(sameBalls,selectedTube,clickedTube);
            }
            else
            {
                BallDeselected(sameBalls);
                selectedTube = null;
            }
        }
    }


    private void BallDeselected(List<Ball> ball)
    {
        ball = sameBalls;
        if(sameBalls.Count ==  0) return;
        foreach (var b in ball)
        {
          b.Deselected();  
        }
    }

    public void HandleBallMove(List<Ball> balls, Tube fromTube, Tube toTube)
    {
        foreach (var b in sameBalls)
        {
            if (toTube.CanReciveBall(b))
            {
                fromTube.balls.Remove(b);
                StartCoroutine(MoveBallCoroutine(selectedTube, toTube,b));
                toTube.balls.Add(b);
            }
            else
            {
                selectedTube = null;
            }
        } 
    }
    
    public IEnumerator MoveBallCoroutine(Tube fromTube,Tube toTube,Ball ball)
    {
        yield return MovePos(ball,fromTube.topPosition.position);
        yield return MovePos(ball,toTube.topPosition.position);
        yield return MovePos(ball,toTube.Pos());
        var move = new MoveState()
        {
            ball = ball,
            from = fromTube,
            to = toTube,
        };
        undoStack.Push(move);
        ball.Deselected();
    }
    public IEnumerator MovePos(Ball ball,Vector3 targetPos)
    {
        //Biến targetPos sẽ lưu lại vị trí để tránh TH targetPos có thể bị null
        //Vector3 targetPos = targetPosition;
        while (Vector3.Distance(ball.transform.position,targetPos) > 0.01f)
        {
            ball.transform.position = Vector3.Lerp(ball.transform.position, targetPos,25f *Time.deltaTime);
            yield return null;
        }
        ball.transform.position = targetPos;
    }

    //Hàm undo
    public void UndoMove()
    {
        if (undoStack.Count == 0)
        {
            Debug.Log("Het luot return");
            return;
        }
        var undoMove = undoStack.Pop();
        undoMove.ball.transform.position = undoMove.from.topPosition.position;
        undoMove.to.balls.Remove(undoMove.ball);
        undoMove.from.balls.Add(undoMove.ball);

    }
    
    
    
}



