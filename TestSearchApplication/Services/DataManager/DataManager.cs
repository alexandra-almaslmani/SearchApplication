using TestSearchApplication.Data;
using TestSearchApplication.Models;
using TestSearchApplication.Services.DataManager.Interfaces;

namespace TestSearchApplication.Services.DataManager
{
    public class DataManager : IDataManager
    {
        private readonly DataMSAccessContext _context;
        public DataManager(DataMSAccessContext context)
        {
            _context = context;
        }
        public List<Tab> Add(Tab tab)
        {
            _context.Tabs.Add(tab);
            _context.SaveChanges();
            return _context.Tabs.ToList();
        }

        //public List<Hadith> GetAllHadiths()
        //{
        //    return _context.Hadiths.ToList(); 
        //}
    }
}
