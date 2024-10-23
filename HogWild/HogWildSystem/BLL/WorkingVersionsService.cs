#nullable disable
using HogWildSystem.DAL;
using HogWildSystem.Entities;
using HogWildSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogWildSystem.BLL
{
    class WorkingVersionsService
    {
		#region Fields
		private readonly HogWildContext _hogWildContext;
		#endregion

		internal WorkingVersionsService(HogWildContext hogWildContext)
		{
			_hogWildContext = hogWildContext;
		}

		public WorkingVersionsView GetWorkingVersion()
		{
			return _hogWildContext.WorkingVersions
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
	}
}