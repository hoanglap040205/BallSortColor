using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
   public List<Ball> balls = new List<Ball>();
   public Ball ballPrefab;
   public int maxBall = 4;
   public Transform topPosition;
   
   public void InstantiateBall(int type)
   {
      var ball = Instantiate(ballPrefab, transform);
      ball.SetType(type);
      if(balls.Count >= 4) return;
      balls.Add(ball);
      ball.transform.localPosition = Pos();
   }
   public Vector3 Pos()
   {
      return new Vector3(0, balls.Count * 0.6f,0);
   }
 //Hàm kiểm tra xem có thể nhận bóng hay không
   public bool CanReciveBall(Ball ball)
   {
      return balls.Count == 0 || balls[balls.Count - 1].type == ball.type && balls.Count < 4;
   }

   //Lấy bóng có màu tương tự với bóng ở đỉnh liên tiếp
   public List<Ball> GetSameBallCanPop()
   {
      if(balls.Count == 0) return null;
      List<Ball> listBall = new List<Ball>();
      Ball ballType = balls[balls.Count - 1];
      for (int i = balls.Count - 1; i >= 0; i--)
      {
         if (balls[i].type == ballType.type)
         {
            listBall.Add(balls[i]);
            balls[i].Selected();
         }
         else
         {
            break;
         }
      }
      return listBall;
   }
   //Kiểm tra xem bình đã hoàn thành hay rỗng
   public bool IsFullSameColor()
   {
      if (balls.Count == 0) return true;
      if(balls.Count != 4) return false;
      int type = balls[0].type;
      for (int i = 0; i < 4; i++)
      {
         if (type != balls[i].type)
         {
            return false;
         }
      }

      return true;
   }

   
   
}