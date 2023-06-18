namespace ShootingGame.Life
{
   public interface ILifeSystem
   {
      public int CurrentLifeCount { get; }
      public void ReduceLife(int amount = 1);
   }
}