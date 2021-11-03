using Microsoft.AspNetCore.Hosting;
using Products_Inc.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Products_Inc.Models.Services
{
    public class ImageService : IImageService
    {
        public ImageServiceOptions Options { get; set; }

        public ImageService(ImageServiceOptions imageServiceOptions)
        {
            Options = imageServiceOptions;
        }
        public byte[] GetImage(string name)
        {
            throw new NotImplementedException();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string SaveImage(string base64data)
        {
            byte[] newBytes = Convert.FromBase64String(base64data);
            string name = RandomString(10);
            string path = $"{Options.RootPath}/{Options.FolderName}/{name}.{Options.ImageFormat}";
            Image image;

            using (MemoryStream ms = new MemoryStream(newBytes))
            {

                image = Image.FromStream(ms);
                image.Save(path);
            }

            image.Dispose();

            return $"{Options.FolderName}/{name}.{Options.ImageFormat}";

        }
    }

    public class ImageServiceOptions
    {
        public string RootPath { get; set; }
        public string FolderName { get; set; }

        public string ImageFormat { get; set; }

        public ImageServiceOptions(string rootPath, string folderName, string imageFormat)
        {
            RootPath = rootPath;
            FolderName = folderName;
            ImageFormat = imageFormat;
        }
    }
}
