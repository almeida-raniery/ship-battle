public class FrontCannon : Cannon
{
   public override void Shoot()
   {
       CannonBall bullet = MakeBullet();

       bullet.gameObject.SetActive(true);
   }
}
