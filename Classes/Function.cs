namespace Kursach.Classes
{
    class Function
    {
        public void TextClear(System.Windows.Controls.TextBox text, string str)
        {
            if (str == text.Text)
            {
                text.Text = "";
            }
        }
    }
}
