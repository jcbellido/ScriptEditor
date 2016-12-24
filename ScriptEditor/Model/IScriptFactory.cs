using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.Model
{
    public interface IScriptFactory
    {
        IScript CreateScript(string title);
        IChapter CreateChapter(string title);
        IParagraph CreateParagraph(string content);
    }
}
