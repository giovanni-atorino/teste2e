using myiveco_selenium.Filters;
using myiveco_selenium.Values;
using myiveco_selenium.Xpath;
using myiveco_selenium.TestCases;
using NUnit.Framework;
using System.Collections.Generic;

namespace myiveco_selenium
{
    public class Test_RemoteCommands : Remote_Commands_Page

    {
        Xpath__RemoteCommands XpathRemoteCommands = new Xpath__RemoteCommands();

        Values__RemoteCommands ValueRemoteCommands = new Values__RemoteCommands();

        [Test]
        public void RemoteCommands_Page()
        {
            RemoteCommandsPage(XpathRemoteCommands, ValueRemoteCommands);
        }
    }
}
