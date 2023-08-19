﻿namespace Hbx.Seedwork.Abstractions;

public interface IEntity<T>
{
	public T Id { get; }

	public System.DateTime InsertDateTime { get; }
}
