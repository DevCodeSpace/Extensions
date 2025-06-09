using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class FileExtensions
    {
        /// <summary>
        /// Copies content of this file to another file.
        /// </summary>
        public static async Task CopyToAsync(this FileInfo sourceFile, FileInfo destinationFile)
        {
            using var sourceStream = sourceFile.OpenRead();
            using var destinationStream = destinationFile.Create();
            await sourceStream.CopyToAsync(destinationStream);
        }

        /// <summary>
        /// Asynchronously clears the content of this file, leaving it empty.
        /// </summary>
        public static async Task ClearAsync(this FileInfo file)
        {
            await File.WriteAllTextAsync(file.FullName, string.Empty);
        }

        /// <summary>
        /// Synchronously clears the content of this file, leaving it empty.
        /// </summary>
        public static void ClearSync(this FileInfo file)
        {
            File.WriteAllText(file.FullName, string.Empty);
        }

        /// <summary>
        /// Sets up an event listener that triggers when the file is modified.
        /// </summary>
        public static FileSystemWatcher OnModified(this FileInfo file, Action action)
        {
            var watcher = new FileSystemWatcher(file.DirectoryName, file.Name)
            {
                NotifyFilter = NotifyFilters.LastWrite
            };
            watcher.Changed += (s, e) => action();
            watcher.EnableRaisingEvents = true;
            return watcher;
        }

        /// <summary>
        /// Sets up an event listener that triggers when the file is deleted.
        /// </summary>
        public static FileSystemWatcher OnDeleted(this FileInfo file, Action action)
        {
            var watcher = new FileSystemWatcher(file.DirectoryName, file.Name)
            {
                NotifyFilter = NotifyFilters.FileName
            };
            watcher.Deleted += (s, e) => action();
            watcher.EnableRaisingEvents = true;
            return watcher;
        }

        /// <summary>
        /// Appends a string to the file asynchronously.
        /// </summary>
        public static async Task AppendStringAsync(this FileInfo file, string value, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            await File.AppendAllTextAsync(file.FullName, value, encoding);
        }

        /// <summary>
        /// Appends a string to the file synchronously.
        /// </summary>
        public static void AppendStringSync(this FileInfo file, string value, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            File.AppendAllText(file.FullName, value, encoding);
        }

        /// <summary>
        /// Appends a line to the file asynchronously.
        /// </summary>
        public static async Task AppendLineAsync(this FileInfo file, string value, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            await File.AppendAllTextAsync(file.FullName, value + Environment.NewLine, encoding);
        }

        /// <summary>
        /// Appends bytes to the file asynchronously.
        /// </summary>
        public static async Task AppendBytesAsync(this FileInfo file, byte[] bytes)
        {
            await using var fileStream = file.Open(FileMode.Append, FileAccess.Write);
            await fileStream.WriteAsync(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Appends bytes to the file synchronously.
        /// </summary>
        public static void AppendBytesSync(this FileInfo file, byte[] bytes)
        {
            using var fileStream = file.Open(FileMode.Append, FileAccess.Write);
            fileStream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Appends the content of another file to this file asynchronously.
        /// </summary>
        public static async Task AppendFromAsync(this FileInfo file, FileInfo sourceFile)
        {
            await using var destinationStream = file.Open(FileMode.Append, FileAccess.Write);
            await using var sourceStream = sourceFile.OpenRead();
            await sourceStream.CopyToAsync(destinationStream);
        }

        /// <summary>
        /// Appends the content of another file to this file synchronously.
        /// </summary>
        public static void AppendFromSync(this FileInfo file, FileInfo sourceFile)
        {
            using var destinationStream = file.Open(FileMode.Append, FileAccess.Write);
            using var sourceStream = sourceFile.OpenRead();
            sourceStream.CopyTo(destinationStream);
        }

        /// <summary>
        /// Appends a string to the file using the << operator.
        /// </summary>
        public static void AppendOperator(this FileInfo file, string value)
        {
            file.AppendStringSync(value);
        }

        /// <summary>
        /// Appends the content of another file to this file using the + operator.
        /// </summary>
        public static void AppendFileOperator(this FileInfo file, FileInfo sourceFile)
        {
            file.AppendFromSync(sourceFile);
        }

        /// <summary>
        /// Checks asynchronously if the file is empty.
        /// </summary>
        public static async Task<bool> IsEmptyAsync(this FileInfo file)
        {
            return (await file.LengthAsync()) == 0;
        }

        /// <summary>
        /// Checks if the file is empty synchronously.
        /// </summary>
        public static bool IsEmptySync(this FileInfo file)
        {
            return file.Length == 0;
        }

        /// <summary>
        /// Gets the length of the file asynchronously.
        /// </summary>
        public static async Task<long> LengthAsync(this FileInfo file)
        {
            await using var stream = file.OpenRead();
            return stream.Length;
        }
    }
}
