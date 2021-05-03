using System;

namespace QuoteGeneratorCore
{
    public class Quote
    {
        public string Text { get; set; }
        public string Author { get; set; }

        public Quote(string author, string text)
        {
            Author = author;
            Text = text;
        }

        public static Quote Empty() => new Quote("Simon", "I have nothing to say.");

    }
}
