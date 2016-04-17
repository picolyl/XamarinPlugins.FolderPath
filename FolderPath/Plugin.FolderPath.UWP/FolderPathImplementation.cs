using Plugin.FolderPath.Abstractions;
using System;
using Windows.Storage;

namespace Plugin.FolderPath
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
                return Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            }
        }

        /// <summary>
        /// Local data path
        /// </summary>
        public string Local
        {
            get
            {
                return ApplicationData.Current.LocalFolder.Path;
            }
        }

        /// <summary>
        /// Roaming data path
        /// </summary>
        public string Roaming
        {
            get
            {
                return ApplicationData.Current.RoamingFolder.Path;
            }
        }

        /// <summary>
        /// Tamporary data path
        /// </summary>
        public string Temporary
        {
            get
            {
                return ApplicationData.Current.TemporaryFolder.Path;
            }
        }

        /// <summary>
        /// Cache folder path
        /// </summary>
        public string Cache
        {
            get
            {
#if WINDOWS_UWP || WINDOWS_PHONE_APP
                return ApplicationData.Current.LocalCacheFolder.Path;
#else
                return null;
#endif
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
                return null;
            }
        }

        /// <summary>
        /// Music folder path
        /// </summary>
        public string Music
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Videos folder path
        /// </summary>
        public string Videos
        {
            get
            {
                return null;
            }
        }
    }
}
