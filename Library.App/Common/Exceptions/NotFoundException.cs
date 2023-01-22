﻿using System;
namespace Library.App.Common.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string name, object key)
			: base($"Entity \"{name}\" ({key}) not found.)") { }
	}
}

