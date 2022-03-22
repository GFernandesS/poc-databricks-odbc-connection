

using System.Data.Odbc;

const string HOSTNAME = "Host";
const int PORT = 443;
const string HTTP_PATH = "HttpPath";
const string PAT = "PersonalAccessToken";
string ODBC_CONNECTION_STRING = $"Driver=Simba Spark ODBC Driver;Host={HOSTNAME};Port={PORT};HTTPPath={HTTP_PATH};ThriftTransport=2;SSL=1;AuthMech=3;UID=token;PWD={PAT}";

using (var connection = new OdbcConnection(ODBC_CONNECTION_STRING))
{
    connection.Open();

    var odbcCommand = new OdbcCommand(@"
    USE test;
    SELECT * FROM arq"
    , connection);

    var result = odbcCommand.ExecuteReader();
}