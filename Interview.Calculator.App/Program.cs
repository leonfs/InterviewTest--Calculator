using System;
using System.Collections.Generic;
using System.IO;
using Interview.Calculator.Model;
using Interview.Calculator.Model.Commands;
using Microsoft.Practices.Unity;

namespace Interview.Calculator.App
{
    class Program
    {
        private const string ADD = "add";
        private const string APPLY = "apply";
        private const string MULTIPLY = "multiply";
        private const string FILE_PATH = "file_path";

        

        static void Main(string[] args)
        {
            var container = Init(args[0]);
            
            try
            {
                using (StreamReader sr = new StreamReader(container.Resolve<string>(FILE_PATH)))
                {
                    string instructionLine;
                    
                    while((instructionLine = sr.ReadLine()) != null)
                    {
                        var commandKeyValue = GetCommandKeyValue(instructionLine);   

                        var command = container.Resolve<ICommand>(commandKeyValue.Key, new ParameterOverride("number", commandKeyValue.Value));
                        if (command != null)
                        {
                            Console.WriteLine("Executing: " + instructionLine);
                            command.Execute();    
                        }
                        
                    }
                }

                Console.WriteLine("[Output]");
                var calculator = container.Resolve<ICalculator>();
                Console.WriteLine(calculator.Result());
            }
            catch(FormatException e)
            {
                Console.WriteLine("Operator is not a number, please validate that all operators are numbers.");    
            }
            catch(ResolutionFailedException e)
            {
                Console.WriteLine(string.Format("Instruction not valid: {0}.", e.NameRequested));
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        private static UnityContainer Init(string fileName)
        {
            var container = new UnityContainer();

            var directoryName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            container.RegisterInstance(FILE_PATH, Path.Combine(directoryName, fileName));

            var calculator = new Model.Calculator();
            container.RegisterInstance<ICalculator>(calculator);
            container.RegisterType(typeof(ICommand), typeof(AddCommand), ADD);
            container.RegisterType(typeof(ICommand), typeof(MultiplyCommand), MULTIPLY);
            container.RegisterType(typeof(ICommand), typeof(ApplyCommand), APPLY);

            return container;
        }

        private static KeyValuePair<string, int> GetCommandKeyValue(string instructionLine)
        {
            string[] instructionKeyValue = instructionLine.Split(' ');
            int value = int.Parse(instructionKeyValue[1]);

            return new KeyValuePair<string, int>(instructionKeyValue[0], value);
        } 

        
    }
}
