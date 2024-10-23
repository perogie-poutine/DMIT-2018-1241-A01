using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class Basics
    {
		#region Privates

		private string? myName;
		private int oddEvenValue;
		
		#region Methods
		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();

			RandomValue();
		}

		private void RandomValue() {

			Random rnd = new Random();

			oddEvenValue = rnd.Next(0, 25);

			if (oddEvenValue % 2 == 0 ) 
				{
						myName = $"Tyler is even {oddEvenValue}";
				}
			else
				{
					myName = null;
				}

			InvokeAsync(StateHasChanged);
		}

		#endregion
		#endregion
	}
}
