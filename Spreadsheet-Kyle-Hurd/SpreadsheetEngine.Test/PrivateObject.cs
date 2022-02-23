// <copyright file="PrivateObject.cs" company="Washington State University">
// Copyright (C) Kyle Hurd - Washington State University
// Cpts 321 Spring 2022
// </copyright>

namespace Spreadsheet_Kyle_Hurd.SpreadsheetEngine.Test;

using System;
using System.Reflection;

/// <summary>
/// Initializes the <see cref="PrivateObject"/> class.
/// This was taken from the following website as PrivateObject is not included in the .NET Framework.:
/// https://gist.github.com/skalinets/1c4e5dbb4e86bd72bf491675901de5ad.
/// </summary>
public class PrivateObject
{
    /// <summary>
    /// A readonly field that contains the instance of the object that is being accessed.
    /// </summary>
    private readonly object o;

    /// <summary>
    /// Initializes a new instance of the <see cref="PrivateObject"/> class.
    /// </summary>
    /// <param name="o">The instance of the object that is being accessed.</param>
    public PrivateObject(object o)
    {
        this.o = o;
    }

    /// <summary>
    /// Gets the value of a private field.
    /// </summary>
    /// <param name="methodName">The method of the private field to be invoked.</param>
    /// <param name="args">The arguments that belong to the method name.</param>
    /// <returns>The value of the private field.</returns>
    public object Invoke(string methodName, params object[] args)
    {
        var methodInfo = this.o.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (methodInfo == null)
        {
            throw new Exception($"Method'{methodName}' not found is class '{this.o.GetType()}'");
        }

        return methodInfo.Invoke(this.o, args) ?? throw new Exception($"Method'{methodName}' returned null");
    }
}