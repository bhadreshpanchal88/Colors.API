using Colors.BAL;
using Colors.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Colors.Services
{

    public class ColorsRepository : IColorsRepository
    {
        private string _filePath;
        public ColorsRepository(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Get All Colors from file
        /// </summary>
        /// <returns>List of colors</returns>
        public async Task<List<ColorsModel>> GetAll()
        {
            try
            {
                var list = await this.ReadJSONFile();
                return list;
            }
            catch (Exception ex)
            {
                //Add Error logging logic here
                string errormsg = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Get Color by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Single Color</returns>
        public async Task<ColorsModel> GetColorByName(string name)
        {
            try
            {
                var list = await this.ReadJSONFile();
                return list.Where(c=> c.Name == name).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //Add Error logging logic here
                string errormsg = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Add New Color in file
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddColor(ColorsModel entity)
        {
            try
            {
                var list = await this.ReadJSONFile();

                list.Add(entity);

                var writeData = await Task.Run(() => JsonConvert.SerializeObject(list, Formatting.Indented));
                using (var writer = new StreamWriter(_filePath))
                {
                    writer.Write(writeData);
                }

                return true;
            }
            catch (Exception ex)
            {
                //Add Error logging logic here
                string errormsg = ex.Message;
                return false;
            }
        }

        public Task<ColorsModel> Update(ColorsModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<ColorsModel> Delete(int id)
        {
            throw new NotImplementedException();
        }


        private async Task<List<ColorsModel>> ReadJSONFile()
        {
            var jsonString = File.ReadAllText(_filePath);
            return await Task.Run(() => JsonConvert.DeserializeObject<List<ColorsModel>>(jsonString));
        }
    }
}
