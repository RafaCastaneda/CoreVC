using System;
using System.Collections.Generic;
using System.IO;

namespace CoreVC.Serve.Services
{
    using Api.Directory;

    public class DirectoryService
    {
        private readonly DirectoryInfo root;

        public DirectoryService()
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            root = new DirectoryInfo(rootPath);
        }

        public List<FilePath> Dir(string queryPath)
        {
            string path = Path.Combine(queryPath.Split('/'));
            string basePath = Path.Combine(root.FullName, path);

            var baseDirectory = new DirectoryInfo(basePath);
            if (!baseDirectory.Exists) {
                throw new DirectoryNotFoundException();
            }

            var filePaths = new List<FilePath>();

            foreach (var directory in baseDirectory.EnumerateDirectories()) {
                var filePath = new FilePath {
                    Path = Path.Combine(path, directory.Name),
                    IsDirectory = true,
                };
                filePaths.Add(filePath);
            }
            foreach (var file in baseDirectory.EnumerateFiles()) {
                var filePath = new FilePath {
                    Path = Path.Combine(path, file.Name),
                };
                filePaths.Add(filePath);
            }

            return filePaths;
        }
    }
}
