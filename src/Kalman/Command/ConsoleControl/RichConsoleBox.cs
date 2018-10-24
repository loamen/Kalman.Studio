
using System;
using System.Collections.Specialized;	// StringCollection
using System.Drawing;			// Color
using System.Text;			// StringBuilder
using System.Windows.Forms;		// DUH!
using System.Diagnostics;		// Process
using System.IO;			// StreamWriter, StreamReader
using System.Threading;         // Thread
using System.Runtime.InteropServices;

namespace Kalman.Command
{

    public partial class RichConsoleBox : RichTextBox
    {
        #region Delegates
        private delegate void ProcessExitedDelegate();
        public delegate void ExitEventHandler(object sender, EventArgs e);
        public delegate void OutputDataAvailableDelegate(string text, bool IsStandardError);

        #endregion

        #region Events
        [DllImport("kernel32.dll")]
        static extern bool GenerateConsoleCtrlEvent(int dwCtrlEvent, int dwProcessGroupId);
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(IntPtr handlerRoutine, bool add);
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

        /// <summary>
        /// Occurs when the Console exits
        /// </summary>
        public event ExitEventHandler Exit;
        private OutputDataAvailableDelegate OutputDataAvailableCallback;
        private ProcessExitedDelegate ProcessExitedCallback;

        #endregion

        #region Fields
        private int commandLineStartIndex = -1;
        private int commandTextLength = 0;
        private StringCollection scCommandLineHistory = null;
        private string cmdDirectory = null; // cmd work directory
        private int historyIndex = -1; // command history index
        private string historyCommand = string.Empty;
        #endregion

        private int updating;
        private IntPtr updatingEventMask = IntPtr.Zero;

        #region Event Overrides

        /// <summary>
        /// 
        /// </summary>
        protected override void OnCreateControl()
        {
            this.AcceptsTab = true;
            //this.BackColor = Color.Black;
            this.DetectUrls = true;
            this.Dock = DockStyle.Fill;
            this.Font = new Font("Lucida Console", 8);
            //this.ForeColor = Color.Lime;
            this.HideSelection = true;
            this.Multiline = true;
            //this.RightMargin = TextRenderer.MeasureText( "A", this.Font ).Width * 80;

            //this.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            this.ShortcutsEnabled = true;
            this.ShowSelectionMargin = false;

            if (!this.DesignMode)
            {
                // Delegates for invoked methods
                ProcessExitedCallback = new ProcessExitedDelegate(ProcessExited);
                OutputDataAvailableCallback = new OutputDataAvailableDelegate(OutputDataAvailable);
                // scCommandLineHistory holds old command lines for quick reuse
                scCommandLineHistory = new StringCollection();
                //
                CreateCMDProcess();
            }
            base.OnCreateControl();
        }



        /// <summary>
        /// Scroll to the last line of text when the console is resized
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            ScrollToBottom();
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Launch recognized links via shell execute
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLinkClicked(LinkClickedEventArgs e)
        {
            try
            {
                Process linkprocess = new Process();
                linkprocess.StartInfo.UseShellExecute = true;
                linkprocess.StartInfo.FileName = e.LinkText;
                linkprocess.Start();
            }
            catch (Exception)
            {

            }

            base.OnLinkClicked(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 127)
            {
                if (commandLineStartIndex == -1)
                    commandLineStartIndex = this.SelectionStart;

            }
            base.OnKeyPress(e);
        }

        /// <summary>
        /// preview key down send ctrl+c
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {

                AttachConsole(processCMD.Id);
                SetConsoleCtrlHandler(IntPtr.Zero, true);   // custom ctrl+c
                var result = GenerateConsoleCtrlEvent(0, 0); // send ctrl+c
                if (result)
                {
                    this.AppendText("CTRL+C was pressed.");
                }
                SetConsoleCtrlHandler(IntPtr.Zero, false);  //reset
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                var seletedText = Clipboard.GetText();
                if (!string.IsNullOrEmpty(seletedText))
                {
                    AppendText(seletedText);
                }
            }
            base.OnPreviewKeyDown(e);
        }

        /// <summary>
        /// key down
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // If StandardInput is closed return
            if (StandardInputWriter == null)
            {
                e.SuppressKeyPress = true;
                return;
            }

