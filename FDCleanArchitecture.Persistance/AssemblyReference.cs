﻿using System.Reflection;

namespace FDCleanArchitecture.Persistance;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
