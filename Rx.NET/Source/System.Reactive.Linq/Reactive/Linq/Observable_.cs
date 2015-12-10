// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Reactive.Linq
{
    /// <summary>
    /// Provides a set of static methods for writing in-memory queries over observable sequences.
    /// </summary>
    public static partial class Observable
    {
#if NO_GVM
		// This avoid Observable extension methods to call QueryLanguage through a Generic Virtual Method call, which 
		// is a extremely time consuming operation on .NET Native and Mono's AOT. (about 80 times slower)
		private static QueryLanguage s_impl = new QueryLanguage();
#else
		private static IQueryLanguage s_impl = QueryServices.GetQueryImpl<IQueryLanguage>(new QueryLanguage());
#endif
	}
}
