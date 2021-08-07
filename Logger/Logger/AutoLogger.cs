using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nLogger
{    
    /// <summary>
    /// 自動建立目錄資料夾 儲存log
    /// </summary>
    public class AutoLogger
    {
        private string DirName = "";
        private string FileName = "";
        private TimeMark enumTimeMark { get; set; } = TimeMark.pre;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DirName"></param>
        /// <param name="fileName">檔案名稱 與 日期標記 不可同時空白</param>
        /// <param name="tm">日期要放在fileName前面或後面，如果選擇none則訊息會都寫在同一檔案</param>
        public AutoLogger(string DirName, string fileName = "", TimeMark tm = TimeMark.pre)
        {            
            if (fileName == null || (fileName.Trim() == "" && tm == TimeMark.none))
                throw new InvalidOperationException("fileName is null or space");
            this.DirName = DirName;
            this.FileName = fileName;
            this.enumTimeMark = tm;
        }

        public void write(string data)
        {            
            Task.Factory.StartNew(() =>
            {
                string pathdir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DirName);
                if (!Directory.Exists(pathdir))
                    Directory.CreateDirectory(pathdir);
                string tmpFileName = "";
                string connectionSymbol = (this.FileName.Trim() == "" ? "" : "_");
                switch (this.enumTimeMark)
                {
                    case TimeMark.pre:
                        tmpFileName = DateTime.Today.ToString("yyyyMMdd") + connectionSymbol + this.FileName;
                        break;
                    case TimeMark.suf:
                        tmpFileName = this.FileName + connectionSymbol + DateTime.Today.ToString("yyyyMMdd");
                        break;
                    case TimeMark.none:
                        tmpFileName = this.FileName;
                        break;
                }
                tmpFileName += ".txt";
                string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DirName, tmpFileName);
                using (FileStream myFile = File.Open(pathFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter myWriter = new StreamWriter(myFile))
                {
                    myWriter.Write(DateTime.Now.ToString("HH:mm:ss.fff") + " " + data + Environment.NewLine);
                }
            });
        }
    }
}
