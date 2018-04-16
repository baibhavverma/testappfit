using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the GameLevelsService service class.
    /// </summary>

    public interface IGameLevelsService
    {
        Task<GameLevel> Insert(GameLevel tblGameLevel);
        IEnumerable<GameLevel> GetAll();
        Task<GameLevel> GetByID(int GameLevelId);
        Task<GameLevel> Delete(int GameLeveltId);
        Task Update(int Id, GameLevel tblGameLevel);
    }

}
