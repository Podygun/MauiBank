namespace MauiBank.Service.Database;

    public static class PatternStrings
{
	public static readonly string insertQuery =
		"INSERT INTO _table (_columns) " +
		"VALUES (_values)";

	public static readonly string deleteQuery =
		"DELETE FROM _table " +
		"WHERE _column = _value";
}
