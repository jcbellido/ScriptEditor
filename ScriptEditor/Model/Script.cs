using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ScriptEditor.Model
{
    [DataContract(Name = "ScriptDataObject")]
    public class ScriptDataObject : IExtensibleDataObject
    {
        #region Extensible Data Object
        private ExtensionDataObject extensionData_Value;

        public ExtensionDataObject ExtensionData
        {
            get
            {
                return extensionData_Value;
            }
            set
            {
                extensionData_Value = value;
            }
        }
        #endregion
    }

    [KnownType(typeof(ScriptDataObject))]
    [DataContract(Name = "Paragraph")]
    public class ParagraphImplementation : ScriptDataObject, IParagraph
    {
        [DataMember]
        protected string m_content; 

        public ParagraphImplementation(string content)
        {
            m_content = content;
        }

        public string Content()
        {
            return m_content;
        }

        public void SetContent(string newContent)
        {
            m_content = newContent;
        }
    }

    [KnownType(typeof(ParagraphImplementation))]
    [DataContract(Name = "Chapter")]
    public class ChapterImplementation : ScriptDataObject, IChapter
    {
        [DataMember]
        protected string m_title = "unkonwn";

        [DataMember]
        protected List<IParagraph> m_paragraphs;

        public ChapterImplementation(string title)
        {
            m_title = title;
            m_paragraphs = new List<IParagraph>();
        }

        public string GetTitle()
        {
            return m_title;
        }

        public void AddParagraph(IParagraph paragraph)
        {
            m_paragraphs.Add(paragraph);
        }

        public void RemoveParagraph(IParagraph paragraph)
        {
            m_paragraphs.Remove(paragraph);
        }

        public List<IParagraph> Paragraphs()
        {
            return m_paragraphs;
        }
    }

    [KnownType(typeof(ChapterImplementation))]
    [DataContract(Name = "Script")]
    public class ScriptImplementation : ScriptDataObject, IScript
    {
        [DataMember]
        protected string m_title;

        [DataMember]
        protected List<IChapter> m_chapters;

        public ScriptImplementation(string title)
        {
            m_title = title;
            m_chapters = new List<IChapter>();
        }

        public string GetTitle()
        {
            return m_title; 
        }

        public List<IChapter> Chapters()
        {
            return m_chapters;
        }

        public void AddChapter(IChapter chapter)
        {
            m_chapters.Add(chapter);
        }
    }
}
