public static class SolutionToQuestion3
{
    public static bool IsValid(string expr)
    {
        var stack = new Stack<char>();

        foreach (var c in expr)
        {
            switch (c)
            {
                case '(' or '[' or '{':
                    stack.Push(c); // Push opening
                    break;
                case '|' when stack.Count > 0 && stack.Peek() == '|': // exists opening |
                    stack.Pop(); // Closing |
                    break;
                case '|':
                    stack.Push('|'); // Opening |
                    break;
                case ')' or ']' or '}':
                {
                    if (stack.Count == 0) 
                    {
                        return false;
                    }

                    var closing = c;
                    var open = stack.Pop(); // extract the opening paren
                    if (GetClosingParen(open) != closing) return false;
                    break;
                }
            }
        }

        // Is valid if no unmatched parens were left
        return stack.Count == 0;
    }

    static char GetClosingParen(char openParen) => openParen switch
    {
        '(' => ')',
        '[' => ']',
        '{' => '}',
        '|' => '|' 
    };
}