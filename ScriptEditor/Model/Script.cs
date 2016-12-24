using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEditor.Model
{
    public class ParagraphImplementation : IParagraph
    {
        protected string m_content; 

        public ParagraphImplementation(string content)
        {
            m_content = content;
        }

        public string Content()
        {
            return m_content;
        }
    }

    public class ChapterImplementation : IChapter
    {
        protected string m_title = "unkonwn";

        public ChapterImplementation(string title)
        {
            m_title = title;
        }

        public string GetTitle()
        {
            return m_title;
        }

        public List<IParagraph> Paragraphs()
        {
            return null;
        }
    }

    public class ScriptImplementation : IScript
    {
        protected string m_title;

        public ScriptImplementation(string title)
        {
            m_title = title;
        }

        public string GetTitle()
        {
            return m_title; 
        }

        public List<IChapter> Chapters()
        {
            return null;
        }
    }
}
