namespace webApp.Utility
{
    public static class CreateFile
    {
        public static string CreateFiles(IWebHostEnvironment _webHost, IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);

            string fileName = Guid.NewGuid().ToString() + extension;
            var uploads = Path.Combine(_webHost.WebRootPath, $@"{folderName}");

            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
            {
                file.CopyTo(fileStreams);
            }

            var path = @"\" + folderName + @"\" + fileName;
            return path;
        }
    }
}
