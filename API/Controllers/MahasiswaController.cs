
using API.Models.Db;
using API.Models.Dto;
using API.Models.Shared;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        private readonly IMahasiswaServices _mahasiswaServices;

        public MahasiswaController(IMahasiswaServices mahasiswaServices)
        {
            _mahasiswaServices = mahasiswaServices;
        }

        [HttpGet("get_list_mahasiswa")]
        public async Task<ActionResult<ServiceResponse<List<mahasiswa>>>> GetListMahasiswa()
        {
            ServiceResponse<List<mahasiswa>> response = new();

            try
            {
                response = await _mahasiswaServices.GetListMahasiswa();

                if (response.Is_Success)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }

            } catch (Exception ex) {
                response.Is_Success = false;
                response.Message = ex.Message;
                return NotFound(response);
            }
        }

        [HttpGet("get_single_mahasiswa")]
        public async Task<ActionResult<ServiceResponse<List<mahasiswa>>>> GetSingeMahasiswa(int id)
        {
            ServiceResponse<mahasiswa> response = new();

            try
            {
                response = await _mahasiswaServices.GetSingleMahasiswa(id);

                if (response.Is_Success)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
                
            }
            catch (Exception ex)
            {
                response.Is_Success = false;
                response.Message = ex.Message;
                return NotFound(response);
            }
        }

        [HttpPost("insert_mahasiswa")]
        public async Task<ActionResult<ServiceResponse<bool>>> InsertMahasiswa(MahasiswaRequestDto dataInsert)
        {
            ServiceResponse<bool> response = new();

            try
            {
                response = await _mahasiswaServices.InsertMahasiswa(dataInsert);

                if (response.Is_Success)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                response.Is_Success = false;
                response.Message = ex.Message;
                return NotFound(response);
            }
        }

        [HttpPut("update_mahasiswa")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateMahasiswa(MahasiswaRequestDto dataUpdate)
        {
            ServiceResponse<bool> response = new();

            try
            {
                response = await _mahasiswaServices.UpdateMahasiswa(dataUpdate);

                if (response.Is_Success)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                response.Is_Success = false;
                response.Message = ex.Message;
                return NotFound(response);
            }
        }

        [HttpDelete("delete_mahasiswa/{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> GetListMahasiswa(int id)
        {
            ServiceResponse<bool> response = new();

            try
            {
                response = await _mahasiswaServices.DeleteMahasiswa(id);

                if (response.Is_Success)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                response.Is_Success = false;
                response.Message = ex.Message;
                return NotFound(response);
            }
        }
    }
}
