
using API.Dao;
using API.Models.Db;
using API.Models.Dto;
using API.Models.Shared;

namespace API.Services
{
    public interface IMahasiswaServices
    {
        Task<ServiceResponse<mahasiswa>> GetSingleMahasiswa(int id);
        Task<ServiceResponse<List<mahasiswa>>> GetListMahasiswa();
        Task<ServiceResponse<bool>> InsertMahasiswa(MahasiswaRequestDto dataInsert);
        Task<ServiceResponse<bool>> UpdateMahasiswa(MahasiswaRequestDto dataUpdate);
        Task<ServiceResponse<bool>> DeleteMahasiswa(int id);
    }

    public class MahasiswaServices : IMahasiswaServices
    {
        private readonly IMahasiswaDao _mahasiswaDao;

        public MahasiswaServices(IMahasiswaDao mahasiswaDao)
        {
            _mahasiswaDao = mahasiswaDao;
        }

        public async Task<ServiceResponse<List<mahasiswa>>> GetListMahasiswa()
        {
            ServiceResponse<List<mahasiswa>> response = new();
            List<mahasiswa> data = new();

            try
            {
                data = await _mahasiswaDao.GetListMahasiswa();

                if (data.Count > 0)
                {
                    response.Data = data;
                }
                else
                {
                    response.Message = "Data is Null";
                }

            }
            catch (Exception ex)
            {
                response.Is_Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<mahasiswa>> GetSingleMahasiswa(int id)
        {
            ServiceResponse<mahasiswa> response = new();
            mahasiswa data = new();

            try
            {
                data = await _mahasiswaDao.GetSingleMahasiswaById(id);

                if (data != null)
                {
                    response.Data = data;
                }
                else
                {
                    response.Message = "Data is Null";
                }
            }
            catch (Exception ex)
            {
                response.Is_Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> InsertMahasiswa(MahasiswaRequestDto dataInsert)
        {
            ServiceResponse<bool> response = new();
            mahasiswa data = new();

            try
            {
                data = await _mahasiswaDao.GetSingleMahasiswaById(dataInsert.Id);

                if (data != null)
                {
                    response.Is_Success = false;
                    response.Message = "Already Id Registered";
                    return response;
                }

                data = new()
                {
                    id = dataInsert.Id,
                    nama = dataInsert.Nama,
                    alamat = dataInsert.Alamat,
                    umur = dataInsert.Umur,
                    created_date = DateTime.UtcNow,
                    is_active = true,
                };


                response.Data = await _mahasiswaDao.InsertMahasiswa(data);
            }
            catch (Exception ex)
            {
                response.Is_Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateMahasiswa(MahasiswaRequestDto dataUpdate)
        {
            ServiceResponse<bool> response = new();
            mahasiswa data = new();

            try
            {
                data = await _mahasiswaDao.GetSingleMahasiswaById(dataUpdate.Id);

                if (data == null)
                {
                    response.Is_Success = false;
                    response.Message = "No Have Data with this Id";
                    return response;
                }

                data = new()
                {
                    id = dataUpdate.Id,
                    nama = dataUpdate.Nama,
                    alamat = dataUpdate.Alamat,
                    umur = dataUpdate.Umur,
                    updated_date = DateTime.UtcNow,
                };

                response.Data = await _mahasiswaDao.UpdateMahasiswa(data);
            }
            catch (Exception ex)
            {
                response.Is_Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<bool>> DeleteMahasiswa(int id)
        {
            ServiceResponse<bool> response = new();
            mahasiswa data = new();

            try
            {
                data = await _mahasiswaDao.GetSingleMahasiswaById(id);

                if (data == null)
                {
                    response.Is_Success = false;
                    response.Message = "No Have Data with this Id";
                    return response;
                }

                response.Data = await _mahasiswaDao.DeleteMahasiswaById(id);
            }
            catch (Exception ex)
            {
                response.Is_Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
