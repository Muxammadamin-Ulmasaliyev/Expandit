using Expandit.Helpers;

namespace Expandit.Tests;

public class TrieTests
{
    [Fact]
    public void Search_ReturnsInsertedValue_ForExactMatch()
    {
        var trie = new Trie<string>();
        trie.Insert("btw", "by the way");

        var result = trie.Search("btw");

        Assert.Equal("by the way", result);
    }

    [Fact]
    public void Search_ReturnsDefault_ForUnknownKey()
    {
        var trie = new Trie<string>();
        trie.Insert("btw", "by the way");

        var result = trie.Search("nope");

        Assert.Null(result);
    }

    [Fact]
    public void Search_ReturnsDefault_ForPrefixOfInsertedKey()
    {
        var trie = new Trie<string>();
        trie.Insert("hello", "hi there");

        var result = trie.Search("hell");

        Assert.Null(result);
    }

    [Fact]
    public void Clear_RemovesAllEntries()
    {
        var trie = new Trie<string>();
        trie.Insert("btw", "by the way");

        trie.Clear();
        var result = trie.Search("btw");

        Assert.Null(result);
    }
}
