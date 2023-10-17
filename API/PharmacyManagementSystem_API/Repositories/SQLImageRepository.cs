namespace PharmacyManagementSystem.API.Repositories
{
    public class SQLImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images", fileName);
            using Stream stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return GetPath(fileName);
        }

        private string GetPath(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}
