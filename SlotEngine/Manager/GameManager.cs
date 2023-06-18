using SlotEngine.Services;

namespace SlotEngine.Manager
{
    public class GameManager : IGameManager
    {
        IRandomService _randomService;
        IGameSettingManager _gameSettingManager;

        public GameManager(IRandomService randomService, IGameSettingManager gameSettingManager)
        {
            this._randomService = randomService;
            this._gameSettingManager = gameSettingManager;
        }
    }
}
