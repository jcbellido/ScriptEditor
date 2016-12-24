using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.Model
{
    public class ScriptFactory : IScriptFactory
    {
        public IScript CreateScript(string title)
        {
            var new_script = new ScriptImplementation(title);
            return new_script;
        }

        public IChapter CreateChapter(string title)
        {
            var new_chapter = new ChapterImplementation(title);
            return new_chapter;
        }

        public IParagraph CreateParagraph(string content)
        {
            var new_paragraph = new ParagraphImplementation(content);
            return new_paragraph;
        }
    }
}
