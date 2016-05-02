using System;

namespace PCLStorage.Abstractions
{
    /// <summary>
    /// Interface for FolderPath
    /// </summary>
    public interface IFolderPath
    {
        /// <summary>
        /// Application path
        /// </summary>
        string App { get; }
        /// <summary>
        /// Local data path
        /// </summary>
        string Local { get; }
        /// <summary>
        /// Roaming data path
        /// </summary>
        string Roaming { get; }
        /// <summary>
        /// Tamporary data path
        /// </summary>
        string Temporary { get; }
        /// <summary>
        /// Cache folder path
        /// </summary>
        string Cache { get; }
        /// <summary>
        /// Documents folder path
        /// </summary>
        string Documents { get; }
        /// <summary>
        /// Pictures folder path
        /// </summary>
        string Pictures { get; }
        /// <summary>
        /// Music folder path
        /// </summary>
        string Music { get; }
        /// <summary>
        /// Videos folder path
        /// </summary>
        string Videos { get; }
    }
}
