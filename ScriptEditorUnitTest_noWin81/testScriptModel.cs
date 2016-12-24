using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ScriptEditor.Model;

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
    }
}
