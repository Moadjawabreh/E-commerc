using MedicalTools.Context;
using MedicalTools.Models;

namespace MedicalTools
{
    public class LayoutService
    {
            private readonly ApplicationContext _context; // Replace with your actual DbContext

            public LayoutService(ApplicationContext context)
            {
                _context = context;
            }

            public List<Category> GetCategories()
            {
                return _context.categories.ToList();
            }
    }
}
