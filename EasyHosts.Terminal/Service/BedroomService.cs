using EasyHosts.Terminal.Models;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyHosts.Terminal.Service
{
    public class BedroomService
    {
        private readonly Context _context;

        public BedroomService(Context context)
        {
            _context = context;
        }
        public async Task<List<Bedroom>> FindAllAsync()
        {
            return await _context.Bedroom.ToListAsync();
        }
    }
}