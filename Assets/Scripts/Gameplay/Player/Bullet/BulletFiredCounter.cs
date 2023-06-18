namespace ShootingGame.Player
{
    public class BulletFiredCounter
    {
        public static BulletFiredCounter Instance => _instance ??= new BulletFiredCounter();
        private static BulletFiredCounter _instance;

        public int BulletsFired { get; private set; }

        private BulletFiredCounter()
        {
            Reset();
        }

        public void OnBullerFired()
        {
            BulletsFired++;
        }

        public void Reset()
        {
            BulletsFired = 0;
        }
    }
}
