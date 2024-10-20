<Query Kind="Program">
  <Connection>
    <ID>1afdeb6f-7240-4575-a2f5-e1534a9b10d1</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>ChinookSept2018</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

//	Driver is responsible for orchestrating the flow by calling 
//	various methods and classes that contain the actual business logic 
//	or data processing operations.
void Main()
{
	//  Pass
	TestGetArtist(1).Dump("Pass - Valid ID");
	TestGetArtist(10000).Dump("Pass - Valid ID - No artist found");

	//  Fail
	//  rule:	artistID must be valid 
	TestGetArtist(0).Dump("Fail - ArtistID must be valid");
}

//	This region contains methods used for testing the functionality
//	of the application's business logic and ensuring correctness.
#region Test Methods
public ArtistEditView TestGetArtist(int artistID)
{
	try
	{
		return GetArtist(artistID);
	}
	#region  catch all exceptions (define later)
	catch (AggregateException ex)
	{
		foreach (var error in ex.InnerExceptions)
		{
			error.Message.Dump();
		}
	}
	catch (ArgumentNullException ex)
	{
		GetInnerException(ex).Message.Dump();
	}
	catch (Exception ex)
	{
		GetInnerException(ex).Message.Dump();
	}
	#endregion
	return null;  // Ensures a valid return value even on failure
}
#endregion
//	This region contains support methods for testing
#region Support Methods
public Exception GetInnerException(System.Exception ex)
{
	while (ex.InnerException != null)
		ex = ex.InnerException;
	return ex;
}
#endregion

//	This region contains all methods responsible 
//	for executing business logic and operations.
#region Methods
public ArtistEditView GetArtist(int artistID)
{
	#region Business Logic and Parameter Exceptions
	//	create a list<Exception> to contain all discovered errors
	List<Exception> errorList = new List<Exception>();

	//  Business Rules
	//	These are processing rules that need to be satisfied
	//		for valid data
	//		rule:	artistID must be valid 

	if (artistID <= 0)
	{
		throw new ArgumentNullException("Please provide a valid artist ID");
	}
	#endregion

	return Artists
		.Where(x => x.ArtistId == artistID)
		.Select(x => new ArtistEditView
		{
			ArtistID = x.ArtistId,
			Name = x.Name
		}).FirstOrDefault();
}
#endregion


//	This region includes the view models used to 
//	represent and structure data for the UI.
#region View Models
public class ArtistEditView
{
	public int ArtistID { get; set; }
	public string Name { get; set; }
}
#endregion

