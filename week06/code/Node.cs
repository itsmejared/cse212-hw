public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Insert unique values only.
    /// If the value already exists in the tree, do not insert it.
    /// </summary>
    public void Insert(int value)
    {
        // If the value already exists, stop to prevent duplicates
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Search for a value in the subtree rooted at this node.
    /// </summary>
    public bool Contains(int value)
    {
        // Base case: Found the value
        if (value == Data)
        {
            return true;
        }

        // Search left subtree if value is smaller
        if (value < Data)
        {
            return Left is not null && Left.Contains(value);
        }

        // Search right subtree if value is larger
        return Right is not null && Right.Contains(value);
    }

    /// <summary>
    /// Problem 4: Get the height of the subtree rooted at this node.
    /// Height is defined as 1 + max(height(left), height(right)).
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left is not null ? Left.GetHeight() : 0;
        int rightHeight = Right is not null ? Right.GetHeight() : 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}