            switch (e.KeyCode)
            {
                // DOWN ARROW: Scroll Forward in History List
                case Keys.Down:
                    if (scCommandLineHistory.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(historyCommand) && this.Text.EndsWith(historyCommand))
                        {
                            this.Text = this.Text.Substring(0, this.Text.Length - historyCommand.Length);
                        }

                        if (historyIndex < 0)
                            historyIndex = 0;
                        if (historyIndex > scCommandLineHistory.Count - 1)
                            historyIndex = scCommandLineHistory.Count - 1;


                        historyCommand = scCommandLineHistory[historyIndex];
                        this.AppendText(historyCommand);
                        historyIndex++;
                    }
                    e.SuppressKeyPress = true;
                    break;
                // UP ARROW: Scroll Backward in History List
                case Keys.Up:
                    if (scCommandLineHistory.Count > 0)
                    {
                        if (historyIndex == -1)
                        {
                            historyIndex = scCommandLineHistory.Count - 1;
                        }

                        if (!string.IsNullOrEmpty(historyCommand) && this.Text.EndsWith(historyCommand))
                        {
                            this.Text = this.Text.Substring(0, this.Text.Length - historyCommand.Length);
                        }

                        if (historyIndex < 0)
                            historyIndex = 0;
                        if (historyIndex > scCommandLineHistory.Count - 1)
                            historyIndex = scCommandLineHistory.Count - 1;

                        historyCommand = scCommandLineHistory[historyIndex];
                        this.AppendText(historyCommand);
                        historyIndex--;
                    }
                    e.SuppressKeyPress = true;
                    break;
                // LEFT ARROW: Don't allow this to passed as a character to the command line
                case Keys.Left:
                    e.SuppressKeyPress = true;
                    break;
                // RIGHT ARROW: Don't allow this to passed as a character to the command line
                case Keys.Right:
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Home:
                    e.SuppressKeyPress = true;
                    break;
                case Keys.End:
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Back:
                    if (this.Text.Length == this.commandTextLength)
                        e.SuppressKeyPress = true;
                    break;
                case Keys.Tab:
                    string command = GetCommandLine().Trim();
                    if (!string.IsNullOrWhiteSpace(command))
                    {
                        var commands = command.Split(' ');
                        if (commands.Length > 0)
                        {
                            var fileName = commands[commands.Length - 1];
                            var name = string.Empty;
                            if (!string.IsNullOrWhiteSpace(cmdDirectory))
                            {
                                var dic = new DirectoryInfo(cmdDirectory);
                                var dics = dic.GetDirectories(fileName + "*");
                                if (dics.Length > 0)
                                {
                                    name = dics[0].Name;
                                }
                                else
                                {
                                    var files = dic.GetFiles(fileName + "*");
                                    if (files.Length > 0)
                                    {
                                        name = files[0].Name;
                                    }
                                }

                                if (!string.IsNullOrWhiteSpace(name))
                                {
                                    commands[commands.Length - 1] = name;
                                    var newCommand = string.Join(" ", commands);
                                    this.Text = this.Text.Substring(0, this.Text.Length - command.Length);

                                    if (commandLineStartIndex == -1)
                                        commandLineStartIndex = this.Text.Length;

                                    this.AppendText(newCommand);
                                    
                                    e.SuppressKeyPress = true;
                                    //StandardInputWriter.WriteLine(newCommand);
                                    //if (!scCommandLineHistory.Contains(newCommand))
                                    //    scCommandLineHistory.Add(newCommand);
                                }
                            }
                        }
                    }
                    break;
                // ENTER: Send the last command line to CMD.EXE via STDIN
                case Keys.Enter:
                    // Get command line
                    string commandLine = GetCommandLine();
                    if (!string.IsNullOrWhiteSpace(commandLine))
                    {
                        // Send the commandLine to standardInput or String.Empty for built-in commands (forces command prompt display)
                        StandardInputWriter.WriteLine(commandLine);
                        // Add this command line to the command line history
                        if (!scCommandLineHistory.Contains(commandLine))
                            scCommandLineHistory.Add(commandLine);
                    }
                    else
                    {
                        var selectedText = this.SelectedText;
                        if (!string.IsNullOrEmpty(selectedText))
                        {
                            Clipboard.SetText(selectedText.Trim()); // copy to clipboard
                        }
                    }
                    break;
                default:
                    break;

            }
            base.OnKeyDown(e);
        }

        private string GetCurrentLine()
        {
            this.WordWrap = false;
            int cursorPosition = this.SelectionStart;
            int lineIndex = this.GetLineFromCharIndex(cursorPosition);
            string lineText = this.Lines[lineIndex];
            if (!string.IsNullOrEmpty(lineText) && lineText.Length > cmdDirectory.Length)
            {
                lineText = lineText.Substring(cmdDirectory.Length + 1, lineText.Length - cmdDirectory.Length - 1);
            }
            this.WordWrap = true;
            return lineText;
        }

        private string GetCommandLine()
        {
            string commandLine = String.Empty;
            if (commandLineStartIndex != -1)
                commandLine = this.Text.Substring(this.commandLineStartIndex);
            // Start index of the next command line is unknown
            commandLineStartIndex = -1;
            if (string.IsNullOrEmpty(commandLine))
            {
                commandLine = GetCurrentLine();
            }
            // Handle built-in commands
            if (ReflectionMethods.ExecuteInternalCommand(commandLine))
            {
                commandLine = String.Empty;
            }
            return commandLine;
        }

        #endregion

        /// <summary>
        /// release process
        /// </summary>
        ~RichConsoleBox()
        {
            if (processCMD != null)
                processCMD.Close();
        }

        public void BeginUpdate()
        {
            // INTEROP: BeginUpdate
            // Deal with nested calls.
            ++updating;
            if (updating > 1)
                return;
            // Prevent events
            updatingEventMask = NativeMethods.SendMessage(this.Handle, NativeMethods.EM_SETEVENTMASK, 0, IntPtr.Zero);
            // Prevent redrawing
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETREDRAW, 0, IntPtr.Zero);
        }

        public void EndUpdate()
        {
            // INTEROP: EndUpdate
            ScrollToBottom();
            // Deal with nested calls.
            --updating;
            if (updating > 0)
                return;
            // Allow redrawing
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETREDRAW, 1, IntPtr.Zero);
            // Allow events
            NativeMethods.SendMessage(this.Handle, NativeMethods.EM_SETEVENTMASK, 0, updatingEventMask);
        }
        /// <summary>
        /// Scroll to the bottom of the RichTextBox
        /// </summary>
        public void ScrollToBottom()
        {
            int min, max;
            NativeMethods.GetScrollRange(this.Handle, NativeMethods.SB_VERT, out min, out max);
            NativeMethods.SendMessage(this.Handle, NativeMethods.EM_SETSCROLLPOS, 0, new NativeMethods.POINT(0, max - this.DisplayRectangle.Height));
        }

        /// <summary>
        /// send command
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="workingDirectory"></param>
        /// <returns></returns>
        public void RunApp(string appName, string workingDirectory = null)
        {
            if (!string.IsNullOrEmpty(workingDirectory))
            {
                processCMD.StartInfo.WorkingDirectory = workingDirectory;
            }
            if (commandLineStartIndex == -1)
                commandLineStartIndex = this.SelectionStart;
            AppendText(appName);
            OnKeyDown(new KeyEventArgs(Keys.Enter));
        }

        /// <summary>
        /// Append text
        /// </summary>
        /// <param name="text"></param>
        public new void AppendText(string text)
        {
            this.BeginUpdate();
            this.SelectionStart = this.TextLength;
            this.SelectedText = text;
            this.EndUpdate();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="foreColor"></param>
        public void AppendFormattedText(string text, Color foreColor)
        {
            this.BeginUpdate();
            this.SelectionStart = this.TextLength;
            this.SelectionColor = foreColor;
            this.SelectedText = text;
            this.EndUpdate();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="foreColor"></param>
        /// <param name="background"></param>
        public void AppendFormattedText(string text, Font font, Color foreColor, Color background)
        {
            this.BeginUpdate();
            this.SelectionStart = this.TextLength;
            this.SelectionFont = font;
            this.SelectionColor = foreColor;
            this.SelectionBackColor = background;
            this.SelectedText = text;
            this.EndUpdate();
        }

        #region Callbacks

        /// <summary>
        /// Invoked by the background reader thread when output data is available
        /// </summary>
        /// <param name="text"></param>
        /// <param name="IsStandardError"></param>
        private void OutputDataAvailable(string text, bool IsStandardError)
        {
            if (IsStandardError)
            {
                this.AppendFormattedText(text, Color.Salmon);
            }
            else
            {
                if (text.Contains(((char)12).ToString()))
                    this.Clear();
                else
                {
                    var dic = text.Replace("\0", "").Trim();
                    if (dic.EndsWith(">")) {
                        dic = dic.TrimEnd('>');
                        if (Directory.Exists(dic)) {
                            cmdDirectory = new DirectoryInfo(dic).FullName;
                            processCMD.StartInfo.WorkingDirectory = cmdDirectory;
                        }
                    }
                    Debug.WriteLine(text);
                    this.AppendText(text);
                    commandTextLength = this.Text.Length;
                }
            }

        }

        /// <summary>
        /// Invoked on the UserControl Thread to cleanup after the CMD.EXE process has exited,
        /// ms-help://MS.LHSMSSDK.1033/MS.LHSNETFX30SDK.1033/fxref_system/html/ebbb0d6a-b7dd-743d-b7a5-cdff7626d7f6.htm
        /// </summary>
        private void ProcessExited()
        {
            // RichTextBox
            this.ForeColor = Color.Gray;
            this.ReadOnly = true;

            // Tell anyone listening that CMD.EXE has exited
            if (Exit != null)
            {
                if (processCMD != null)
                    processCMD.Close();
                Exit(this, new EventArgs());
            }
        }
        #endregion
    }
}
