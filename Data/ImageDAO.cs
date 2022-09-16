using API.Models;

using Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ImageDAO
    {
        private readonly IDbContextFactory<CancellationTokenTestContext> factory;

        public ImageDAO(IDbContextFactory<CancellationTokenTestContext> factory)
        {
            this.factory = factory;
        }

        public async Task<int> InsertAsync(string name, byte[] data, CancellationToken token = default)
        {
            using var db = factory.CreateDbContext();
            var image = new IMAGE
            {
                Name = name,
                IMAGE_DATA = new IMAGE_DATA
                {
                    Data = data
                }
            };
            db.IMAGE.Add(image);
            await db.SaveChangesAsync(token); //commit transaction
            int ID = image.ID;
            return ID;
        }

        public async Task<List<Image>> LoadAllAsync(CancellationToken token = default) 
        {
            using var db = factory.CreateDbContext();
            var query = from image in db.IMAGE.Include(image => image.IMAGE_DATA)
                        select new Image
                        {
                            ID = image.ID,
                            Name = image.Name,
                            Data = image.IMAGE_DATA.Data
                        };
            return await query.ToListAsync(token);
        }
    }
}
