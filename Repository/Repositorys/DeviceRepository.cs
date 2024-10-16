using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhatDoYouOwn_ASPNET.Migrations;
using WhatDoYouOwn_ASPNET.Models;
using WhatDoYouOwn_ASPNET.Repository.Interfaces;

namespace WhatDoYouOwn_ASPNET.Repository.Repositorys
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly MyDbContext _context;

        public DeviceRepository(MyDbContext context)
        {
            _context = context;
        }

        // Obtém todos os dispositivos
        public async Task<IEnumerable<DeviceModel>> GetAllDevicesAsync()
        {
            return await _context.Computador.ToListAsync();
        }

        // Obtém um dispositivo por ID
        public async Task<DeviceModel> GetDeviceByIdAsync(int id)
        {
            return await _context.Computador.FindAsync(id);
        }

        // Adiciona um novo dispositivo
        public async Task<DeviceModel> AddDeviceAsync(DeviceModel device)
        {
            _context.Computador.Add(device);
            await _context.SaveChangesAsync();

            return device;
        }

        // Atualiza um dispositivo existente
        public async Task UpdateDeviceAsync(DeviceModel device)
        {
            _context.Entry(device).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Remove um dispositivo pelo ID
        public async Task<bool> DeleteDeviceAsync(int id)
        {
            var device = await _context.Computador.FindAsync(id);
            if (device != null)
            {
                _context.Computador.Remove(device);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<DeviceModel>> GetDevicesByUserIdAsync(int idfUsuario)
        {
            return await _context.Computador
                                 .Where(d => d.IdfUsuario == idfUsuario)
                                 .ToListAsync();
        }
    }
}
