using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
   public List<Ball> balls = new List<Ball>();
   public Ball ballPrefab;
   public int maxBall = 4;
   public Transform topPosition;
   
   
   public static Ball ballPoped;
   //public static Tube tubePoped;
   

   
 //Hàm kiểm tra xem có thể nhận bóng hay không
   public bool CanReciveBall(Ball ball)
   {
      return balls.Count == 0 || balls[balls.Count - 1].type == ball.type && balls.Count < 4;
   }

   //Lấy bóng có màu tương tự với bóng ở đỉnh liên tiếp
   public List<Ball> GetSameBallCanPop(int type)
   {
      if(balls.Count == 0) return null;
      List<Ball> listBall = new List<Ball>();
      for (int i = balls.Count - 1; i >= 0; i--)
      {
         if (balls[i].type == type)
         {
            listBall.Add(balls[i]);
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


   
   //Instantiate ball
   public Ball InstantiateBall(int type)
   {
      var ball = Instantiate(ballPrefab, transform);
      ball.SetType(type);
      return ball;
   }
   
   //Add ball vao danh sach
   public void AddBall(Ball ball)
   {
      if(balls.Count >= 4) return;
      balls.Add(ball);
     // ball.transform.SetParent(transform);
      ball.tube = this;
      ball.transform.localPosition = new Vector3(0, balls.Count * 0.5f,0);
   }


   public Ball PopBall()
   {
      if(balls.Count == 0) return null;
      ballPoped = balls[balls.Count - 1];
      balls.Remove(ballPoped);
      return ballPoped;
      

   }
   
   
}