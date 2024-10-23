<Query Kind="Program" />

void Main()
{
	//	Driver is responsible for orchestrating the flow by calling 
	//	various methods and classes that contain the actual business logic 
	//	or data processing operations.

	//	passing in empty first and last name
	TestAggregateException("", "");
}
//	This region contains methods used for testing the functionality
//	of the application's business logic and ensuring correctness.
#region Test Methods
private void TestAggregateException(string firstName, string lastName)
{

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

#endregion

//	This region includes the view models used to 
//	represent and structure data for the UI.
#region View Models

#endregion


