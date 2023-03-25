using System.Collections;

namespace BurrowsWheelerTransform;

public class Bwt
{
    public string Transform(string input)
    {
        var output = string.Empty;
        var data = input+"$";
        var allRotations = MakeAllRotations(data);
        var sorted = LexographicsSort(allRotations, 0);
        foreach (var rotation in sorted)
        {
            output += rotation[^1];
        }

        return output;
    }
    
    public string DeTransform(string input)
    {
        var letters = new string[input.Length];
        for (var s = 0; s < input.Length; s++)
        {
            for (var i = 0; i < letters.Length; i++)
            {
                letters[i] = input[i]+letters[i];
            }

            letters = LexographicsSort(letters, 0);
        }

        var output = letters.First(x => x[^1] == '$');
        return output[..^1];
    }

    private string[] LexographicsSort(string[] toSort, int level)
    {
        SelectionSort(level, toSort);
        
        if (level + 1 == toSort[0].Length)
            return toSort;
        
        var groups = DivideToGroupsWithSameLettersOnLevel(toSort, level);
        var output = new List<string>();
       
        foreach (var group in groups)
        {
            var sorted = LexographicsSort(group.ToArray(), level + 1);
            output.AddRange(sorted);
        }

        return output.ToArray();
    }

    private static void SelectionSort(int level, string[] data)
    {
        char minChar = char.MaxValue;
        var selectedIndex = 0;

        for (int i = 0; i < data.Length; i++)
        {
            for (int k = i; k < data.Length; k++)
            {
                if (data[k][level] <= minChar)
                {
                    selectedIndex = k;
                    minChar = data[k][level];
                }
            }

            minChar = char.MaxValue;
            (data[i], data[selectedIndex]) = (data[selectedIndex], data[i]);
        }
    }

    private List<List<string>> DivideToGroupsWithSameLettersOnLevel(string[] arrays, int level)
    {
        var output = new List<List<string>>();
        var actualCollection = new List<string> { arrays[0] };
        for (var i = 1; i < arrays.Length; i++)
        {
            if (arrays[i][level] != actualCollection[0][level])
            {
                output.Add(actualCollection);
                actualCollection = new List<string>();
            }

            actualCollection.Add(arrays[i]);
        }
        output.Add(actualCollection);

        return output;
    }

    private string[] MakeAllRotations(string input)
    {
        var rotations = new string[input.Length];
        for (var i = 0; i < input.Length; i++)
        {
            rotations[i] = input;
            for (var j = 0; j < i; j++)
            {
                rotations[i] = Rotate(rotations[i]);
            }
        }

        return rotations;
    }

    private string Rotate(string input)
    {
        var output = input.ToCharArray();
        var replacer = output[^1];
        for (var i = output.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                output[^1] = replacer;
                break;
            }

            (output[i - 1], replacer) = (replacer, output[i - 1]);
        }

        return new string(output);
    }
}