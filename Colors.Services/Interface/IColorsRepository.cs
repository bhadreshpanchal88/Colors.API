
using Colors.BAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Colors.Services.Interface
{
    public interface IColorsRepository
    {
        Task<List<ColorsModel>> GetAll();
        Task<ColorsModel> GetColorByName(string name);
        Task<bool> AddColor(ColorsModel entity);
        Task<ColorsModel> Update(ColorsModel entity);
        Task<ColorsModel> Delete(int id);
    }
}
