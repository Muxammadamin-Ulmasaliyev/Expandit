namespace Expandit.Helpers;

public class TrieNode<T>
{
    public Dictionary<char, TrieNode<T>> Children { get; } = new Dictionary<char, TrieNode<T>>();
    public T Value { get; set; }
    public bool IsEndOfWord { get; set; }
}

public class Trie<T>
{
    private readonly TrieNode<T> _root = new TrieNode<T>();

    public void Insert(string key, T value)
    {
        var current = _root;
        foreach (var c in key)
        {
            if (!current.Children.ContainsKey(c))
            {
                current.Children[c] = new TrieNode<T>();
            }
            current = current.Children[c];
        }
        current.Value = value;
        current.IsEndOfWord = true;
    }

    public T Search(string key)
    {
        var current = _root;
        foreach (var c in key)
        {
            if (!current.Children.ContainsKey(c))
            {
                return default;
            }
            current = current.Children[c];
        }
        return current.IsEndOfWord ? current.Value : default;
    }

    public void Clear()
    {       
        _root.Children.Clear();
    }
}
