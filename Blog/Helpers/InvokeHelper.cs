using System;
using System.Threading.Tasks;
using Blog.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Helpers
{
	public static class InvokeHelper
	{
		public static async Task<IActionResult> SaveInvokeAsync<T>(this ControllerBase controller, Func<Task<T>> action)
		{
			try
			{
				T value = await action();
				if (value == null)
				{
					return controller.NotFound();
				}
				return controller.Ok(value);
			}
			catch (ValidationFailedException)
			{
				return controller.BadRequest();
			}
			catch
			{
				return controller.StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		public static async Task<IActionResult> SaveInvokeAsync(this ControllerBase controller, Func<Task> action)
		{
			try
			{
				await action();
				return controller.Ok();
			}
			catch (ValidationFailedException)
			{
				return controller.BadRequest();
			}
			catch
			{
				return controller.StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
