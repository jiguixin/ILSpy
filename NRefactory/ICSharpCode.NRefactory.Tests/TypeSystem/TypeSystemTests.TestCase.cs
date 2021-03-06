﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

[assembly: ICSharpCode.NRefactory.TypeSystem.TestCase.TypeTestAttribute(
	42, typeof(System.Action<>), typeof(IDictionary<string, IList<NUnit.Framework.TestAttribute>>))]

[assembly: TypeForwardedTo(typeof(Func<,>))]

namespace ICSharpCode.NRefactory.TypeSystem.TestCase
{
	public delegate S GenericDelegate<in T, out S>(T input) where T : S where S : class;
	
	public class SimplePublicClass
	{
		public void Method() {}
	}
	
	public class TypeTestAttribute : Attribute
	{
		public TypeTestAttribute(int a1, Type a2, Type a3) {}
	}
	
	public unsafe class DynamicTest
	{
		public dynamic SimpleProperty { get; set; }
		
		public List<dynamic> DynamicGenerics1(Action<object, dynamic[], object> param) { return null; }
		public void DynamicGenerics2(Action<object, dynamic, object> param) { }
		public void DynamicGenerics3(Action<int, dynamic, object> param) { }
		public void DynamicGenerics4(Action<int[], dynamic, object> param) { }
		public void DynamicGenerics5(Action<int*[], dynamic, object> param) { }
		public void DynamicGenerics6(ref Action<object, dynamic, object> param) { }
		public void DynamicGenerics7(Action<int[,][], dynamic, object> param) { }
	}
	
	public class GenericClass<A, B> where A : B
	{
		public void TestMethod<K, V>(string param) where V: K where K: IComparable<V> {}
		public void GetIndex<T>(T element) where T : IEquatable<T> {}
	}
	
	public class PropertyTest
	{
		public int PropertyWithProtectedSetter { get; protected set; }
		
		public object PropertyWithPrivateSetter { get; private set; }
		
		public string this[int index] { get { return "Test"; } }
	}
	
	public enum MyEnum : short
	{
		First,
		Second,
		Flag1 = 0x10,
		Flag2 = 0x20,
		CombinedFlags = Flag1 | Flag2
	}
	
	public class Base<T> {
		public class Nested<X> {}
	}
	public class Derived<A, B> : Base<B> {}
	
	public struct MyStructWithCtor
	{
		public MyStructWithCtor(int a) {}
	}
	
	[Serializable]
	public class NonCustomAttributes
	{
		[NonSerialized]
		public readonly int NonSerializedField;
		
		[DllImport("unmanaged.dll", CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DllMethod([In, Out] ref int p);
	}
	
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode, Pack = 8)]
	public struct ExplicitFieldLayoutStruct
	{
		[FieldOffset(0)]
		public int Field0;
		
		[FieldOffset(100)]
		public int Field100;
	}
	
	public class ParameterTests
	{
		public void MethodWithOutParameter(out int x) { x = 0; }
		public void MethodWithParamsArray(params object[] x) {}
	}
	
	[ComImport(), Guid("21B8916C-F28E-11D2-A473-00C04F8EF448"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAssemblyEnum
	{
		[PreserveSig()]
		int GetNextAssembly(uint dwFlags);
	}
	
	public class ConstantTest
	{
		public const int Answer = 42;
		
		public const string NullString = null;
	}
}
