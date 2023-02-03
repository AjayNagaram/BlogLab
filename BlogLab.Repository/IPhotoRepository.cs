using BlogLab.Models.Photo;

namespace BlogLab.Repository
{
    public interface IPhotoRepository
    {
        public Task<Photo> InsertPhoto(PhotoCreate photo, int applicationUserId);
        public Task<Photo> GetAsync(int photoId);
        public Task<List<Photo>> GetAllByUserIdAsync(int applicationUserId);
        public Task<int> DeletePhoto(int photoId);
    }
}
