using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Repository
{
    public class CardiacCatheterizationStudyRepository : ICardiacCatheterizationStudyRepository
    {
        private readonly ManagementContext _context;

        public CardiacCatheterizationStudyRepository(ManagementContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<CardiacCatheterizationStudy>> GetCardiacCatheterizationStudiesAsync()
        {
            return await _context.CardiacCatheterizationStudies.ToListAsync();
        }

        public async Task<CardiacCatheterizationStudy> GetCardiacCatheterizationStudyAsync(int id)
        {
            return await _context.CardiacCatheterizationStudies.FindAsync(id);
        }
    }
}