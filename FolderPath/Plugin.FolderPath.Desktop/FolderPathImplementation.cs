using Plugin.FolderPath.Abstractions;
using System;

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
                return AppPath;
            }
        }

        /// <summary>
        /// Local data path
        /// </summary>
        public string Local
        {
            get
            {
                return GetPath(Environment.SpecialFolder.LocalApplicationData, "Local");
            }
        }

        /// <summary>
        /// Roaming data path
        /// </summary>
        public string Roaming
        {
            get
            {
                return GetPath(Environment.SpecialFolder.ApplicationData);
            }
        }

        /// <summary>
        /// Tamporary data path
        /// </summary>
        public string Temporary
        {
            get
            {
                return GetPath(Environment.SpecialFolder.LocalApplicationData, "Temporary");
            }
        }

        /// <summary>
        /// Cache folder path
        /// </summary>
        public string Cache
        {
            get
            {
                return GetPath(Environment.SpecialFolder.LocalApplicationData, "Cache");
            }
        }

        /// <summary>
        /// Documents folder path
        /// </summary>
        public string Documents
        {
            get
            {
                return GetPath(Environment.SpecialFolder.MyDocuments);
            }
        }

        /// <summary>
        /// Pictures folder path
        /// </summary>
        public string Pictures
        {
            get
            {
                return GetPath(Environment.SpecialFolder.MyPictures);
            }
        }

        /// <summary>
        /// Music folder path
        /// </summary>
        public string Music
        {
            get
            {
                return GetPath(Environment.SpecialFolder.MyMusic);
            }
        }

        /// <summary>
        /// Videos folder path
        /// </summary>
        public string Videos
        {
            get
            {
                return GetPath(Environment.SpecialFolder.MyVideos);
            }
        }

        #region Helpers
        private string GetPath(Environment.SpecialFolder specialFolder, string subFolder = "")
        {
            var path = Environment.GetFolderPath(specialFolder);
            switch (specialFolder)
            {
                case Environment.SpecialFolder.ApplicationData:
                case Environment.SpecialFolder.LocalApplicationData:
                    path = System.IO.Path.Combine(path, CompanyName, AppName);
                    System.IO.Directory.CreateDirectory(path);
                    break;
            }
            if (!string.IsNullOrWhiteSpace(subFolder))
            {
                path = System.IO.Path.Combine(path, subFolder);
                System.IO.Directory.CreateDirectory(path);
            }
            return path;
        }

        private Lazy<string> _appPath = new Lazy<string>(() =>
        {
            var path = "";
            var assembly = System.Reflection.Assembly.GetEntryAssembly();
            if (assembly == null)
            {
                assembly = System.Reflection.Assembly.GetExecutingAssembly();
            }
            if (assembly != null)
            {
                path = System.IO.Path.GetDirectoryName(assembly.Location);
            }
            return path;
        });
        private string AppPath { get { return _appPath.Value; } }

        private string _appName = "";
        /// <summary>
        /// Local/Roaming folder Application Name
        /// </summary>
        public string AppName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_appName))
                {
                    return _appName;
                }
                else if (!string.IsNullOrWhiteSpace(InternalAppName))
                {
                    return InternalAppName;
                }
                else
                {
                    throw new MemberAccessException("There is a need to set a valid value to AppName.");
                }
            }
            set
            {
                _appName = value;
            }
        }

        private string _companyName = "";
        /// <summary>
        /// Local/Roaming folder Company Name
        /// </summary>
        public string CompanyName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_companyName))
                {
                    return _companyName;
                }
                else if (!string.IsNullOrWhiteSpace(InternalCompanyName))
                {
                    return InternalCompanyName;
                }
                else
                {
                    throw new MemberAccessException("There is a need to set a valid value to AssemblyCompany of AssemblyInfo.cs.");
                }
            }
            set
            {
                _companyName = value;
            }
        }

        private static Lazy<string> _internalAppName = new Lazy<string>(() => GetInternalAppName());
        private static string InternalAppName { get { return _internalAppName.Value; } }

        private static string GetInternalAppName()
        {
            var assembly = System.Reflection.Assembly.GetEntryAssembly();
            //if (assembly == null)
            //{
            //    assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //}
            var appName = "";
            if (assembly != null)
            {
                appName = System.IO.Path.GetFileNameWithoutExtension(assembly.Location);
            }
            return appName;
        }

        private static Lazy<string> _internalCompanyName = new Lazy<string>(() => GetInternalCompanyName());
        private static string InternalCompanyName { get { return _internalCompanyName.Value; } }

        private static string GetInternalCompanyName()
        {
            var assembly = System.Reflection.Assembly.GetEntryAssembly();
            //if (assembly == null)
            //{
            //    assembly = System.Reflection.Assembly.GetExecutingAssembly();
            //}
            var companyName = "";
            if (assembly != null)
            {
                var attribute = (System.Reflection.AssemblyCompanyAttribute)Attribute.GetCustomAttribute(
                    assembly, typeof(System.Reflection.AssemblyCompanyAttribute));
                companyName = attribute.Company;
            }
            return companyName;
        }
        #endregion Helpers
    }
}
