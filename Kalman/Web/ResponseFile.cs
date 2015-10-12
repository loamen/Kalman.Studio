using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

namespace Kalman.Web
{
    /// <summary>
    /// 向客户端输出文件
    /// </summary>
    public class ResponseFile
    {
        private HttpResponse response = HttpContext.Current.Response;

        public ResponseFile()
        {
            response = HttpContext.Current.Response;

            // 清空当前 HTTP 响应流(RESPONSE)
            response.Clear();
            // 设置当前 HTTP 响应流(RESPONSE)的骗码.
            response.Charset = "utf-8";
            // 设置缓冲输入.
            response.Buffer = true;
            // 设置内容类型
            response.ContentType = "application/octet-stream";
            // 设置当前 HTTP 响应流(RESPONSE)内容编码.
            response.ContentEncoding = System.Text.Encoding.UTF8;
        }

        /// <summary>
        /// 获取或设置输出流的HTTP字符集，默认"utf-8"
        /// </summary>
        public string Charset
        {
            get { return response.Charset; }
            set { response.Charset = value; }
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否缓冲输出，并在完成处理整个响应之后将其发送，默认true
        /// </summary>
        public bool Buffer
        {
            get { return response.Buffer; }
            set { response.Buffer = value; }
        }

        /// <summary>
        /// 获取或设置输出流的 HTTP MIME 类型，默认"application/octet-stream"
        /// </summary>
        public string ContentType
        {
            get { return response.ContentType; }
            set { response.ContentType = value; }
        }

        /// <summary>
        /// 获取或设置输出流的 HTTP 字符集，默认
        /// </summary>
        public Encoding ContentEncoding
        {
            get { return response.ContentEncoding; }
            set { response.ContentEncoding = value; }
        }

        /// <summary>
        /// 输出文件
        /// </summary>
        /// <param name="path">文件物理路径</param>
        /// <param name="outputFilename"></param>
        public void Export(string path, string outputFilename)
        {
            // 判断是否为Firefox浏览器
            if (!HttpContext.Current.Request.Browser.Browser.Equals("Firefox"))
            {
                // 文件名编码处理
                outputFilename = HttpContext.Current.Server.UrlEncode(outputFilename);
            }

            // 设置当前 HTTP 响应头.如果是下载，加上 attachment
            response.AppendHeader("Content-Disposition", "attachment;filename=" + outputFilename);
            // 文件写入响应流以便下载
            response.BinaryWrite(File.ReadAllBytes(path));
            // 向客户端清除当前所有缓存输出.
            response.Flush();
            // 停止执行该页.
            response.End();
        }
    }
}
