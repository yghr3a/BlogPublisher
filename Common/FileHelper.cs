using BlogPublisher.CustomException;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogPublisher.Helper
{
    public static class FileHelper
    {
        public static string GetFileContent(string path)
        {
            if(String.IsNullOrWhiteSpace(path)) 
                throw new FileHelperException("获取文件内容失败!", new ArgumentNullException("文件路径为空!"));

            try
            {
                return File.ReadAllText(path);
            }
            catch(Exception ex) 
            {
                throw new FileHelperException("获取文件内容!", ex);
            }
        }

        public static string GetFileContent(string dir, string name, string exName)
        {
            var fileName = ContactFileName(dir, name, exName);
            return GetFileContent(fileName);
        }

        public static List<string> GetFileNamesInDir(string dir)
        {
            if (String.IsNullOrWhiteSpace(dir))
                throw new FileHelperException("获取某一目录下的所有文件的名字失败!", new ArgumentNullException("文件路径为空!"));

            if (Directory.Exists(dir) == false)
                throw new FileHelperException("获取某一目录下的所有文件的名字失败!");

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dir);

                var fileInfos = dirInfo.GetFiles();

                return fileInfos.Select(f => Path.GetFileNameWithoutExtension(f.Name)).ToList();

            }
            catch (Exception ex)
            {
                throw new FileHelperException("获取某一目录下的所有文件的名字失败!", ex);
            }

        }

        public static string GetFileName(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) 
                throw new FileHelperException("文件路径为空!");

            try
            {
                var name =  Path.GetFileNameWithoutExtension(path);
                if (String.IsNullOrWhiteSpace(name))
                    throw new FileHelperException("获取文件名字失败");

                return name;
            }
            catch (Exception ex)
            {
                throw new FileHelperException("获取文件名字失败", ex);
            }
        }

        public static void WriteInto(string path, string content)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new FileHelperException("写入文件失败", new ArgumentNullException("文件路径为空!"));

            File.WriteAllText(path, content);
        }

        // 在"dir"目录下创建名字为"name",后缀为"exName"的文件
        public static string CreateFile(string dir, string name, string exName)
        {
            var fileName = ContactFileName(dir, name, exName);
            try
            {
                using(File.Create(fileName)){ }
                return fileName;
            }
            catch(Exception ex) 
            {
                throw new FileHelperException("创建文件失败",ex);
            }
        }

        /// <summary>
        /// 文件名拼接
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="name"></param>
        /// <param name="exName"></param>
        /// <returns></returns>
        /// <exception cref="FileHelperException"></exception>
        public static string ContactFileName(string dir, string name, string exName)
        {
            if(string.IsNullOrWhiteSpace(dir))
                throw new FileHelperException("拼接文件名失败", new ArgumentNullException("文件目录为空"));

            if (string.IsNullOrWhiteSpace(name))
                throw new FileHelperException("拼接文件名失败", new ArgumentNullException("文件名为空"));

            if (string.IsNullOrWhiteSpace(exName))
                throw new FileHelperException("拼接文件名失败", new ArgumentNullException("文件扩展名为空"));

            try
            {
                var fileName = Path.Combine(dir, name);
                if (exName.Contains('.') == false)
                    fileName += '.';

                fileName += exName;

                return fileName;
            }
            catch (Exception ex)
            {
                throw new FileHelperException ( "拼接文件名失败", ex );
            }
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileHelperException"></exception>
        public static bool IsFileExist(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new FileHelperException("判断文件是否存在失败", new ArgumentNullException("文件路径为空!"));

            return File.Exists(path);
        }

        /// <summary>
        /// 判断文件夹是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="FileHelperException"></exception>
        public static bool IsFolderExist(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new FileHelperException("判断文件夹是否存在失败", new ArgumentNullException("文件夹路径为空!"));
            return Directory.Exists(path);
        }

        /// <summary>
        /// 创建文件夹(路径)
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="FileHelperException"></exception>
        public static void CreateFolder(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new FileHelperException("创建文件夹失败", new ArgumentNullException("文件夹路径为空!"));
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                throw new FileHelperException("创建文件夹失败", ex);
            }
        }
    }
}
