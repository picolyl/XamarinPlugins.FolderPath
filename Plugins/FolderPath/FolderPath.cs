using PCLStorage.Abstractions;
using System;

namespace PCLStorage
{
    /// <summary>
    /// Cross platform FolderPath implemenations
    /// </summary>
    public class FolderPath
    {
        static Lazy<IFolderPath> Implementation = new Lazy<IFolderPath>(() => CreateFolderPath(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        public static IFolderPath Current
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
            set
            {
                Implementation = new Lazy<IFolderPath>(() => value);
            }
        }

        static IFolderPath CreateFolderPath()
        {
#if PORTABLE
            return null;
#else
            return new FolderPathImplementation();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
