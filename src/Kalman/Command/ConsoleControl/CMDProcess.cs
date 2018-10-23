
using System;
using System.Collections.Specialized;	// StringCollection
using System.Drawing;			// Color
using System.Text;			// StringBuilder
using System.Windows.Forms;		// DUH!
using System.Diagnostics;		// Process
using System.IO;			// StreamWriter, StreamReader
using System.Threading;			// Thread

namespace Kalman.Command
{
    public partial class RichConsoleBox : RichTextBox
    {
        #region Fields

        private Process processCMD = null;
        private StreamWriter StandardInputWriter = null;

        private Thread threadStandardOutput = null;
        private Thread threadStandardError = null;

        #endregion

        private void CreateCMDProcess()
        {
            // 
            if (processCMD != null)
                return;

            // Create the cmd.exe background process
            processCMD = new Process();

            // ProcessStartInfo is used together with the Process component.
            processCMD.StartInfo.Arguments = "/Q";
            processCMD.StartInfo.CreateNoWindow = true;
            processCMD.StartInfo.FileName = "cmd.exe";
            processCMD.StartInfo.RedirectStandardError = true;
            processCMD.StartInfo.RedirectStandardOutput = true;
            processCMD.StartInfo.RedirectStandardInput = true;
            processCMD.StartInfo.UseShellExecute = false;
            processCMD.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
            processCMD.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Process
            processCMD.Exited += new EventHandler(processCMD_Exited);
            processCMD.EnableRaisingEvents = true;

            // Start
            if (processCMD.Start())
            {
                // Standard Streams
                StandardInputWriter = processCMD.StandardInput;
                threadStandardOutput = BeginBackgroundReader("threadStandardOutput", processCMD.StandardOutput);
                threadStandardError = BeginBackgroundReader("threadStandardError", processCMD.StandardError);

            }
        }

        #region StandardOutput/StandardError Reading Threads

        /// <summary>
        /// Creates a background thread that reads from cmd.exe StandardOutput
        /// </summary>
        private Thread BeginBackgroundReader(string threadName, StreamReader reader)
        {

            Thread threadReader = new Thread(new ParameterizedThreadStart(threadBackgroundReaderMethod));
            threadReader.Name = threadName;
            threadReader.IsBackground = true;
            threadReader.Start(reader);
            return threadReader;

        }

        /// <summary>
        /// Thread method used to read and display StandardOutput
        /// </summary>
        /// <param name="data"></param>
        private void threadBackgroundReaderMethod(object data)
        {

            StreamReader reader = data as StreamReader;
            bool isStandardError = reader.Equals(processCMD.StandardError);

            try
            {

                while (!reader.EndOfStream)
                {

                    char[] buffer = new char[32768];

                    if (reader.Read(buffer, 0, 32768) > 0)
                        this.Invoke(OutputDataAvailableCallback, new object[] { new string(buffer, 0, buffer.Length), isStandardError });

                    buffer = null;

                }


            }
            catch (Exception)
            {

            }
            finally
            {

                reader.Close();

            }

        }

        #endregion

        #region Process Events
        /// <summary>
        /// The Exited event indicates that the associated process exited.
        /// ms-help://MS.LHSMSSDK.1033/MS.LHSNETFX30SDK.1033/fxref_system/html/ebbb0d6a-b7dd-743d-b7a5-cdff7626d7f6.htm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processCMD_Exited(object sender, EventArgs e)
        {

            this.Invoke(ProcessExitedCallback);

        }

        #endregion

    }
}