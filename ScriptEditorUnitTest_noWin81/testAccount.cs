using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ScriptEditor.Model;

namespace ScriptEditorUnitTest_noWin81
{
    [TestClass]
    public class testAccount
    {
        [TestMethod]
        public void TestAccountObject()
        {
            Account a = new Account(1);
            Assert.IsTrue(a.Value == 1, "Failed initialization");
            a.Value = 2;
            Assert.IsTrue(a.Value == 2, "Failed set property");
        }
    }
}
