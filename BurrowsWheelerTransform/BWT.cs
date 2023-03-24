namespace BurrowsWheelerTransform;

public class BWT
{
    public string Transform(string input)
    {
        string output = String.Empty;
        var data = input.ToLower();
        var allRotations = MakeAllRotations(data);
        var sorted = LexographicsSort(allRotations);
        foreach (var rotation in sorted)
        {
            output += rotation[^1];
        }

        return output;
    }

    private string[] LexographicsSort(string[] toSort)
    {
        var data = toSort;
        char minChar = char.MaxValue;
        var selectedIndex = 0;
        List<int[]> areas = new List<int[]>();
        char actualSortedChar = Char.MaxValue;
        int areaStart = 0;
        for (int i = 0; i < data[0].Length; i++)
        {
            for (int l = 0; l < areas.Count; l++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    for (int k = j; k < data.Length; k++)
                    {
                        if (data[k][i] <= minChar)
                        {
                            selectedIndex = k;
                            minChar = data[k][i];
                        }
                    }

                    minChar = char.MaxValue;

                    if (actualSortedChar != char.MaxValue)
                    {
                        if (actualSortedChar != data[selectedIndex][i])
                        {
                            areas.Add(new []{areaStart, j});
                            areaStart = j;
                        }
                    }
                    else
                    {
                        actualSortedChar = data[selectedIndex][i];
                    }

                    if (ArePreviousLettersSame(data, j, selectedIndex, i))
                        (data[j], data[selectedIndex]) = (data[selectedIndex], data[j]);
                }

                selectedIndex = 0;
            }

            areas.Clear();
        }

        return data;
    }

    private bool ArePreviousLettersSame(string[] data, int baseIndex, int selectedIndex, int level)
    {
        for (int i = 0; i < level; i++)
        {
            if (data[baseIndex][i] != data[selectedIndex][i])
                return false;
        }

        return true;
    }


    private string[] MakeAllRotations(string input)
    {
        var rotations = new string[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            rotations[i] = input;
            for (int j = 0; j < i; j++)
            {
                rotations[i] = Rotate(rotations[i]);
            }
        }

        return rotations;
    }

    private string Rotate(string input)
    {
        char[] output = input.ToCharArray();
        char replacer = output[0];
        char temp;
        for (int i = 0; i < output.Length; i++)
        {
            if (i == output.Length - 1)
            {
                output[0] = replacer;
                break;
            }

            temp = output[i + 1];
            output[i + 1] = replacer;
            replacer = temp;
        }

        return new string(output);
    }

    public string DeTransform(string input)
    {
        string output = String.Empty;

        return output;
    }
}