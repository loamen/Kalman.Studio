namespace Kalman.Data.DbProvider
{
	/// <summary>
	/// Represents the description of an oracle package mapping.
	/// </summary>
	/// <remarks>
	/// <see cref="IOraclePackage"/> is used to specify how to transform store procedure names 
	/// into package qualified Oracle stored procedure names.
	/// </remarks>
	public interface IOraclePackage
	{
		/// <summary>
		/// When implemented by a class, gets the name of the package.
		/// </summary>
		/// <value>
		/// The name of the package.
		/// </value>
		string Name
		{ get; }

		/// <summary>
		/// When implemented by a class, gets the prefix for the package.
		/// </summary>
		/// <value>
		/// The prefix for the package.
		/// </value>
		string Prefix
		{ get; }
	}
}
