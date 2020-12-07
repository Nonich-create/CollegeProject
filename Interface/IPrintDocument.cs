namespace Kursach.Interface
{
    interface IPrintDocument
    {
        void IPrintDocument(string path);
        void ReplaceWordStub(string StubToReplace, string text, Microsoft.Office.Interop.Word.Document wordDocument);
    }
}
