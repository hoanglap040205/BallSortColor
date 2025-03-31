using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int type;
    public Sprite[] sprites;
    private Animator anim;
    private float speed;
    public Tube tube;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        speed = 25f;
    }
    //Gọi hàm di chuyển đến từng đích
    /*public IEnumerator MoveBallCoroutine(Tube fromTube,Tube toTube)
    {
        yield return MovePos(fromTube.topPosition);
        yield return MovePos(toTube.topPosition);
        //yield return MovePos(toTube.GetTopPosition());
        anim.SetBool("Selected",false);

    }*/

    //Di chuyển bóng tới điểm đích
    /*public IEnumerator MovePos(Vector3 targetPosition)
    {
        //Biến targetPos sẽ lưu lại vị trí để tránh TH targetPos có thể bị null
        Vector3 targetPos = targetPosition;
        while (Vector3.Distance(transform.position,targetPos) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos,speed *Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
    }*/
    
    public void SetType(int type)
    {
        this.type = type;
        this.GetComponent<SpriteRenderer>().sprite = sprites[type];
    }
    
    
    
    
    
}
