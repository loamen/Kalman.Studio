using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kalman.Studio
{
    public interface IDockDocument
    {
        /// <summary>
        /// 文件名，不包含路径
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// 保存文档
        /// </summary>
        void Save();

        /// <summary>
        /// 另存文档
        /// </summary>
        void SaveAs();

        void Undo();
        void Redo();
        void Cut(object sender, EventArgs e);
        void Copy(object sender, EventArgs e);
        void Paste(object sender, EventArgs e);
        void Delete(object sender, EventArgs e);
        void SelectAll(object sender, EventArgs e);
    }
}
