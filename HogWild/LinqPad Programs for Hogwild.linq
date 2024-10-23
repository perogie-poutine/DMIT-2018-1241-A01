<Query Kind="Program">
  <Connection>
    <ID>237fedb3-c1e3-4cb5-b0b8-d4a59527b2c8</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>OLTP-DMIT2018</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	GetWorkingVersion().Dump();
}

public WorkingVersionsView GetWorkingVersion()
{
	return WorkingVersions
		.Select(x => new WorkingVersionsView
			{
				VersionId = x.VersionId,
				Major = x.Major,
				Minor = x.Minor,
				Build = x.Build,
				Revision = x.Revision,
				AsOfDate = x.AsOfDate,
				Comments = x.Comments
			}).FirstOrDefault();
}

public class WorkingVersionsView
{
	public int VersionId { get; set; }
	public int Major { get; set; }
	public int Minor { get; set; }
	public int Build { get; set; }
	public int Revision { get; set; }
	public DateTime AsOfDate { get; set; }
	public string Comments { get; set; }
}

// You can define other methods, fields, classes and namespaces here
