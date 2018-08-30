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

                    fileScanResult.Log.AppendLine(
                        $"FOLDER name:'{(string.IsNullOrEmpty(folderName) ? "root" : folderName)}'");

                    string[] filePaths;
                    try
                    {
                        filePaths = Directory.GetFiles(folderPath, "*.*");
                        fileScanResult.ProcessedFolderCount += 1;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        fileScanResult.Log.AppendLine($"ERROR folder-access rights-:'{folderPath}'");
                        fileScanResult.FoldersWithErrorCount += 1;
                        continue;
                    }
                    catch (Exception)
                    {
                        fileScanResult.Log.AppendLine($"ERROR folder-unknown-:'{folderPath}'");
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
                            fileScanResult.Log.AppendLine($"ERROR file-access rights-:'{filePath}'");
                            fileScanResult.FilesWithErrorCount += 1;
                            continue;
                        }
                        catch (Exception)
                        {
                            fileScanResult.Log.AppendLine($"ERROR file-unknown-:'{filePath}'");
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
                            $"FILE level:{locations[i].Level}, name:'{info.Name}', extension:'{info.Extension}', path:'{info.DirectoryName}', dateCreated:{info.CreationTime}, dateModified:{info.LastWriteTime}, size:{Convert.ToDecimal(info.Length)}, isreadonly:{info.IsReadOnly}");
                    }

                    string[] folderPaths = Directory.GetDirectories(folderPath);
                    foreach (var path in folderPaths)
                    {
                        locations.Add(new FolderLevel { FolderPath = path, Level = locations[i].Level + 1 });
                    }
                }

                fileScanResult.TotalTime = DateTime.Now.Subtract(currentTime);
                fileScanResult.Log.AppendLine(
                    $"Scan finished:{fileScanResult.TotalTime.Hours}hs:{fileScanResult.TotalTime.Minutes}min:{fileScanResult.TotalTime.Seconds}sec:{fileScanResult.TotalTime.Milliseconds}msec, files:{fileScanResult.ProcessedFileCount}, fileErrors:{fileScanResult.FilesWithErrorCount}, folders:{fileScanResult.ProcessedFolderCount}, folderErrors:{fileScanResult.FoldersWithErrorCount}");
            });
            fileScanTask.Start();
            return fileScanTask;
        }
    }
}