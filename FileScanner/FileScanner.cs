using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileScanner
{
    public class FileScanner
    {
        public static Task ScanFolderForFilesAsync(string initialFolder, FileScanResult fileScanResult)
        {
            var fileScanTask = new Task(() =>
            {
                var currentTime = DateTime.Now;
                var locations = new List<FolderLevel> { new FolderLevel { FolderPath = initialFolder, Level = 0 } };

                for (int i = 0; i < locations.Count; i++)
                {
                    string folderPath = locations[i].FolderPath;
                    string folderName = Path.GetFileNameWithoutExtension(folderPath);

                    fileScanResult.Log.AppendLine(string.Format("FOLDER name:'{0}'",
                                                 string.IsNullOrEmpty(folderName) ? "root" : folderName));

                    string[] filePaths;
                    try
                    {
                        filePaths = Directory.GetFiles(folderPath, "*.*");
                        fileScanResult.ProcessedFolderCount += 1;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        fileScanResult.Log.AppendLine(string.Format("ERROR folder-access rights-:'{0}'", folderPath));
                        fileScanResult.FoldersWithErrorCount += 1;
                        continue;
                    }
                    catch (Exception)
                    {
                        fileScanResult.Log.AppendLine(string.Format("ERROR folder-unknown-:'{0}'", folderPath));
                        fileScanResult.FoldersWithErrorCount += 1;
                        continue;
                    }

                    foreach (var filePath in filePaths)
                    {
                        FileInfo info;
                        try
                        {
                            info = new FileInfo(filePath);
                            fileScanResult.ProcessedFileCount += 1;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            fileScanResult.Log.AppendLine(string.Format("ERROR file-access rights-:'{0}'", filePath));
                            fileScanResult.FilesWithErrorCount += 1;
                            continue;
                        }
                        catch (Exception)
                        {
                            fileScanResult.Log.AppendLine(string.Format("ERROR file-unknown-:'{0}'", filePath));
                            fileScanResult.FilesWithErrorCount += 1;
                            continue;
                        }

                        fileScanResult.Items.Add(new FileScanItem
                        {
                            Level = locations[i].Level,
                            Name = info.Name,
                            Extension = info.Extension,
                            FolderPath = info.DirectoryName,
                            FolderName =  info.Directory != null ? info.Directory.Name : string.Empty,
                            CreationTime = info.CreationTime,
                            LastWriteTime = info.LastWriteTime,
                            Size = info.Length,
                            IsReadOnly = info.IsReadOnly
                        });

                        fileScanResult.Log.AppendLine(
                            string.Format(
                                "FILE level:{0}, name:'{1}', extension:'{2}', path:'{3}', dateCreated:{4}, dateModified:{5}, size:{6}, isreadonly:{7}",
                                locations[i].Level,
                                info.Name,
                                info.Extension,
                                info.DirectoryName,
                                info.CreationTime,
                                info.LastWriteTime,
                                Convert.ToDecimal(info.Length),
                                info.IsReadOnly
                                ));
                    }

                    string[] folderPaths = Directory.GetDirectories(folderPath);
                    foreach (var path in folderPaths)
                    {
                        locations.Add(new FolderLevel { FolderPath = path, Level = locations[i].Level + 1 });
                    }
                }

                fileScanResult.TotalTime = DateTime.Now.Subtract(currentTime);
                fileScanResult.Log.AppendLine(string.Format("Scan finished:{0}hs:{1}min:{2}sec:{3}msec, files:{4}, fileErrors:{5}, folders:{6}, folderErrors:{7}", fileScanResult.TotalTime.Hours, fileScanResult.TotalTime.Minutes, fileScanResult.TotalTime.Seconds, fileScanResult.TotalTime.Milliseconds, fileScanResult.ProcessedFileCount, fileScanResult.FilesWithErrorCount, fileScanResult.ProcessedFolderCount, fileScanResult.FoldersWithErrorCount));
            });
            fileScanTask.Start();
            return fileScanTask;
        }

        //public static void ScanFolderForFiles(string folderPath, FileScanResult fileScanResult, int level, StringBuilder log)
        //{
        //    string folderName = Path.GetFileNameWithoutExtension(folderPath);

        //    log.AppendLine(string.Format("FOLDER name:'{0}'",
        //                                 string.IsNullOrEmpty(folderName) ? "root" : folderName));

        //    string[] filePaths;
        //    try
        //    {
        //        filePaths = Directory.GetFiles(folderPath, "*.*");
        //        fileScanResult.ProcessedFolderCount += 1;
        //    }
        //    catch (UnauthorizedAccessException)
        //    {
        //        log.AppendLine(string.Format("ERROR folder-access rights-:'{0}'", folderPath));
        //        fileScanResult.FoldersWithErrorCount += 1;
        //        return;
        //    }
        //    catch (Exception)
        //    {
        //        log.AppendLine(string.Format("ERROR folder-unknown-:'{0}'", folderPath));
        //        fileScanResult.FoldersWithErrorCount += 1;
        //        return;
        //    }

        //    foreach (var filePath in filePaths)
        //    {
        //        FileInfo info;
        //        try
        //        {
        //            info = new FileInfo(filePath);
        //            fileScanResult.ProcessedFileCount += 1;
        //        }
        //        catch (UnauthorizedAccessException)
        //        {
        //            log.AppendLine(string.Format("ERROR file-access rights-:'{0}'", filePath));
        //            fileScanResult.FilesWithErrorCount += 1;
        //            continue;
        //        }
        //        catch (Exception)
        //        {
        //            log.AppendLine(string.Format("ERROR file-unknown-:'{0}'", filePath));
        //            fileScanResult.FilesWithErrorCount += 1;
        //            continue;
        //        }

        //        log.AppendLine(
        //            string.Format(
        //                "FILE level:{0}, name:'{1}', extension:'{2}', path:'{3}', dateCreated:{4}, dateModified:{5}, size:{6}",
        //                level,
        //                info.Name,
        //                info.Extension,
        //                info.Directory,
        //                info.CreationTime,
        //                info.LastWriteTime,
        //                Convert.ToDecimal(info.Length)
        //                ));
        //    }

        //    string[] folderPaths = Directory.GetDirectories(folderPath);
        //    foreach (var path in folderPaths)
        //    {
        //        ScanFolderForFiles(path, fileScanResult, level + 1, log);
        //    }
        //}
    }
}