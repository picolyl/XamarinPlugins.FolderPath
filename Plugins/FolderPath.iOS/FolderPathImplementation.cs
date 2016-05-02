using Foundation;
using PCLStorage.Abstractions;
using System;
using System.Linq;

namespace PCLStorage
{
    /// <summary>
    /// Implementation for FolderPath
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
                return NSBundle.MainBundle.BundlePath;
            }
        }

        /// <summary>
        /// Resource file path
        /// </summary>
        public string Resource
        {
            get
            {
                return NSBundle.MainBundle.ResourcePath;
            }
        }

        /// <summary>
        /// Local data path
        /// </summary>
        public string Local
        {
            get
            {
                return GetPath(NSSearchPathDirectory.LibraryDirectory);
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
                return TemporaryDirectory;
            }
        }

        /// <summary>
        /// Cache folder path
        /// </summary>
        public string Cache
        {
            get
            {
                return GetPath(NSSearchPathDirectory.CachesDirectory);
            }
        }

        /// <summary>
        /// Documents folder path
        /// </summary>
        public string Documents
        {
            get
            {
                return GetPath(NSSearchPathDirectory.DocumentDirectory);
            }
        }

        /// <summary>
        /// Pictures folder path
        /// </summary>
        public string Pictures
        {
            get
            {
                return GetPath(NSSearchPathDirectory.PicturesDirectory);
            }
        }

        /// <summary>
        /// Music folder path
        /// </summary>
        public string Music
        {
            get
            {
                return GetPath(NSSearchPathDirectory.MusicDirectory);
            }
        }

        /// <summary>
        /// Videos folder path
        /// </summary>
        public string Videos
        {
            get
            {
                return GetPath(NSSearchPathDirectory.MoviesDirectory);
            }
        }

        private string GetPath(NSSearchPathDirectory directory)
        {
            return NSSearchPath.GetDirectories(directory, NSSearchPathDomain.User).FirstOrDefault();
        }

        [System.Runtime.InteropServices.DllImport("/System/Library/Frameworks/Foundation.framework/Foundation")]
        private static extern IntPtr NSHomeDirectory();

        private static string HomeDirectory
        {
            get
            {
                return ((NSString)ObjCRuntime.Runtime.GetNSObject(NSHomeDirectory())).ToString();
            }
        }

        [System.Runtime.InteropServices.DllImport("/System/Library/Frameworks/Foundation.framework/Foundation")]
        private static extern IntPtr NSTemporaryDirectory();

        private static string TemporaryDirectory
        {
            get
            {
                return ((NSString)ObjCRuntime.Runtime.GetNSObject(NSTemporaryDirectory())).ToString();
            }
        }
    }
}
