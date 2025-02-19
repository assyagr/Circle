using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Circle.Web.Models.Utilities.Binding
{
	public class TaggedUsersModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}

			var result = bindingContext.ValueProvider.GetValue("TaggedUsers").Values[0]?.Split(",").ToList();

			bindingContext.Result = ModelBindingResult.Success(result);
			return Task.CompletedTask;
		}
	}
}
