﻿using DFDAnalyzer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dfdquery
{
	internal class Program
	{

		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Invalid args");
                Help(null);
				return;
			}

			var command = args[0];

			if (!commandMap.ContainsKey(command))
			{
				Console.WriteLine("Invalid command");
				Help(null);
				return;
			}

			commandMap[command](args.Skip(1).ToArray());

		}
		private static readonly Dictionary<string, Action<string[]>> commandMap = new Dictionary<string, Action<string[]>>(StringComparer.InvariantCultureIgnoreCase)
		{
			[nameof(Export)] = Export,
			[nameof(Help)] = Help,
			[nameof(Convert)] = Convert
		};
		

		static void Help(string[] args)
		{
			Console.WriteLine("The following commands are available:");
			foreach (var command in commandMap.Keys)
				Console.WriteLine("\t - " + command);
		}

		static void Convert(string[] args)
		{
			if (args.Length == 2)
			{

				DFDDiagram diagram = new DFDDiagram(args[0]);
				RebecaCode code = new RebecaCode(diagram);
                code.ExportToFile(args[1]);
			}
			else
			{
				Console.WriteLine("Invalid args. Expected format: Export <input_file> <output_file>");
			}
		}


		static void Export(string[] args)
		{
			if (args.Length == 2)
			{
				DFDDiagram diagram = new DFDDiagram(args[0]);
				diagram.ExportFlows(args[1]);
			}
			else
			{
				Console.WriteLine("Invalid args. Expected format: Export <input_file> <output_file>");
			}
		}


	}
}
