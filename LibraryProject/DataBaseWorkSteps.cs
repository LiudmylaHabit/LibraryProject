using NUnit.Framework;
using System.Data;
using TechTalk.SpecFlow;

namespace LibraryProject
{
    [Binding]
    public class DataBaseWorkSteps
    {
        private SqlConnectorHelper _sqlHelper = (SqlConnectorHelper)ScenarioContext.Current["SqlHelper"];

        [When(@"I create row in table ""(.*)"" with data")]
        public void WhenICreateRowInTableWithData(string tableName, Table table)
        {
            string query = $"INSERT INTO {tableName} (AuthorName, PublishDate) " +
                $"VALUES ('{table.Rows[0]["AuthorName"]}', '{table.Rows[0]["PublishDate"]}')";
            _sqlHelper.MakeQuery(query);
        }

        [When(@"I select whole ""(.*)"" table")]
        public void WhenISelectWholeTable(string tableName)
        {
            string query = "SELECT * FROM Authors";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["AuthorsTable"] = responseTable;
        }

        [Then(@"Table contains data")]
        public void ThenTableContainsData(Table table)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["AuthorsTable"];
            int numOfRows = responseTable.Rows.Count;
            string lastAuthors = responseTable.Rows[numOfRows - 1]["AuthorName"].ToString();
            Assert.AreEqual(lastAuthors, table.Rows[0]["AuthorName"]);
        }
    }
}