using System.IO;
using System.Collections.Generic;
using System.Management.Automation;
using static System.Math;

namespace CoreVC.PSClient.Commands
{
    [Cmdlet(VerbsData.Compare, "Content")]
    public class CompareContentCommand : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string ReferencePath { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public string DifferencePath { get; set; }

        protected override void ProcessRecord()
        {
            string[] reference = File.ReadAllLines(ReferencePath);
            string[] difference = File.ReadAllLines(DifferencePath);
            string[] diff = LCS(reference, difference);

            WriteObject(diff);
        }

        private string[] LCS(string[] reference, string[] difference)
        {
            var matrix = LCSLen(reference, difference);
            var result = new List<string>();

            Backtrack(reference, difference, matrix, reference.Length, difference.Length, result);
            return result.ToArray();
        }

        private int[,] LCSLen(string[] reference, string[] difference)
        {
            var matrix = new int[reference.Length + 1, difference.Length + 1];

            for (int i = 1; i <= reference.Length; i++) {
                for (int j = 1; j <= difference.Length; j++) {
                    matrix[i, j] = reference[i - 1] == difference[j - 1] ? 
                        matrix[i - 1, j - 1] + 1 : 
                        Max(matrix[i, j - 1], matrix[i - 1, j]);
                }
            }

            return matrix;
        }

        private void Backtrack(string[] reference, string[] difference, int[,] matrix, int i, int j, List<string> result)
        {
            if (i > 0 && j > 0 && reference[i - 1] == difference[j - 1]) {
                Backtrack(reference, difference, matrix, i - 1, j - 1, result);
                result.Add("  " + reference[i - 1]);
                return;
            }
            if (j > 0 && (i == 0 || matrix[i, j - 1] >= matrix[i - 1, j])) {
                Backtrack(reference, difference, matrix, i, j - 1, result);
                result.Add("+ " + difference[j - 1]);
                return;
            }
            if (i > 0 && (j == 0 || matrix[i, j - 1] < matrix[i - 1, j])) {
                Backtrack(reference, difference, matrix, i - 1, j, result);
                result.Add("- " + reference[i - 1]);
                return;
            }
        }
    }
}
