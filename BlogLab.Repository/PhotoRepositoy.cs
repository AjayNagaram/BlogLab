﻿using System.Data;
using System.Data.SqlClient;
using BlogLab.Models.Photo;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BlogLab.Repository
{
    public class PhotoRepositoy : IPhotoRepository
    {
        private readonly IConfiguration _config;

        public PhotoRepositoy(IConfiguration config)
        {
            _config = config;
        }

        public async Task<int> DeletePhoto(int photoId)
        {
            int affectedRows = 0;

            using(var connection = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
            {
                await connection.OpenAsync();

                affectedRows = await connection.ExecuteAsync("Phot_Delete",
                    new { PhotoId = photoId },
                    commandType: CommandType.StoredProcedure);
            }

            return affectedRows;
        }

        public async Task<List<Photo>> GetAllByUserIdAsync(int applicationUserId)
        {
            IEnumerable<Photo> photos;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
            {
                await connection.OpenAsync();

                photos = await connection.QueryAsync<Photo>("Photo_GetByUserId",
                    new { ApplicationUserId = applicationUserId },
                    commandType: CommandType.StoredProcedure);
            }
            
            return photos.ToList();
        }

        public async Task<Photo> GetAsync(int photoId)
        {
            Photo photo;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnectionString")))
            {
                await connection.OpenAsync();

                photo = await connection.QueryFirstOrDefaultAsync<Photo>("Photo_Get",
                    new { PhotoId = photoId },
                    commandType: CommandType.StoredProcedure);
            }

            return photo;

        }

        public async Task<Photo> InsertPhoto(Photo photoCreate, int applicationUserId)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("PublicId", typeof(string));
            dataTable.Columns.Add("ImageUrl", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));

            dataTable.Rows.Add(photoCreate.PublicId, photoCreate.ImageUrl, photoCreate.Description);

            int newPhotoId;

            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();

                newPhotoId = await connection.ExecuteScalarAsync<int>(
                    "Photo_Insert",
                    new
                    {
                        Photo = dataTable.AsTableValuedParameter("dbo.PhotoType"),
                        ApplicationUserId = applicationUserId
                    },
                    commandType: CommandType.StoredProcedure);
            }

            Photo photo = await GetAsync(newPhotoId);

            return photo;
        }
    }
}
