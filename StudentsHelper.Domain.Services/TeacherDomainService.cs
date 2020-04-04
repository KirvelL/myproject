using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using StudentsHelper.Domain.Interfaces;
using StudentsHelper.Domain.Services.Models.Teacher;
using StudentsHelper.Infastructure;
using StudentsHelper.Infastructure.Interfaces;

namespace StudentsHelper.Domain.Services
{
    public class TeacherDomainService : ITeacherDomainService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public TeacherDomainService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }
        public Teacher GetTeacherById(Guid id)
        {
            return _unitOfWork.TeachersRepository.GetTeacherById(id);
        }
        public async Task<IEnumerable<Review>> GetTeacherReview(Guid id)
        {
            return (await _unitOfWork.TeachersRepository.GetTeacherWithReview(id)).Reviews;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersForMaterial(Guid materialId)
        {
            return (await _unitOfWork.TeachersRepository.GetTeachersForMaterialAsync(materialId));
        }
        public IEnumerable<Teacher> GetAll()
        {
            return _unitOfWork.TeachersRepository.GetAll();
        }

        public async Task Create(CreateTeacherDTO teacher)
        {
            Teacher temp = new Teacher();
            temp.FirstName = teacher.FirstName;
            temp.LastName = teacher.LastName;
            temp.OtherInformation = teacher.OtherInformation;
            temp.Id = Guid.NewGuid();
            temp.Avatar = temp.Id + ".jpg";
            _unitOfWork.TeachersRepository.Create(temp);

            var connectionString = _config["AzureStorage:ConnectionString"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            var containerName = _config["AzureStorage:UserPhotoContainerName"];
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            await blobContainer.CreateIfNotExistsAsync();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(temp.Avatar);
            await blob.UploadFromStreamAsync(teacher.Avatar);
        }
        public async Task Delete(Teacher teacher)
        {
            _unitOfWork.TeachersRepository.Delete(teacher);
            var connectionString = _config["AzureStorage:ConnectionString"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            var containerName = _config["AzureStorage:UserPhotoContainerName"];
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
            await blobContainer.CreateIfNotExistsAsync();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(teacher.Avatar);
            await blob.DeleteAsync();
        }
        public Teacher Read(Teacher teacher)
        {
            return _unitOfWork.TeachersRepository.Read(teacher);
        }
        public async Task Update(UpdateTeacherDTO teacher)
        {
            var dbTeacher = _unitOfWork.TeachersRepository.GetTeacherById(teacher.Id);
            dbTeacher.FirstName = teacher.FirstName;
            dbTeacher.LastName = teacher.LastName;
            dbTeacher.OtherInformation = teacher.OtherInformation;

            if (teacher.Avatar != null && teacher.Avatar.Length > 0)
            {
                var connectionString = _config["AzureStorage:ConnectionString"];
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                var containerName = _config["AzureStorage:UserPhotoContainerName"];
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);
                await blobContainer.CreateIfNotExistsAsync();
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(dbTeacher.Avatar);
                await blob.DeleteAsync();
                await blob.UploadFromStreamAsync(teacher.Avatar);

                dbTeacher.Avatar = dbTeacher.Id + ".jpg";
            }
            
            _unitOfWork.TeachersRepository.Update(dbTeacher);
        }
        public IEnumerable<Teacher> GetTeacher()
        {

            return new List<Teacher>();
        }
        public IEnumerable<Teacher> GetImage()
        {

            return new List<Teacher>();
        }
        public IEnumerable<Teacher> AddReview()
        {

            return new List<Teacher>();
        }
        public IEnumerable<Teacher> AddTeacher()
        {
            return new List<Teacher>();
        }

    }
}
