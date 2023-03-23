namespace BurrowsWheelerTransform;

public class BWT
{
    public string Transform(string input)
    {
        string output = String.Empty;
        var allRotations = MakeAllRotations(input);
        var sorted = LexographicsSort(allRotations);
        return output;
    }

    private string[] LexographicsSort(string[] toSort)
    {
        var sorted = toSort;
        
        
        
        return sorted;
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
            if (i == output.Length-1)
            {
                output[0] = replacer;
                break;
            }
            temp = output[i + 1];
            output[i+1] = replacer;
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