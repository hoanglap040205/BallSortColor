using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public BallColor ballColor;
    public BallState currentBallState;
    private Animator anim;
    private float speed;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        SetAnim(BallState.Idle);    
        speed = 25f;
    }
    //Gọi hàm di chuyển đến từng đích
    public IEnumerator MoveBallCoroutine(Tube fromTube,Tube toTube)
    {
        yield return MovePos(fromTube.topPosition.position);
        yield return MovePos(toTube.topPosition.position);
        yield return MovePos(toTube.GetTopPosition());
        SetAnim(BallState.Idle);
    }


    //Di chuyển bóng tới điểm đích
    public IEnumerator MovePos(Vector3 targetPosition)
    {
        //Biến targetPos sẽ lưu lại vị trí để tránh TH targetPos có thể bị null
        Vector3 targetPos = targetPosition;
        while (Vector3.Distance(transform.position,targetPos) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos,speed *Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
    }

    public void SetAnim(BallState newState)
    {
        if(currentBallState == newState) return;
        currentBallState = newState;
        switch (currentBallState)
        {
            case BallState.Idle:
                anim.SetBool("Selected",false);
                break;
            case BallState.Selecting:
                anim.SetBool("Selected",true);
                break;  


        }
    }
}
