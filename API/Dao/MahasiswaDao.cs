
using API.Models.Data;
using API.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace API.Dao
{
    public interface IMahasiswaDao
    {
        Task<List<mahasiswa>> GetListMahasiswa();
        Task<mahasiswa> GetSingleMahasiswaById(int id);
        Task<bool> InsertMahasiswa(mahasiswa dataInsert);
        Task<bool> UpdateMahasiswa(mahasiswa dataUpdate);
        Task<bool> DeleteMahasiswaById(int id);
    }

    public class MahasiswaDao : IMahasiswaDao
    {
        private readonly MahasiswaContext _context;

        public MahasiswaDao(MahasiswaContext context)
        {
            _context = context;
        }

        public async Task<List<mahasiswa>> GetListMahasiswa()
        {
            return await _context.mahasiswas.AsNoTracking().ToListAsync();
        }

        public async Task<mahasiswa> GetSingleMahasiswaById(int id)
        {
            return await _context.mahasiswas.AsNoTracking().Where(q => q.id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> InsertMahasiswa(mahasiswa dataInsert)
        {
            _context.mahasiswas.Add(dataInsert);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateMahasiswa(mahasiswa dataUpdate)
        {
            mahasiswa dataOld = await _context.mahasiswas.FindAsync(dataUpdate.id);

            if(dataOld != null)
            {
                dataOld.nama = dataUpdate.nama;
                dataOld.umur = dataUpdate.umur;
                dataOld.alamat = dataUpdate.alamat; 
                dataOld.created_date = dataUpdate.created_date;
                dataOld.updated_date = DateTime.UtcNow;
                dataOld.is_active = true;

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteMahasiswaById(int id)
        {
            mahasiswa dataOld = await _context.mahasiswas.FindAsync(id);

            if (dataOld != null) {
                _context.mahasiswas.Remove(await GetSingleMahasiswaById(id));
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
