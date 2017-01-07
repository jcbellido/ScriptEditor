using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ScriptEditor.Model;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using System.Runtime.Serialization;

namespace ScriptEditorUnitTest_noWin81
{
    [TestClass]
    public class testScriptModel
    {
        [TestMethod]
        public void TestScriptFactory()
        {
            var factory = new ScriptFactory();
            Assert.IsNotNull(factory);
            IScript new_script = factory.CreateScript("New Script");
            Assert.IsTrue(new_script.GetTitle() == "New Script");

            IChapter new_chapter = factory.CreateChapter("New Chapter");
            Assert.IsTrue(new_chapter.GetTitle() == "New Chapter");

            IParagraph new_paragraph = factory.CreateParagraph("Content of first paragraph");
            Assert.IsTrue(new_paragraph.Content() == "Content of first paragraph");
        }


        [TestMethod]
        public void TestDataConnection()
        {
            var factory = new ScriptFactory();
            IScript new_script = factory.CreateScript("New Script");
            IChapter new_chapter = factory.CreateChapter("New Chapter");
            IParagraph new_paragraph = factory.CreateParagraph("Content of first paragraph");

            new_chapter.AddParagraph(new_paragraph);
            Assert.IsTrue(new_chapter.Paragraphs().Count == 1);

            new_script.AddChapter(new_chapter);
            Assert.IsTrue(new_script.Chapters().Count == 1);
        }


        [TestMethod]
        public void TestParagraphRemoval()
        {
            var factory = new ScriptFactory();
            IScript new_script = factory.CreateScript("New Script");
            IChapter new_chapter = factory.CreateChapter("New Chapter");
            IParagraph new_paragraph = factory.CreateParagraph("Content of first paragraph");

            new_chapter.AddParagraph(new_paragraph);
            Assert.IsTrue(new_chapter.Paragraphs().Count == 1);

            new_chapter.RemoveParagraph(new_paragraph);
            Assert.IsTrue(new_script.Chapters().Count == 0);

            new_chapter.RemoveParagraph(new_paragraph);
            new_chapter.RemoveParagraph(new_paragraph);
        }




        [TestMethod]
        public void TestParagraphSerialization()
        {
            var factory = new ScriptFactory();
            IParagraph new_paragraph = factory.CreateParagraph("Content of first paragraph");


            XmlSerializer xsSubmit = new XmlSerializer(typeof(ParagraphImplementation));
            // var subReq = new MyObject();
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, new_paragraph);
                    xml = sww.ToString(); // Your XML

                    using (var reader = new StringReader(xml))
                    {
                        object o = xsSubmit.Deserialize(reader);
                        var reconstructed_paragraph = o as ParagraphImplementation;
                        Assert.IsNotNull(reconstructed_paragraph);
                        Assert.IsTrue(reconstructed_paragraph.Content() == "Content of first paragraph");
                    }
                }
            }
        }

        [TestMethod]
        public void TestChapterSerialization()
        {
            var factory = new ScriptFactory();
            IChapter new_chapter = factory.CreateChapter("New Chapter");
            new_chapter.AddParagraph(factory.CreateParagraph("Paragraph one\n Paragraph one"));
            new_chapter.AddParagraph(factory.CreateParagraph("Paragraph two\n Paragraph two"));
            new_chapter.AddParagraph(factory.CreateParagraph("Paragraph three\n Paragraph three"));


            using (FileStream writer = new FileStream("ficherin.xml", FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(ChapterImplementation));
                ser.WriteObject(writer, new_chapter);
                writer.Close();
            }

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    // FileStream writer = new FileStream(fileName, FileMode.Create);
                    DataContractSerializer ser = new DataContractSerializer(typeof(ChapterImplementation));
                    ser.WriteObject(writer, new_chapter);
                    var xml = "";
                    xml = sww.ToString(); // Your XML
                    using (var reader = new StringReader(xml))
                    {

                    }
                }
            }
        }

        [TestMethod]
        public void TestScriptSerialization()
        {
            var factory = new ScriptFactory();
            IScript new_script = factory.CreateScript("My Beautiful script");
            IChapter new_chapter = factory.CreateChapter("First Chapter");
            new_chapter.AddParagraph(factory.CreateParagraph("001"));
            new_chapter.AddParagraph(factory.CreateParagraph("002"));
            new_chapter.AddParagraph(factory.CreateParagraph("003"));

            IChapter second_chapter = factory.CreateChapter("Second Chapter");
            second_chapter.AddParagraph(factory.CreateParagraph("001"));
            second_chapter.AddParagraph(factory.CreateParagraph("002"));
            second_chapter.AddParagraph(factory.CreateParagraph("003"));

            new_script.AddChapter(new_chapter);
            new_script.AddChapter(second_chapter);

            using (FileStream writer = new FileStream("script.xml", FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(ScriptImplementation));
                ser.WriteObject(writer, new_script);
                writer.Close();
            }

            FileStream fs = new FileStream("script.xml", FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer serializer = new DataContractSerializer(typeof(ScriptImplementation));

            ScriptImplementation recovered_script = (ScriptImplementation)serializer.ReadObject(reader, true);
            reader.Close();
            fs.Close();

            Assert.IsNotNull(recovered_script);
        }

    }
}
