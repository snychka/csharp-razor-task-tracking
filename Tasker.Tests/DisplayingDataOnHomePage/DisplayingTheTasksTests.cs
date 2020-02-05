using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Tasker.Tests.DisplayingDataOnHomePage
{
    public class DisplayingTheTasksTests
    {
        [Fact(DisplayName = "Display the tasks on the index page. @display-task-index")]
        public void DisplayingTheTasks()
        {
            var filePath = TestHelpers.GetRootString() + "Tasker"
            + Path.DirectorySeparatorChar + "Pages"
            + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the Tasker project.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            var pattern = @"<\s*?table\s*?>[\s\S]*?@foreach\s*?[(]\s*?(var|Task)\s*task\s*in\s*Model.Tasks\s*?[)]\s*?{\s*?<\s*?[tT][rR]\s*?>\s*?<[tT][dD]>\s*?@task.Id\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?\s*?<[tT][dD]>\s*?@task.Title\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?\s*?<[tT][dD]>\s*?@task.Description\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?\s*?<[tT][dD]>\s*?@task.Priority\s*?<\s*?\/\s*?[tT][dD]\s*?>\s*?<\/\s*?[tT][rR]\s*?>\s*?}\s*?<\s*?\/table\s*?>";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`Index.cshtml` was found, but does not appear to contain a `table` with a `foreach` loop that creates rows and columns for the `task` items.");
        }
    }
}
