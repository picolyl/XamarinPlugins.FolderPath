using PCLStorage.Abstractions;
using System;

namespace PCLStorage
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class FolderPathImplementation : IFolderPath
    {
        /// <summary>
        /// Application path
        /// </summary>
        public string App
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Local data path
        /// </summary>
        public string Local
        {
            get
            {
                return Android.App.Application.Context.FilesDir.AbsolutePath;
            }
        }

        /// <summary>
        /// Roaming data path
        /// </summary>
        public string Roaming
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Tamporary data path
        /// </summary>
        public string Temporary
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Cache folder path
        /// </summary>
        public string Cache
        {
            get
            {
                return Android.App.Application.Context.CacheDir.AbsolutePath;
            }
        }

        /// <summary>
        /// Documents folder path
        /// </summary>
        public string Documents
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Pictures folder path
        /// </summary>
        public string Pictures
        {
            get
            {
                return GetPath(Android.OS.Environment.DirectoryPictures);
            }
        }

        /// <summary>
        /// Music folder path
        /// </summary>
        public string Music
        {
            get
            {
                return GetPath(Android.OS.Environment.DirectoryMusic);
            }
        }

        /// <summary>
        /// Videos folder path
        /// </summary>
        public string Videos
        {
            get
            {
                return GetPath(Android.OS.Environment.DirectoryMovies);
            }
        }

        private string GetPath(Java.IO.File javaFile)
        {
            var path = javaFile.AbsolutePath;
            return path;
        }

        private string GetPath(string type)
        {
            var javaFile = Android.OS.Environment.GetExternalStoragePublicDirectory(type);
            return GetPath(javaFile);
        }
    }
}
