namespace Emlakci.WEBUI.Mapping
{
    public static class ImageMethod
    {
        internal static void DeleteImage(string fileName)
        {
            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\RealEstate\\img", fileName);

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
        }

        internal static async Task<string> UploadImage(IFormFile file)
        {
            string newFileName = GenerateUniqueFileName(file.FileName, ".jpg");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\RealEstate\\img", newFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return newFileName;
        }

        private static string GenerateUniqueFileName(string fileName, string fileExtension = ".jpg")
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var uniqueName = $"{timestamp}{fileExtension}";
            return uniqueName;
        }
    }
}
