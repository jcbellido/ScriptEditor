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
    }

    public interface IChapter
    {
        string GetTitle();
        List<IParagraph> Paragraphs();
    }

    public interface IScript
    {
        string GetTitle();
        List<IChapter> Chapters();
    }
}
