using Kursach.Interface;
using System.Diagnostics;
using System.Windows.Forms;

namespace Kursach.Classes
{
    class Print : IPrintDocument
    {
        public void ReplaceWordStub(string StubToReplace, string text, Microsoft.Office.Interop.Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: StubToReplace, ReplaceWith: text);
        }
        public void IPrintDocument(string path)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                pd.ShowDialog();
                ProcessStartInfo info = new ProcessStartInfo(path)
                {
                    Verb = "PrintTo",
                    Arguments = pd.PrinterSettings.PrinterName,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(info);
            }
        }
    }
}
