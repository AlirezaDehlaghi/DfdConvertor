using DFDAnalyzer;
using System.IO;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        public string filePath { get {
                return Path.Combine(
    Helper.TryGetSolutionDirectoryInfo().FullName,
    "RemoteControlHxDFDV10.tm7");
            } }

        public string saveFilePath{
            get{
                return Path.Combine(
    Helper.TryGetSolutionDirectoryInfo().FullName,
    "Flows.csv");
            } 
        }

        public string RebecaFilePath
        {
            get
            {
                return Path.Combine(
    Helper.TryGetSolutionDirectoryInfo().FullName,
    "RemoteControllerHx_V9new.rebeca");
            }
        }



        [Fact]
        public void Test1()
        {

            DFDDiagram diagram = new DFDDiagram(filePath);
            var x = diagram.ProcessList;
            Assert.True(true);

        }

        [Fact]
        public void Test_ExportFlows() 
        {
            DFDDiagram diagram = new DFDDiagram(filePath);
            diagram.ExportFlows(this.saveFilePath);
            Assert.True(true);
        }

        [Fact]
        public void Test_ExportRebeca()
        {
            DFDDiagram diagram = new DFDDiagram(filePath);
            RebecaCode code = new RebecaCode(diagram);
            code.ExportToFile(this.RebecaFilePath);
        }
    }
}
