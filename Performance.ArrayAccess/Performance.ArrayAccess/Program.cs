using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Performance.ArrayAccess
{
	public class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<Program>();
		}

		readonly int[] _source;

		public Program() : this(Enumerable.Range(0, 1000).ToArray()) {}

		public Program(int[] source) => _source = source;

		[Benchmark]
		public int Access()
		{
			var length = _source.Length;
			var result = 0;
			for (var i = 0u; i < length; i++)
			{
				result += _source[i];
			}

			return result;
		}

		[Benchmark(Baseline = true)]
		public int Magic()
		{
			var     length = _source.Length;
			var     result = 0;
			for (var i = 0; i < length; i++)
			{
				result = _source.Access(i);
			}

			return result;
		}
	}

	public static class Extensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T Access<T>(this T[] @this, int index)
		{
			var     data = Unsafe.As<RawData>(@this);
			ref var r0   = ref Unsafe.As<byte, T>(ref data.Data);
			ref var r1   = ref Unsafe.Add(ref r0, index);
			return ref r1;
		}
	}

	sealed class RawData
	{
		public IntPtr Length;

		public byte Data;
	}
}