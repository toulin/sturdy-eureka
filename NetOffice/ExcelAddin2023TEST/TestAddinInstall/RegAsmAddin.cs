using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAddinInstall
{
    internal class RegAsmAddin
    {
        /// <summary>
        /// 組件名稱
        /// </summary>
        private readonly string AssemblyName;

        /// <summary>
        /// 組件dll與tlb檔案的所在目錄
        /// </summary>
        internal readonly string TargetDir;

        /// <summary>
        /// 執行動作 true:反註冊  false:註冊
        /// </summary>
        private readonly bool UnRegister;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="unRegister">執行動作 true:反註冊  false:註冊</param>
        public RegAsmAddin(  string assemblyName, string targetDir, bool unRegister)
        {
            UnRegister = unRegister;
            AssemblyName = assemblyName;
            TargetDir = targetDir; 
        }

        /// <summary>
        /// 註冊與反註冊的動作
        /// </summary>
        /// <param name="mainName">dll主檔名</param>
        internal void RegAsm(bool for64)
        {
            string dll = Path.Combine(TargetDir, $"{AssemblyName}.dll");
            string tlb = Path.Combine(TargetDir, $"{AssemblyName}.tlb");


            if (TryGetFrameworkFolder(for64, out string frameworkFolder) && Directory.Exists(frameworkFolder))
            {
                string regasmPath = Path.Combine(frameworkFolder, @"v4.0.30319\regasm.exe");
                string arg;
                if (UnRegister)
                {
                    arg = string.Format(@"-u ""{0}"" /codebase", dll);
                }
                else
                {
                    arg = string.Format(@"""{0}"" /tlb: ""{1}"" /codebase", dll, tlb);
                }
                if (File.Exists(regasmPath))
                {
                    RunRegAsm(regasmPath, arg);
                }
                else
                {
                    throw new Exception("找不到檔案,請重新安裝.Net framework 4.0\r\n" + regasmPath);
                }

            }
        }

        /// <summary>
        /// 依參數執行 RegAsm.exe
        /// </summary>
        /// <param name="regasmPath">RegAsm.exe的路徑</param>
        /// <param name="arg">執行參數</param>
        /// <exception cref="InvalidOperationException"></exception>
        private void RunRegAsm(string regasmPath, string arg)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = regasmPath;
                proc.StartInfo.Arguments = arg;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"執行註冊失敗({regasmPath} - {arg})", ex);
            }
        }

        /// <summary>
        /// 取得.net framework 4.0的安裝目錄
        /// </summary>
        /// <param name="is64bit">Office is 64 bit</param>
        /// <returns></returns>
        private bool TryGetFrameworkFolder(bool is64bit, out string folder)
        {
            folder = "";
            string relativePath = (is64bit) ? @"Microsoft.NET\Framework64" : @"Microsoft.NET\Framework";
            try
            {
                folder = Path.Combine(Environment.GetEnvironmentVariable("windir"), relativePath);
                return true;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("取得.net framework 4.0的安裝目錄失敗", ex);
            }
            return false;
        }
    }
}
