namespace ShootingGame.Level
{
	public interface ILevelManager
	{
		public int CurrentLevel { get; }
		
		public void OnLevelWin();
		
		public void ResetProgress();

	}
}