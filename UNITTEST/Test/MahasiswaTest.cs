
using API.Controllers;
using API.Models.Db;
using API.Models.Dto;
using API.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UNITTEST.Helper;
using UNITTEST.Response;

namespace UNITTEST.Test
{
    public class MahasiswaTest
    {
        private readonly MahasiswaRequestDto _requestDtoNull;
        private readonly SetupService _setupService;
        private readonly MahasiswaResponse _mahasiswaResponse;

        public MahasiswaTest()
        {
            _mahasiswaResponse = new MahasiswaResponse();
            _setupService = new SetupService();
            _requestDtoNull = new MahasiswaRequestDto();
        }

        [Fact]
        public async Task GetListMahasiswa()
        {
            ServiceResponse<List<mahasiswa>> dataResponse = _mahasiswaResponse.GetDataListMahasiswa();

            MahasiswaController mahasiswaController = await _setupService.GetMahasiswaController(_requestDtoNull);
            var resultGetListMahasiswa = await mahasiswaController.GetListMahasiswa();
            var resultOk = Assert.IsType<OkObjectResult>(resultGetListMahasiswa.Result);

            var dataJsonString = JsonConvert.SerializeObject(resultOk.Value);
            var dataJson = JsonConvert.DeserializeObject<ServiceResponse<List<mahasiswa>>>(dataJsonString);
            //var dataJsonResponseString = JsonConvert.SerializeObject(dataResponse);

            Assert.True(dataJson.Is_Success && dataJson.Data.Count > 0);

            //Assert.True(dataJsonString.Equals(dataJsonResponseString));
        }
    }
}
