namespace ProductReview.API.ExternalServices
{
    public class PictureExternalService
    {
        private readonly IWebHostEnvironment _env;

        public PictureExternalService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> AddPictureAndGetPath(IFormFile file)
        {
            string path = Path.Combine(_env.WebRootPath, "images", Guid.NewGuid() + file.FileName);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            return path;
        }
    }
}
