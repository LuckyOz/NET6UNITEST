
using Moq;
using Moq.EntityFrameworkCore;
using API.Dao;
using API.Models.Db;
using API.Models.Data;
using Microsoft.EntityFrameworkCore;
using API.Services;
using API.Models.Dto;
using API.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using Microsoft.Extensions.Options;

namespace UNITTEST.Helper
{
    public class SetupService
    {
        private Mock<MahasiswaContext> GetMahasiswaContext()
        {
            var data = new List<mahasiswa>
            {
                new mahasiswa
                {
                    id = 1,
                    nama = "Arya Santoso",
                    alamat = "Dago - Bandung",
                    umur = 20,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 2,
                    nama = "Astrid Ardia",
                    alamat = "Nginden - Surabaya",
                    umur = 21,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 3,
                    nama = "Budi Arga",
                    alamat = "Cicaheum - Bandung",
                    umur = 22,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 4,
                    nama = "Dini Andari",
                    alamat = "Menteng - Jakarta",
                    umur = 21,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 5,
                    nama = "Dwi Ciska",
                    alamat = "Merdeka - Malang",
                    umur = 22,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 6,
                    nama = "Edi Prastowo",
                    alamat = "Dago - Bandung",
                    umur = 23,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 7,
                    nama = "Eka Sapta",
                    alamat = "Setiabudi - Bandung",
                    umur = 22,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 8,
                    nama = "Fifin Aliana",
                    alamat = "Mande - Mataram",
                    umur = 24,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 9,
                    nama = "Giri Rekso",
                    alamat = "Perak - Surabaya",
                    umur = 21,
                    created_date = DateTime.UtcNow,
                    is_active = true
                },
                new mahasiswa
                {
                    id = 10,
                    nama = "Heri Ahmad Surya",
                    alamat = "Antapani - Bandung",
                    umur = 24,
                    created_date = DateTime.UtcNow,
                    is_active = true
                }
            }.AsQueryable();
            var mahasiswaContext = new Mock<MahasiswaContext>();
            mahasiswaContext.Setup<DbSet<mahasiswa>>(x => x.mahasiswas)
                .ReturnsDbSet(data);

            return mahasiswaContext;
        }

        private async Task<Mock<IMahasiswaDao>> GetMahasiswaDaoMoq(Mock<MahasiswaContext> mahasiswaContextMoq, mahasiswa dataRequest)
        {
            MahasiswaDao mahasiswaDao = new MahasiswaDao(mahasiswaContextMoq.Object);
            var resultMahasiswaDaoGetListMahasiswa = await mahasiswaDao.GetListMahasiswa();
            var resultMahasiswaDaoGetSingleMahasiswa = await mahasiswaDao.GetSingleMahasiswaById(dataRequest.id);
            var resultMahasiswaDaoInsertMahasiswa = await mahasiswaDao.InsertMahasiswa(dataRequest);
            var resultMahasiswaDaoUpdateMahasiswa = await mahasiswaDao.UpdateMahasiswa(dataRequest);
            var resultMahasiswaDaoDeleteMahasiswa = await mahasiswaDao.DeleteMahasiswaById(dataRequest.id);

            Mock<IMahasiswaDao> mahasiswaDaoMoq = new();
            mahasiswaDaoMoq.Setup(q => q.GetListMahasiswa()).ReturnsAsync(resultMahasiswaDaoGetListMahasiswa);
            mahasiswaDaoMoq.Setup(q => q.GetSingleMahasiswaById(dataRequest.id)).ReturnsAsync(resultMahasiswaDaoGetSingleMahasiswa);
            mahasiswaDaoMoq.Setup(q => q.InsertMahasiswa(dataRequest)).ReturnsAsync(resultMahasiswaDaoInsertMahasiswa);
            mahasiswaDaoMoq.Setup(q => q.UpdateMahasiswa(dataRequest)).ReturnsAsync(resultMahasiswaDaoUpdateMahasiswa);
            mahasiswaDaoMoq.Setup(q => q.DeleteMahasiswaById(dataRequest.id)).ReturnsAsync(resultMahasiswaDaoDeleteMahasiswa);

            return mahasiswaDaoMoq;
        }

        private async Task<Mock<IMahasiswaServices>> GetMahasiswaServiceMoq(Mock<IMahasiswaDao> mahasiswaDaoMoq, MahasiswaRequestDto dataRequest)
        {
            MahasiswaServices mahasiswaService = new MahasiswaServices(mahasiswaDaoMoq.Object);
            var resultMahasiswaServiceGetListMahasiswa = await mahasiswaService.GetListMahasiswa();
            var resultMahasiswaServiceGetSingleMahasiswa = await mahasiswaService.GetSingleMahasiswa(dataRequest.Id);
            var resultMahasiswaServiceInsertMahasiswa = await mahasiswaService.InsertMahasiswa(dataRequest);
            var resultMahasiswaServiceUpdateMahasiswa = await mahasiswaService.UpdateMahasiswa(dataRequest);
            var resultMahasiswaServiceDeleteMahasiswa = await mahasiswaService.DeleteMahasiswa(dataRequest.Id);

            Mock<IMahasiswaServices> mahasiswaServiceMoq = new();
            mahasiswaServiceMoq.Setup(q => q.GetListMahasiswa()).ReturnsAsync(resultMahasiswaServiceGetListMahasiswa);
            mahasiswaServiceMoq.Setup(q => q.GetSingleMahasiswa(dataRequest.Id)).ReturnsAsync(resultMahasiswaServiceGetSingleMahasiswa);
            mahasiswaServiceMoq.Setup(q => q.InsertMahasiswa(dataRequest)).ReturnsAsync(resultMahasiswaServiceInsertMahasiswa);
            mahasiswaServiceMoq.Setup(q => q.UpdateMahasiswa(dataRequest)).ReturnsAsync(resultMahasiswaServiceUpdateMahasiswa);
            mahasiswaServiceMoq.Setup(q => q.DeleteMahasiswa(dataRequest.Id)).ReturnsAsync(resultMahasiswaServiceDeleteMahasiswa);

            return mahasiswaServiceMoq;
        }

        public async Task<MahasiswaController> GetMahasiswaController(MahasiswaRequestDto dataRequest)
        {
            mahasiswa dataMhs = new();

            if (dataRequest.Nama != null) {
                dataMhs.id = dataRequest.Id;
                dataMhs.nama = dataRequest.Nama;
                dataMhs.alamat = dataRequest.Alamat;
                dataMhs.umur = dataRequest.Umur;
                dataMhs.created_date = DateTime.UtcNow;
                dataMhs.updated_date = DateTime.UtcNow;
                dataMhs.is_active = true;
            }

            var mahasiswaContext = GetMahasiswaContext();
            var mahasiswaDao = await GetMahasiswaDaoMoq(mahasiswaContext, dataMhs);
            var mahasiswaService = await GetMahasiswaServiceMoq(mahasiswaDao, dataRequest);

            MahasiswaController promotionController = new MahasiswaController(mahasiswaService.Object);

            return promotionController;
        }
    }
}
