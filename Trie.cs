using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Trie
{
    //root of the Trie
    private TrieNode root;

    //constructor
    public Trie()
    {
        root = new TrieNode();
    }

    //Insert a word into the Trie. O(m) time/space complexity. m is word length
    public void Insert(String word)
    {
        TrieNode node = root;
        for (int i = 0; i < word.Length; ++i)
        {
            if (!node.ContainsKey(word[i]))
            {
                node.Put(word[i], new TrieNode());
            }
            node = node.Get(word[i]);
        }
        node.SetEnd();
    }

    //search a prefix(or whole key) in trie and
    //returns the node where search ends
    //O(m) time complexity, O(1) space complexity
    private TrieNode SearchPrefix(string prefix)
    {
        TrieNode node = root;
        for (int i = 0; i < prefix.Length; ++i)
        {
            if (node.ContainsKey(prefix[i]))
            {
                node = node.Get(prefix[i]);
            } else
            {
                return null;
            }
        }
        return node;
    }

    //Search a whole word in the trie
    //Returns if the word is in the trie.
    public bool Search(String word)
    {
        TrieNode node = SearchPrefix(word);
        return node != null && node.IsEnd();
    }

    // Returns if there is any word in the trie
    // that starts with the given prefix.
    // O(m) time complexity, O(1) space complexity
    public bool StartsWith(string prefix)
    {
        TrieNode node = SearchPrefix(prefix);
        return node != null;
    }
}

public class TrieNode
{
    //links to children node
    private Dictionary<char,TrieNode> children;
    //denote if this node is an word end
    private bool isEnd;


    //constructor
    public TrieNode()
    {
        children = new Dictionary<char, TrieNode>();
    }


    //check if a child exists
    public bool ContainsKey(char ch)
    {
        return children.ContainsKey(ch);
    }

    //get child
    public TrieNode Get(char ch)
    {
        return children[ch];
    }

    //put a child node in
    public void Put(char ch, TrieNode node)
    {
        children[ch] = node;
    }

    //set current node as word end
    public void SetEnd()
    {
        isEnd = true;
    }

    //check if current node is word end
    public bool IsEnd()
    {
        return isEnd;
    }
}

