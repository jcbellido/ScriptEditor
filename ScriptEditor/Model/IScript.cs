using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.Model
{
    public interface IParagraph
    {
        string Content();
        void SetContent(string newContent);
    }

    public interface IChapter
    {
        string GetTitle();
        List<IParagraph> Paragraphs();
        void AddParagraph(IParagraph paragraph);
        void RemoveParagraph(IParagraph paragraph);
    }

    public interface IScript
    {
        string GetTitle();
        List<IChapter> Chapters();
        void AddChapter(IChapter chapter);
    }
}
